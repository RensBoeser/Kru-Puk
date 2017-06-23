using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kru_Puk
{
    class Area: IArea //InterfaceNotImplemented
    {
        private Tuple<float, float> Position;
        private int Width;
        private int Height;
        private string AreaType;
        private bool Discovered;
        private Texture2D[] Sprites;
        private ???[] Assets;

        Area(Tuple<float,float> Position, int Width, int Height, string AreaType, bool Discovered, Texture2D[] Sprites, ???[] Sprites)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            this.AreaType = AreaType;
            this.Discovered = Discovered;
            this.Sprites = Sprites;
            this.Assets = Assets;
        }
    }

}
