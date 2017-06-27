using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class SpriteIterator : IIterator<Texture2D>
  {
    Texture2D[] data;
    int current;
    int timer;
    public SpriteIterator(Texture2D[] data)
    {
      this.data = data;
      this.current = 0;
      this.timer = 0;
    }
    public Texture2D GetNext()
    {
      timer += 1;
      if (timer > 16)
      {
        current += 1;
        timer = 0;
      }
      if(current >= data.Length)
      {
        current = 0;
      }
      return data[current];
    }
  }
}
