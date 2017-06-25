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
        private Point position;
        private Vector2 Velocity;
        private Vector2 Acceleration;
        private Texture2D[] Sprites;
        private WeaponPouch WeaponPouch;
        private int Ammo;
        private int Health;
        private int Width;
        private int Height;
        

        Player(Point position, Vector2 Velocity, Vector2 Acceleration, Texture2D[] Sprites,WeaponPouch WeaponPouch, int Ammo, int Health, int Width, int Height)
        {
            this.position = position;
            this.Velocity = Velocity;
            this.Acceleration = Acceleration;
            this.Sprites = Sprites;
            this.WeaponPouch = WeaponPouch;
            this.Ammo = Ammo;
            this.Health = Health;
            this.Width = Width;
            this.Height = Height;
        }

    public void Intersect(int x, int y, int w, int h)
    {
      throw new NotImplementedException();
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
      this.Health = (this.Health - damage);
    }

    public void DoDamage()
    {
      throw new NotImplementedException();
    }

    public Point getPosition()
    {
      return position;
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

  }
}
