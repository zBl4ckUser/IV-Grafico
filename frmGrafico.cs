using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Grafico
{
    public partial class frmGrafico : Form
    {
        public frmGrafico()
        {
            InitializeComponent();
        }

        bool foiSalvo = true; // Se as operações feitas foram salvas no arquivo
        bool esperaPonto = false;
        bool esperaInicioReta = false;
        bool esperaFimReta = false;
        
        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        Color corAtual = Color.Black;

        private void LimparEsperas()
        {
            esperaPonto = false;
            esperaInicioReta = false;
            esperaFimReta = false;
        }

        private void pbAreaDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // acessa contexto gráfico
            figuras.IniciarPercursoSequencial();
            while (figuras.PodePercorrer())
            {
                Ponto figuraAtual = figuras.Atual.Info;
                figuraAtual.Desenhar(figuraAtual.Cor, g);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
                try
                {
                    StreamReader arqFiguras = new StreamReader(dlgAbrir.FileName);
                    String linha = arqFiguras.ReadLine();

                    Double xInfEsq = Convert.ToDouble(linha.Substring(0, 5).Trim());
                    Double yInfEsq = Convert.ToDouble(linha.Substring(5, 5).Trim());
                    Double xSupDir = Convert.ToDouble(linha.Substring(10, 5).Trim());
                    Double ySupDir = Convert.ToDouble(linha.Substring(15, 5).Trim());
                    while ((linha = arqFiguras.ReadLine()) != null)
                    {
                        String tipo = linha.Substring(0, 5).Trim();

                        int xBase = Convert.ToInt32(linha.Substring(5, 5).Trim());
                        int yBase = Convert.ToInt32(linha.Substring(10, 5).Trim());
                        int corR = Convert.ToInt32(linha.Substring(15, 5).Trim());
                        int corG = Convert.ToInt32(linha.Substring(20, 5).Trim());
                        int corB = Convert.ToInt32(linha.Substring(25, 5).Trim());
                        Color cor = new Color();
                        cor = Color.FromArgb(255, corR, corG, corB);
                        switch (tipo[0])
                        {

                            case 'p': // figura é um ponto
                                figuras.InserirAposFim(new Ponto(xBase, yBase, cor));
                                break;
                            case 'l': // figura é uma reta
                                int xFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                int yFinal = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                figuras.InserirAposFim(new Reta(xBase, yBase, xFinal, yFinal, cor));
                                break;
                            case 'c': // figura é um círculo
                                int raio = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                figuras.InserirAposFim(new Circulo(xBase, yBase, raio, cor));
                                break;
                            case 'e':
                                int raio0 = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                int raio1 = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                figuras.InserirAposFim(new Ellipse(xBase, yBase, raio0, raio1, cor));
                                break;
                        }
                    }

                    arqFiguras.Close();
                    this.Text = dlgAbrir.FileName;
                    pbAreaDesenho.Invalidate();

                }
                catch (IOException)
                {
                    Console.WriteLine("Erro de leitura no arquivo");
                }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do ponto desejado:";
            LimparEsperas();
            esperaPonto = true;
        }

        private void btnReta_Click(object sender, EventArgs e)
        {

        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {

        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {

        }

        private void btnRetangulo_Click(object sender, EventArgs e)
        {

        }

        private void btnPolilinha_Click(object sender, EventArgs e)
        {

        }

        private void btnCor_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = e.X + "," + e.Y;
        }

        private void pbAreaDesenho_Click(object sender, EventArgs e)
        {
            
        }

        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (esperaPonto)
            {
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(novoPonto);
                novoPonto.Desenhar(novoPonto.Cor, pbAreaDesenho.CreateGraphics());
                esperaPonto = false;
                stMensagem.Items[1].Text = "";
            }
        }
    }
}
