using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    class Retangulo : Ponto
    {
        private int w, h; //width, height
        public Retangulo(int cX, int cY, int w, int h, Color qualCor) : base(cX, cY, qualCor)
        {
            this.w = w;
            this.h = h;
        }

        public int W 
        { 
            get => w; 
            set => w = value; 
        }
        public int H 
        { 
            get => h; 
            set => h = value; 
        }

        public override void Desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawRectangle(pen, base.X, base.Y, w, h);
        }
        public override void Desenhar(Color cor, Graphics g, int width)
        {
            Pen pen = new Pen(cor, width);
            g.DrawRectangle(pen, base.X, base.Y, w, h);
        }

        public override String ToString()
        {
            return transformaString("r", 5) +
            transformaString(X, 5) +
            transformaString(Y, 5) +
            transformaString(Cor.R, 5) +
            transformaString(Cor.G, 5) +
            transformaString(Cor.B, 5) +
            transformaString(w, 5) +
            transformaString(h, 5);
        }

    }
}
