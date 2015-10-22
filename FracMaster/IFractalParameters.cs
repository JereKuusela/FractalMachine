using System;
using System.Collections;

namespace FracMaster
{
  public interface IFractalParameters : IEnumerable, IEnumerator, ICloneable
  {
    bool HasValue(string name);
    void AddValue(string name, object value);
    void SetValue(string name, object value);
    object GetValue(string name);
    object GetValue(string name, object defaultValue);
  }
}
