using System;
using System.Windows.Forms;

namespace FracMaster
{
  public partial class FractalSettingsDialog : Form
    {
        IFractalParameters pars = null;
        public FractalSettingsDialog()
        {
            InitializeComponent();
        }

        public IFractalParameters Parameters
        {
            set
            {
                pars = value;
                ApplyParameters();
            }
            get
            {
                return pars;
            }
        }

        private void ApplyParameters()
        {
            if (InvokeRequired)
            {
        Invoke(new MethodInvoker(ApplyParameters));
            }
            else
            {
                foreach (Parameter p in pars)
                {
          ParameterGridView.Rows.Add(new object[] { p.Name, p.Type.ToString(), p.Value });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
      Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
      Close();
        }
    }
}