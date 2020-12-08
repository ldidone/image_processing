using ProcesamientoImagenes1.Logica.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoImagenes1.Logica
{
    public class ImageProcessing
    {
        public readonly float[,] W_RGB2YIQ = new float[3, 3]
        {
            { 0.299F, 0.587F, 0.114F },
            { 0.595716F , -0.274453F , -0.321263F },
            { 0.211456F, -0.522591F, 0.311135F }
        };

        public readonly float[,] W_YIQ2RGB = new float[3, 3]
        {
            { 1F, 0.9663F, 0.6210F },
            { 1F , -0.2721F , -0.6474F },
            { 1F, -1.1070F, 1.7046F }
        };

        public int GetMin(int a, int b)
        {
            if (a == b) return a;
            if (a < b) return a;
            else return b;
        }

        // Source: https://stackoverflow.com/questions/13481558/converting-a-bitmap-image-to-a-matrix
        public Color[][] ColorMatrixFromBitmap(Bitmap image)
        {
            int hight = image.Height;
            int width = image.Width;

            Color[][] colorMatrix = new Color[width][];
            for (int i = 0; i < width; i++)
            {
                colorMatrix[i] = new Color[hight];
                for (int j = 0; j < hight; j++)
                {
                    colorMatrix[i][j] = image.GetPixel(i, j);
                }
            }

            return colorMatrix;
        }

        // Source: https://stackoverflow.com/questions/38989837/convert-rgb-array-to-image-in-c-sharp
        public Bitmap BitmapFromColorMatrix(int w, int h, Color[][] data, bool normalize = false)
        {
            Bitmap pic = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    byte A, R, G, B;
                    A = data[x][y].A;
                    R = data[x][y].R;
                    G = data[x][y].G;
                    B = data[x][y].B;

                    Color c = Color.FromArgb(A, R, G, B);
                    pic.SetPixel(x, y, c);
                }
            }

            return pic;
        }

        // RGB2YIQ
        public CustomImage<YIQPixel> RGB2YIQ(Color[][] RGBImage, bool normalize = true)
        {
            CustomImage<YIQPixel> image = new CustomImage<YIQPixel>
            {
                Width = RGBImage[0].Length,
                Height = RGBImage[1].Length
            };

            List<YIQPixel> pixels = new List<YIQPixel>();

            for (int i = 0; i < RGBImage[0].Length; i++)
            {
                for (int j = 0; j < RGBImage[1].Length; j++)
                {
                    // Normalize each pixel value
                    float NR, NG, NB;
                    NR = normalize ? RGBImage[i][j].R / 255.00F : RGBImage[i][j].R;
                    NG = normalize ? RGBImage[i][j].G / 255.00F : RGBImage[i][j].G;
                    NB = normalize ? RGBImage[i][j].B / 255.00F : RGBImage[i][j].B;

                    YIQPixel Pixel = new YIQPixel()
                    {
                        Xpos = i,
                        Ypos = j,
                        Y = NR * W_RGB2YIQ[0, 0] + NG * W_RGB2YIQ[0, 1] + NB * W_RGB2YIQ[0, 2],
                        I = NR * W_RGB2YIQ[1, 0] + NG * W_RGB2YIQ[1, 1] + NB * W_RGB2YIQ[1, 2],
                        Q = NR * W_RGB2YIQ[2, 0] + NG * W_RGB2YIQ[2, 1] + NB * W_RGB2YIQ[2, 2]
                    };
                    pixels.Add(Pixel);
                }
            }

            image.Pixels = pixels;
            return image;
        }

        public CustomImage<YIQPixel> RGB2YIQ(Bitmap RGBImage, bool normalize = true)
        {
            CustomImage<YIQPixel> image = new CustomImage<YIQPixel>
            {
                Width = RGBImage.Width,
                Height = RGBImage.Height
            };

            List<YIQPixel> pixels = new List<YIQPixel>();

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    // Normalize each pixel value
                    float NR, NG, NB;
                    NR = normalize ? RGBImage.GetPixel(i, j).R / 255.00F : RGBImage.GetPixel(i, j).R;
                    NG = normalize ? RGBImage.GetPixel(i, j).G / 255.00F : RGBImage.GetPixel(i, j).G;
                    NB = normalize ? RGBImage.GetPixel(i, j).B / 255.00F : RGBImage.GetPixel(i, j).B;

                    YIQPixel Pixel = new YIQPixel()
                    {
                        Xpos = i,
                        Ypos = j,
                        Y = NR * W_RGB2YIQ[0, 0] + NG * W_RGB2YIQ[0, 1] + NB * W_RGB2YIQ[0, 2],
                        I = NR * W_RGB2YIQ[1, 0] + NG * W_RGB2YIQ[1, 1] + NB * W_RGB2YIQ[1, 2],
                        Q = NR * W_RGB2YIQ[2, 0] + NG * W_RGB2YIQ[2, 1] + NB * W_RGB2YIQ[2, 2]
                    };
                    pixels.Add(Pixel);
                }
            }

            image.Pixels = pixels;
            return image;
        }

        public CustomImage<RGBPixel> YIQ2RGB(CustomImage<YIQPixel> YIQImage, bool normalize = true)
        {
            CustomImage<RGBPixel> image = new CustomImage<RGBPixel>
            {
                Width = YIQImage.Width,
                Height = YIQImage.Height
            };

            List<RGBPixel> pixels = new List<RGBPixel>();
            int normalizerTerm = normalize ? 255 : 1;

            foreach (var pixel in YIQImage.Pixels)
            {
                RGBPixel Pixel = new RGBPixel()
                {
                    Xpos = pixel.Xpos,
                    Ypos = pixel.Ypos,
                    R = ValidateRange(((pixel.Y * W_YIQ2RGB[0, 0] + pixel.I * W_YIQ2RGB[0, 1] + pixel.Q * W_YIQ2RGB[0, 2]) * normalizerTerm)),
                    G = ValidateRange(((pixel.Y * W_YIQ2RGB[1, 0] + pixel.I * W_YIQ2RGB[1, 1] + pixel.Q * W_YIQ2RGB[1, 2]) * normalizerTerm)),
                    B = ValidateRange(((pixel.Y * W_YIQ2RGB[2, 0] + pixel.I * W_YIQ2RGB[2, 1] + pixel.Q * W_YIQ2RGB[2, 2]) * normalizerTerm))
                };
                pixels.Add(Pixel);
            }

            image.Pixels = pixels;
            return image;
        }

        public int FloatToInt(float value)
        {
            return (int)Math.Truncate(Math.Round(value));
        }

        public int ValidateRange(float value, int min = 0, int max = 255)
        {
            int intValue = FloatToInt(value);
            if (value < min) return min;
            else if (value > max) return max;
            else return intValue;
        }

        public Bitmap BitmapFromCustomImage (CustomImage<RGBPixel> customImage)
        {
            Bitmap pic = new Bitmap(customImage.Width, customImage.Height);

            foreach (var pixel in customImage.Pixels)
            {
                Color c = Color.FromArgb(pixel.R, pixel.G, pixel.B);
                pic.SetPixel(pixel.Xpos, pixel.Ypos, c);
            }
        
            return pic;
        }

        public CustomImage<RGBPixel> LumaChrominance(CustomImage<YIQPixel> YIQImage, float alpha = 1.0F, float beta = 1.0F)
        {
            CustomImage<YIQPixel> result = new CustomImage<YIQPixel>
            {
                Width = YIQImage.Width,
                Height = YIQImage.Height
            };

            List<YIQPixel> pixels = new List<YIQPixel>();
            foreach (var pixel in YIQImage.Pixels)
            {
                YIQPixel YIQModPixel = new YIQPixel
                {
                    Xpos = pixel.Xpos,
                    Ypos = pixel.Ypos,
                    Y = ValidateYIQ(pixel.Y * alpha, 0F, 1F),
                    I = ValidateYIQ(pixel.I * beta, -0.5957F, 0.5957F),
                    Q = ValidateYIQ(pixel.Q * beta, -0.5226F, 0.5226F)
                };
                pixels.Add(YIQModPixel);
            }

            result.Pixels = pixels;
            return YIQ2RGB(result);
        }

        public CustomImage<RGBPixel> LumaFilter(CustomImage<YIQPixel> YIQImage, string filter, float min=0.2F, float max=0.8F)
        {
            CustomImage<YIQPixel> result = new CustomImage<YIQPixel>
            {
                Width = YIQImage.Width,
                Height = YIQImage.Height
            };

            List<YIQPixel> pixels = new List<YIQPixel>();
            foreach (var pixel in YIQImage.Pixels)
            {
                YIQPixel YIQModPixel = new YIQPixel
                {
                    Xpos = pixel.Xpos,
                    Ypos = pixel.Ypos,
                    I = ValidateYIQ(pixel.I, -0.5957F, 0.5957F),
                    Q = ValidateYIQ(pixel.Q, -0.5226F, 0.5226F)
                };

                switch(filter)
                {
                    case "Raíz":
                        YIQModPixel.Y = ValidateYIQ((float)Math.Sqrt(pixel.Y), 0, 1);
                        break;
                    case "Cuadrado":
                        YIQModPixel.Y = ValidateYIQ((float)Math.Pow(pixel.Y, 2), 0, 1);                    
                        break;
                    case "Lineal a trozos":
                        float n = min / (1 - min);
                        float m = (1 + n) * max;
                        float Y = m * pixel.Y - n;
                        YIQModPixel.Y = ValidateYIQ(Y, 0, 1);
                        break;
                }

                pixels.Add(YIQModPixel);
            }

            result.Pixels = pixels;
            return YIQ2RGB(result);
        }

        public float ValidateYIQ(float value, float min, float max)
        {
            if (value < min) return min;
            else if (value > max) return max;
            else return value;
        }

        public Bitmap ApplyLumaChrominance(Bitmap image, float alpha=1.0F, float beta=1.0F)
        {
            var YIQImage = RGB2YIQ(image);
            var processedImage = LumaChrominance(YIQImage, alpha, beta);
            return BitmapFromCustomImage(processedImage);
        }

        public Bitmap ApplyLumaFilter(Bitmap image, string filter, float min = 0.2F, float max = 0.8F)
        {
            var YIQImage = RGB2YIQ(image);
            var processedImage = LumaFilter(YIQImage, filter, min, max);
            return BitmapFromCustomImage(processedImage);
        }
    }
}
