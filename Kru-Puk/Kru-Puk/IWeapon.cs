using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
    public interface IWeapon : IUpdatable, IDrawable
    {
        void Use();
        void Reload(int Ammo);
    }
}
