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
    private Level level;
    private SpriteIterator animationWalking;
    private DrawingAdapter drawingadapter;

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
    
    public void Move()
    {
        
    }

    public bool Intersect(int x, int y, int w, int h)
    {
      throw new NotImplementedException();
    }

    public void AddEntity()
    {
      level.AddEntity(this);
    }

    public void RemoveEntity()
    {
      level.RemoveEntity(this);
    }

    public void Update(float dt)
    {
        Position.X = Position.X + (int)Velocity.X;
        Position.Y = Position.Y + (int)Velocity.Y;
    }

    public void Draw(SpriteBatch spritebatch)
    {
        //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
        bool flipped = true;
        Texture2D sprite = animationWalking.GetNext();
        drawingadapter.Draw(spritebatch, sprite, Position, flipped);
    }

    public void TakeDamage(int damage)
    {
        this.Health = (Health - damage);
    }

    public void DoDamage()
    {
        throw new NotImplementedException();
    }

    public Point getPosition()
    {
        return Position;
    }
  }
}
