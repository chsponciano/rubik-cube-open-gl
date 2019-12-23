using System;


namespace gcgcg
{
  internal class Cor
  {
    private float _red;
    public float Red {
        set { this._red = normalizar(value); }
        get { return this._red; }
    }

    private float _green;
    public float Green {
        set { this._green = normalizar(value); }
        get { return this._green; }
    }

    private float _blue;
    public float Blue {
        set { this._blue = normalizar(value); }
        get { return this._blue; }
    }

    private float _originalRed;
    private float _originalGreen;
    private float _originalBlue;

    public Cor(float r, float g, float b) {
        SetRGB(r, g, b);
        this._originalRed = r;
        this._originalGreen = g;
        this._originalBlue = b;
    }

    private float normalizar(float valor) {
        return (float)(valor / 255);
    }

    public void SetRGB(float r, float g, float b) {
        this.Red = r;
        this.Green = g;
        this.Blue = b;
    }

    public void Reset() {
        this.Red = this._originalRed;
        this.Green = this._originalGreen;
        this.Blue = this._originalBlue;
    }
  }
}