﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Kru_Puk
{
  class Menu : IUpdateable, IDrawable
  {
    Main main;
    Texture2D background;
    Texture2D logo;
    SpriteFont font;
    Window window;
    Button[] buttons;
    EntityFactory entityFactory;
    DrawingAdapter drawingadapter;

    public Menu(Main main, Window window, Texture2D logo, Texture2D background, EntityFactory entityFactory, SpriteFont font)
    {
      this.background = background;
      this.main = main;
      this.logo = logo;
      this.font = font;
      this.window = window;
      this.entityFactory = entityFactory;
      this.drawingadapter = new DrawingAdapter();

      buttons = new Button[3];
      // Put the buttons here.
      // for putting the buttons in the middle of the screen you can use window.Center to get the exact middle of the screen.
      buttons[0] = entityFactory.CreateButton(new Rectangle((int)(window.Center().X * 1.25), (int)(window.Center().Y * 0.5), 256, 128), () => main.ToggleMenu(), font, "Start Game");
      buttons[1] = entityFactory.CreateButton(new Rectangle((int)(window.Center().X * 1.25), (int)(window.Center().Y * 0.5) + 128 + 32, 256, 128), () => Console.WriteLine("Continue"), font, "Continue");
      buttons[2] = entityFactory.CreateButton(new Rectangle((int)(window.Center().X * 1.25), (int)(window.Center().Y * 0.5) + 256 + 64, 256, 128), () => Exit(), font, "Exit Game");

      buttons[1].ToggleClickable(); // The continue button is inaccessable due to no saved game.
    }

    public void Exit()
    {
      main.Exit();
    }

    public void Update(float dt)
    {
      foreach (Button button in buttons)
      {
        button.Update(dt);
      }
    }

    public void Draw(SpriteBatch spritebatch)
    {
      drawingadapter.Draw(spritebatch, background, new Point(0, 0), false);
      drawingadapter.Draw(spritebatch, logo, new Point(0, 0), false); // don't know the position yet
      foreach (Button button in buttons)
      {
        button.Draw(spritebatch);
      }
    }
  }
}
