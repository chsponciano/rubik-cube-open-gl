using OpenTK.Graphics.OpenGL;
using System;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Cubo : ObjetoGeometria
  {
    private bool exibeVetorNormal = false;
    public CorCubo CorCubo { get; set; }
    public Ponto4D PontoReferencia { get; set; }
    private float _tamanhoFace = 1;
    public float TamanhoFace {
      set { 
        this._tamanhoFace = value;
        this.CalcularPontos();
      }
      get { return this._tamanhoFace; }
    }

    public Cubo(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {      
      CorCubo = new CorCubo();
      PontoReferencia = new Ponto4D(0, 0, 0);
      CalcularPontos();
    }
    
    protected override void DesenharObjeto()
    {
        GL.Begin(PrimitiveType.Quads);
        
        // Face da frente
        GL.Color3(CorCubo.Frente.Red, CorCubo.Frente.Green, CorCubo.Frente.Blue);
        GL.Vertex3(base.pontosLista[0].X + PontoReferencia.X, base.pontosLista[0].Y + PontoReferencia.Y, base.pontosLista[0].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[1].X + PontoReferencia.X, base.pontosLista[1].Y + PontoReferencia.Y, base.pontosLista[1].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[2].X + PontoReferencia.X, base.pontosLista[2].Y + PontoReferencia.Y, base.pontosLista[2].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[3].X + PontoReferencia.X, base.pontosLista[3].Y + PontoReferencia.Y, base.pontosLista[3].Z + PontoReferencia.Z);
     
        // Face do fundo
        GL.Color3(CorCubo.Fundo.Red, CorCubo.Fundo.Green, CorCubo.Fundo.Blue);
        GL.Vertex3(base.pontosLista[4].X + PontoReferencia.X, base.pontosLista[4].Y + PontoReferencia.Y, base.pontosLista[4].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[7].X + PontoReferencia.X, base.pontosLista[7].Y + PontoReferencia.Y, base.pontosLista[7].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[6].X + PontoReferencia.X, base.pontosLista[6].Y + PontoReferencia.Y, base.pontosLista[6].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[5].X + PontoReferencia.X, base.pontosLista[5].Y + PontoReferencia.Y, base.pontosLista[5].Z + PontoReferencia.Z);

        // Face de cima
        GL.Color3(CorCubo.Cima.Red, CorCubo.Cima.Green, CorCubo.Cima.Blue);
        GL.Vertex3(base.pontosLista[3].X + PontoReferencia.X, base.pontosLista[3].Y + PontoReferencia.Y, base.pontosLista[3].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[2].X + PontoReferencia.X, base.pontosLista[2].Y + PontoReferencia.Y, base.pontosLista[2].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[6].X + PontoReferencia.X, base.pontosLista[6].Y + PontoReferencia.Y, base.pontosLista[6].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[7].X + PontoReferencia.X, base.pontosLista[7].Y + PontoReferencia.Y, base.pontosLista[7].Z + PontoReferencia.Z);

        // Face de baixo
        GL.Color3(CorCubo.Baixo.Red, CorCubo.Baixo.Green, CorCubo.Baixo.Blue);
        GL.Vertex3(base.pontosLista[0].X + PontoReferencia.X, base.pontosLista[0].Y + PontoReferencia.Y, base.pontosLista[0].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[4].X + PontoReferencia.X, base.pontosLista[4].Y + PontoReferencia.Y, base.pontosLista[4].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[5].X + PontoReferencia.X, base.pontosLista[5].Y + PontoReferencia.Y, base.pontosLista[5].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[1].X + PontoReferencia.X, base.pontosLista[1].Y + PontoReferencia.Y, base.pontosLista[1].Z + PontoReferencia.Z);

        // Face da direita
        GL.Color3(CorCubo.Direita.Red, CorCubo.Direita.Green, CorCubo.Direita.Blue);
        GL.Vertex3(base.pontosLista[1].X + PontoReferencia.X, base.pontosLista[1].Y + PontoReferencia.Y, base.pontosLista[1].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[5].X + PontoReferencia.X, base.pontosLista[5].Y + PontoReferencia.Y, base.pontosLista[5].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[6].X + PontoReferencia.X, base.pontosLista[6].Y + PontoReferencia.Y, base.pontosLista[6].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[2].X + PontoReferencia.X, base.pontosLista[2].Y + PontoReferencia.Y, base.pontosLista[2].Z + PontoReferencia.Z);

        // Face da esquerda
        GL.Color3(CorCubo.Esquerda.Red, CorCubo.Esquerda.Green, CorCubo.Esquerda.Blue);
        GL.Vertex3(base.pontosLista[0].X + PontoReferencia.X, base.pontosLista[0].Y + PontoReferencia.Y, base.pontosLista[0].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[3].X + PontoReferencia.X, base.pontosLista[3].Y + PontoReferencia.Y, base.pontosLista[3].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[7].X + PontoReferencia.X, base.pontosLista[7].Y + PontoReferencia.Y, base.pontosLista[7].Z + PontoReferencia.Z);
        GL.Vertex3(base.pontosLista[4].X + PontoReferencia.X, base.pontosLista[4].Y + PontoReferencia.Y, base.pontosLista[4].Z + PontoReferencia.Z);
        
        GL.End();

    }

    public void CalcularPontos() {
      base.PontosRemoverTodos();
      // Console.WriteLine("_tamanhoFace = " + _tamanhoFace + "; PontoReferencia = { x = " + PontoReferencia.X + "; y = " + PontoReferencia.Y + "; z = " + PontoReferencia.Z + "; }");
      double x = ((double) _tamanhoFace / 2);
      double y = ((double) _tamanhoFace / 2);
      double z = ((double) _tamanhoFace / 2);
      // Console.WriteLine("x: " + x + "; y = " + y + "; z = " + z + ";" );
      base.PontosAdicionar(new Ponto4D(-x, -y,  z));
      base.PontosAdicionar(new Ponto4D( x, -y,  z));
      base.PontosAdicionar(new Ponto4D( x,  y,  z));
      base.PontosAdicionar(new Ponto4D(-x,  y,  z));
      base.PontosAdicionar(new Ponto4D(-x, -y, -z));
      base.PontosAdicionar(new Ponto4D( x, -y, -z));
      base.PontosAdicionar(new Ponto4D( x,  y, -z));
      base.PontosAdicionar(new Ponto4D(-x,  y, -z));

    }

    public void AtualizarCor() {
      CorCubo.SetCorNormal();
    }

    public void Rotate(char eixoSelecionado, bool horario){
      RotacionarReferencias(eixoSelecionado, horario);
      CorCubo.Rotacionar(eixoSelecionado, horario);
    }

    private void RotacionarReferencias(char eixoSelecionado, bool horario) {
      if (eixoSelecionado == 'x')
      {
          if (horario) //Up
          {
              //Edges
              if (PontoReferencia.Y < 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }
              else if (PontoReferencia.Y < 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }
              else if (PontoReferencia.Y > 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }
              else if (PontoReferencia.Y > 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }

              //Middles
              else if (PontoReferencia.Y == 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Y = PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.Y == 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Y = PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Y;
                  PontoReferencia.Y = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Y;
                  PontoReferencia.Y = 0;
              }
          }
          else //Down
          {
              //Edges
              if (PontoReferencia.Y < 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }
              else if (PontoReferencia.Y < 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }
              else if (PontoReferencia.Y > 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }
              else if (PontoReferencia.Y > 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }

              //Middles
              else if (PontoReferencia.Y == 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.Y == 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.Z = PontoReferencia.Y;
                  PontoReferencia.Y = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.Z = PontoReferencia.Y;
                  PontoReferencia.Y = 0;
              }
          }
      }

      if (eixoSelecionado == 'y')
      {
          if (horario) //Left
          {
              if (PontoReferencia.X < 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }
              else if (PontoReferencia.X < 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }

              //Middle
              else if (PontoReferencia.X == 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.X = -PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.X == 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.X = -PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.X < 0)
              {
                  PontoReferencia.Z = PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.X > 0)
              {
                  PontoReferencia.Z = PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
          }
          else
          {
              if (PontoReferencia.X < 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }
              else if (PontoReferencia.X < 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.Z = -PontoReferencia.Z;
              }

              //Middle
              else if (PontoReferencia.X == 0 && PontoReferencia.Z < 0)
              {
                  PontoReferencia.X = PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.X == 0 && PontoReferencia.Z > 0)
              {
                  PontoReferencia.X = PontoReferencia.Z;
                  PontoReferencia.Z = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.X < 0)
              {
                  PontoReferencia.Z = -PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
              else if (PontoReferencia.Z == 0 && PontoReferencia.X > 0)
              {
                  PontoReferencia.Z = -PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
          }
      }

      if (eixoSelecionado == 'z')
      {
          if (horario)
          {
              if (PontoReferencia.X < 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }
              else if (PontoReferencia.X < 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }

              //Middle
              else if (PontoReferencia.X == 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.X = PontoReferencia.Y;
                  PontoReferencia.Y = 0;
              }
              else if (PontoReferencia.X == 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.X = PontoReferencia.Z;
                  PontoReferencia.Y = 0;
              }
              else if (PontoReferencia.Y == 0 && PontoReferencia.X < 0)
              {
                  PontoReferencia.Y = -PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
              else if (PontoReferencia.Y == 0 && PontoReferencia.X > 0)
              {
                  PontoReferencia.Y = -PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
          }
          else
          {
              if (PontoReferencia.X < 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }
              else if (PontoReferencia.X < 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.Y = -PontoReferencia.Y;
              }
              else if (PontoReferencia.X > 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.X = -PontoReferencia.X;
              }

              //Middle
              else if (PontoReferencia.X == 0 && PontoReferencia.Y < 0)
              {
                  PontoReferencia.X = -PontoReferencia.Y;
                  PontoReferencia.Y = 0;
              }
              else if (PontoReferencia.X == 0 && PontoReferencia.Y > 0)
              {
                  PontoReferencia.X = -PontoReferencia.Z;
                  PontoReferencia.Y = 0;
              }
              else if (PontoReferencia.Y == 0 && PontoReferencia.X < 0)
              {
                  PontoReferencia.Y = PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
              else if (PontoReferencia.Y == 0 && PontoReferencia.X > 0)
              {
                  PontoReferencia.Y = PontoReferencia.X;
                  PontoReferencia.X = 0;
              }
          }
      }
    }
    
    protected override void PontosExibir() {
      base.PontosExibir();
    }

    public void Exibir() {
      PontosExibir();
    }

    public string ToString() {
      var aux = "";
      foreach (Ponto4D ponto in base.pontosLista) {
        aux += ponto.X + ";" + ponto.Y + ";" + ponto.Z + "; /// ";
      }
      return base.rotulo + " /// " + PontoReferencia.X + ";" + PontoReferencia.Y + ";" + PontoReferencia.Z + ";";
    }

  }
}