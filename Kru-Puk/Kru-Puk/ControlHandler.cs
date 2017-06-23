using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kru_Puk
{
    public class ControlHandler : Game //Change the Console.WriteLine for real outputs
    {
        GamePadState state = GamePad.GetState(PlayerIndex.One);
        public ControlHandler()
        {

        }
        public void MoveLeft()
        {
            Console.WriteLine("Move left!");
        }

        public void MoveRight()
        {
            Console.WriteLine("Move Right!");
        }

        public void Jump()
        {
            Console.WriteLine("Jump!");
        }

        public void GunUp()
        {
            Console.WriteLine("Move gun up");
        }

        public void GunDown()
        {
            Console.WriteLine("Move gun down");
        }

        public void Fire()
        {
            Console.WriteLine("Fire!");
        }

        public void Reload()
        {
            Console.WriteLine("Reloading");
        }

        public void Interact()
        {
            Console.WriteLine("Interacting");
        }
    }
}
