using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
    class Player
    {
        private Tuple<float, float> Position;
        private Vector2 Velocity;
        private Vector2 Acceleration;
        private Texture2D[] Sprites;
        private WeaponPouch WeaponPouch;
        private int Ammo;
        private int Health;
        private int Width;
        private int Height;

        Player(Tuple<float,float> Position, Vector2 Velocity, Vector2 Acceleration, Texture2D[] Sprites,WeaponPouch WeaponPouch, int Ammo, int Health, int Width, int Height)
        {
            this.Position = Position;
            this.Velocity = Velocity;
            this.Acceleration = Acceleration;
            this.Sprites = Sprites;
            this.WeaponPouch = WeaponPouch;
            this.Ammo = Ammo;
            this.Health = Health;
            this.Width = Width;
            this.Height = Height;
        }
    }
}
