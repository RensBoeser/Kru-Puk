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
    public void Draw(SpriteBatch spritebatch, Texture2D sprite, Point position, bool flipped)
    {
      if (flipped)
      {
        spritebatch.Draw(sprite, position.ToVector2(), null, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 0.0f);
      }
      else
      {
        spritebatch.Draw(sprite, position.ToVector2(), null, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.0f);
      }
    }
    public void DrawString(SpriteBatch spritebatch, SpriteFont font, string text, Point position, Color color)
    {
      spritebatch.DrawString(font, text, position.ToVector2(), color);
    }
  }
}
