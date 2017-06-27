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
    private bool pressed;

    private Rectangle rectangle;
    private Action function;
    private Texture2D[] sprite;
    private SpriteFont font;
    private string label;
    private DrawingAdapter drawingAdapter;
    private bool clickable;

    public Button(Rectangle rectangle, Action function, Texture2D[] sprite, SpriteFont font, string label)
    {
      this.rectangle = rectangle;
      this.function = function;
      this.sprite = sprite;
      this.font = font;
      this.label = label;
      this.drawingAdapter = new DrawingAdapter();
      this.pressed = false;
      this.clickable = true;
    }


    public bool OnHover()
    {
      if(rectangle.X < Mouse.GetState().X && Mouse.GetState().X < rectangle.X + rectangle.Width)
      {
        if (rectangle.Y < Mouse.GetState().Y && Mouse.GetState().Y < rectangle.Y + rectangle.Height)
        {
          return true;
        }
      }
      return false;
    }

    public void ToggleClickable()
    {
      if(clickable)
      { clickable = false; }
      else
      { clickable = true; }
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
      if (clickable)
      {
        if (OnHover())
        {
          drawingAdapter.Draw(spritebatch, sprite[1], rectangle.Location, false);
          drawingAdapter.DrawString(spritebatch, font, label, new Point(rectangle.X + 24, rectangle.Y + 24), Color.Black);
          if (Mouse.GetState().LeftButton == ButtonState.Pressed)
          {
            pressed = true;
          }
          else if (pressed)
          {
            pressed = false;
            Click();
          }
        }
        else
        {
          drawingAdapter.Draw(spritebatch, sprite[0], rectangle.Location, false);
          drawingAdapter.DrawString(spritebatch, font, label, new Point(rectangle.X + 20, rectangle.Y + 20), Color.Black);
        }
      }
      else
      {
        drawingAdapter.Draw(spritebatch, sprite[0], rectangle.Location, false, Color.Gray);
        drawingAdapter.DrawString(spritebatch, font, label, new Point(rectangle.X + 20, rectangle.Y + 20), Color.Black);
      }
    }
  }
}
