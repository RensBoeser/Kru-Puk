using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
    class Door : IDoor // InterfaceNotImplemented
    {
        private Texture2D[] Sprites;
        private Tuple<float, float> Position;
        private int Width;
        private int Height;
        private bool Open;
        private bool interactable;
    }
}
