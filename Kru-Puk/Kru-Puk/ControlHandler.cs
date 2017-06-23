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
    public class ControlHandler : Game //Change the Console.WriteLine for real outputs || Some possible void outputs have already been coded ||
    {
        GamePadState state = GamePad.GetState(PlayerIndex.One);
        public ControlHandler()
        {

        }
        public void MoveLeft()
        {
            Console.WriteLine("Move left!");
            //player1.Move.Left();
        }

        public void MoveRight()
        {
            Console.WriteLine("Move Right!");
            //player1.Move.Right();
        }

        public void Jump()
        {
            Console.WriteLine("Jump!");
            //player1.Move.Jump();
        }

        public void GunUp()
        {
            Console.WriteLine("Move gun up");
            //NotYetImplemented
        }

        public void GunDown()
        {
            Console.WriteLine("Move gun down");
            //NotYetImplemented
        }

        public void Fire()
        {
            Console.WriteLine("Fire!");
            //player1.WeaponPouch.Currentweapon.Use();
        }

        public void Reload()
        {
            Console.WriteLine("Reloading");
            //player1.WeaponPouch.Currentweapon.Reload();
        }

        public void Interact()
        {
            Console.WriteLine("Interacting");
        }
    }
}
