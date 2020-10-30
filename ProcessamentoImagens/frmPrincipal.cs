using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Image image;
        private Bitmap imageBitmap;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAbrirImagem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictBoxImg1.Image = image;
                pictBoxImg1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pictBoxImg1.Image = null;
            pictBoxImg2.Image = null;
        }

        private void btnFatiamento_Click(object sender, EventArgs e)
        {
            Bitmap[] dst = new Bitmap[8];
            for(int i = 0; i < 8; i++)
                dst[i] = new Bitmap(image);


            imageBitmap = (Bitmap)image;
            Filtros.FatiarPlanoBits(imageBitmap, dst);
            Process.Start("Explorer",@"D:\TTC\imagens\Fatiamento");
        }

        private void btnFatiarDMA_Click(object sender, EventArgs e)
        {
            Bitmap[] dst = new Bitmap[8];
            for (int i = 0; i < 8; i++)
                dst[i] = new Bitmap(image);


            imageBitmap = (Bitmap)image;
            Filtros.FatiarPlanoBitsDMA(imageBitmap, dst);
            Process.Start("Explorer", @"D:\TTC\imagens\Fatiamento");
        }

        private void btnEqualizar_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.EqualizarHistograma(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnEqualizarDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.EqualizarHistogramaDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnEqualizarCinza_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.EqualizarHistogramaCinza(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnEqualizarCinzaDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.EqualizarHistogramaCinzaDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnSuavizarMV_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.MediaVizinhanca5(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnSuavizarMVDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.MediaVizinhanca5DMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnSuavizarFM_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.Mediana(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnSuavizarFMDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.MedianaDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }
    }
}
