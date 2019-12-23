using OpenTK.Graphics.OpenGL;
using System;
using CG_Biblioteca;
using System.Collections.Generic;

namespace gcgcg
{
  internal class SelecaoCubo : ObjetoGeometria
  {
    public List<Cubo> Selecionados { get; set; }
    
    public SelecaoCubo(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {
        Selecionados = new List<Cubo>();
    }

    public bool TemAlgum() {
        return Selecionados.Count > 0;
    }

    protected override void DesenharObjeto()
    {
        foreach (Cubo cubo in Selecionados) {
            cubo.Desenhar();
        }
    }
    
    protected override void PontosExibir() {
      foreach (Cubo cubo in Selecionados) {
        cubo.Exibir();
      }
    }

    public void Exibir() {
      PontosExibir();
    }

  }
}
