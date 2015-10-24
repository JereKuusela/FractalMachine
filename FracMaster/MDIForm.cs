using System;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace FracMaster
{
  public partial class MDIForm : Form
  {
    int childCount = 1;

    public MDIForm()
    {
      InitializeComponent();
    }

    private FractalForm createFractalForm(string text)
    {
      FractalForm frmchild = new FractalForm();
      frmchild.MdiParent = this;
      //child Form will now hold a reference value to the tab control
      frmchild.TabCtrl = tabControl1;

      frmchild.Dock = System.Windows.Forms.DockStyle.Fill;
      frmchild.Location = new System.Drawing.Point(0, 0);
      frmchild.Text = text;

      //Add a Tabpage and enables it
      TabPage tp = new TabPage();
      tp.Parent = tabControl1;
      tp.Text = frmchild.Text;
      tp.Show();

      //child Form will now hold a reference value to a tabpage
      frmchild.TabPage = tp;

      //Activate the MDI child form
      childCount++;

      //Activate the newly created Tabpage
      tabControl1.SelectedTab = tp;

      frmchild.Show();
      return frmchild;
    }

    private void mandelbrotFractalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FractalForm frmchild = createFractalForm("Mandelbrot Fractal");
      frmchild.Fractal = new MandelbrotFractal();
      frmchild.UpdateFractalSize();
      frmchild.ParametersToDialog();
    }

    private void juliaFractalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FractalForm frmchild = createFractalForm("Julia Fractal");
      frmchild.Fractal = new JuliaFractal();
      frmchild.UpdateFractalSize();
      frmchild.ParametersToDialog();
    }

    private void newtonFractalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FractalForm frmchild = createFractalForm("Newton Fractal - Iterations Required");
      frmchild.Fractal = new NewtonFractalByIterationsRequired();
      frmchild.UpdateFractalSize();
      frmchild.ParametersToDialog();
    }


    private void loadFractalFromStream(Stream s)
    {
      // ToDo get type of fractal and load it!
      XmlDocument xmldoc = new XmlDocument();
      xmldoc.Load(s);
      XmlNodeList nodes = xmldoc.GetElementsByTagName("frac");
      if (nodes.Count == 1)
      {
        try
        {
          s.Position = 0;
          string type = nodes[0].Attributes["type"].Value;

          if (type == "FracMaster.MandelbrotFractal")
          {
            FractalForm frmchild = new FractalForm();
            frmchild.MdiParent = this;
            frmchild.Fractal = new MandelbrotFractal();
            frmchild.Fractal.ReadFromXml(s);
            frmchild.Show();
            frmchild.Text = "Mandelbrot Fractal";
          }
          else if (type == "FracMaster.JuliaFractal")
          {
            FractalForm frmchild = new FractalForm();
            frmchild.MdiParent = this;
            frmchild.Fractal = new JuliaFractal();
            frmchild.Fractal.ReadFromXml(s);
            frmchild.Show();
            frmchild.Text = "Julia Fractal";
          }
          else if (type == "FracMaster.NewtonFractal" ||
                   type == "FracMaster.NewtonFractalByIterationsRequired")
          {
            FractalForm frmchild = new FractalForm();
            frmchild.MdiParent = this;
            frmchild.Fractal = new NewtonFractalByIterationsRequired();
            frmchild.Fractal.ReadFromXml(s);
            frmchild.Show();
            frmchild.Text = "Newton Fractal - Iterations required";
          }

          else
          {
            // ignore
          }
        }
        catch { }
      }
    }

    private void loadFractalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // load fractal here
      OpenFileDialog dia = new OpenFileDialog();
      dia.Filter = "xml file (*.xml)|*.xml";

      if (dia.ShowDialog() == DialogResult.OK)
      {
        Stream s = new FileStream(dia.FileName, FileMode.Open);
        loadFractalFromStream(s);

      }
    }

    private void aboutFracMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("FracMaster(C) 2009 Zimmermann Stephan \n\r\n\rFraktaalikone 2015 Jere Kuusela");
    }

    private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      foreach (FractalForm childForm in this.MdiChildren)
      {
        //Check for its corresponding MDI child form
        if (childForm.TabPage.Equals(tabControl1.SelectedTab))
        {
          //Activate the MDI child form
          childForm.Select();
        }
      }
    }

    private void tabControl1_MouseUp(object sender, MouseEventArgs e)
    {
      // check if the right mouse button was pressed
      if (e.Button == MouseButtons.Right)
      {
        // iterate through all the tab pages
        for (int i = 0; i < tabControl1.TabCount; i++)
        {
          // get their rectangle area and check if it contains the mouse cursor
          Rectangle r = tabControl1.GetTabRect(i);
          if (r.Contains(e.Location))
          {
            foreach (FractalForm childForm in this.MdiChildren)
            {
              //Check for its corresponding MDI child form
              if (childForm.TabPage.Equals(tabControl1.TabPages[i]))
              {
                childForm.Close();
                return;
              }
            }
          }
        }
      }
    }
  }
}