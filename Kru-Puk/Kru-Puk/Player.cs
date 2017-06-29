using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class Player : IEntity
  {
    private Rectangle rectangle;
    private Point velocity;
    private SpriteIterator animationWalkingUnarmed;
    private WeaponPouch weaponPouch;
    private int ammo; // In weaponpouch
    private int health;
    private Level level;
    private DrawingAdapter drawingAdapter;
    private bool isFloating;
    private EntityFactory entityFactory;


    public Player(Rectangle rectangle, Texture2D[][] animations, WeaponPouch weaponPouch, int ammo, int health, EntityFactory entityFactory)
    {
      this.rectangle = rectangle;
      this.velocity = new Point(0, 0);
      this.animationWalkingUnarmed = new SpriteIterator(animations[0], 15);
      this.weaponPouch = weaponPouch;
      this.ammo = ammo;
      this.health = health;
      this.drawingAdapter = new DrawingAdapter();
      this.isFloating = true;
      this.entityFactory = entityFactory;
    }

    public void Die()
    {
      RemoveEntity();
    }

    public void AddEntity(Level level)
    {
      this.level = level;
      level.AddPlayer(this);
      rectangle.Location = level.GetSpawnPoint();
    }

    public void RemoveEntity()
    {
      health = 100;
      rectangle.Location = level.GetSpawnPoint();
    }

    public void Update(float dt)
    {
      if (health <= 0)
      {
        Die();
      }
      rectangle.Location = rectangle.Location + velocity;
      Move("");
    }

    public void Draw(SpriteBatch spritebatch)
    {
      drawingAdapter.Draw(spritebatch, animationWalkingUnarmed.GetNext(), rectangle.Location, false);
    }

    public void TakeDamage(int damage)
    {
      this.health = (this.health - damage);
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

    public void SetFollowingObject(IEntity entity)
    {
      throw new NotImplementedException();
    }
    public void Action(string action)
    {
      switch (action)
      {
        case "fire":
          if (flipped)
          {
            weaponPouch.GetWeapon().Use((damage) => level.AddEntity(entityFactory.CreateProjectile(new Rectangle(rectangle.Center, new Point(4, 2)), new Point(-6, 0), damage)));
          }
          else
          {
            weaponPouch.GetWeapon().Use((damage) => level.AddEntity(entityFactory.CreateProjectile(new Rectangle(rectangle.Center, new Point(4, 2)), new Point(6, 0), damage)));
          }
          break;
        case "reload":
          ammo = weaponPouch.GetWeapon().Reload(ammo);
          break;
        case "interact":
          break;
        default:
          break;
      }
    }
    public void Move(string action)
    {
      switch (action)
      {
        case "left":
          velocity.X = -3;
          break;
        case "right":
          velocity.X = 3;
          break;
        case "jump":
          if (!isFloating)
          {
            velocity.Y = velocity.Y - 15;
          }
          break;
        default:
          velocity.X = 0;
          break;
      }

      if (isFloating)
      {
        velocity.Y = 15;
      }

      foreach (Platform platform in level.GetPlatforms())
      {
        Rectangle nextFrame = new Rectangle(this.rectangle.X + velocity.X, this.rectangle.Y + velocity.Y, this.rectangle.Width, this.rectangle.Height);
        if (velocity.Y > 0)
        {
          while (platform.Intersect(nextFrame))
          {
            velocity.Y = velocity.Y - 1;
            nextFrame = new Rectangle(this.rectangle.X + velocity.X, this.rectangle.Y + velocity.Y, rectangle.Width, rectangle.Height);
          }
          isFloating = false;
        }
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
  }
}
