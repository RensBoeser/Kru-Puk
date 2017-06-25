using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Kru_Puk
{
  class Asset : IAsset
  {
    Point position;
    Texture2D sprite;
    public Asset(Point position, Texture2D sprite)
    {
      this.position = position;
      this.sprite = sprite;
    }

    public void SetRelativePosition(Point position)
    {
      this.position.X = this.position.X + position.X;
      this.position.Y = this.position.Y + position.Y;
    }

    public void Draw(SpriteBatch spritebatch)
    {
      throw new NotImplementedException();
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }
  }
}
