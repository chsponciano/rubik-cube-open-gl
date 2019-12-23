using OpenTK.Graphics.OpenGL;
using System;
using CG_Biblioteca;
using System.Threading;

namespace gcgcg
{
  internal class Animacao
  {
      private static int tempo = 50;
      private static bool animando = false;
      public static void Executar(int transicao, CuboMagico cubo) 
      {
          if (!animando) 
          {
              animando = true;
              var acao = new Thread(()=> Movimentar(transicao, cubo) );
              acao.Start();
          }
      }

      private static void Movimentar(int transicao, CuboMagico cubo)
      {
          for (int i = 0; i < 9; i++)
          {
              cubo.Rotacionar(transicao);
              Thread.Sleep(tempo);
          }
          
          animando = false;
      }
  }
}