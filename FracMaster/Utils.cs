using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FracMaster
{
  public class Utils
  {
    private Utils()
    {

    }

    static public int InterpolateColors(int s1, int s2, int weigth)
    {
      Color c1 = Color.FromArgb(s1);
      Color c2 = Color.FromArgb(s2);

      byte red = (byte)(c1.R + ((c2.R - c1.R) * weigth >> 8) & 0xff);
      byte green = (byte)(c1.G + ((c2.G - c1.G) * weigth >> 8) & 0xff);
      byte blue = (byte)(c1.B + ((c2.B - c1.B) * weigth >> 8) & 0xff);

      return Color.FromArgb(red, green, blue).ToArgb();
    }

    static public IEnumerable<Control> GetAll(Control control)
    {
      var controls = control.Controls.Cast<Control>();

      return controls.SelectMany(ctrl => GetAll(ctrl))
                                .Concat(controls);
    }
  }
}
