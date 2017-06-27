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
    int time;
    public SpriteIterator(Texture2D[] data, int time)
    {
      this.data = data;
      this.current = 0;
      this.timer = 0;
      this.time = time;
    }
    public Texture2D GetNext()
    {
      timer += 1;
      if (timer >= time)
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
