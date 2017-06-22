using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
    class WeaponPouch: IEntity //InterfaceNotImplemented
    {
        private IWeapon[] Weapons;
        private int MaxWeapons;
        private int CurrentWeapon;

        WeaponPouch(IWeapon[] Weapons, int MaxWeapons, int CurrentWeapon)
        {
            this.Weapons = Weapons;
            this.MaxWeapons = MaxWeapons;
            this.CurrentWeapon = CurrentWeapon;

        }
    }
}
