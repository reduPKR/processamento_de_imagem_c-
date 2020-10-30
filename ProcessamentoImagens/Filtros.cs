using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ProcessamentoImagens
{
    class Filtros
    {
        public static void FatiarPlanoBits(Bitmap src, Bitmap[] bit)
        {
            int i;
            int height = src.Height;
            int width = src.Width;           

            Color cor;
            int r, g, b;
            int auxR, auxB, auxG;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    cor = src.GetPixel(x, y);
                    r = cor.R;
                    g = cor.G;
                    b = cor.B;

                    for (i = 0; i < 8; i++)
                    {
                        auxR = r << i;
                        auxG = g << i;
                        auxB = b << i;

                        auxR = auxR >> 7;
                        auxG = auxG >> 7;
                        auxB = auxB >> 7;

                        auxR = auxR == 1 ? 255 : 0;
                        auxG = auxG == 1 ? 255 : 0;
                        auxB = auxB == 1 ? 255 : 0;

                        cor = Color.FromArgb(auxR, auxG, auxB);
                        bit[i].SetPixel(x, y, cor);
                    }
                }
            }

            for (i = 0; i < 8; i++)
                bit[i].Save(@"D:\TTC\imagens\Fatiamento\imagem_bit" + (7-i) +".jpg");
        }

        public static void FatiarPlanoBitsDMA(Bitmap bmpSrc, Bitmap[] bit)
        {
            int height = bmpSrc.Height;
            int width = bmpSrc.Width;
            int pxl = 3;
            int i;

            BitmapData srcData = bmpSrc.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData[] dstData = new BitmapData[8];

            for(i = 0; i < 8; i++)
                dstData[i] = bit[i].LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pxl);

            unsafe
            {
                byte* src = (byte*)srcData.Scan0.ToPointer();

                byte*[] dst = new byte*[8];
                for (i = 0; i < 8; i++)
                    dst[i] = (byte*)dstData[i].Scan0.ToPointer();
                int r, g, b;
                int auxR, auxG, auxB;

                for(int y = 0; y < height; y++)
                {
                    for(int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        for(i = 0; i < 8; i++)
                        {
                            auxB = b << i;
                            auxG = g << i;
                            auxR = r << i;

                            auxR = auxR >> 7;
                            auxG = auxG >> 7;
                            auxB = auxB >> 7;


                            auxR = auxR == 1 ? 255 : 0;
                            auxG = auxG == 1 ? 255 : 0;
                            auxB = auxB == 1 ? 255 : 0;

                            *(dst[i]++) = (byte)auxB;
                            *(dst[i]++) = (byte)auxG;
                            *(dst[i]++) = (byte)auxR;
                        }
                    }

                    src += padding;
                    for (i = 0; i < 8; i++)
                        dst[i] += padding;
                }

                bmpSrc.UnlockBits(srcData);

                for (i = 0; i < 8; i++)
                    bit[i].UnlockBits(dstData[i]);
                for (i = 0; i < 8; i++)
                    bit[i].Save(@"D:\TTC\imagens\Fatiamento\imagem_bit" + (7-i) + ".jpg");
            }
        }

        public static void EqualizarHistograma(Bitmap src, Bitmap dst)
        {
            int height = src.Height;
            int width = src.Width;

            int r, g, b, y, x, aux, i, j;
            double E;
            int[] q = new int[256];//resultado
            int[] n = new int[256];//histograma
            Color cor;

            for(y = 0; y < height; y++)
            {
                for(x = 0; x < width; x++)
                {
                    cor = src.GetPixel(x, y);
                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    aux = (r + g + b) / 3;

                    n[aux]++;
                }
            }

            for (j = 1; j < 256; j++)
                n[j] = n[j] + n[j - 1];//somatorio n

            i = (height * width) / 255;
            for (j = 0; j < 256; j++)
            {
                E = (n[j])/i - 1;

                q[j] = (int) Math.Max(0, Math.Round(E));
            }

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    cor = src.GetPixel(x, y);
                    r = cor.R;
                    g = cor.G;
                    b = cor.B;

                    r = q[r];
                    g = q[g];
                    b = q[b];
                    cor = Color.FromArgb(r, g, b);
                    dst.SetPixel(x, y, cor);
                }
            }
        }

        public static void EqualizarHistogramaDMA(Bitmap bmpSrc, Bitmap bmpDst)
        {
            int heigth = bmpSrc.Height;
            int width = bmpSrc.Width;
            int pxl = 3;

            BitmapData srcData = bmpSrc.LockBits(new Rectangle(0, 0, width, heigth), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dstData = bmpDst.LockBits(new Rectangle(0, 0, width, heigth), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pxl);

            unsafe
            {
                byte* src = (byte*)srcData.Scan0.ToPointer();
                byte* dst = (byte*)dstData.Scan0.ToPointer();

                int r, g, b, x, y, i, j, aux;
                double E;
                int[] q = new int[256];//resultado
                int[] n = new int[256];//histograma

                for (y = 0; y < heigth; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        aux = (r + g + b) / 3;
                        n[aux]++;
                    }
                    src += padding;
                }

                for (j = 1; j < 256; j++)//somatorio de n
                    n[j] = n[j] + n[j - 1];

                i = (heigth * width) / 255;
                for(j = 0; j < 256; j++)
                {
                    E = (n[j] / i) - 1;
                    q[j] = (int)Math.Max(0, Math.Round(E));
                }

                src = (byte*)srcData.Scan0.ToPointer();
                for (y = 0; y < heigth; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        r = q[r];
                        g = q[g];
                        b = q[b];

                        *(dst++) = (byte)b;
                        *(dst++) = (byte)g;
                        *(dst++) = (byte)r;
                    }
                    src += padding;
                    dst += padding;
                }

                bmpSrc.UnlockBits(srcData);
                bmpDst.UnlockBits(dstData);
            }

        }

        public static void EqualizarHistogramaCinza(Bitmap src, Bitmap dst)
        {
            int height = src.Height;
            int width = src.Width;

            int r, g, b, y, x, aux, i, j;
            double E;
            int[] q = new int[256];//resultado
            int[] n = new int[256];//histograma
            Color cor;

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    cor = src.GetPixel(x, y);
                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    aux = (r + g + b) / 3;

                    n[aux]++;
                }
            }

            for (j = 1; j < 256; j++)
                n[j] = n[j] + n[j - 1];//somatorio n

            i = (height * width) / 255;
            for (j = 0; j < 256; j++)
            {
                E = (n[j]) / i - 1;

                q[j] = (int)Math.Max(0, Math.Round(E));
            }

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    cor = src.GetPixel(x, y);
                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    aux = (r + g + b) / 3;
                    r = q[aux];
                    cor = Color.FromArgb(r, r, r);
                    dst.SetPixel(x, y, cor);
                }
            }
        }

        public static void EqualizarHistogramaCinzaDMA(Bitmap bmpSrc, Bitmap bmpDst)
        {
            int heigth = bmpSrc.Height;
            int width = bmpSrc.Width;
            int pxl = 3;

            BitmapData srcData = bmpSrc.LockBits(new Rectangle(0, 0, width, heigth), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dstData = bmpDst.LockBits(new Rectangle(0, 0, width, heigth), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pxl);

            unsafe
            {
                byte* src = (byte*)srcData.Scan0.ToPointer();
                byte* dst = (byte*)dstData.Scan0.ToPointer();

                int r, g, b, x, y, i, j, aux;
                double E;
                int[] q = new int[256];//resultado
                int[] n = new int[256];//histograma

                for (y = 0; y < heigth; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        aux = (r + g + b) / 3;
                        n[aux]++;
                    }
                    src += padding;
                }

                for (j = 1; j < 256; j++)//somatorio de n
                    n[j] = n[j] + n[j - 1];

                i = (heigth * width) / 255;
                for(j = 0; j < 256; j++)
                {
                    E = (n[j] / i) - 1;
                    q[j] = (int)Math.Max(0, Math.Round(E));
                }

                src = (byte*)srcData.Scan0.ToPointer();
                for (y = 0; y < heigth; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        aux = (r + g + b) / 3;

                        b = q[aux];
                        *(dst++) = (byte)b;
                        *(dst++) = (byte)b;
                        *(dst++) = (byte)b;
                    }
                    src += padding;
                    dst += padding;
                }

                bmpSrc.UnlockBits(srcData);
                bmpDst.UnlockBits(dstData);
            }

        }

        private static int OrdenarVetor(int[] vet,int posV)
        {
            /*insercao direta*/
            int i, pos, aux;
            
            for(i = 1; i < 25; i++)
            {
                aux = vet[i];
                pos = i;

                while(pos > 0 && aux < vet[pos-1])
                {
                    vet[pos] = vet[pos - 1];
                    pos--;
                }

                vet[pos] = aux;
                if (i == posV)
                    posV = pos;
            }

            return posV;
        }

        private static int mediaVizinhaca(int[] vet, int posV)
        {
            int k = 9;
            int ret = 0;

            OrdenarVetor(vet,posV);

            for (int i = posV - 10; i < k; i++)
                ret += vet[i];
            ret /= k;

            return ret;
        }

        public static void MediaVizinhanca5(Bitmap src, Bitmap dst)
        {
            int height = src.Height;
            int width = src.Width;

            Color cor;
            int r, g, b;
            int i, j, k1, k2, k3;
            int[] vetR = new int[25];
            int[] vetG = new int[25];
            int[] vetB = new int[25];

            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    cor = src.GetPixel(x, y);

                    if(y >= 2 && y < height-2 && x >= 2 && x < width-2)
                    {
                        k1 = k2 = k3 = 0;
                        for(i = y - 2; i < y + 2; i++)
                        {
                            for(j = x - 2; j < x+2; j++)
                            {
                                cor = src.GetPixel(j, i);
                                vetR[k1++] = cor.R;
                                vetG[k2++] = cor.G;
                                vetB[k3++] = cor.B;
                                
                            }
                        }
                        r = mediaVizinhaca(vetR, 13);
                        g = mediaVizinhaca(vetG, 13);
                        b = mediaVizinhaca(vetB, 13);
                        cor = Color.FromArgb(r, g, b);
                    }
                    else
                        cor = Color.FromArgb(0, 0, 0);

                    dst.SetPixel(x, y, cor);
                }
            }

        }

        public static void MediaVizinhanca5DMA(Bitmap bmpSrc, Bitmap bmpDst)
        {
            int height = bmpSrc.Height;
            int width = bmpSrc.Width;
            int pxl = 3;

            BitmapData srcData = bmpSrc.LockBits(new Rectangle(0,0,width,height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dstData = bmpDst.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pxl);
            int stride = srcData.Stride;
            unsafe
            {
                byte* src = (byte*)srcData.Scan0.ToPointer();
                byte* dst = (byte*)dstData.Scan0.ToPointer();

                byte* ini = src;//ponteiro para o inicio do src

                int r, g, b;
                int i, j, k1,k2,k3;
                int[] vetR = new int[25];
                int[] vetG = new int[25];
                int[] vetB = new int[25];


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (y >= 2 && y < height - 2 && x >= 2 && x < width - 2)
                        {
                            k1 = k2 = k3 = 0;
                            for (i = y - 2; i < y + 2; i++)
                            {
                                for (j = x - 2; j < x + 2; j++)
                                {
                                    src = (byte*)(ini + ((i * stride) + (j * pxl)));

                                    vetB[k1++] = *(src++);
                                    vetG[k2++] = *(src++);
                                    vetR[k3++] = *(src++);
                                    
                                }
                            }
                            b = mediaVizinhaca(vetB, 13);
                            g = mediaVizinhaca(vetG, 13);
                            r = mediaVizinhaca(vetR, 13);
                        }
                        else
                            b = g = r = 0;

                        *(dst++) = (byte)b;
                        *(dst++) = (byte)g;
                        *(dst++) = (byte)r;
                    }
                    src += padding;
                    dst += padding;
                }

                bmpSrc.UnlockBits(srcData);
                bmpDst.UnlockBits(dstData);
            }
        }

        private static int MedianaVal(int[] vet)
        {
            OrdenarVetor(vet, 13);
            return vet[13];
        }

        public static void Mediana(Bitmap src, Bitmap dst)
        {
            int height = src.Height;
            int width = src.Width;

            int r, g, b;
            int k1, k2, k3, i, j;
            int[] vetR = new int[25];
            int[] vetG = new int[25];
            int[] vetB = new int[25];

            Color cor;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (y >= 2 && y < height - 2 && x >= 2 && x < width - 2)
                    {
                        k1 = k2 = k3 = 0;
                        for (i = y -2; i < y+2; i++)
                        {
                            for(j = x-2; j < x+2; j++)
                            {
                                cor = src.GetPixel(j, i);
                                vetR[k1++] = cor.R;
                                vetG[k2++] = cor.G;
                                vetB[k3++] = cor.B;
                            }
                        }
                        r = MedianaVal(vetR);
                        g = MedianaVal(vetG);
                        b = MedianaVal(vetB);
                        cor = Color.FromArgb(r, g, b);
                    }
                    else
                        cor = Color.FromArgb(0, 0, 0);

                    dst.SetPixel(x, y, cor);
                }
            }
        }

        public static void MedianaDMA(Bitmap bmpSrc, Bitmap bmpDst)
        {
            int height = bmpSrc.Height;
            int width = bmpSrc.Width;
            int pxl = 3;

            BitmapData srcData = bmpSrc.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dstData = bmpDst.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pxl);
            int stride = srcData.Stride;
            unsafe
            {
                byte* src = (byte*)srcData.Scan0.ToPointer();
                byte* dst = (byte*)dstData.Scan0.ToPointer();

                byte* ini = src;

                int r, g, b;
                int i, j, k1, k2, k3;
                int[] vetR = new int[25];
                int[] vetG = new int[25];
                int[] vetB = new int[25];


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (y >= 2 && y < height - 2 && x >= 2 && x < width - 2)
                        {
                            k1 = k2 = k3 = 0;
                            for (i = y - 2; i < y + 2; i++)
                            {
                                for (j = x - 2; j < x + 2; j++)
                                {
                                    src = (byte*)(ini + ((i * stride) + (j * pxl)));

                                    vetB[k1++] = *(src++);
                                    vetG[k2++] = *(src++);
                                    vetR[k3++] = *(src++);

                                }
                            }
                            b = MedianaVal(vetB);
                            g = MedianaVal(vetG);
                            r = MedianaVal(vetR);
                        }
                        else
                            b = g = r = 0;

                        *(dst++) = (byte)b;
                        *(dst++) = (byte)g;
                        *(dst++) = (byte)r;
                    }
                    src += padding;
                    dst += padding;
                }

                bmpSrc.UnlockBits(srcData);
                bmpDst.UnlockBits(dstData);
            }
        }
    }
}
