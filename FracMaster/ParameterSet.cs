using System;
using System.Collections.Generic;
using System.Collections;

namespace FracMaster
{
  public class ParameterSet : IFractalParameters
  {
    private List<Parameter> pars = new List<Parameter>();

    public IEnumerator GetEnumerator()
    {
      return pars.GetEnumerator();
    }

    public object Clone()
    {
      ParameterSet p = new ParameterSet();
      foreach (Parameter px in pars)
      {
        p.AddValue(px.Name, px.Value);
      }
      return p;
    }

    public object Current
    {
      get
      {
        return pars.GetEnumerator().Current;
      }
    }

    public bool MoveNext()
    {
      return pars.GetEnumerator().MoveNext();
    }

    public void Reset()
    {

    }

    public bool HasValue(string name)
    {
      foreach (Parameter p in pars)
      {
        if (p.Name == name)
        {
          return true;
        }
      }
      return false;
    }

    public void SetValue(string name, object value)
    {
      foreach (Parameter p in pars)
      {
        if (p.Name == name)
        {
          p.Value = value;
          return;
        }
      }
      AddValue(name, value);
    }

    public object GetValue(string name)
    {
      foreach (Parameter p in pars)
      {
        if (p.Name == name)
        {
          return p.Value;
        }
      }
      throw new ApplicationException("parameter '" + name + "' not found");
    }

    public object GetValue(string name, object defaultValue)
    {
      foreach (Parameter p in pars)
      {
        if (p.Name == name)
        {
          return p.Value;
        }
      }
      return defaultValue;
    }

    public void AddValue(string name, object value)
    {
      foreach (Parameter p in pars)
      {
        if (p.Name == name)
        {
          throw new ArgumentException("Paramter with that name already exists");
        }
      }

      pars.Add(new Parameter(name, value));
    }
  }
}
