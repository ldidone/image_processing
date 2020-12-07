namespace ProcesamientoImagenes1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.OriginalImage = new System.Windows.Forms.PictureBox();
            this.ImageProcessed = new System.Windows.Forms.PictureBox();
            this.Load = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelError = new System.Windows.Forms.Label();
            this.ApplyFilter = new System.Windows.Forms.Button();
            this.selectFilter = new System.Windows.Forms.ComboBox();
            this.lblElegirFiltro = new System.Windows.Forms.Label();
            this.HistogramaValue = new System.Windows.Forms.TextBox();
            this.lblHistograma = new System.Windows.Forms.Label();
            this.selectHistogram = new System.Windows.Forms.ComboBox();
            this.MainGroup = new System.Windows.Forms.GroupBox();
            this.useFilter = new System.Windows.Forms.RadioButton();
            this.useHistogram = new System.Windows.Forms.RadioButton();
            this.MinTxt = new System.Windows.Forms.TextBox();
            this.MaxTxt = new System.Windows.Forms.TextBox();
            this.MinLabel = new System.Windows.Forms.Label();
            this.MaxLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageProcessed)).BeginInit();
            this.MainGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalImage
            // 
            this.OriginalImage.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.OriginalImage.Location = new System.Drawing.Point(12, 12);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(360, 360);
            this.OriginalImage.TabIndex = 0;
            this.OriginalImage.TabStop = false;
            // 
            // ImageProcessed
            // 
            this.ImageProcessed.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ImageProcessed.Location = new System.Drawing.Point(403, 13);
            this.ImageProcessed.Name = "ImageProcessed";
            this.ImageProcessed.Size = new System.Drawing.Size(360, 360);
            this.ImageProcessed.TabIndex = 1;
            this.ImageProcessed.TabStop = false;
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(12, 391);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(103, 105);
            this.Load.TabIndex = 2;
            this.Load.Text = "Cargar";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(19, 503);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 4;
            // 
            // ApplyFilter
            // 
            this.ApplyFilter.Location = new System.Drawing.Point(665, 391);
            this.ApplyFilter.Name = "ApplyFilter";
            this.ApplyFilter.Size = new System.Drawing.Size(98, 105);
            this.ApplyFilter.TabIndex = 5;
            this.ApplyFilter.Text = "Filtrar";
            this.ApplyFilter.UseVisualStyleBackColor = true;
            this.ApplyFilter.Click += new System.EventHandler(this.ApplyFilter_Click);
            // 
            // selectFilter
            // 
            this.selectFilter.FormattingEnabled = true;
            this.selectFilter.Location = new System.Drawing.Point(389, 39);
            this.selectFilter.Name = "selectFilter";
            this.selectFilter.Size = new System.Drawing.Size(136, 21);
            this.selectFilter.TabIndex = 6;
            this.selectFilter.Text = "Raíz";
            this.selectFilter.SelectedIndexChanged += new System.EventHandler(this.selectFilter_SelectedIndexChanged);
            // 
            // lblElegirFiltro
            // 
            this.lblElegirFiltro.AutoSize = true;
            this.lblElegirFiltro.Location = new System.Drawing.Point(433, 21);
            this.lblElegirFiltro.Name = "lblElegirFiltro";
            this.lblElegirFiltro.Size = new System.Drawing.Size(58, 13);
            this.lblElegirFiltro.TabIndex = 7;
            this.lblElegirFiltro.Text = "Elegir Filtro";
            // 
            // HistogramaValue
            // 
            this.HistogramaValue.Location = new System.Drawing.Point(282, 37);
            this.HistogramaValue.Name = "HistogramaValue";
            this.HistogramaValue.Size = new System.Drawing.Size(86, 20);
            this.HistogramaValue.TabIndex = 8;
            this.HistogramaValue.Text = "0";
            // 
            // lblHistograma
            // 
            this.lblHistograma.AutoSize = true;
            this.lblHistograma.Location = new System.Drawing.Point(247, 16);
            this.lblHistograma.Name = "lblHistograma";
            this.lblHistograma.Size = new System.Drawing.Size(60, 13);
            this.lblHistograma.TabIndex = 9;
            this.lblHistograma.Text = "Histograma";
            // 
            // selectHistogram
            // 
            this.selectHistogram.FormattingEnabled = true;
            this.selectHistogram.Location = new System.Drawing.Point(192, 36);
            this.selectHistogram.Name = "selectHistogram";
            this.selectHistogram.Size = new System.Drawing.Size(72, 21);
            this.selectHistogram.TabIndex = 10;
            this.selectHistogram.Text = "Alpha";
            this.selectHistogram.SelectedIndexChanged += new System.EventHandler(this.selectHistogram_SelectedIndexChanged);
            // 
            // MainGroup
            // 
            this.MainGroup.Controls.Add(this.MaxLabel);
            this.MainGroup.Controls.Add(this.MinLabel);
            this.MainGroup.Controls.Add(this.MaxTxt);
            this.MainGroup.Controls.Add(this.MinTxt);
            this.MainGroup.Controls.Add(this.useFilter);
            this.MainGroup.Controls.Add(this.useHistogram);
            this.MainGroup.Controls.Add(this.lblHistograma);
            this.MainGroup.Controls.Add(this.lblElegirFiltro);
            this.MainGroup.Controls.Add(this.HistogramaValue);
            this.MainGroup.Controls.Add(this.selectFilter);
            this.MainGroup.Controls.Add(this.selectHistogram);
            this.MainGroup.Location = new System.Drawing.Point(121, 391);
            this.MainGroup.Name = "MainGroup";
            this.MainGroup.Size = new System.Drawing.Size(538, 105);
            this.MainGroup.TabIndex = 12;
            this.MainGroup.TabStop = false;
            this.MainGroup.Text = "Seleccione el tipo de procesamiento";
            // 
            // useFilter
            // 
            this.useFilter.AutoSize = true;
            this.useFilter.Location = new System.Drawing.Point(22, 51);
            this.useFilter.Name = "useFilter";
            this.useFilter.Size = new System.Drawing.Size(72, 17);
            this.useFilter.TabIndex = 12;
            this.useFilter.Text = "Usar Filtro";
            this.useFilter.UseVisualStyleBackColor = true;
            this.useFilter.CheckedChanged += new System.EventHandler(this.useFilter_CheckedChanged);
            // 
            // useHistogram
            // 
            this.useHistogram.AutoSize = true;
            this.useHistogram.Checked = true;
            this.useHistogram.Location = new System.Drawing.Point(22, 27);
            this.useHistogram.Name = "useHistogram";
            this.useHistogram.Size = new System.Drawing.Size(103, 17);
            this.useHistogram.TabIndex = 11;
            this.useHistogram.TabStop = true;
            this.useHistogram.Text = "Usar Histograma";
            this.useHistogram.UseVisualStyleBackColor = true;
            this.useHistogram.CheckedChanged += new System.EventHandler(this.useHistogram_CheckedChanged);
            // 
            // MinTxt
            // 
            this.MinTxt.Location = new System.Drawing.Point(389, 79);
            this.MinTxt.Name = "MinTxt";
            this.MinTxt.Size = new System.Drawing.Size(61, 20);
            this.MinTxt.TabIndex = 13;
            this.MinTxt.Text = "0";
            // 
            // MaxTxt
            // 
            this.MaxTxt.Location = new System.Drawing.Point(464, 79);
            this.MaxTxt.Name = "MaxTxt";
            this.MaxTxt.Size = new System.Drawing.Size(61, 20);
            this.MaxTxt.TabIndex = 14;
            this.MaxTxt.Text = "1";
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(386, 63);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(27, 13);
            this.MinLabel.TabIndex = 15;
            this.MinLabel.Text = "Min.";
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(464, 62);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(30, 13);
            this.MaxLabel.TabIndex = 16;
            this.MaxLabel.Text = "Máx.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 527);
            this.Controls.Add(this.MainGroup);
            this.Controls.Add(this.ApplyFilter);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.ImageProcessed);
            this.Controls.Add(this.OriginalImage);
            this.Name = "Form1";
            this.Text = "Procesamiento de Imágenes";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageProcessed)).EndInit();
            this.MainGroup.ResumeLayout(false);
            this.MainGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalImage;
        private System.Windows.Forms.PictureBox ImageProcessed;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button ApplyFilter;
        private System.Windows.Forms.ComboBox selectFilter;
        private System.Windows.Forms.Label lblElegirFiltro;
        private System.Windows.Forms.TextBox HistogramaValue;
        private System.Windows.Forms.Label lblHistograma;
        private System.Windows.Forms.ComboBox selectHistogram;
        private System.Windows.Forms.GroupBox MainGroup;
        private System.Windows.Forms.RadioButton useFilter;
        private System.Windows.Forms.RadioButton useHistogram;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.TextBox MaxTxt;
        private System.Windows.Forms.TextBox MinTxt;
    }
}

