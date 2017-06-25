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
        private Tuple<float,float> Position;
        private Vector2 Velocity;
        private Vector2 Direction;
        private Texture2D Sprite;
        private int Damage;
        private int Width;
        private int Height;
        private CollisionGroups Collidables;

        Projectile(Tuple<float,float> Position, Vector2 Velocity, Vector2 Direction, Texture2D Sprite, int Damage, int Width, int Height, CollisionGroups Collidables)
        {
            this.Position = Position;
            this.Velocity = Velocity;
            this.Direction = Direction;
            this.Sprite = Sprite;
            this.Damage = Damage;
            this.Width = Width;
            this.Height = Height;
            this.Collidables = Collidables;
        }

    public bool Intersect(int x, int y, int w, int h)
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
  }
}
