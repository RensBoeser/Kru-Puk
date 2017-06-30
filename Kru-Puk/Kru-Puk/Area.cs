using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  class Area : IArea
  {
    private Rectangle rectangle;
    private bool discovered;
    private SpriteIterator sprite;
    private Asset[] assets;
    private DrawingAdapter drawingAdapter;
    private IEntity[] spawnableEntities;
    private Platform[] platforms;

    public Area(Rectangle rectangle, Texture2D[] sprites, Asset[] assets, IEntity[] spawnableEntities, Platform[] platforms)
    {
      this.rectangle  = rectangle;
      this.discovered = false;
      this.sprite    = new SpriteIterator(sprites, 1);
      this.assets     = assets;
      this.spawnableEntities = spawnableEntities;
      this.platforms = platforms;
      this.drawingAdapter = new DrawingAdapter();
      
            
      for(int i = 0; i < assets.Length; i = i + 1)
      {
        assets[i].SetRelativePosition(this.rectangle.Location);
      }
        
    }

    public void Discover(Level level)
    {
      foreach (IEntity entity in spawnableEntities)
      {
        entity.AddEntity(level);
      }

      sprite.GetNext();

    }

    public Platform[] GetPlatforms()
    {
      return platforms;
    }

    public void Draw(SpriteBatch spritebatch)
    {      
      if(discovered)
      {
        drawingAdapter.Draw(spritebatch, sprite.GetCurrent(), rectangle.Location, false);
        
        for (int i = 0; i < assets.Length; i = i + 1)
        {
          assets[i].Draw(spritebatch);
        }
      }
      else
      {
        drawingAdapter.Draw(spritebatch, sprite.GetCurrent(), rectangle.Location, false);
      }
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }
  }
}
