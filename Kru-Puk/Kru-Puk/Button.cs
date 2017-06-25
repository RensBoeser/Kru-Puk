using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Kru_Puk
{
  class Button : IButton
  {
    private Point position;
    private int width, height;
    private Action function;
    private Texture2D[] sprite;
    private SpriteFont font;
    private string label;
    private DrawingAdapter drawingAdapter;

    public Button(Point position, int width, int height, Action function, Texture2D[] sprite, SpriteFont font, string label)
    {
      this.position = position;
      this.width = width;
      this.height = height;
      this.function = function;
      this.sprite = sprite;
      this.font = font;
      this.label = label;
    }


    public bool OnHover()
    {
      if(position.X < Mouse.GetState().X && Mouse.GetState().X < position.X + width)
      {
        if (position.Y < Mouse.GetState().Y && Mouse.GetState().Y < position.Y + height)
        {
          return true;
        }
      }
      return false;
    }

    public void Click()
    {
      function();
    }

    public void Update(float dt)
    {
    }

    public void Draw(SpriteBatch spritebatch)
    {
      if (OnHover())
      {
        drawingAdapter.Draw(spritebatch, sprite[1], position, false);
        drawingAdapter.DrawString(spritebatch, font, label, position, Color.White);
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
          Click();
        }
      }
      else
      {
        drawingAdapter.Draw(spritebatch, sprite[0], position, false);
        drawingAdapter.DrawString(spritebatch, font, label, position, Color.White);
      }
    }
  }
}
