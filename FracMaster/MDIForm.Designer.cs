using System.Windows.Forms;

namespace FracMaster
{
  partial class MDIForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mandelbrotFractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.juliaFractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newtonFractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutFracMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.aboutToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(668, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mandelbrotFractalToolStripMenuItem,
            this.juliaFractalToolStripMenuItem,
            this.newtonFractalToolStripMenuItem});
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
      this.newToolStripMenuItem.Text = "Uusi";
      // 
      // mandelbrotFractalToolStripMenuItem
      // 
      this.mandelbrotFractalToolStripMenuItem.Name = "mandelbrotFractalToolStripMenuItem";
      this.mandelbrotFractalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.mandelbrotFractalToolStripMenuItem.Text = "Mandelbrot";
      this.mandelbrotFractalToolStripMenuItem.Click += new System.EventHandler(this.mandelbrotFractalToolStripMenuItem_Click);
      // 
      // juliaFractalToolStripMenuItem
      // 
      this.juliaFractalToolStripMenuItem.Name = "juliaFractalToolStripMenuItem";
      this.juliaFractalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.juliaFractalToolStripMenuItem.Text = "Julia";
      this.juliaFractalToolStripMenuItem.Click += new System.EventHandler(this.juliaFractalToolStripMenuItem_Click);
      // 
      // newtonFractalToolStripMenuItem
      // 
      this.newtonFractalToolStripMenuItem.Name = "newtonFractalToolStripMenuItem";
      this.newtonFractalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.newtonFractalToolStripMenuItem.Text = "Newton";
      this.newtonFractalToolStripMenuItem.Click += new System.EventHandler(this.newtonFractalToolStripMenuItem_Click);
      // 
      // loadToolStripMenuItem
      // 
      this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
      this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
      this.loadToolStripMenuItem.Text = "Avaa";
      this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadFractalToolStripMenuItem_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
      this.aboutToolStripMenuItem.Text = "Tekijät";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutFracMasterToolStripMenuItem_Click);
      // 
      // aboutFracMasterToolStripMenuItem
      // 
      this.aboutFracMasterToolStripMenuItem.Name = "aboutFracMasterToolStripMenuItem";
      this.aboutFracMasterToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // tabControl1
      // 
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.tabControl1.Location = new System.Drawing.Point(0, 24);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(668, 24);
      this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
      this.tabControl1.TabIndex = 4;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseUp);
      // 
      // MDIForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(668, 434);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.Name = "MDIForm";
      this.Text = "Fraktaalikone";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutFracMasterToolStripMenuItem;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mandelbrotFractalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem juliaFractalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newtonFractalToolStripMenuItem;
  }
}

