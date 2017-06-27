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
    private int timer;
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

    public AIZombie(Rectangle rectangle, int health, int damage, Texture2D[] animationWalking)
    {
      this.rectangle = rectangle;
      this.velocity = new Vector2(0, 0);
      this.acceleration = new Vector2(0, 0);
      this.health = health;
      // this.Pick-up = Pick-up;
      this.damage = damage;
      this.attacking = false;
      this.idle = true;
      this.animationWalking = new SpriteIterator(animationWalking);
      this.drawingadapter = new DrawingAdapter();
      
    }

    public void Move()
    {
      if (followingObject.getPosition().X > this.rectangle.X)
      {
        this.velocity = new Vector2 (1, 0); 
      }
      else if (followingObject.getPosition().X < this.rectangle.X)
      {
        this.velocity = new Vector2(-1, 0);
      }
      else
      {
        this.velocity = new Vector2(0, 0);
      }
    }

    public void StartAttack()
    {
      this.timer = 0;
      this.attacking = true;
    }

    public void Die()
    {
        this.RemoveEntity();
    }

    public void SetFollowingObject(IEntity entity)
    {
      followingObject = entity;
    }

    public void DoDamage(IEntity entity)
    {
      entity.TakeDamage(this.damage);
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

    public void AddEntity(Level level)
    {
      this.level = level;
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
      if (health <= 0)
      {
        Die();
      }
      if (attacking)
      {
        timer = timer + 1;
        Console.WriteLine(timer);
        if (timer > 60)
        {
          attacking = false;
          foreach( IEntity entity in level.GetEntities())
          {
            IEntity thisisme = this;
            if (entity != thisisme)
            {
              if (followingObject.getPosition().X < this.getPosition().X)
              {
                if (entity.Intersect(new Rectangle(this.rectangle.X - this.rectangle.Width, this.rectangle.Y, this.rectangle.Width * 2, this.rectangle.Height)))
                {
                  DoDamage(entity);
                }
              }
              else
              {
                if (entity.Intersect(new Rectangle(this.rectangle.X, this.rectangle.Y, this.rectangle.Width * 2, this.rectangle.Height)))
                {
                  DoDamage(entity);
                }
              }
            }
          }
        }
      }
      else
      {
        if (followingObject.Intersect(this.rectangle))
        {
          StartAttack();
        }
        else
        {
          Move();
          rectangle.X = (int)(rectangle.X + velocity.X);
        }
      }
    }

    public void Draw(SpriteBatch spritebatch)
    {
      bool flipped;
      if (followingObject.getPosition().X < this.getPosition().X)
      {
        flipped = true;
      }
      else
      {
        flipped = false;
      }

      Texture2D sprite = animationWalking.GetNext();
      drawingadapter.Draw(spritebatch, sprite, rectangle.Location, flipped); 
    }
  }
}
