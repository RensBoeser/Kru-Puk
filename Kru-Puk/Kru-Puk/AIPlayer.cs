using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class AIPlayer : IEntity
  {
    private Vector2 velocity;
    private Vector2 acceleration;
    private Rectangle rectangle;
    private int health;
    private int damage;
    private Texture2D sprite;
    private Level level;
    private SpriteIterator animationWalking;
    private DrawingAdapter drawingAdapter;

    public AIPlayer(Rectangle rectangle, int health, int damage, Texture2D sprite)
    {
      this.velocity = new Vector2(0, 0);
      this.acceleration = new Vector2(0, 0);
      this.rectangle = rectangle;
      this.health = health;
      this.damage = damage;
      this.sprite = sprite;
    }
    
    public void Move()
    {
        
    }

    public void AddEntity()
    {
      level.AddEntity(this);
    }

    public void RemoveEntity()
    {
      level.RemoveEntity(this);
    }

    public void Update(float dt)
    {
    }

    public void Draw(SpriteBatch spritebatch)
    {
      //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
      bool flipped = true;
      Texture2D sprite = animationWalking.GetNext();
      drawingAdapter.Draw(spritebatch, sprite, rectangle.Location, flipped);
    }

    public void TakeDamage(int damage)
    {
        this.health = (health - damage);
    }

    public void DoDamage(IEntity entity)
    {
        throw new NotImplementedException();
    }

    public Point getPosition()
    {
        return rectangle.Location;
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
  }
}
