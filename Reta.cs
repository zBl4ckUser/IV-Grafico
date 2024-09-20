using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    class Reta : Ponto
    {
        private Ponto pontoFinal;

        
        public int FinalX
        {
            get { return pontoFinal.X; }
            set { pontoFinal.X = value; }
        }
        public int FinalY
        {
            get { return pontoFinal.Y; }
            set { pontoFinal.Y = value; }
        }
        public Reta(int x1, int y1, int x2, int y2, Color novaCor) : base(x1, y1, novaCor)
        {
            pontoFinal = new Ponto(x2, y2, novaCor);
        }
        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawLine(pen, base.X, base.Y, // ponto inicial
            pontoFinal.X, pontoFinal.Y);
        }
        public override void Desenhar(Color corDesenho, Graphics g, int width)
        {
            Pen pen = new Pen(corDesenho, width);
            g.DrawLine(pen, base.X, base.Y, // ponto inicial
            pontoFinal.X, pontoFinal.Y);
        }

        public override String ToString()
        {
            return transformaString("l", 5) +
            transformaString(X, 5) +
            transformaString(Y, 5) +
            transformaString(Cor.R, 5) +
            transformaString(Cor.G, 5) +
            transformaString(Cor.B, 5) +
            transformaString(FinalX, 5) +
            transformaString(FinalY, 5);
        }
    }
}
