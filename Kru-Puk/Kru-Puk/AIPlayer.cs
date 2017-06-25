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
    private Vector2 velocity;
    private Vector2 acceleration;
    private Rectangle rectangle;
    private int health;
    private int damage;
    private Texture2D sprite;
    private Level level;
    private SpriteIterator animationWalking;
    private DrawingAdapter drawingAdapter;

    public AIPlayer(Rectangle rectangle, int health, int damage, Texture2D sprite)
    {
      this.velocity = new Vector2(0, 0);
      this.acceleration = new Vector2(0, 0);
      this.rectangle = rectangle;
      this.health = health;
      this.damage = damage;
      this.sprite = sprite;
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
    }

    public void Draw(SpriteBatch spritebatch)
    {
      //UNABLE TO SEE IF HE GOES RIGHT OR LEFT
      bool flipped = true;
      Texture2D sprite = animationWalking.GetNext();
      drawingAdapter.Draw(spritebatch, sprite, rectangle.Location, flipped);
    }

    public void TakeDamage(int damage)
    {
        this.health = (health - damage);
    }

    public void DoDamage()
    {
        throw new NotImplementedException();
    }

    public Point getPosition()
    {
        return rectangle.Location;
    }

    public bool Intersect(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }
}
