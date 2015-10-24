using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FracMaster
{
  public partial class FractalForm : Form
  {
    #region MEMBERS

    IAsyncResult renderResult = null;
    IFractal frac = null;
    string caption = string.Empty;
    float CalculationProgress = 0;
    Bitmap LastFractalImage = null;
    int LastErrorCode = 0;
    Point dragStart = Point.Empty;
    Point dragEnd = Point.Empty;
    Rectangle r = new Rectangle();
    bool isDragging = false;
    bool isZooming = false;
    bool isRendering = false;
    DateTime renderStart = DateTime.MinValue;
    TimeSpan renderTime = new TimeSpan();

    #endregion

    /// <summary>
    /// get or set fractal associated with  this form
    /// </summary>
    public IFractal Fractal
    {
      get { return frac; }
      set { frac = value; }
    }

    public FractalForm()
    {
      InitializeComponent();
      pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
      pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
      pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
      pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
      splitContainer1.Panel2.SizeChanged += new System.EventHandler(splitContainer1_Panel2_SizeChanged);
    }

    public void UpdateFractalSize()
    {
      if (frac != null)
        Fractal.Parameters.SetValue("WIDTH", pictureBox1.Width);
      if (frac != null)
        Fractal.Parameters.SetValue("HEIGHT", pictureBox1.Height);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (isRendering && renderResult != null)
      {
        frac.EndRender(renderResult);
      }
      base.OnClosing(e);
    }

    private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
    {
      UpdatePictureBox();
    }


    void UpdatePictureBox()
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(UpdatePictureBox));
      }
      else
      {
        if (LastFractalImage != null)
        {
          pictureBox1.Width = LastFractalImage.Width + 20;
          pictureBox1.Height = LastFractalImage.Height + 20;

          Point loc = pictureBox1.Location;

          if (pictureBox1.Width < splitContainer1.Panel2.Width)
          {
            loc.X = (splitContainer1.Panel2.Width - pictureBox1.Width) / 2;
          }
          else
          {
            loc.X = -splitContainer1.Panel2.HorizontalScroll.Value;
          }

          if (pictureBox1.Height < splitContainer1.Panel2.Height)
          {
            loc.Y = (splitContainer1.Panel2.Height - pictureBox1.Height) / 2;
          }
          else
          {
            loc.Y = -splitContainer1.Panel2.VerticalScroll.Value;
          }

          pictureBox1.Location = loc;
        }
      }
    }

    void OnImageOriginDragged(Point dragEnd)
    {
      ((Generic2DFractal)frac).SetOrigin(dragEnd.X, dragEnd.Y);
      ParametersToDialog();
      RenderFractal(false);
    }

    void OnControlPointDragged(Point dragEnd)
    {
      ((Generic2DFractal)frac).SetControlParameter(dragEnd.X, dragEnd.Y);
      ParametersToDialog();
      RenderFractal(false);

    }
    bool ScreenToFractal(double X, double Y, out double XF, out double YF)
    {
      if (pictureBox1.Image != null)
      {
        int off_x = pictureBox1.Width - pictureBox1.Image.Width;
        int off_y = pictureBox1.Height - pictureBox1.Image.Height;

        off_x /= 2;
        off_y /= 2;

        if (X > off_x && X < (off_x + pictureBox1.Image.Width) &&
            Y > off_y && Y < (off_y + pictureBox1.Image.Height))
        {
          X -= off_x;
          Y -= off_y;
          IFractalParameters pars = frac.Parameters;

          double FracX = (int)pars.GetValue("X");
          double FracY = (int)pars.GetValue("Y");
          double FracWidth = (int)pars.GetValue("WIDTH");
          double FracHeight = (int)pars.GetValue("HEIGHT");
          double FracW = (double)pars.GetValue("W");
          double FracH = (double)pars.GetValue("H");
          double FracX1 = (-FracX / FracWidth - 0.5) * FracW;
          double FracY1 = (FracY / FracHeight - 0.5) * FracH;

          // PicW : X = FracWidth : dxf
          // pictureBox2.Image.Width : X = FracWidth : dxf
          double dxf = FracW * X / pictureBox1.Image.Width;
          double dyf = FracH * Y / pictureBox1.Image.Height;
          XF = FracX1 + dxf;
          YF = FracY1 + dyf;
          return true;
        }
      }
      XF = 0;
      YF = 0;
      return false;
    }

    void OnImageZoomed(Point p1, Point p2)
    {
      ((Generic2DFractal)frac).SetOrigin((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
      ((Generic2DFractal)frac).SetScale((p2.X - p1.X), (p2.Y - p1.Y));
      ParametersToDialog();
      RenderFractal(false);
    }

    void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      if (IsMouseOverImage(e.X, e.Y) && e.Button == MouseButtons.Left)
      {
        OnImageOriginDragged(new Point(e.X, e.Y));
      }
      else if (IsMouseOverImage(e.X, e.Y) && e.Button == MouseButtons.Middle)
      {
        OnControlPointDragged(new Point(e.X, e.Y));
      }
      else if (IsMouseOverImage(e.X, e.Y) && dragStart != Point.Empty && e.Button == MouseButtons.Right)
      {
        double ar = 1.0;

        if (pictureBox1.Image != null)
        {
          ar = pictureBox1.Image.Width / (double)pictureBox1.Image.Height;
        }

        double drw = e.X - dragStart.X;
        double drh = e.Y - dragStart.Y;

        if (drw > drh) drh = drw / ar;
        else drw = drh * ar;

        dragEnd = new Point((int)(dragStart.X + drw), (int)(dragStart.Y + drh));
        OnImageZoomed(dragStart, dragEnd);
      }

      isZooming = false;
      isDragging = false;
      dragStart = Point.Empty;
      dragEnd = Point.Empty;
      Cursor = Cursors.Default;
    }

    void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (IsMouseOverImage(e.X, e.Y) &&
               dragStart == Point.Empty &&
               e.Button == MouseButtons.Right &&
               !isRendering)
      {
        dragStart = new Point(e.X, e.Y);
        Cursor = Cursors.IBeam;
        isZooming = true;
        // begin zoom
        Point startPoint = pictureBox1.PointToScreen(new Point(e.X, e.Y));
        r = new Rectangle(startPoint.X, startPoint.Y, 0, 0);
      }
      else
      {
        dragStart = Point.Empty;
        dragEnd = Point.Empty;
        Cursor = Cursors.Default;
      }
    }

    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {

      if (!isDragging && !isZooming && !isRendering)
      {
        if (IsMouseOverImage(e.X, e.Y))
        {
          Cursor = Cursors.Hand;
        }
        else
        {
          Cursor = Cursors.Default;
        }
      }
      else if (isZooming && !isRendering)
      {
        ControlPaint.DrawReversibleFrame(r, BackColor, FrameStyle.Dashed);

        Point endPoint = pictureBox1.PointToScreen(new Point(e.X, e.Y));
        Point startPoint = pictureBox1.PointToScreen(dragStart);
        double ar = 1.0;

        if (pictureBox1.Image != null)
        {
          ar = pictureBox1.Image.Width / (double)pictureBox1.Image.Height;
        }

        double drw = endPoint.X - startPoint.X;
        double drh = endPoint.Y - startPoint.Y;

        if (drw > drh) drh = drw / ar;
        else drw = drh * ar;

        r = new Rectangle(startPoint.X, startPoint.Y, (int)drw, (int)drh);

        ControlPaint.DrawReversibleFrame(r, BackColor, FrameStyle.Dashed);
      }
    }

    private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
    {
      // Update the drawing based upon the mouse wheel scrolling.

      double numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 720.0;
      ((Generic2DFractal)frac).SetScaleDelta(Math.Pow(2, numberOfTextLinesToMove));
      ParametersToDialog();
      RenderFractal(false);
    }

    bool IsMouseOverImage(int X, int Y)
    {
      if (pictureBox1.Image != null)
      {
        int off_x = pictureBox1.Width - pictureBox1.Image.Width;
        int off_y = pictureBox1.Height - pictureBox1.Image.Height;

        off_x /= 2;
        off_y /= 2;

        if (X > off_x && X < (off_x + pictureBox1.Image.Width) &&
             Y > off_y && Y < (off_y + pictureBox1.Image.Height))
        {
          return true;
        }
      }
      return false;
    }

    private void UpdateFormContent()
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(UpdateFormContent));
      }
      else
      {
        try
        {
          Text = caption;
          buttonRender.Text = "Piirrä";
          if (LastErrorCode == 0)
          {
            pictureBox1.Image = LastFractalImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            UpdatePictureBox();
          }

        }
        catch { }
      }
    }

    private void UpdateFormCaption()
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(UpdateFormCaption));
      }
      else
      {
        int Pcnt = (int)CalculationProgress;
        Text = caption + "[" + Pcnt + "%]";
      }
    }

    private void RenderComplete(Bitmap bmp, int ErrorCode)
    {
      try
      {
        if (renderResult != null)
        {
          renderTime = DateTime.Now - renderStart;
          LastErrorCode = ErrorCode;

          frac.EndRender(renderResult);
          LastFractalImage = bmp;

          UpdateFormContent();

          renderResult = null;
          isRendering = false;
        }
      }
      catch { }
    }

    private void RenderStatusUpdated(float pcnt)
    {
      try
      {
        CalculationProgress = pcnt;
        UpdateFormCaption();
      }
      catch { }
    }

    private void InterruptRender()
    {
      if (renderResult != null)
      {
        frac.EndRender(renderResult);
      }
      buttonRender.Text = "Piirrä";
    }

    private void RenderFractal(bool automatic)
    {
      if (automatic && (int)frac.Parameters.GetValue("AUTOMATIC_PREVIEW") == 0)
        return;
      if (renderResult == null)
      {
        caption = Text;
        isRendering = true;

        renderStart = DateTime.Now;
        renderResult = frac.BeginRender(new RenderResult.RenderComplete(RenderComplete),
                                          new RenderResult.RenderStatus(RenderStatusUpdated));

        buttonRender.Text = "Pysäytä";
      }
    }

    public void ParametersToDialog()
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(ParametersToDialog));
      }
      else
      {
        numericCenterX.Value = Convert.ToDecimal(frac.Parameters.GetValue("X"));
        numericCenterY.Value = Convert.ToDecimal(frac.Parameters.GetValue("Y"));
        if (frac.Parameters.HasValue("XC"))
          numericControlX.Value = Convert.ToDecimal(frac.Parameters.GetValue("XC"));
        else
          numericControlX.Enabled = false;
        if (frac.Parameters.HasValue("YC"))
          numericControlY.Value = Convert.ToDecimal(frac.Parameters.GetValue("YC"));
        else
          numericControlY.Enabled = false;
        if (frac.Parameters.HasValue("A"))
          numericNewton.Value = Convert.ToDecimal(frac.Parameters.GetValue("A"));
        else
          numericNewton.Enabled = false;
        numericZoomX.Value = Convert.ToDecimal(Math.Log((double)frac.Parameters.GetValue("W"), 2));
        numericZoomY.Value = Convert.ToDecimal(Math.Log((double)frac.Parameters.GetValue("H"), 2));
        numericSizeX.Value = Convert.ToDecimal(frac.Parameters.GetValue("WIDTH"));
        numericSizeY.Value = Convert.ToDecimal(frac.Parameters.GetValue("HEIGHT"));
        numericIteration.Value = Convert.ToDecimal(frac.Parameters.GetValue("ITERATIONS"));
        if(frac.Parameters.HasValue("RENDER_INTERPOLATED"))
           checkBoxInterpolation.Checked = (int)frac.Parameters.GetValue("RENDER_INTERPOLATED", 0) == 1 ? true : false;
        else
          checkBoxInterpolation.Enabled = false;
       
        checkBoxFilter.Checked = (int)frac.Parameters.GetValue("APPLY_BILINEAR_FILTER", 0) == 1 ? true : false;
        checkBoxPreview.Checked = (int)frac.Parameters.GetValue("AUTOMATIC_PREVIEW", 0) == 1 ? true : false;
      }
    }

    private void buttonRender_Click(object sender, EventArgs e)
    {
      if (isRendering)
        InterruptRender();
      else
        RenderFractal(false);
    }

    private void buttonSaveImage_Click(object sender, EventArgs e)
    {
      if (LastFractalImage != null)
      {
        SaveFileDialog dia = new SaveFileDialog();
        dia.Filter = "png file (*.png)|*.png";

        if (dia.ShowDialog() == DialogResult.OK)
        {
          try
          {
            LastFractalImage.Save(dia.FileName);
          }
          catch { }
        }
      }
    }

    private void buttonSaveInfo_Click(object sender, EventArgs e)
    {
      SaveFileDialog dia = new SaveFileDialog();
      dia.Filter = "xml file (*.xml)|*.xml";

      if (dia.ShowDialog() == DialogResult.OK)
      {
        frac.WriteToXml(dia.FileName);
      }
    }

    private void buttonPalett_Click(object sender, EventArgs e)
    {
      int[] Palette = (int[])frac.Parameters.GetValue("PALETTE");
      EditPaletteDialog dia = new EditPaletteDialog();
      dia.ColorCount = (int)frac.Parameters.GetValue("COLOR_COUNT");
      dia.Palette = (int[])Palette.Clone();
     
      if (dia.ShowDialog() == DialogResult.OK)
      {
        frac.Parameters.SetValue("PALETTE", dia.Palette);
        frac.Parameters.SetValue("COLOR_COUNT", dia.ColorCount);
        RenderFractal(true);
      }
    }

    private void numericCenterX_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToDouble(box.Value);
      frac.Parameters.SetValue("X", value);
      RenderFractal(true);
    }

    private void numericCenterY_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToDouble(box.Value);
      frac.Parameters.SetValue("Y", value);
      RenderFractal(true);
    }

    private void numericZoomX_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Math.Pow(2, Convert.ToDouble(box.Value));
      frac.Parameters.SetValue("W", value);
      RenderFractal(true);
    }

    private void numericZoomY_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Math.Pow(2, Convert.ToDouble(box.Value));
      frac.Parameters.SetValue("H", value);
      RenderFractal(true);
    }

    private void numericSizeX_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToInt32(box.Value);
      frac.Parameters.SetValue("WIDTH", value);
      RenderFractal(true);
    }

    private void numericSizeY_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToInt32(box.Value);
      frac.Parameters.SetValue("HEIGHT", value);
      RenderFractal(true);
    }

    private void numericIteration_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToInt32(box.Value);
      frac.Parameters.SetValue("ITERATIONS", value);
      RenderFractal(true);
    }

    private void checkBoxInterpolation_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox box = (CheckBox)sender;
      if (box == null)
        return;
      frac.Parameters.SetValue("RENDER_INTERPOLATED", box.Checked ? 1 : 0);
      RenderFractal(true);
    }

    private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox box = (CheckBox)sender;
      if (box == null)
        return;
      frac.Parameters.SetValue("APPLY_BILINEAR_FILTER", box.Checked ? 1 : 0);
      RenderFractal(true);
    }

    private void checkBoxPreview_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox box = (CheckBox)sender;
      if (box == null)
        return;
      frac.Parameters.SetValue("AUTOMATIC_PREVIEW", box.Checked ? 1 : 0);
      RenderFractal(true);
    }

    private void numericControlX_ValueChanged(object sender, EventArgs e)
    {
      if (!frac.Parameters.HasValue("XC"))
        return;
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToDouble(box.Value);
      frac.Parameters.SetValue("XC", value);
      RenderFractal(true);
    }

    private void numericControlY_ValueChanged(object sender, EventArgs e)
    {
      if (!frac.Parameters.HasValue("YC"))
        return;
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToDouble(box.Value);
      frac.Parameters.SetValue("YC", value);
      RenderFractal(true);
    }

    private void numericNewton_ValueChanged(object sender, EventArgs e)
    {
      if (!frac.Parameters.HasValue("A"))
        return;
      NumericUpDown box = (NumericUpDown)sender;
      if (box == null)
        return;
      var value = Convert.ToDouble(box.Value);
      frac.Parameters.SetValue("A", value);
      RenderFractal(true);
    }
  }
}