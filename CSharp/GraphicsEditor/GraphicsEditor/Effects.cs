
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraphicsEditor
{
	/// <summary>
	/// Knihovní třída pro přidání efektů
	/// </summary>
	public static class Effects
	{
		public static class Brightness
		{
			private const decimal r = 0.2989M;
			private const decimal g = 0.5870M;
			private const decimal b = 0.1140M;

			/// <summary>
			/// Vypočítá světlost barvy na základě předané barvy
			/// </summary>
			/// <param name="color">Barva</param>
			/// <returns>Světlost barvy</returns>
			public static decimal CalculateBrightness(Color color) => r * color.R + g * color.G + b * color.B;
        }

		/// <summary>
		/// Funkce z původní bitmapy vytvoří její černobílou variaci v závislosti na hranici světlosti.
		/// </summary>
		/// <param name="sourceBitmap">Zpracovávaná bitmapa</param>
		/// <param name="brightnessTreshold">Hranice světelnosti</param>
		/// <returns>Funkce vrací bitmapu</returns>
		public static Bitmap BlackAndWhite(Bitmap sourceBitmap, byte brightnessTreshold)
		{
			Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

			for (int row = 0; row < sourceBitmap.Width; row++)
			{
				for (int column = 0; column < sourceBitmap.Height; column++)
				{
					Color pixelColor = sourceBitmap.GetPixel(row, column);
					decimal pixelBrightness = Brightness.CalculateBrightness(pixelColor);

					resultBitmap.SetPixel(row, column, pixelBrightness < brightnessTreshold ? Color.Black : Color.White);
				}
			}
			return resultBitmap;
		}
		/*
		public static Bitmap Obrys(Bitmap image)
		{
			Bitmap resultImage = new Bitmap(image.Width, image.Height);

			for (int row = 0; row < image.Width; row++)
			{
				for (int column = 0; column < image.Height; column++)
				{
					Color pixel = image.GetPixel(row, column);
					decimal pixelLightness = LightnessContribution.Lightness(pixel);

					if ((row < resultImage.Width - 1) && (column < resultImage.Height - 1))
					{
						pixel = obr.GetPixel(row + 1, column + 1);
						red = pixel.R;
						green = pixel.G;
						blue = pixel.B;
						svetlost = (red * podR + green * podG + blue * podB);
					}

					if (Math.Abs(starasvetlost - svetlost) > 20)
					{
						pixel = Color.Black;
					}
					else
					{
						pixel = Color.White;
					}

					resultImage.SetPixel(i, j, Math.Abs(starasvetlost - svetlost) > 20 ? Color.Black : Color.White);
				}
			}
			return resultImage;
		}

		public static Bitmap Relief(Bitmap image, int posuvnik)
		{
			obr = new Bitmap(image);
			Color[,] poleBarev = new Color[obr.Width, obr.Height];
			for (int i = 0; i < obr.Width; i++)
			{
				for (int j = 0; j < obr.Height; j++)
				{
					Color pixel = obr.GetPixel(i, j);
					int red = pixel.R;
					int green = pixel.G;
					int blue = pixel.B;
					svetlost = (red * podR + green * podG + blue * podB);
					Color Cpixel;
					if ((j < obr.Height - 2) && (i < obr.Width - 2)) { Cpixel = obr.GetPixel(i + 2, j + 2); }
					else { Cpixel = obr.GetPixel(i, j); }
					int r = Cpixel.R;
					int g = Cpixel.G;
					int b = Cpixel.B;
					decimal svetlost2 = (r * podR + g * podG + b * podB);
					decimal Csvetlo = (posuvnik + svetlost2 - svetlost);
					if (Csvetlo < 0) { Csvetlo = 0; }
					if (Csvetlo > 255) { Csvetlo = 255; }
					int Barva = Convert.ToInt32(Csvetlo);
					Color color = Color.FromArgb(Barva, Barva, Barva);
					obr.SetPixel(i, j, color);
				}
			}
			return obr;
		}

		public static Bitmap ZmenaBarev(Bitmap image, int R, int G, int B)
		{
			obr = new Bitmap(image);
			float red = R / 100f;
			float green = G / 100f;
			float blue = B / 100f;
			Graphics g = Graphics.FromImage(obr);
			ColorMatrix matice = new ColorMatrix(new float[][]{new float[] {red, green, blue, 0, 0},
													 new float[] {red, green, blue, 0, 0},
													 new float[] {red, green, blue, 0, 0},
													 new float[] {0, 0, 0, 1, 0},
													 new float[] {0, 0, 0, 0, 1},});
			ImageAttributes ai = new ImageAttributes();
			ai.SetColorMatrix(matice);
			g.DrawImage(obr, new Rectangle(0, 0, obr.Width, obr.Height), 0, 0, obr.Width, obr.Height, GraphicsUnit.Pixel, ai);
			g.Dispose();
			return obr;
		}

		public static Bitmap šeď(Bitmap image)
		{
			obr = new Bitmap(image);
			for (int i = 0; i < obr.Width; i++)
			{
				for (int j = 0; j < obr.Height; j++)
				{
					Color pixel = obr.GetPixel(i, j);
					red = pixel.R;
					green = pixel.G;
					blue = pixel.B;
					svetlost = (red * podR + green * podG + blue * podB);
					obr.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(svetlost), Convert.ToInt32(svetlost), Convert.ToInt32(svetlost))); //- lepší černo bílý obrázek
				}
			}
			return obr;
		}

		public static Bitmap Zvětšení(Bitmap image)
		{
			obr = image;
			Bitmap obrn;
			obrn = new Bitmap(obr.Width * 2, obr.Height * 2);
			for (int i = 0; i < obr.Width; i++)
			{
				for (int j = 0; j < obr.Height; j++)
				{
					Color pixel = obr.GetPixel(i, j);
					obrn.SetPixel(2 * i, 2 * j, pixel);
					obrn.SetPixel(2 * i + 1, 2 * j, pixel);
					obrn.SetPixel(2 * i, 2 * j + 1, pixel);
					obrn.SetPixel(2 * i + 1, 2 * j + 1, pixel);
				}
			}
			return obrn;
		}

		public static Bitmap Negativ(Bitmap image)
		{
			obr = image;
			for (int i = 0; i < obr.Width; i++)
			{
				for (int j = 0; j < obr.Height; j++)
				{
					Color pixel = obr.GetPixel(i, j);
					//získání hodnoty
					alpha = pixel.A;
					red = pixel.R;
					green = pixel.G;
					blue = pixel.B;

					//negace hodnoty
					alpha = 255 - alpha;
					red = 255 - red;
					green = 255 - green;
					blue = 255 - blue;

					obr.SetPixel(i, j, Color.FromArgb(alpha, red, green, blue));
				}
			}
			return obr;
		}*/

	}
}
