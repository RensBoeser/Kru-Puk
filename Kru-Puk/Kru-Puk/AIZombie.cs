using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class AIZombie : IZombie //InterfaceNotImplemented
  {
    private IEntity followingObject;
    private Point position;
    private Vector2 velocity;
    private Vector2 acceleration;
    private int health;
    // private ??? Pick-up;
    private int damage;
    private bool attacking;
    private bool idle;
    private SpriteIterator animationWalking;
    private int width;
    private int height;
    private DrawingAdapter drawingadapter;
    private Level level;

    public AIZombie(Point position, int health, int damage, Texture2D[] animationWalking, int width, int height, Level level)
    {
      // this.FollowingObject = FollowingObject;
      this.position = position;
      this.velocity = new Vector2(0, 0);
      this.acceleration = new Vector2(0, 0);
      this.health = health;
      // this.Pick-up = Pick-up;
      this.damage = damage;
      this.attacking = false;
      this.idle = true;
      this.animationWalking = new SpriteIterator(animationWalking);
      this.width = width;
      this.height = height;
      this.level = level;
    }

    public void Move()
    {
      if (followingObject.getPosition().X > this.position.X)
      {
        this.velocity = new Vector2 (4,0); 
      }
      if (followingObject.getPosition().X > this.position.X)
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

    public bool Intersect(int x, int y, int w, int h)
    {
      //x > x && x < x + w;
      //y > y && y < y + h;
      Point[] puntenarray = new Point[] { new Point { X = x, Y = y }, new Point { X = (x + w), Y = y }, new Point { X = (x), Y = (y + h) }, new Point { X = (x + w), Y = (y + h) } };
      foreach (Point punt in puntenarray)
      {
        Rectangle box = new Rectangle(this.position, new Point(this.width, this.height));
        if (box.Contains(punt)){
          return true;
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
      return position;
    }

    public void Update(float dt)
    {
      position.X = position.X + (int)velocity.X;
      position.Y = position.Y + (int)velocity.Y;
    }

    public void Draw(SpriteBatch spritebatch)
    {
      //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
      bool flipped = true;
      Texture2D sprite = animationWalking.GetNext();
      drawingadapter.Draw(spritebatch, sprite, position, flipped);
    }
  }
}
