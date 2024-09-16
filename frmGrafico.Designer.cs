namespace Grafico
{
    partial class frmGrafico
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrafico));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPonto = new System.Windows.Forms.ToolStripButton();
            this.btnReta = new System.Windows.Forms.ToolStripButton();
            this.btnCirculo = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnRetangulo = new System.Windows.Forms.ToolStripButton();
            this.btnPolilinha = new System.Windows.Forms.ToolStripButton();
            this.btnCor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stMensagem = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlgCor = new System.Windows.Forms.ColorDialog();
            this.pbAreaDesenho = new System.Windows.Forms.PictureBox();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.dlgSalvar = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            this.stMensagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAreaDesenho)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrir,
            this.btnSalvar,
            this.toolStripSeparator1,
            this.btnPonto,
            this.btnReta,
            this.btnCirculo,
            this.btnEllipse,
            this.btnRetangulo,
            this.btnPolilinha,
            this.btnCor,
            this.toolStripSeparator3,
            this.btnSair,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "s";
            // 
            // btnAbrir
            // 
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = global::Grafico.Properties.Resources.file;
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(23, 22);
            this.btnAbrir.Text = "Abrir arquivo";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(23, 22);
            this.btnSalvar.Text = "Salvar arquivo";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPonto
            // 
            this.btnPonto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPonto.Image = global::Grafico.Properties.Resources.oval;
            this.btnPonto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPonto.Name = "btnPonto";
            this.btnPonto.Size = new System.Drawing.Size(23, 22);
            this.btnPonto.Text = "Ponto";
            this.btnPonto.Click += new System.EventHandler(this.btnPonto_Click);
            // 
            // btnReta
            // 
            this.btnReta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReta.Image = ((System.Drawing.Image)(resources.GetObject("btnReta.Image")));
            this.btnReta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReta.Name = "btnReta";
            this.btnReta.Size = new System.Drawing.Size(23, 22);
            this.btnReta.Text = "Reta";
            this.btnReta.Click += new System.EventHandler(this.btnReta_Click);
            // 
            // btnCirculo
            // 
            this.btnCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCirculo.Image = global::Grafico.Properties.Resources.circle;
            this.btnCirculo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(23, 22);
            this.btnCirculo.Text = "Círculo";
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.Image = global::Grafico.Properties.Resources.ellipse;
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(23, 22);
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnRetangulo
            // 
            this.btnRetangulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRetangulo.Image = global::Grafico.Properties.Resources.rectangle;
            this.btnRetangulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRetangulo.Name = "btnRetangulo";
            this.btnRetangulo.Size = new System.Drawing.Size(23, 22);
            this.btnRetangulo.Text = "Retângulo";
            this.btnRetangulo.Click += new System.EventHandler(this.btnRetangulo_Click);
            // 
            // btnPolilinha
            // 
            this.btnPolilinha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPolilinha.Image = global::Grafico.Properties.Resources.line_segment;
            this.btnPolilinha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPolilinha.Name = "btnPolilinha";
            this.btnPolilinha.Size = new System.Drawing.Size(23, 22);
            this.btnPolilinha.Text = "Polilinha";
            this.btnPolilinha.Click += new System.EventHandler(this.btnPolilinha_Click);
            // 
            // btnCor
            // 
            this.btnCor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCor.Image = global::Grafico.Properties.Resources.art;
            this.btnCor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(23, 22);
            this.btnCor.Text = "Mudar cor";
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSair
            // 
            this.btnSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSair.Image = global::Grafico.Properties.Resources.exit;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(23, 22);
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // stMensagem
            // 
            this.stMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.stMensagem.Location = new System.Drawing.Point(0, 428);
            this.stMensagem.Name = "stMensagem";
            this.stMensagem.Size = new System.Drawing.Size(785, 22);
            this.stMensagem.TabIndex = 1;
            this.stMensagem.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "Mensagem:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel2.Text = "sem mensagem";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel3.Text = "Coordenadas:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel4.Text = "x, y";
            // 
            // pbAreaDesenho
            // 
            this.pbAreaDesenho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAreaDesenho.Location = new System.Drawing.Point(0, 28);
            this.pbAreaDesenho.Name = "pbAreaDesenho";
            this.pbAreaDesenho.Size = new System.Drawing.Size(785, 397);
            this.pbAreaDesenho.TabIndex = 2;
            this.pbAreaDesenho.TabStop = false;
            this.pbAreaDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAreaDesenho_Paint);
            this.pbAreaDesenho.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbAreaDesenho_MouseClick);
            this.pbAreaDesenho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbAreaDesenho_MouseMove);
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // frmGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.pbAreaDesenho);
            this.Controls.Add(this.stMensagem);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmGrafico";
            this.Text = "Desenho Geométrico";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.stMensagem.ResumeLayout(false);
            this.stMensagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAreaDesenho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip stMensagem;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnPonto;
        private System.Windows.Forms.ToolStripButton btnReta;
        private System.Windows.Forms.ToolStripButton btnCirculo;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.ToolStripButton btnRetangulo;
        private System.Windows.Forms.ToolStripButton btnPolilinha;
        private System.Windows.Forms.ToolStripButton btnCor;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pbAreaDesenho;
        private System.Windows.Forms.ColorDialog dlgCor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.SaveFileDialog dlgSalvar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

