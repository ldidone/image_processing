using ProcesamientoImagenes1.Logica;
using ProcesamientoImagenes1.Logica.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesamientoImagenes1
{
    public partial class Form1 : Form
    {
        private string FilePath { get; set; }
        private string SelectedFilter { get; set; }
        private string SelectedHistogram { get; set; }
        private string ProcessingOption { get; set; }
        private string HistogramValue { get; set; }
        private ImageProcessing ImageProcessing { get; set; }
        private string[] Filters { get; set; } = new string[]
        {
            "Raíz",
            "Cuadrado",
            "Lineal a trozos"
        };

        public Form1()
        {
            InitializeComponent();
            FilePath = "C:\\";
            SelectedFilter = "Raíz";
            SelectedHistogram = "Alpha";
            ProcessingOption = "Histogram";
            HistogramValue = "0";
            ImageProcessing = new ImageProcessing();

            // Add Histogram options
            AddHistogramOptions();
            // Add Filter Options
            AddFilterOptions();

            // enabled default
            selectHistogram.Enabled = true;
            selectFilter.Enabled = false;
            HistogramaValue.Enabled = true;
            HistogramaValue.Text = "0";
            MinTxt.Enabled = false;
            MaxTxt.Enabled = false;
            MinTxt.Text = "0";
            MaxTxt.Text = "1";

        }

        private void AddHistogramOptions()
        {
            string[] options = new string[]
            {
                "Alpha",
                "Beta",
            };

            selectHistogram.Items.AddRange(options);
        }

        private void AddFilterOptions()
        {
            string[] filters = new string[] 
            {
                "Raíz",
                "Cuadrado",
                "Lineal a trozos"
            };

            selectFilter.Items.AddRange(filters);
        }

        // Cargar la imagen
        private void Load_Click(object sender, EventArgs e)
        {
            ClearError();
            // configuración de algunos parámetros del openFileDialog
            // directorio inicial donde se abrirá
            openFileDialog.InitialDirectory = FilePath;
            // filtro de archivos.
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";

            // código para abrir el cuadro de diálogo
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Show image
                    FilePath = openFileDialog.FileName;
                    Bitmap originalImage = new Bitmap(FilePath);

                    OriginalImage.Image = originalImage;
                    OriginalImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch(Exception ex)
                {
                    labelError.Text = $"Ha ocurrido el siguiente error al intentar cargar la imagen: {ex.Message}";
                }
            }
        }

        // Aplicar el filtro
        private void ApplyFilter_Click(object sender, EventArgs e)
        {
            ClearError();
            try
            {
                if (useHistogram.Checked)
                {
                    if (SelectedHistogram != string.Empty)
                    {
                        // Aplicar histograma
                        string HistogramValue = HistogramaValue.Text;
                        HistogramValue = HistogramValue.Replace('.', ',');
                        if (float.TryParse(HistogramValue, out float histogramValue))
                        {
                            Bitmap originalImage = new Bitmap(FilePath);
                            Bitmap processedImage = null;

                            try
                            {
                                if (SelectedHistogram == "Alpha")
                                    processedImage = ImageProcessing.ApplyLumaChrominance(originalImage, alpha: histogramValue);
                                else if (SelectedHistogram == "Beta")
                                    processedImage = ImageProcessing.ApplyLumaChrominance(originalImage, beta: histogramValue);
                                else
                                    throw new InvalidHistogramException();

                                ImageProcessed.Image = processedImage;
                                ImageProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            catch(InvalidHistogramException)
                            {
                                labelError.Text = $"Error: no se ha seleccionado un valor de histograma válido.";
                            }
                        }
                        else
                        {
                            labelError.Text = $"Error: no se ha introducido un valor válido.";
                        }                      
                    }
                    else
                    {
                        labelError.Text = $"Error: no se ha seleccionado ningún tipo de histograma.";
                    }
                }
                else
                {
                    if (SelectedFilter != string.Empty)
                    {
                        // Aplicar filtro                     
                        Bitmap originalImage = new Bitmap(FilePath);
                        Bitmap processedImage = null;

                        try
                        {
                            if (Filters.Any(x => x == SelectedFilter))
                            {
                                if (SelectedFilter == "Lineal a trozos" )
                                {
                                    string minTxt = MinTxt.Text;
                                    minTxt = minTxt.Replace('.', ',');
                                    string maxTxt = MaxTxt.Text;
                                    maxTxt = maxTxt.Replace('.', ',');
                                    if (float.TryParse(minTxt, out float min) && float.TryParse(maxTxt, out float max))
                                    {
                                        if ((min >= 0 && min <= 1) && (max >= 0 && max <= 1) && (min <= max))
                                            processedImage = ImageProcessing.ApplyLumaFilter(originalImage, filter: SelectedFilter, min: min, max: max);
                                        else
                                            throw new InvalidHistogramException();
                                    }
                                    else
                                    {
                                        throw new InvalidHistogramException();
                                    }
                                }
                                else
                                {
                                    processedImage = ImageProcessing.ApplyLumaFilter(originalImage, filter: SelectedFilter);
                                }                               
                                ImageProcessed.Image = processedImage;
                                ImageProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                labelError.Text = $"Error: no se ha seleccionado un valor de filtro válido.";
                            }
                           
                        }
                        catch (InvalidHistogramException)
                        {
                            labelError.Text = $"Error: no se ha seleccionado un valor de Min. o Máx. válido.";
                        }                      
                    }
                    else
                    {
                        labelError.Text = $"Error: no se ha seleccionado ningún filtro.";
                    }
                }                    
            }
            catch (Exception ex)
            {
                labelError.Text = $"Ha ocurrido el siguiente error al intentar filtrar la imagen: {ex.Message}";
            }
        }

        private void selectFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectFilter.SelectedItem != null)
            {
                SelectedFilter = selectFilter.SelectedItem.ToString();
                if (SelectedFilter == "Lineal a trozos")
                {
                    MinTxt.Text = "0";
                    MaxTxt.Text = "1";
                    MinTxt.Enabled = true;
                    MaxTxt.Enabled = true;
                }
                else
                {
                    MinTxt.Text = "0";
                    MaxTxt.Text = "1";
                    MinTxt.Enabled = false;
                    MaxTxt.Enabled = false;
                }
            }
        }

        private void ClearError()
        {
            labelError.Text = "";
        }

        private void useHistogram_CheckedChanged(object sender, EventArgs e)
        {
            selectHistogram.Enabled = true;
            selectFilter.Enabled = false;
            HistogramaValue.Enabled = true;
            HistogramaValue.Text = "0";
            MinTxt.Text = "0";
            MaxTxt.Text = "1";
            MinTxt.Enabled = false;
            MaxTxt.Enabled = false;
        }

        private void useFilter_CheckedChanged(object sender, EventArgs e)
        {
            selectFilter.Enabled = true;
            selectHistogram.Enabled = false;
            HistogramaValue.Enabled = false;
            HistogramaValue.Text = "0";
            MinTxt.Text = "0";
            MaxTxt.Text = "1";
            if (SelectedFilter == "Lineal a trozos")
            {
                MinTxt.Enabled = true;
                MaxTxt.Enabled = true;
            }
            else
            {
                MinTxt.Enabled = false;
                MaxTxt.Enabled = false;
            }             
        }

        private void selectHistogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectHistogram.SelectedItem != null)
            {
                SelectedHistogram = selectHistogram.SelectedItem.ToString();
            }
        }
    }
}
