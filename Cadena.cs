// Decompiled with JetBrains decompiler
// Type: MainApp.Cadena
// Assembly: MainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A76AF54-C020-47AD-8D62-E1DA74B99A85
// Assembly location: \\192.168.0.101\Work\1_WamasolTours\WamaProcessor v1.5.1\MainApp.exe

using System;

namespace WamaProcessor
{
  public class Cadena
  {
    public string Name;
    public string[,] Data;
    public int MaxX;
    public string Text;

    public Cadena(string name, int rows, int cols)
    {
      this.Name = name;
      this.Data = new string[rows, cols];
    }

    public void Normalize()
    {
      for (int index = 1; index < this.Data.GetLength(0); ++index)
      {
        for (int val1 = this.Data.GetLength(1) - 1; val1 > 0; --val1)
        {
          if (this.Data[index, val1] != string.Empty && this.Data[index, val1] != null)
          {
            this.MaxX = Math.Max(val1, this.MaxX);
            this.Text = this.Data[index, val1];
          }
        }
      }
      ++this.MaxX;
    }
  }
}
