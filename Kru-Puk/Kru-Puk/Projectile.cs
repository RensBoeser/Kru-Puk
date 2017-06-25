using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class Projectile : IEntity
  {
    private Rectangle rectangle;
    private Vector2 velocity;
    private Vector2 direction;
    private Texture2D sprite;
    private int damage;

    Projectile(Rectangle rectangle, Vector2 velocity, Vector2 direction, Texture2D sprite, int damage)
    {
      this.rectangle = rectangle;
      this.velocity = velocity;
      this.direction = direction;
      this.sprite = sprite;
      this.damage = damage;
    }

    public void AddEntity()
    {
      throw new NotImplementedException();
    }

    public void RemoveEntity()
    {
      throw new NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
      throw new NotImplementedException();
    }

    public void DoDamage()
    {
      throw new NotImplementedException();
    }

    public Point getPosition()
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

    public bool Intersect(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }
}
