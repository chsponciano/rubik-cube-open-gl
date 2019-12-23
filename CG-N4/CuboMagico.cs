using OpenTK.Graphics.OpenGL;
using System;
using CG_Biblioteca;
using System.Collections.Generic;

namespace gcgcg
{
  internal class CuboMagico : ObjetoGeometria
  {
    private List<char> _VALORES_EIXO = new List<char>{'x', 'y', 'z'};
    private int _contadorAuxiliar = 0;
    private List<Cubo> cubos = new List<Cubo>();
    private float _tamanhoCuboMagico = 3;
    private List<Cubo> Selecionados = new List<Cubo>(9);
    public float TamanhoCuboMagico { 
        get { return _tamanhoCuboMagico; }
        set { 
            _tamanhoCuboMagico = value;
            CriarMatrizCubo();
        }
    }
    private char _eixoSelecionado = 'x';
    public char EixoSelecionado {
        get { return _eixoSelecionado; }
        set { 
            if (value != 'x' && value != 'y' && value != 'z') {
                throw new System.ArgumentException("Eixo \"" + value + "\" é inválido para seleção.");
            } else {
                _eixoSelecionado = value;
            }
        }
    }
    private int _valorEixoSelecionado = 0;
    public int ValorEixoSelecionado {
        get { return _valorEixoSelecionado; }   
        set { 
            if (value < 0 || value > 2) {
                throw new System.ArgumentException("Valor de eixo \"" + value + "\" é inválido para seleção.");
            } else {
                _valorEixoSelecionado = value;
            }
        }
    }


    public CuboMagico(string rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {
        CriarMatrizCubo();
    }

    private void CriarMatrizCubo() {
        var tamanhoCubo = TamanhoCuboMagico / 3;
        cubos = new List<Cubo>();
        var counter = 0;
        for (int i = -2; i < 1; i++) {
            for (int j = -2; j < 1; j++) {
                for (int k = -2; k < 1; k++) {
                    var cubo = new Cubo(counter + ";", this);
                    cubo.PontoReferencia = new Ponto4D((i + 1) * tamanhoCubo, (j + 1) * tamanhoCubo, (k + 1) * tamanhoCubo);
                    cubo.TamanhoFace = tamanhoCubo;
                    cubos.Add(cubo);
                    cubo.AtualizarCor();
                    counter++;
                }
            }
        }
    }

    public void SelecionarProximaJogada() {
        if (AnguloValidoParaTrocarJogada()) {
            
            RotacionarSelecionados();
            SelecionarValoresParaProximaJogada();
            SelecionarCubosProximaJogada();
            AtualizarCorSelecionados();


            _contadorAuxiliar = 0;
        }
    }

    private void SelecionarCubosProximaJogada() {
        if (EixoSelecionado == 'x')
        {
            if (ValorEixoSelecionado == 0)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.X < 0);
            }
            else if (ValorEixoSelecionado == 1)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.X == 0);
            }
            else if (ValorEixoSelecionado == 2)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.X > 0);
            }

        }
        else if (EixoSelecionado == 'y')
        {
            if (ValorEixoSelecionado == 0)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.Y > 0);
            }
            else if (ValorEixoSelecionado == 1)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.Y == 0);
            }
            else if (ValorEixoSelecionado == 2)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.Y < 0);
            }
        }
        else if (EixoSelecionado == 'z')
        {
            if (ValorEixoSelecionado == 0)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.Z > 0);
            }
            else if (ValorEixoSelecionado == 1)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.Z == 0);
            }
            else if (ValorEixoSelecionado == 2)
            {
                Selecionados = cubos.FindAll(cubo => cubo.PontoReferencia.Z < 0);
            }
        }
    }

    private void SelecionarValoresParaProximaJogada() {
        var valorEixoAtual = ValorEixoSelecionado;
        var proximoValorEixo = -1;
        if (valorEixoAtual != 2) {
            proximoValorEixo = valorEixoAtual + 1;
        } else {
            proximoValorEixo = 0;

            var indexEixoAtual = _VALORES_EIXO.IndexOf(EixoSelecionado);
            int indexProximoEixo = -1;
            if (indexEixoAtual != 2) {
                indexProximoEixo = indexEixoAtual + 1;
            } else {
                indexProximoEixo = 0;
            }

            EixoSelecionado = _VALORES_EIXO[indexProximoEixo];
        }

        ValorEixoSelecionado = proximoValorEixo;
    }

    public void SelecionarFace(int valorEixoSelecionado, char eixoSelecionado)
    {
        this.RotacionarSelecionados();
        this.ValorEixoSelecionado = valorEixoSelecionado;
        this.EixoSelecionado = eixoSelecionado;
        this.SelecionarCubosProximaJogada();
        this.AtualizarCorSelecionados();
    }

    public void Rotacionar(int valor) {
        _contadorAuxiliar += valor;
        if (_contadorAuxiliar == 360) {
            _contadorAuxiliar = 0;
        }
        Console.WriteLine("aqui");
        foreach (Cubo cubo in Selecionados) {
            cubo.TrocaEixoRotacao(EixoSelecionado);
            cubo.Rotacao(valor);
        }
    }

    private void RotacionarSelecionados() {
        var nVezes = _contadorAuxiliar / 90;
        bool horario = nVezes < 0;
        // nVezes = horario ? 4 + nVezes : nVezes;
        Console.WriteLine("nVezes: " + nVezes + "; horario: " + horario);
        foreach (var item in Selecionados)
        {
            for (int i = 0; i < Math.Abs(nVezes); i++) {
                item.Rotate(EixoSelecionado, horario);    
            }
            item.CalcularPontos();
            item.AtualizarCor();
            item.AtribuirIdentidade();
        }
    }

    private void AtualizarCorSelecionados() {
        foreach (Cubo cubo in Selecionados) {
            cubo.CorCubo.SetCorSelecionado();
            cubo.CorCubo.GerarCorParaCubo(cubo.PontoReferencia);
        }
    }

    private bool AnguloValidoParaTrocarJogada() {
        var angulo = Math.Abs(_contadorAuxiliar);
        while (angulo > 270) {
            angulo = angulo - 270;
        }
        return angulo == 0 || angulo == 90 || angulo == 180 || angulo == 270;
    }

    public void Embaralhar() {
        CriarMatrizCubo();
        Random rnd = new Random();
        var cs = new List<char>{'x', 'y', 'z'};
        for (int i = 0; i < this.cubos.Count; i++) {
            for (int j = 0; j < rnd.Next(360); j++) {
                this.cubos[i].CorCubo.Rotacionar(cs[rnd.Next(3)], rnd.Next(1) == 1);
            }
        }
        foreach (Cubo cubo in this.cubos) {
            cubo.AtualizarCor();
            cubo.CalcularPontos();
        }
    }

    protected override void DesenharObjeto()
    {
        for (int i = 0; i < cubos.Count; i++) {
            cubos[i].Desenhar();
        }
    }

    protected override void PontosExibir() { }

  }
}
