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
    private Vector2 velocity;
    private Vector2 acceleration;
    private Texture2D[] sprites;
    private WeaponPouch weaponPouch;
    private int ammo;
    private int health;


    public Player(Rectangle rectangle, Texture2D[] sprites, WeaponPouch weaponPouch, int ammo, int health)
    {
      this.rectangle = rectangle;
      this.velocity = new Vector2(0, 0);
      this.acceleration = new Vector2(0, 0);
      this.sprites = sprites;
      this.weaponPouch = weaponPouch;
      this.ammo = ammo;
      this.health = health;
    }

    public void AddEntity(Level level)
    {
      throw new NotImplementedException();
    }

    public void RemoveEntity()
    {
      throw new NotImplementedException();
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spritebatch)
    {
      throw new NotImplementedException();
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

    //Experimental Move Class
    //Implementing a Move Class to make movement actions more clear and simple

    public class Move
    {
      Player player;
      private float X;
      private float Y;
      private Vector2 MaxSpeedX;
      private Vector2 MaxSpeedY;
      private Point CurrentPosition;

      public void GetCurrentPosition()
      {

        CurrentPosition = player.rectangle.Location;
      }

      public void Jump() // Player jumps 20 pixels
      {
        GetCurrentPosition();
        for (int i = 0; i <= 20; i = i + 1)
        {
          CurrentPosition.Y = CurrentPosition.Y - 1;
          player.rectangle.Y = CurrentPosition.Y;

        }
      }

      public void Left() // Player walks left 10 pixels
      {
        GetCurrentPosition();
        for (int i = 0; i <= 10; i = i + 1)
        {
          CurrentPosition.X = CurrentPosition.X - 1;
          player.rectangle.X = CurrentPosition.X;
        }

      }

      public void Right() // Player walks right 10 pixels
      {
        GetCurrentPosition();
        for (int i = 0; i <= 10; i = i + 1)
        {
          CurrentPosition.X = CurrentPosition.X + 1;
          player.rectangle.X = CurrentPosition.X;
        }

      }



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
  }
}
