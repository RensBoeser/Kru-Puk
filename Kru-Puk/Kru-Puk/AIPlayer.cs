using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class AIPlayer : IEntity
  {
    private Vector2 Velocity;
    private Vector2 Acceleration;
    private Tuple<float, float> Position;
    private int Health;
    private int Damage;
    private Texture2D Sprite;
    private int Width;
    private int Height;

    public AIPlayer(Vector2 Velocity, Vector2 Acceleration, Tuple<float, float> Position, int Health, int Damage, Texture2D Sprite, int Width, int Height)
    {
      this.Velocity = Velocity;
      this.Acceleration = Acceleration;
      this.Position = Position;
      this.Health = Health;
      this.Damage = Damage;
      this.Sprite = Sprite;
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
  }
}
