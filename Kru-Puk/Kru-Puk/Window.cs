using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class Window
  {
    private GraphicsDevice graphicsDevice;
    public Window(GraphicsDevice graphicsDevice)
    {
      this.graphicsDevice = graphicsDevice;
    }
    public Rectangle WholeWindow()
    {
      return graphicsDevice.PresentationParameters.Bounds;
    }
    public Point Center()
    {
      return graphicsDevice.PresentationParameters.Bounds.Center;
    }
  }
}
