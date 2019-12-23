#define CG_Gizmo
#define CG_Privado

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;

namespace gcgcg
{
  class Mundo : GameWindow
  {
    private static Mundo instanciaMundo = null;

    private Mundo(int width, int height) : base(width, height) { }

    public static Mundo GetInstance(int width, int height)
    {
      if (instanciaMundo == null)
        instanciaMundo = new Mundo(width, height);
      return instanciaMundo;
    }

    private CameraPerspective camera = new CameraPerspective();
    private CuboMagico CuboMagico = null;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");

      CuboMagico = new CuboMagico("F", null);
      CuboMagico.TamanhoCuboMagico = 9;
      CuboMagico.EscalaXYZ(50, 50, 50);

      PresetCamera1();

      GL.ClearColor(Color.Gray);
      GL.Enable(EnableCap.DepthTest);
      GL.Enable(EnableCap.CullFace);
    }
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

      Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(camera.Fovy, Width / (float)Height, camera.Near, camera.Far);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadMatrix(ref projection);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      Matrix4 modelview = Matrix4.LookAt(camera.Eye, camera.At, camera.Up);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadMatrix(ref modelview);
      CuboMagico.Desenhar();
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (CuboMagico != null)
      {
        if (e.Key == Key.M)
          CuboMagico.ExibeMatriz();
        else if (e.Key == Key.P)
          CuboMagico.PontosExibirObjeto();
        else if (e.Key == Key.PageUp)
          CuboMagico.EscalaXYZ(2, 2, 2);
        else if (e.Key == Key.PageDown)
          CuboMagico.EscalaXYZ(0.5, 0.5, 0.5);
        else if (e.Key == Key.X)
          CuboMagico.TrocaEixoRotacao('x');
        else if (e.Key == Key.Y)
          CuboMagico.TrocaEixoRotacao('y');
        else if (e.Key == Key.Z)
          CuboMagico.TrocaEixoRotacao('z');
        else if (e.Key == Key.O)
          CuboMagico.SelecionarProximaJogada();
        else if (e.Key == Key.Space)
          CuboMagico.Embaralhar();
        else if (e.Key == Key.Right)
          Animacao.Executar(10, CuboMagico);
        else if (e.Key == Key.Left)
          Animacao.Executar(-10, CuboMagico);
        else if (e.Key == Key.Up)
          Animacao.Executar(10, CuboMagico);
        else if (e.Key == Key.Down)
          Animacao.Executar(-10, CuboMagico);
        else if (e.Key == Key.Number1)
          PresetCamera1();
        else if (e.Key == Key.Number2)
          PresetCamera2();
        else if (e.Key == Key.Number3)
          PresetCamera3();
        else if (e.Key == Key.Number4)
          PresetCamera4();
        else if (e.Key == Key.Number5)
          PresetCamera5();
        else if (e.Key == Key.Number6)
          PresetCamera6();
        else if (e.Key == Key.Number7)
          PresetCamera7();
        else if (e.Key == Key.U)
          CuboMagico.SelecionarFace(0, 'y');
        else if (e.Key == Key.L)
          CuboMagico.SelecionarFace(0, 'x');
        else if (e.Key == Key.F)
          CuboMagico.SelecionarFace(0, 'z');
        else if (e.Key == Key.R)
          CuboMagico.SelecionarFace(2, 'x');
        else if (e.Key == Key.B)
          CuboMagico.SelecionarFace(2, 'z');
        else if (e.Key == Key.D)
          CuboMagico.SelecionarFace(2, 'y');
        else
          Console.WriteLine(" __ Tecla não implementada.");
      }
      else
        Console.WriteLine("Cubo Magico está 'nulo'.");
    }

    private void PresetCamera1() {
      camera.At = new Vector3(0, 0, 0);
      camera.Eye = new Vector3(1000, 1000, 1000);
      camera.Near = 100.0f;
      camera.Far = 20000000.0f;
    }

    private void PresetCamera2() {
      camera.Eye = new Vector3(0, 0, 1000);
    }

    private void PresetCamera3() {
      camera.Eye = new Vector3(-1000, 0, 0); 
    }

    private void PresetCamera4() {
      camera.Eye = new Vector3(1000, 0, 0); 
    }

    private void PresetCamera5() {
      camera.Eye = new Vector3(0, 0, -1000); 
    }

    private void PresetCamera6() {
      camera.Eye = new Vector3(0, 1000, 1); 
    }

    private void PresetCamera7() {
      camera.Eye = new Vector3(0, -1000, 1); 
    }

  }
  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG-N4";
      window.Run(1.0 / 60.0);
    }
  }
}
