using System;
using CG_Biblioteca;


namespace gcgcg
{
  internal class CorCubo
  {
      private const int _incremento = 100;
      
      public Cor Frente { get; set; }
      public Cor Fundo { get; set; }
      public Cor Cima { get; set; }
      public Cor Baixo { get; set; }
      public Cor Esquerda { get; set; }
      public Cor Direita { get; set; }

      private Cor verde;
      private Cor azul;
      private Cor branco;
      private Cor amarelo;
      private Cor laranja;
      private Cor vermelho;

      public CorCubo() {
        verde = new Cor(0, 255, 0);
        azul = new Cor(0, 0, 255);
        branco = new Cor(255, 255, 255);
        amarelo = new Cor(255, 255, 0);
        laranja = new Cor(255, 165, 0);
        vermelho = new Cor(255, 0, 0);

        SetPadrao();
      }

      public void SetCorGlobal(Cor cor) {
        Frente = cor;
        Fundo = cor;
        Cima = cor;
        Baixo = cor;
        Esquerda = cor;
        Direita = cor;
      }

      public void SetPadrao() {
        Frente = verde;
        Fundo = azul;
        Cima = branco;
        Baixo = amarelo;
        Esquerda = laranja;
        Direita = vermelho;
      }


      public void SetCorNormal() {
        Frente.Reset();
        Fundo.Reset();
        Cima.Reset();
        Baixo.Reset();
        Esquerda.Reset();
        Direita.Reset();
      }

      public void SetCorSelecionado() {
        verde.SetRGB(60, 195, 60);
        azul.SetRGB(60, 60, 195);
        branco.SetRGB(195, 195, 195);
        amarelo.SetRGB(195, 195, 60);
        laranja.SetRGB(255, 200, 0);
        vermelho.SetRGB(195, 60, 60);
      }


      public void Rotacionar(char eixo, bool horario)
      {
        var clone = (CorCubo) this.MemberwiseClone();

        if (eixo == 'x')
        {
          if (horario)
          {
            this.Frente = clone.Baixo;
            this.Baixo = clone.Fundo;
            this.Fundo = clone.Cima;
            this.Cima = clone.Frente;
          }
          else
          {
            this.Frente = clone.Cima;
            this.Baixo = clone.Frente;
            this.Fundo = clone.Baixo;
            this.Cima = clone.Fundo;
          }
        }
        else if (eixo == 'y')
        {
          if (horario)
          {
            this.Frente = clone.Direita;
            this.Esquerda = clone.Frente;
            this.Fundo = clone.Esquerda;
            this.Direita = clone.Fundo;
          }
          else
          {
            this.Frente = clone.Esquerda;
            this.Esquerda = clone.Fundo;
            this.Fundo = clone.Direita;
            this.Direita = clone.Frente;
          }
        }
        else if (eixo == 'z')
        {
          if (horario) 
          {
            this.Cima = clone.Esquerda;
            this.Direita = clone.Cima;
            this.Baixo = clone.Direita;
            this.Esquerda = clone.Baixo;
          }
          else
          {
            this.Cima = clone.Direita;
            this.Direita = clone.Baixo;
            this.Baixo = clone.Esquerda;
            this.Esquerda = clone.Cima;
          }
        }
      }

      public void GerarCorParaCubo(Ponto4D ponto)
        {
            var cinza = new Cor(106, 106, 106);
            if (ponto.X < 0)
            {
                Direita = cinza;
            }
            if (ponto.X == 0)
            {
                Esquerda = cinza;
                Direita = cinza;
            }
            if (ponto.X > 0)
            {
                Esquerda = cinza;
            }
            if (ponto.Y < 0)
            {
                Cima = cinza;
            }
            if (ponto.Y == 0)
            {
                Cima = cinza;
                Baixo = cinza;
            }
            if (ponto.Y > 0)
            {
                Baixo = cinza;
            }
            if (ponto.Z < 0)
            {
                Frente = cinza;
            }
            if (ponto.Z == 0)
            {
                Frente = cinza;
                Fundo = cinza;
            }
            if (ponto.Z > 0)
            {
                Fundo = cinza;
            }

        }

  }
}