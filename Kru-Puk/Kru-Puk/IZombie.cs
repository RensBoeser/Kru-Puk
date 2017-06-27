using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  interface IZombie : IEntity
  {
    void Move();
    void StartAttack();
    void Die();
  }
}
