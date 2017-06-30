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
    private Point velocity;
    private Texture2D sprite;
    private int damage;
    private Level level;
    private DrawingAdapter drawingAdapter;

    public Projectile(Rectangle rectangle, Point velocity, Texture2D sprite, int damage)
    {
      this.rectangle = rectangle;
      this.velocity = velocity;
      this.sprite = sprite;
      this.damage = damage;
      this.drawingAdapter = new DrawingAdapter();
    }

    public void AddEntity(Level level)
    {
      this.level = level;
      level.AddEntity(this);
    }

    public void TakeDamage(int damage)
    {
    }

    public void DoDamage(IEntity entity)
    {
      entity.TakeDamage(this.damage);
    }

    public Point getPosition()
    {
      return rectangle.Location;
    }

    public void Update(float dt)
    {
      foreach (IEntity entity in level.GetEntities())
      {
        if (entity.Intersect(this.rectangle) && entity is IZombie)
        {
          //check voor elke zombie of de kogel in range is
          this.DoDamage(entity);
          this.RemoveEntity();
          break;
        }
      }
      foreach (Platform platform in level.GetPlatforms())
      {
        if (platform.Intersect(this.rectangle))
        {
          RemoveEntity();
        }
      }
      this.rectangle.Location = rectangle.Location + velocity;
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

    public void RemoveEntity()
    {
      level.RemoveEntity(this);
    }

    public void SetFollowingObject(IEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}
