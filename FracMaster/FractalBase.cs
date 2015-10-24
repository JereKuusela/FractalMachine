using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Xml;

namespace FracMaster
{
  public class GenericFractal : IFractal
  {
    protected RenderResult res = null;
    protected IFractalParameters pars = new ParameterSet();
    protected AutoResetEvent interrupt = new AutoResetEvent(false);
    protected int lines_rendered = 0;

    public GenericFractal()
    {
      // basic parameters that any fractal should use:
      // name of the fractal
      pars.AddValue("NAME", "GenericFractal");
      // output width and height
      pars.AddValue("WIDTH", 600);
      pars.AddValue("HEIGHT", 800);
      // version of the fractal render engine 
      pars.AddValue("VERSION", "1.0.0");

      int Colors = 256;
      int[] Palette = new int[Colors];

      for (int i = 0; i < Colors; i++)
      {
        int g = (int)(255.0 * i / Colors);
        Palette[i] = Color.FromArgb(g, g, g).ToArgb();
      }
      Palette[Colors - 1] = Palette[0];
      pars.AddValue("PALETTE", Palette);
    }

    public void ReadFromXml(Stream instream)
    {
      try
      {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(instream);
        XmlNodeList nodes = xmldoc.GetElementsByTagName("frac");
        if (nodes.Count == 1)
        {
          nodes = xmldoc.GetElementsByTagName("parameter");
          foreach (XmlNode n in nodes)
          {
            string type = n.Attributes["type"].Value;
            string name = n.Attributes["name"].Value;
            string value = n.InnerXml;

            if (type == "System.Int32[]")
            {
              string[] vals = value.Split(new char[] { ',' });
              int Count = vals.Length;
              int[] values = new int[Count];
              for (int i = 0; i < Count; i++)
              {
                values[i] = Convert.ToInt32(vals[i]);
              }
              pars.SetValue(name, values);
            }
            else if (type == "System.Int32")
            {
              pars.SetValue(name, Convert.ToInt32(value));
            }
            else if (type == "System.Double")
            {
              pars.SetValue(name, Convert.ToDouble(value));
            }
            else if (type == "System.String")
            {
              pars.SetValue(name, value);
            }
            else
            {
              throw new ApplicationException("unsupported parameter type:" + type);
            }
          }
        }
        else
        {
          throw new IOException("illegal file format!");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("exception caught: " + ex.Message);
      }
    }

    virtual public void ReadFromXml(string filename)
    {
      try
      {
        FileStream f = new FileStream(filename, FileMode.Open);
        ReadFromXml(f);
      }
      catch
      {
      }
    }

    virtual public void WriteToXml(string filename)
    {
      try
      {
        Stream stream = File.Open(filename, FileMode.Create);
        string name = (string)pars.GetValue("NAME");

        TextWriter w = new StreamWriter(stream, Encoding.UTF8);
        w.WriteLine("<?xml version='1.0' encoding='utf-8' ?>");
        w.WriteLine("<frac name='" + name + "' type='" + GetType().ToString() + "'>");

        foreach (Parameter p in Parameters)
        {
          string pname = p.Name;
          string type = p.Type.ToString();

          if (type == "System.Int32[]")
          {
            int[] pal = (int[])p.Value;
            string palette = string.Empty;

            for (int i = 0; i < pal.Length; i++)
            {
              // TODO : format to hex
              if (i < pal.Length - 1) palette += "" + pal[i] + ",";
              else palette += "" + pal[i];
            }

            w.WriteLine("<parameter name='" + pname + "' type='" + type + "' >" + palette + "</parameter>");
          }
          else if (type == "System.Int32" ||
                   type == "System.String" ||
                   type == "System.Double" ||
                   type == "System.Float")
          {
            string value = p.Value.ToString();
            w.WriteLine("<parameter name='" + pname + "' type='" + type + "' >" + value + "</parameter>");
          }
          else
          {
            throw new ApplicationException("unsupported parameter type:" + type);
          }
        }

        w.WriteLine("</frac>");
        w.Flush();
        w.Close();
      }
      catch
      {
      }
    }

    public IFractalParameters Parameters
    {
      get
      {
        return pars;
      }
      set
      {
        pars = value;
      }
    }

    public IAsyncResult BeginRender(Delegate completed, Delegate status)
    {
      if (res == null)
      {
        res = new RenderResult();
        interrupt.Reset();
        Thread d = new Thread(new ParameterizedThreadStart(RenderFunction));
        d.Start(new object[] { completed, status });
        res.AsyncState = d;
        return res;
      }
      else
      {
        throw new ApplicationException("BeginRender already called");
      }
    }

    public void EndRender(IAsyncResult Res)
    {
      interrupt.Set();
      res = null;
    }

    virtual protected void RenderFunction(object o)
    {
      throw new ApplicationException("Virtual function not overridden!");
    }

  }
}
