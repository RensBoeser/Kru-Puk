﻿using System;
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
    private Point Position;
    private Vector2 Velocity;
    private Vector2 Acceleration;
    private int Health;
    // private ??? Pick-up;
    private int Damage;
    private bool Attacking;
    private bool Idle;
    private SpriteIterator animationWalking;
    private int Width;
    private int Height;
    private DrawingAdapter drawingadapter;

    public AIZombie(Point Position, int Health, int Damage, Texture2D[] animationWalking, int Width, int Height)
    {
      // this.FollowingObject = FollowingObject;
      this.Position = Position;
      this.Velocity = new Vector2(0, 0);
      this.Acceleration = new Vector2(0, 0);
      this.Health = Health;
      // this.Pick-up = Pick-up;
      this.Damage = Damage;
      this.Attacking = false;
      this.Idle = true;
      this.animationWalking = new SpriteIterator(animationWalking);
      this.Width = Width;
      this.Height = Height;
    }

    public void Move()
    {
      throw new NotImplementedException();
    }

    public void StartAttack()
    {
      throw new NotImplementedException();
    }

    public void Die()
    {
      throw new NotImplementedException();
    }

    public void FindOject()
    {
      throw new NotImplementedException();
    }

    public void ChangeObject()
    {
      throw new NotImplementedException();
    }

    public void Attack()
    {
      throw new NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
      throw new NotImplementedException();
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
      //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
      bool flipped = true;
      Texture2D sprite = animationWalking.GetNext();
      drawingadapter.Draw(spritebatch, sprite, Position, flipped);
    }
  }
}
