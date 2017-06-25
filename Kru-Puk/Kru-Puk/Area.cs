﻿using System;
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
    private Point Position;
    private int Width;
    private int Height;
    private bool Discovered;
    private Texture2D[] Sprites;
    private Asset[] Assets;

    public Area(Point Position, int Width, int Height, Texture2D[] Sprites, Asset[] Assets)
    {
      this.Position = Position;
      this.Width = Width;
      this.Height = Height;
      this.Discovered = false;
      this.Sprites = Sprites;
      this.Assets = Assets;
            
      for(int i = 0; i < Assets.Length; i = i + 1)
      {
        Assets[i].SetRelativePosition(this.Position);
      }
        
    }

    public void Discover()
    {
      throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spritebatch)
    {      
      for(int i = 0; i < Assets.Length; i = i + 1)
      {
        Assets[i].Draw(spritebatch);
      }
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }
  }

}
