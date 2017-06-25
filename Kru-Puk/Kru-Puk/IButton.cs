using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  interface IButton : IUpdateable, IDrawable
  {
    bool OnHover();
    void Click();
    
  }
}
