using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Kru_Puk
{
    class AssaultRifle: IWeapon //ClassNotImplemented
    {
        private int MaxClipAmount;
        private int ClipAmount;
        private Projectile projectile;

        AssaultRifle(int MaxClipAmount, int ClipAmount, Projectile projectile)
        {
            this.MaxClipAmount = MaxClipAmount;
            this.ClipAmount = ClipAmount;
            this.projectile = projectile;
        }


        
    }
}
