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
    private Point Position;
    private int Health;
    private int Damage;
    private Texture2D Sprite;
    private int Width;
    private int Height;

    public AIPlayer(Point Position, int Health, int Damage, Texture2D Sprite, int Width, int Height)
    {
      this.Velocity = new Vector2(0, 0);
      this.Acceleration = new Vector2(0, 0);
      this.Position = Position;
      this.Health = Health;
      this.Damage = Damage;
      this.Sprite = Sprite;
      this.Width  = Width;
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
