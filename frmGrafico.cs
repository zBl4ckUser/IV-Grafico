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

        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        private ListaSimples<Ponto> figurasSelecionadas = new ListaSimples<Ponto>();
        private Ponto p1 = new Ponto(0, 0, Color.Black);
        private Polilinha polilinhaBase;

        const string numbers = "0123456789";
        private bool foiSalvo = true; // Se as operações feitas foram salvas no arquivo
        private bool esperaPonto = false;
        private bool esperaInicioReta = false;
        private bool esperaFimReta = false;
        private bool esperaCentroCirculo = false;
        private bool esperaRaioCirculo = false;
        private bool esperaCentroElipse = false;
        private bool esperaRaio0Elipse = false;
        private bool esperaRaio1Elipse = false;
        private bool esperaInicioRetangulo = false;
        private bool esperaFimRetangulo = false;
        Color corAtual = Color.Black;
        private int raio0;
        private bool esperaInicioPolilinha = false;
        private bool esperaFimPolilinha;

        private void LimparEsperas()
        {
            esperaPonto = false;
            esperaInicioReta = false;
            esperaFimReta = false;
            esperaCentroCirculo = false;
            esperaRaioCirculo = false;
            esperaCentroElipse = false;
            esperaRaio0Elipse = false;
            esperaRaio1Elipse = false;
            esperaInicioRetangulo = false;
            esperaFimRetangulo = false;
            esperaInicioPolilinha = false;
            esperaFimPolilinha = false;
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

            figurasSelecionadas.IniciarPercursoSequencial();
            while (figurasSelecionadas.PodePercorrer())
            {
                Ponto figuraSelecionadaAtual = figurasSelecionadas.Atual.Info;
                figuraSelecionadaAtual.Desenhar(Color.Red, g);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!foiSalvo)
            {
                var confirmacao = MessageBox.Show("Tens trabalho não salvo. Você tem certeza que quer abrir um novo arquivo?",
                        "Trabalho não salvo", MessageBoxButtons.YesNo);
                if(confirmacao == DialogResult.No)
                {
                    return;
                }
            }

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
                        Color cor = Color.FromArgb(255, corR, corG, corB);
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
                            case 'e': // figura é uma elipse
                                int raio0 = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                int raio1 = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                figuras.InserirAposFim(new Elipse(xBase, yBase, raio0, raio1, cor));
                                break;
                            case 'r': // figura é uma reta
                                int width = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                int height = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                figuras.InserirAposFim(new Retangulo(xBase, yBase, width, height, cor));
                                break;
                            case 'm': // figura é uma polilinha
                                if (polilinhaBase == null)
                                { 
                                    polilinhaBase = new Polilinha(xBase, yBase, cor); 
                                }
                                polilinhaBase.AdicionarPonto(new Ponto(xBase, yBase, cor));
                                break;

                        }
                    }

                    if (polilinhaBase != null)
                    {
                        figuras.InserirAposFim(polilinhaBase);
                        polilinhaBase = null;
                    }

                    arqFiguras.Close();
                    this.Text = dlgAbrir.FileName;
                    pbAreaDesenho.Invalidate();

                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ocorreu um erro durante a leitura do arquivo.", "Erro");
                    Console.WriteLine($"Erro de leitura no arquivo. \n {ex.Message}");
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Houve um erro ao ler o arquivo. {ex.Message}", "Erro");
                    Console.WriteLine($"Erro de formato nos dados do arquivo.\nMensagem:{ex.Message}");
                }
            foiSalvo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dlgSalvar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(dlgSalvar.FileName);
                    // Variáveis que representam o limite da imagem
                    int xInfEsq = 0, yInfEsq = 0, width = pbAreaDesenho.Width, height = pbAreaDesenho.Height;
                    writer.WriteLine($"{xInfEsq,5}{yInfEsq,5}{width,5}{height,5}");
                    figuras.IniciarPercursoSequencial();
                    while (figuras.PodePercorrer())
                    {
                        Ponto figuraAtual = figuras.Atual.Info;
                        writer.WriteLine(figuraAtual);
                    }
                    writer.Close();
                    foiSalvo = true;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao salvar o arquivo {ex.Message}");
                }
            }
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do ponto desejado:";
            LimparEsperas();
            esperaPonto = true;
        }

        private void btnReta_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do inicío da reta:";
            LimparEsperas();
            esperaInicioReta = true;
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do centro do círculo:";
            LimparEsperas();
            esperaCentroCirculo = true;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do centro da elipse:";
            LimparEsperas();
            esperaCentroElipse = true;
        }

        private void btnRetangulo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no ponto vertical do retângulo desejado";
            LimparEsperas();
            esperaInicioRetangulo = true;
        }

        private void btnPolilinha_Click(object sender, EventArgs e)
        {
            if (esperaFimPolilinha)
            {
                stMensagem.Items[1].Text = "sem mensagem";
                LimparEsperas();
                figuras.InserirAposFim(polilinhaBase);
                polilinhaBase = null;
            }
            else
            {
                stMensagem.Items[1].Text = "Clique no primeiro ponto do polilinha";
                LimparEsperas();
                esperaInicioPolilinha = true;
            }
        }

        private void btnCor_Click(object sender, EventArgs e)
        {
            dlgCor.ShowDialog();
            corAtual = dlgCor.Color;
            if (!figurasSelecionadas.EstaVazia)
            {
                NoLista<Ponto> atual = figurasSelecionadas.Primeiro;
                while (atual != null)
                {
                    atual.Info.Desenhar(corAtual, pbAreaDesenho.CreateGraphics(), 1);
                    atual = atual.Prox;
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = e.X + "," + e.Y;
        }

        private int CalcRaio(int x1, int x2, int y1, int y2)
        {
            int a = x1 - x2;
            int b = y1 - y2;

            return (int)Math.Sqrt(a * a + b * b);
        }
        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (esperaPonto)
            {
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(novoPonto);
                novoPonto.Desenhar(novoPonto.Cor, pbAreaDesenho.CreateGraphics());
                esperaPonto = false;
                stMensagem.Items[1].Text = "sem mensagem";
                pbAreaDesenho.Invalidate();
                foiSalvo = false;
                return;
            }
            if (esperaInicioReta)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioReta = false;
                esperaFimReta = true;
                stMensagem.Items[1].Text = ("clique o ponto final da reta");
                return;
            }
            if (esperaFimReta)
            {
                Reta reta = new Reta(p1.X, p1.Y, e.X, e.Y, corAtual);
                figuras.InserirAposFim(reta);
                reta.Desenhar(reta.Cor, pbAreaDesenho.CreateGraphics());

                esperaFimReta = false;
                stMensagem.Items[1].Text = "sem mensagem";
                pbAreaDesenho.Invalidate();
                foiSalvo = false;
                return;
            }
            if (esperaCentroCirculo)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaCentroCirculo = false;
                esperaRaioCirculo = true;
                stMensagem.Items[1].Text = ("clique onde será o raio do círculo");
                return;
            }
            if (esperaRaioCirculo)
            {
                int raio = CalcRaio(p1.X, e.X, p1.Y, e.Y);
                Circulo circ = new Circulo(p1.X, p1.Y, raio, corAtual);
                figuras.InserirAposFim(circ);
                circ.Desenhar(circ.Cor, pbAreaDesenho.CreateGraphics());

                stMensagem.Items[1].Text = "sem mensagem";
                pbAreaDesenho.Invalidate();
                esperaRaioCirculo = false;
                foiSalvo = false;
                return;
            }
            if (esperaCentroElipse)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaCentroElipse = false;
                esperaRaio0Elipse = true;
                stMensagem.Items[1].Text = ("clique onde será o primeiro raio da elipse");
                return;
            }
            if (esperaRaio0Elipse)
            {
                raio0 = CalcRaio(p1.X, e.X, p1.Y, e.Y);
                esperaRaio0Elipse = false;
                esperaRaio1Elipse = true;
                stMensagem.Items[1].Text = ("clique onde será o segundo raio da elipse");
                return;
            }
            if (esperaRaio1Elipse)
            {
                int raio1 = CalcRaio(p1.X, e.X, p1.Y, e.Y);
                Elipse elipse = new Elipse(p1.X, p1.Y, raio0, raio1, p1.Cor);
                figuras.InserirAposFim(elipse);
                elipse.Desenhar(elipse.Cor, pbAreaDesenho.CreateGraphics());
                esperaRaio1Elipse = false;
                stMensagem.Items[1].Text = "sem mensagem";
                pbAreaDesenho.Invalidate();
                foiSalvo = false;
                return;
            }
            if (esperaInicioRetangulo)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioRetangulo = false;
                esperaFimRetangulo = true;
                stMensagem.Items[1].Text = ("clique o ponto horizontal do retângulo");
                return;

            }
            if (esperaFimRetangulo)
            {
                int aux, x = e.X, y = e.Y;
                if (e.X < p1.X) { aux = p1.X; p1.X = e.X; x = aux; }
                if (e.Y < p1.Y) { aux = p1.Y; p1.Y = e.Y; y = aux; }
                int width = x - p1.X;
                int height = y - p1.Y;

                Retangulo retangulo = new Retangulo(p1.X, p1.Y, width, height, corAtual);
                figuras.InserirAposFim(retangulo);
                retangulo.Desenhar(retangulo.Cor, pbAreaDesenho.CreateGraphics());
                esperaFimRetangulo = false;
                stMensagem.Items[1].Text = "sem mensagem";
                pbAreaDesenho.Invalidate();
                foiSalvo = false;
                return;
            }

            if (esperaInicioPolilinha)
            {
                polilinhaBase = new Polilinha(e.X, e.Y, corAtual);
                esperaInicioPolilinha = false;
                esperaFimPolilinha = true;
                stMensagem.Items[1].Text = "clique no próximo ponto do polilinha | Clique no botão de polilinha para finalizar a polilinha";
                return;
            }
            if (esperaFimPolilinha)
            {
                Ponto p = new Ponto(e.X, e.Y, corAtual);

                polilinhaBase.AdicionarPonto(p);
                polilinhaBase.Desenhar(p.Cor, pbAreaDesenho.CreateGraphics()); // Assim 
                    //ou
                polilinhaBase.Desenhar(polilinhaBase.Cor, pbAreaDesenho.CreateGraphics()); // Assim?
                foiSalvo = false;
                return;
            }

        }

        private void frmGrafico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!foiSalvo)
            {
                var msgBox = MessageBox.Show("Você tem formas que não foram salvas.\n Desejas salvar o seu trabalho?",
                        "Trabalho não salvo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msgBox == DialogResult.Yes)
                {
                    btnSalvar_Click(sender, e);
                }
                if (msgBox == DialogResult.Cancel)
                {
                    e.Cancel = true; // Cancela o fechamento do form
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show("Você tem certeza que quer limpar todas as figuras?", "Deseja limpar a tela?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.Yes)
            {
                figuras = new ListaSimples<Ponto>();
                figurasSelecionadas = new ListaSimples<Ponto>();
                p1 = new Ponto(0, 0, corAtual);
                pbAreaDesenho.Invalidate();
                foiSalvo = true;
                LimparEsperas();
                // O Garbage Collector do C# vai fazer o trabalho de desalocar os objetos da lista antiga
            }
            return;
        }

        private void tbFigura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!numbers.Contains(Convert.ToString(e.KeyChar)) &&
                    e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {

            if (tbFigura.Text.Length > 0)
            {
                int contador = 0;
                NoLista<Ponto> atual = figuras.Primeiro;
                while (atual != null)
                {
                    if (contador == Convert.ToInt32(tbFigura.Text))
                    {
                        atual.Info.Desenhar(Color.Red, pbAreaDesenho.CreateGraphics(), 2);
                        figurasSelecionadas.InserirAposFim(atual.Info);
                        tbFigura.Clear();
                        return;
                    }
                    contador++;
                    atual = atual.Prox;
                }
                tbFigura.Clear();
            }
            else
            {
                MessageBox.Show("Insira o índice da figura na caixa de texto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            NoLista<Ponto> atual = figurasSelecionadas.Primeiro;
            while (atual != null)
            {
                figuras.Remover(atual.Info);
                atual = atual.Prox;
            }
            figurasSelecionadas = new ListaSimples<Ponto>();
            pbAreaDesenho.Invalidate();
            foiSalvo = false;
        }
    }
}
