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

        public int InicialX 
        {
            get { return base.X; } 
            set { base.X = value; } 
        }
        public int InicialY
        {
            get { return base.Y; }
            set { base.Y = value; }
        }
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
    }
}
