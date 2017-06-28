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
    private Point velocity;
    private Vector2 acceleration;
    private int health;
    private int damage;
    private bool attacking;
    private SpriteIterator animationWalking;
    private SpriteIterator animationWalkingDamaged;
    private SpriteIterator animationAttacking;
    private SpriteIterator animationAttackingDamaged;
    private DrawingAdapter drawingadapter;
    private Level level;
    private bool isFloating;

    public AIZombie(Rectangle rectangle, int health, int damage, Texture2D[][] animations)
    {
      this.rectangle = rectangle;
      this.velocity = new Point(0,0);
      this.acceleration = new Vector2(0, 0);
      this.health = health;
      this.damage = damage;
      this.attacking = false;
      this.animationWalking = new SpriteIterator(animations[0], 15);
      this.animationWalkingDamaged = new SpriteIterator(animations[1], 15);
      this.animationAttacking = new SpriteIterator(animations[2], 15);
      this.animationAttackingDamaged = new SpriteIterator(animations[3], 15);
      this.drawingadapter = new DrawingAdapter();
      this.isFloating = true;
    }

    public void Move()
    {
      //Point random = new Point(0, 0);
      if (followingObject.getPosition().X > rectangle.X)
      {
        this.velocity.X = 2;// = new Point (2, 0); 
      }
      else if (followingObject.getPosition().X < rectangle.X)
      {
        this.velocity.X = - 2;// = new Point(-2, 0);
      }
      else
      {
        this.velocity.X = 0;// = new Point(0, 0);
      }

      if (isFloating)
      {
        velocity.Y = 15 ;
      }
      foreach(Platform platform in level.GetPlatforms())
      {
        Rectangle nextFrame = new Rectangle(this.rectangle.X + velocity.X, this.rectangle.Y + velocity.Y, this.rectangle.Width, this.rectangle.Height);
        if (platform.Intersect(nextFrame))
        {
          isFloating = false;
        }
        else
        {
          isFloating = true;
        }
      }

      if (rectangle.Y + rectangle.Height >= 720)
      {
        isFloating = false;
      }

      if (!isFloating)
      {
        velocity.Y = 0;
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
        if (timer > 40)
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
          rectangle.Location = rectangle.Location + velocity;
          
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

      Texture2D sprite;
      if (health > 10)
      {
        if (attacking)
        {
          sprite = animationAttacking.GetNext();
        }
        else
        {
          sprite = animationWalking.GetNext();
        }
      }
      else
      {
        if (attacking)
        {
          sprite = animationAttackingDamaged.GetNext();
        }
        else
        {
          sprite = animationWalkingDamaged.GetNext();
        }
      }
      drawingadapter.Draw(spritebatch, sprite, rectangle.Location, flipped); 
    }
  }
}
