using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class Projectile : IEntity
  {
    private Rectangle rectangle;
    private Vector2 velocity;
    private Vector2 direction;
    private Texture2D sprite;
    private int damage;
    private Level level;
    private DrawingAdapter drawingAdapter;

    public Projectile(Rectangle rectangle, Vector2 velocity, Vector2 direction, Texture2D sprite, int damage)
    {
      this.rectangle = rectangle;
      this.velocity = velocity;
      this.direction = direction;
      this.sprite = sprite;
      this.damage = damage;
    }

    public void AddEntity()
    {
      level.AddEntity(this);
    }

    public void TakeDamage(int damage)
    {
      throw new NotImplementedException();
    }

    public void DoDamage()
    {
      foreach (IEntity entity in level.GetEntities())
      {
        //check voor elke zombie of de kogel in range is
        //if (entity.GetType() == )
        //{

        //}
      }
      throw new NotImplementedException();
    }

    public Point getPosition()
    {
      return rectangle.Location;
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spritebatch)
    {
      //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
      bool flipped = true;
      drawingAdapter.Draw(spritebatch, sprite, rectangle.Location, flipped);
    }

    public bool Intersect(Rectangle rectangle)
    {
      //x > x && x < x + w;
      //y > y && y < y + h;
      Point[] puntenarray = new Point[] { new Point { X = rectangle.X, Y = rectangle.Y }, new Point { X = (rectangle.X + rectangle.Width), Y = rectangle.Y }, new Point { X = (rectangle.X), Y = (rectangle.Y + rectangle.Height) }, new Point { X = (rectangle.X + rectangle.Width), Y = (rectangle.Y + rectangle.Height) } };
      foreach (Point punt in puntenarray)
      {
        if (this.rectangle.Contains(punt))
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      throw new NotImplementedException();
    }

    public void RemoveEntity()
    {
      level.RemoveEntity(this);
    }
  }
}
