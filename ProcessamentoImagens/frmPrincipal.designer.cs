namespace ProcessamentoImagens
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictBoxImg1 = new System.Windows.Forms.PictureBox();
            this.pictBoxImg2 = new System.Windows.Forms.PictureBox();
            this.btnAbrirImagem = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnFatiamento = new System.Windows.Forms.Button();
            this.btnFatiarDMA = new System.Windows.Forms.Button();
            this.btnEqualizar = new System.Windows.Forms.Button();
            this.btnEqualizarDMA = new System.Windows.Forms.Button();
            this.btnSuavizarMV = new System.Windows.Forms.Button();
            this.btnSuavizarMVDMA = new System.Windows.Forms.Button();
            this.btnKVDMA = new System.Windows.Forms.Button();
            this.btnKV = new System.Windows.Forms.Button();
            this.btnSuavizarFMDMA = new System.Windows.Forms.Button();
            this.btnSuavizarFM = new System.Windows.Forms.Button();
            this.btnEqualizarCinzaDMA = new System.Windows.Forms.Button();
            this.btnEqualizarCinza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImg1.Location = new System.Drawing.Point(5, 6);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(675, 500);
            this.pictBoxImg1.TabIndex = 102;
            this.pictBoxImg1.TabStop = false;
            // 
            // pictBoxImg2
            // 
            this.pictBoxImg2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImg2.Location = new System.Drawing.Point(686, 6);
            this.pictBoxImg2.Name = "pictBoxImg2";
            this.pictBoxImg2.Size = new System.Drawing.Size(675, 500);
            this.pictBoxImg2.TabIndex = 105;
            this.pictBoxImg2.TabStop = false;
            // 
            // btnAbrirImagem
            // 
            this.btnAbrirImagem.Location = new System.Drawing.Point(5, 512);
            this.btnAbrirImagem.Name = "btnAbrirImagem";
            this.btnAbrirImagem.Size = new System.Drawing.Size(101, 23);
            this.btnAbrirImagem.TabIndex = 106;
            this.btnAbrirImagem.Text = "Abrir Imagem";
            this.btnAbrirImagem.UseVisualStyleBackColor = true;
            this.btnAbrirImagem.Click += new System.EventHandler(this.btnAbrirImagem_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(112, 512);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(101, 23);
            this.btnLimpar.TabIndex = 107;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnFatiamento
            // 
            this.btnFatiamento.Location = new System.Drawing.Point(226, 512);
            this.btnFatiamento.Name = "btnFatiamento";
            this.btnFatiamento.Size = new System.Drawing.Size(170, 23);
            this.btnFatiamento.TabIndex = 108;
            this.btnFatiamento.Text = "Fatiar plano de bits";
            this.btnFatiamento.UseVisualStyleBackColor = true;
            this.btnFatiamento.Click += new System.EventHandler(this.btnFatiamento_Click);
            // 
            // btnFatiarDMA
            // 
            this.btnFatiarDMA.Location = new System.Drawing.Point(226, 541);
            this.btnFatiarDMA.Name = "btnFatiarDMA";
            this.btnFatiarDMA.Size = new System.Drawing.Size(170, 23);
            this.btnFatiarDMA.TabIndex = 109;
            this.btnFatiarDMA.Text = "Fatiar plano de bits com DMA";
            this.btnFatiarDMA.UseVisualStyleBackColor = true;
            this.btnFatiarDMA.Click += new System.EventHandler(this.btnFatiarDMA_Click);
            // 
            // btnEqualizar
            // 
            this.btnEqualizar.Location = new System.Drawing.Point(402, 512);
            this.btnEqualizar.Name = "btnEqualizar";
            this.btnEqualizar.Size = new System.Drawing.Size(170, 23);
            this.btnEqualizar.TabIndex = 110;
            this.btnEqualizar.Text = "Equalizar histograma";
            this.btnEqualizar.UseVisualStyleBackColor = true;
            this.btnEqualizar.Click += new System.EventHandler(this.btnEqualizar_Click);
            // 
            // btnEqualizarDMA
            // 
            this.btnEqualizarDMA.Location = new System.Drawing.Point(402, 541);
            this.btnEqualizarDMA.Name = "btnEqualizarDMA";
            this.btnEqualizarDMA.Size = new System.Drawing.Size(170, 23);
            this.btnEqualizarDMA.TabIndex = 111;
            this.btnEqualizarDMA.Text = "Equalizar histograma comDMA";
            this.btnEqualizarDMA.UseVisualStyleBackColor = true;
            this.btnEqualizarDMA.Click += new System.EventHandler(this.btnEqualizarDMA_Click);
            // 
            // btnSuavizarMV
            // 
            this.btnSuavizarMV.Location = new System.Drawing.Point(784, 512);
            this.btnSuavizarMV.Name = "btnSuavizarMV";
            this.btnSuavizarMV.Size = new System.Drawing.Size(200, 23);
            this.btnSuavizarMV.TabIndex = 112;
            this.btnSuavizarMV.Text = "Suavizar media de vizinhaca 5x5";
            this.btnSuavizarMV.UseVisualStyleBackColor = true;
            this.btnSuavizarMV.Click += new System.EventHandler(this.btnSuavizarMV_Click);
            // 
            // btnSuavizarMVDMA
            // 
            this.btnSuavizarMVDMA.Location = new System.Drawing.Point(784, 541);
            this.btnSuavizarMVDMA.Name = "btnSuavizarMVDMA";
            this.btnSuavizarMVDMA.Size = new System.Drawing.Size(200, 23);
            this.btnSuavizarMVDMA.TabIndex = 113;
            this.btnSuavizarMVDMA.Text = "Suavisar media da vizinhaca DMA 5x5\r\n\r\n";
            this.btnSuavizarMVDMA.UseVisualStyleBackColor = true;
            this.btnSuavizarMVDMA.Click += new System.EventHandler(this.btnSuavizarMVDMA_Click);
            // 
            // btnKVDMA
            // 
            this.btnKVDMA.Location = new System.Drawing.Point(1166, 541);
            this.btnKVDMA.Name = "btnKVDMA";
            this.btnKVDMA.Size = new System.Drawing.Size(170, 23);
            this.btnKVDMA.TabIndex = 117;
            this.btnKVDMA.Text = "k-vizinhos DMA 9";
            this.btnKVDMA.UseVisualStyleBackColor = true;
            // 
            // btnKV
            // 
            this.btnKV.Location = new System.Drawing.Point(1166, 512);
            this.btnKV.Name = "btnKV";
            this.btnKV.Size = new System.Drawing.Size(170, 23);
            this.btnKV.TabIndex = 116;
            this.btnKV.Text = "k-Vizinhos 9";
            this.btnKV.UseVisualStyleBackColor = true;
            // 
            // btnSuavizarFMDMA
            // 
            this.btnSuavizarFMDMA.Location = new System.Drawing.Point(990, 541);
            this.btnSuavizarFMDMA.Name = "btnSuavizarFMDMA";
            this.btnSuavizarFMDMA.Size = new System.Drawing.Size(170, 23);
            this.btnSuavizarFMDMA.TabIndex = 115;
            this.btnSuavizarFMDMA.Text = "Filtro da mediana com DMA 5x5";
            this.btnSuavizarFMDMA.UseVisualStyleBackColor = true;
            this.btnSuavizarFMDMA.Click += new System.EventHandler(this.btnSuavizarFMDMA_Click);
            // 
            // btnSuavizarFM
            // 
            this.btnSuavizarFM.Location = new System.Drawing.Point(990, 512);
            this.btnSuavizarFM.Name = "btnSuavizarFM";
            this.btnSuavizarFM.Size = new System.Drawing.Size(170, 23);
            this.btnSuavizarFM.TabIndex = 114;
            this.btnSuavizarFM.Text = "Filtro da mediana 5x5";
            this.btnSuavizarFM.UseVisualStyleBackColor = true;
            this.btnSuavizarFM.Click += new System.EventHandler(this.btnSuavizarFM_Click);
            // 
            // btnEqualizarCinzaDMA
            // 
            this.btnEqualizarCinzaDMA.Location = new System.Drawing.Point(578, 541);
            this.btnEqualizarCinzaDMA.Name = "btnEqualizarCinzaDMA";
            this.btnEqualizarCinzaDMA.Size = new System.Drawing.Size(200, 23);
            this.btnEqualizarCinzaDMA.TabIndex = 119;
            this.btnEqualizarCinzaDMA.Text = "Equalizar histograma cinza comDMA";
            this.btnEqualizarCinzaDMA.UseVisualStyleBackColor = true;
            this.btnEqualizarCinzaDMA.Click += new System.EventHandler(this.btnEqualizarCinzaDMA_Click);
            // 
            // btnEqualizarCinza
            // 
            this.btnEqualizarCinza.Location = new System.Drawing.Point(578, 512);
            this.btnEqualizarCinza.Name = "btnEqualizarCinza";
            this.btnEqualizarCinza.Size = new System.Drawing.Size(200, 23);
            this.btnEqualizarCinza.TabIndex = 118;
            this.btnEqualizarCinza.Text = "Equalizar histograma cinza";
            this.btnEqualizarCinza.UseVisualStyleBackColor = true;
            this.btnEqualizarCinza.Click += new System.EventHandler(this.btnEqualizarCinza_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 608);
            this.Controls.Add(this.btnEqualizarCinzaDMA);
            this.Controls.Add(this.btnEqualizarCinza);
            this.Controls.Add(this.btnKVDMA);
            this.Controls.Add(this.btnKV);
            this.Controls.Add(this.btnSuavizarFMDMA);
            this.Controls.Add(this.btnSuavizarFM);
            this.Controls.Add(this.btnSuavizarMVDMA);
            this.Controls.Add(this.btnSuavizarMV);
            this.Controls.Add(this.btnEqualizarDMA);
            this.Controls.Add(this.btnEqualizar);
            this.Controls.Add(this.btnFatiarDMA);
            this.Controls.Add(this.btnFatiamento);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAbrirImagem);
            this.Controls.Add(this.pictBoxImg2);
            this.Controls.Add(this.pictBoxImg1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.PictureBox pictBoxImg2;
        private System.Windows.Forms.Button btnAbrirImagem;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnFatiamento;
        private System.Windows.Forms.Button btnFatiarDMA;
        private System.Windows.Forms.Button btnEqualizar;
        private System.Windows.Forms.Button btnEqualizarDMA;
        private System.Windows.Forms.Button btnSuavizarMV;
        private System.Windows.Forms.Button btnSuavizarMVDMA;
        private System.Windows.Forms.Button btnKVDMA;
        private System.Windows.Forms.Button btnKV;
        private System.Windows.Forms.Button btnSuavizarFMDMA;
        private System.Windows.Forms.Button btnSuavizarFM;
        private System.Windows.Forms.Button btnEqualizarCinzaDMA;
        private System.Windows.Forms.Button btnEqualizarCinza;
    }
}

