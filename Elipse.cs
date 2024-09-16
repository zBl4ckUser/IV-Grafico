using System.Drawing;
using System;

namespace Grafico
{
    class Ellipse : Ponto
    {
        int raio0, raio1;
        public Ellipse(int xCentro, int yCentro, int novoRaio0, int novoRaio1, Color novaCor) :
        base(xCentro, yCentro, novaCor) // construtor de Ponto(x,y)
        {
            raio0 = novoRaio0;
            raio1 = novoRaio1;
        }

        public int InicialX
        {
            get { return base.X; }
            set
            {
                if (value >= 0)
                {
                    base.X = value;
                }
                else
                {
                    throw new System.Exception("O valor de X não pode ser negativo");
                }
            }
        }
        public int InicialY
        {
            get { return base.Y; }
            set
            {
                if (value >= 0)
                {
                    base.Y = value;
                }
                else
                {
                    throw new Exception("O valor de Y não pode ser negativo");
                }
            }
        }

        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawEllipse(pen, base.X - raio0, base.Y - raio1, 2* raio0, 2 * raio1);
        }

        public override String ToString()
        {
            return transformaString("e", 5) +
            transformaString(X, 5) +
            transformaString(Y, 5) +
            transformaString(raio0, 5) +
            transformaString(raio1, 5) +
            transformaString(Cor.R, 5) +
            transformaString(Cor.G, 5) +
            transformaString(Cor.B, 5);

        }
    }
}
