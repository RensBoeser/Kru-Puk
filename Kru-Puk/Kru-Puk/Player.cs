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

    public void AddEntity()
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

    public void DoDamage()
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
            private float X;
            private float Y;
            private Vector2 MaxSpeedX;
            private Vector2 MaxSpeedY;
            private Tuple<float, float> CurrentPosition;

            

            public void Jump()
            {
                //Get CurrentPosition
                //Change Y from 0 to the max jump height with MaxSpeedY per update.
            }

            public void Left()
            {
                //GetCurrentPosition
                //Change X from 0 to the max walking distance (per called Left()) with MaxSpeedX per update.
            }

            public void Right()
            {
                //GetCurrentPosition
                //Change X from 0 to the max walking distance (per called Right()) with MaxSpeedX per update.
            }



        }

    public bool Intersect(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }

    public bool Intersect(int x, int y, int w, int h)
    {
      throw new NotImplementedException();
    }
  }
}
