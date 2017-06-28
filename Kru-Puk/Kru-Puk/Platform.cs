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
    private Rectangle collisionRectangle;
    public Rectangle rectangle;

    public Platform(Texture2D sprite, Rectangle rectangle, Rectangle collisionRectangle)
    {
      this.sprite = sprite;
      this.rectangle = rectangle;
      this.collisionRectangle = collisionRectangle;
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
      Point[] puntenarray2 = new Point[] { new Point { X = this.collisionRectangle.X, Y = this.collisionRectangle.Y }, new Point { X = (this.collisionRectangle.X + this.collisionRectangle.Width), Y = this.collisionRectangle.Y }, new Point { X = (this.collisionRectangle.X), Y = (this.collisionRectangle.Y + this.collisionRectangle.Height) }, new Point { X = (this.collisionRectangle.X + this.collisionRectangle.Width), Y = (this.collisionRectangle.Y + this.collisionRectangle.Height) } };
      foreach (Point punt in puntenarray)
      {
        if (this.collisionRectangle.Contains(punt))
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
