using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class Some<T> : IOption<T>
  {
    private T Value;
    public Some(T Value)
    {
      this.Value = Value;
    }

    public U Visit<U>(Func<T, U> OnSome, Func<U> OnNone)
    {
      return OnSome(Value);
    }

    public void Visit(Action<T> OnSome, Action OnNone)
    {
      OnSome(Value);
    }
  }

  class None<T> : IOption<T>
  {
    public U Visit<U>(Func<T, U> OnSome, Func<U> OnNone)
    {
      return OnNone();
    }

    public void Visit(Action<T> OnSome, Action OnNone)
    {
      OnNone();
    }
  }
}
