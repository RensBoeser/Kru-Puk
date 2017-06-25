using System;
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
    Texture2D background;
    Texture2D logo;
    Texture2D[] buttontexture;
    SpriteFont font;
    Window window;
    Button[] buttons;
    DrawingAdapter drawingadapter;

    public Menu(Window window, Texture2D logo, Texture2D background, Texture2D[] buttontexture, SpriteFont font)
    {
      this.background = background;
      this.logo = logo;
      this.buttontexture = buttontexture;
      this.font = font;
      this.window = window;

      buttons = new Button[1];
      // Put the buttons here.
      // for putting the buttons in the middle of the screen you can use window.Center to get the exact middle of the screen.
      //                      position        width height                    function when clicked                            sprites     font     label
      buttons[0] = new Button(window.Center(), 100, 40, () => Console.WriteLine("THIS IS DONE WHEN THE BUTTON IS CLICKED"), buttontexture, font, "Testbutton");
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
