using System;
using System.Drawing;

namespace Grafico
{
    class Polilinha : Ponto
    {
        private static ListaSimples<Ponto> pontos;

        public Polilinha(int cX, int cY, Color qualCor) : base(cX, cY, qualCor)
        {
            pontos = new ListaSimples<Ponto>();
        }

        public void AdicionarPonto(Ponto p1) // Para proteger a lista de pontos, e não deixar o usuário fazer besteira
        {
            pontos.InserirAposFim(p1);
        }

        public override void Desenhar(Color corDesenho, Graphics g) => Desenhar(corDesenho, g, 1);

        public override void Desenhar(Color corDesenho, Graphics g, int width)
        {
            int cordX = base.X;
            int cordY = base.Y;

            Pen pen = new Pen(corDesenho, width);
            pontos.IniciarPercursoSequencial();
            while (pontos.PodePercorrer())
            {
                Ponto p = pontos.Atual.Info;
                g.DrawLine(pen, p.X, p.Y, cordX, cordY);

                cordX = p.X;
                cordY = p.Y;
            }
        }

        public override String ToString()
        {
            string finalToString = "";

            pontos.IniciarPercursoSequencial();
            while (pontos.PodePercorrer())
            {

                finalToString += transformaString("m", 5) +
                    transformaString(pontos.Atual.Info.X, 5) +
                    transformaString(pontos.Atual.Info.Y, 5) +
                    transformaString(Cor.R, 5) +
                    transformaString(Cor.G, 5) +
                    transformaString(Cor.B, 5);
                if (pontos.Atual.Prox != null)
                {
                    finalToString += '\n';
                }

            }
            finalToString.Trim();

            return finalToString;

        }
    }
}
