using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class LevelIterator : IIterator<IOption<Level>>
  {
    private Level[] levels;
    private int current;
    public LevelIterator(Level[] levels)
    {
      this.levels = levels;
      this.current = 0;
    }

    public IOption<Level> GetNext()
    {
      current = current + 1;
      if (current >= levels.Length)
      {
        return new None<Level>();
      }
      else
      {
        return new Some<Level>(levels[current]);
      }
    }

    public void Reset()
    {
      current = 0;
    }

    public IOption<Level> GetCurrent()
    {
      if (current >= levels.Length)
      {
        return new None<Level>();
      }
      else
      {
        return new Some<Level>(levels[current]);
      }
    }
  }
}

