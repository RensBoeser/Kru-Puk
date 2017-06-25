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
    private Texture2D[] sprites;
    private Asset[] assets;
    private DrawingAdapter drawingAdapter;

    public Area(Rectangle rectangle, Texture2D[] sprites, Asset[] assets)
    {
      this.rectangle  = rectangle;
      this.discovered = false;
      this.sprites    = sprites;
      this.assets     = assets;
            
      for(int i = 0; i < assets.Length; i = i + 1)
      {
        assets[i].SetRelativePosition(this.rectangle.Location);
      }
        
    }

    public void Discover()
    {
      throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spritebatch)
    {      
      if(discovered)
      {
        drawingAdapter.Draw(spritebatch, sprites[1], rectangle.Location, false);
        
        for (int i = 0; i < assets.Length; i = i + 1)
        {
          assets[i].Draw(spritebatch);
        }
      }
      else
      {
        drawingAdapter.Draw(spritebatch, sprites[0], rectangle.Location, false);
      }
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }
  }
}
