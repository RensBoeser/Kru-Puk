using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class Platform : IDrawable, IUpdateable
  {
    private Texture2D sprite;
    public Rectangle rectangle;

    public Platform(Texture2D sprite, Rectangle rectangle)
    {
      this.sprite = sprite;
      this.rectangle = rectangle;
    }

    public void Draw(SpriteBatch spritebatch)
    {
      spritebatch.Draw(sprite, rectangle, Color.White);
    }

    public void Update(float dt)
    {
      
    }
    public bool Intersect(Rectangle rectangle)
    {
      //x > x && x < x + w;
      //y > y && y < y + h;   
      Point[] puntenarray = new Point[] { new Point { X = rectangle.X, Y = rectangle.Y }, new Point { X = (rectangle.X + rectangle.Width), Y = rectangle.Y }, new Point { X = (rectangle.X), Y = (rectangle.Y + rectangle.Height) }, new Point { X = (rectangle.X + rectangle.Width), Y = (rectangle.Y + rectangle.Height) } };
      Point[] puntenarray2 = new Point[] { new Point { X = this.rectangle.X, Y = this.rectangle.Y }, new Point { X = (this.rectangle.X + this.rectangle.Width), Y = this.rectangle.Y }, new Point { X = (this.rectangle.X), Y = (this.rectangle.Y + this.rectangle.Height) }, new Point { X = (this.rectangle.X + this.rectangle.Width), Y = (this.rectangle.Y + this.rectangle.Height) } };
      foreach (Point punt in puntenarray)
      {
        if (this.rectangle.Contains(punt))
        {
          return true;
        }
      }
      foreach (Point punt in puntenarray2)
      {
        if (rectangle.Contains(punt))
        {
          return true;
        }
      }
      return false;
    }
  }
}
