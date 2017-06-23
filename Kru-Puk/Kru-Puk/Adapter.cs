using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class DrawingAdapter
  {
    private SpriteBatch spritebatch;
    public DrawingAdapter(SpriteBatch spritebatch)
    {
      this.spritebatch = spritebatch;
    }
    public void Draw(Texture2D sprite, Point position, bool flipped)
    {
      if (flipped)
      {
        spritebatch.Draw(sprite, position.ToVector2(), null, Color.White, 0.0f, new Vector2(0, 0), 0.0f, SpriteEffects.FlipHorizontally, 0.0f);
      }
      else
      {
        spritebatch.Draw(sprite, position.ToVector2(), null, Color.White, 0.0f, new Vector2(0, 0), 0.0f, SpriteEffects.None, 0.0f);
      }
    }
  }
}
