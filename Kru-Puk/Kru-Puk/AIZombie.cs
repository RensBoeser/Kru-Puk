using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class AIZombie : IZombie
  {
    private IEntity followingObject;
    private Rectangle rectangle;
    private Vector2 velocity;
    private Vector2 acceleration;
    private int health;
    // private ??? Pick-up;
    private int damage;
    private bool attacking;
    private bool idle;
    private SpriteIterator animationWalking;
    private DrawingAdapter drawingadapter;
    private Level level;

    public AIZombie(Rectangle rectangle, int health, int damage, Texture2D[] animationWalking, IEntity followingObject, Level level)
    {
      this.followingObject = followingObject;
      this.rectangle = rectangle;
      this.velocity = new Vector2(0, 0);
      this.acceleration = new Vector2(0, 0);
      this.health = health;
      // this.Pick-up = Pick-up;
      this.damage = damage;
      this.attacking = false;
      this.idle = true;
      this.animationWalking = new SpriteIterator(animationWalking);
      this.level = level;
    }

    public void Move()
    {
      if (followingObject.getPosition().X > this.rectangle.X)
      {
        this.velocity = new Vector2 (4,0); 
      }
      if (followingObject.getPosition().X < this.rectangle.X)
      {
        this.velocity = new Vector2(-4, 0);
      }
    }

    public void StartAttack()
    {
      this.attacking = true;
    }

    public void Die()
    {
        this.RemoveEntity();
    }

    public void ChangeObject(IEntity newObject)
    {
      followingObject = newObject;
    }

    public void DoDamage()
    {
      followingObject.TakeDamage(this.damage);
    }

    public void TakeDamage(int damage)
    {
      this.health = (this.health - damage);
    }

    public bool Intersect(Rectangle rectangle)
    {
      //x > x && x < x + w;
      //y > y && y < y + h;
      Point[] puntenarray = new Point[] { new Point { X = rectangle.X, Y = rectangle.Y }, new Point { X = (rectangle.X + rectangle.Width), Y = rectangle.Y }, new Point { X = (rectangle.X), Y = (rectangle.Y + rectangle.Height) }, new Point { X = (rectangle.X + rectangle.Width), Y = (rectangle.Y + rectangle.Height) } };
      foreach (Point punt in puntenarray)
      {
        if (this.rectangle.Contains(punt)){
          return true;
        }
        else
        {
          return false;
        }
      }
      throw new NotImplementedException();
    }

    public void AddEntity()
    {
      level.AddEntity(this);
    }

    public void RemoveEntity()
    {
      level.RemoveEntity(this);
    }

    public Point getPosition()
    {
      return rectangle.Location;
    }

    public void Update(float dt)
    {
    }

    public void Draw(SpriteBatch spritebatch)
    {
      //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
      bool flipped = true;
      Texture2D sprite = animationWalking.GetNext();
      drawingadapter.Draw(spritebatch, sprite, rectangle.Location, flipped);
    }
  }
}
