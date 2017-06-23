using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class Stairs : IStairs //InterfaceNotImplemented
  {
    private ??? State;
    private Tuple<float, float> Position;
    private Texture2D Sprite;

    public Stairs(??? State, Tuple<float,float> Position, Texture2D Sprite)
    {
      this.State = State;
      this.Position = Position;
      this.Sprite = Sprite;
    }
  }
}
