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
    private Tuple<float, float> Position;
    private Texture2D Sprite;

    public Stairs(Tuple<float,float> Position, Texture2D Sprite)
    {
      this.Position = Position;
      this.Sprite = Sprite;
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spritebatch)
    {
      throw new NotImplementedException();
    }
  }
}
