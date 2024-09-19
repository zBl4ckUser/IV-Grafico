using System;
using System.Drawing;

namespace Grafico
{
    class Ponto : IComparable<Ponto>
    {
        private int x, y;
        private Color cor;

        public Ponto(int cX, int cY, Color qualCor)
        {
            this.x = cX;
            this.y = cY;
            this.cor = qualCor;
        }

        public int X
        {
            get { return x; }
            set 
            {
                if(value >= 0)
                {
                    x = value;
                }
                else
                {
                    throw new Exception("O valor de X não pode ser negativo");
                }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
               if(value >= 0)
                {
                    y = value;
                }
                else
                {
                    throw new Exception("O valor de Y não pode ser negativo");
                }
            }
                
        }
        public Color Cor
        {
            get { return cor; }
            set { cor = value; }
        }


        public virtual void Desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor); // a espessura padrão da caneta é '1'
            g.DrawEllipse(pen, x, y, 10, 10); 
        }

        public virtual void Desenhar(Color cor, Graphics g, int width)
        {
            Pen pen = new Pen(cor, width); //espessura custom, vai ser usado na hora de selecionar a figura
            g.DrawEllipse(pen, x, y, 10, 10);
        }

        public int CompareTo(Ponto other)
        {
            int diferencaX = X - other.X;
            if (diferencaX == 0)
                return Y - other.Y;
            return diferencaX;
        }

        public String transformaString(int valor, int quantasPosicoes)
        {
            String cadeia = valor + "";
            while (cadeia.Length < quantasPosicoes)
                cadeia = "0" + cadeia;
            return cadeia.Substring(0, quantasPosicoes); // corta, se necessário, para
                                                         // tamanho máximo
        }
        public String transformaString(String valor, int quantasPosicoes)
        {
            String cadeia = valor + "";
            while (cadeia.Length < quantasPosicoes)
                cadeia = cadeia + " ";
            return cadeia.Substring(0, quantasPosicoes); // corta, se necessário, para
                                                         // tamanho máximo
        }
        public override String ToString()
        {
            return transformaString("p", 5) +
            transformaString(X, 5) +
            transformaString(Y, 5) +
            transformaString(Cor.R, 5) +
            transformaString(Cor.G, 5) +
            transformaString(Cor.B, 5);
        }
    }
}
