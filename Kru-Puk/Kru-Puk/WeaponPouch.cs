using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class WeaponPouch
  {
    private IWeapon[] Weapons;
    private int MaxWeapons;
    private int CurrentWeapon;
    EntityFactory enitityfactory;

    public WeaponPouch(IWeapon[] Weapons, int MaxWeapons, int CurrentWeapon, EntityFactory enitityfactory)
    {
      this.Weapons = Weapons;
      this.MaxWeapons = MaxWeapons;
      this.CurrentWeapon = CurrentWeapon;
      this.enitityfactory = enitityfactory;
    }

    public void AddWeapon(IWeapon Weapon)
    {
      List<IWeapon> tempList = new List<IWeapon>();
      foreach(IWeapon weapon in Weapons)
      {
        tempList.Add(weapon);
      }
      tempList.Add(Weapon);
      Weapons = tempList.ToArray();
    }

    public void RemoveWeapon(IWeapon Weapon)
    {

    }

    public void SwitchWeapon(IWeapon Weapon)
    {

    }

    public IWeapon GetWeapon(IWeapon Weapon)
    { 
      return null;
    }

  }
}
