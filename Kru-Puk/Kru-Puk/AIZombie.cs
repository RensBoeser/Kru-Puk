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
    // private ??? FollowingObject;
    private Tuple<float,float> Position;
    private Vector2 Velocity;
    private Vector2 Acceleration;
    private int Health;
    // private ??? Pick-up;
    private int Damage;
    private bool Attacking;
    private bool Idle;
    private Texture2D Sprite;
    private int Width;
    private int Height;

    public AIZombie(Tuple<float, float> Position, Vector2 Velocity, Vector2 Acceleration, int Health, ??? Pick-up, int Damage, bool Attacking, bool Idle, Texture2D Sprite,int Width, int Height)
    {
      // this.FollowingObject = FollowingObject;
      this.Position = Position;
      this.Velocity = Velocity;
      this.Acceleration = Acceleration;
      this.Health = Health;
      // this.Pick-up = Pick-up;
      this.Damage = Damage;
      this.Attacking = Attacking;
      this.Idle = Idle;
      this.Sprite = Sprite;
      this.Width = Width;
      this.Height = Height;
    }
  }
}
