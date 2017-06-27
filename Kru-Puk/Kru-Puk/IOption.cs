using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  interface IOption<T>
  {
    U Visit<U>(Func<T, U> OnSome, Func<U> OnNone);
    void Visit(Action<T> OnSome, Action OnNone);
  }
}
