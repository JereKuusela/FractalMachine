using System.Windows.Forms;

namespace FracMaster
{
  partial class FractalForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    public TabControl TabCtrl
    {
      get; set;
    }
    public TabPage TabPage
    {
      get; set;
    }
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.numericNewton = new System.Windows.Forms.NumericUpDown();
      this.labelNewton = new System.Windows.Forms.Label();
      this.numericControlY = new System.Windows.Forms.NumericUpDown();
      this.numericControlX = new System.Windows.Forms.NumericUpDown();
      this.labelControlY = new System.Windows.Forms.Label();
      this.labelControlX = new System.Windows.Forms.Label();
      this.labelExtraInfo = new System.Windows.Forms.Label();
      this.checkBoxPreview = new System.Windows.Forms.CheckBox();
      this.numericIteration = new System.Windows.Forms.NumericUpDown();
      this.numericSizeY = new System.Windows.Forms.NumericUpDown();
      this.numericSizeX = new System.Windows.Forms.NumericUpDown();
      this.numericZoomY = new System.Windows.Forms.NumericUpDown();
      this.numericZoomX = new System.Windows.Forms.NumericUpDown();
      this.numericCenterY = new System.Windows.Forms.NumericUpDown();
      this.numericCenterX = new System.Windows.Forms.NumericUpDown();
      this.buttonPalett = new System.Windows.Forms.Button();
      this.checkBoxFilter = new System.Windows.Forms.CheckBox();
      this.checkBoxInterpolation = new System.Windows.Forms.CheckBox();
      this.labelIteration = new System.Windows.Forms.Label();
      this.labelSizeY = new System.Windows.Forms.Label();
      this.labelSizeX = new System.Windows.Forms.Label();
      this.labelSize = new System.Windows.Forms.Label();
      this.labelZoomY = new System.Windows.Forms.Label();
      this.labelZoomX = new System.Windows.Forms.Label();
      this.labelZoom = new System.Windows.Forms.Label();
      this.labelCenterY = new System.Windows.Forms.Label();
      this.labelCenterX = new System.Windows.Forms.Label();
      this.labelCenter = new System.Windows.Forms.Label();
      this.labelInfo = new System.Windows.Forms.Label();
      this.buttonSaveInfo = new System.Windows.Forms.Button();
      this.buttonSaveImage = new System.Windows.Forms.Button();
      this.buttonRender = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericNewton)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericControlY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericControlX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericIteration)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericSizeY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericSizeX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericZoomY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericZoomX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericCenterY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericCenterX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.IsSplitterFixed = true;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.splitContainer1.Panel1.Controls.Add(this.numericNewton);
      this.splitContainer1.Panel1.Controls.Add(this.labelNewton);
      this.splitContainer1.Panel1.Controls.Add(this.numericControlY);
      this.splitContainer1.Panel1.Controls.Add(this.numericControlX);
      this.splitContainer1.Panel1.Controls.Add(this.labelControlY);
      this.splitContainer1.Panel1.Controls.Add(this.labelControlX);
      this.splitContainer1.Panel1.Controls.Add(this.labelExtraInfo);
      this.splitContainer1.Panel1.Controls.Add(this.checkBoxPreview);
      this.splitContainer1.Panel1.Controls.Add(this.numericIteration);
      this.splitContainer1.Panel1.Controls.Add(this.numericSizeY);
      this.splitContainer1.Panel1.Controls.Add(this.numericSizeX);
      this.splitContainer1.Panel1.Controls.Add(this.numericZoomY);
      this.splitContainer1.Panel1.Controls.Add(this.numericZoomX);
      this.splitContainer1.Panel1.Controls.Add(this.numericCenterY);
      this.splitContainer1.Panel1.Controls.Add(this.numericCenterX);
      this.splitContainer1.Panel1.Controls.Add(this.buttonPalett);
      this.splitContainer1.Panel1.Controls.Add(this.checkBoxFilter);
      this.splitContainer1.Panel1.Controls.Add(this.checkBoxInterpolation);
      this.splitContainer1.Panel1.Controls.Add(this.labelIteration);
      this.splitContainer1.Panel1.Controls.Add(this.labelSizeY);
      this.splitContainer1.Panel1.Controls.Add(this.labelSizeX);
      this.splitContainer1.Panel1.Controls.Add(this.labelSize);
      this.splitContainer1.Panel1.Controls.Add(this.labelZoomY);
      this.splitContainer1.Panel1.Controls.Add(this.labelZoomX);
      this.splitContainer1.Panel1.Controls.Add(this.labelZoom);
      this.splitContainer1.Panel1.Controls.Add(this.labelCenterY);
      this.splitContainer1.Panel1.Controls.Add(this.labelCenterX);
      this.splitContainer1.Panel1.Controls.Add(this.labelCenter);
      this.splitContainer1.Panel1.Controls.Add(this.labelInfo);
      this.splitContainer1.Panel1.Controls.Add(this.buttonSaveInfo);
      this.splitContainer1.Panel1.Controls.Add(this.buttonSaveImage);
      this.splitContainer1.Panel1.Controls.Add(this.buttonRender);
      this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.splitContainer1.Panel1MinSize = 200;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.AutoScroll = true;
      this.splitContainer1.Panel2.AutoScrollMinSize = new System.Drawing.Size(10, 10);
      this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
      this.splitContainer1.Panel2MinSize = 20;
      this.splitContainer1.Size = new System.Drawing.Size(1000, 800);
      this.splitContainer1.SplitterDistance = 200;
      this.splitContainer1.SplitterWidth = 1;
      this.splitContainer1.TabIndex = 1;
      this.splitContainer1.TabStop = false;
      // 
      // numericNewton
      // 
      this.numericNewton.DecimalPlaces = 1;
      this.numericNewton.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.numericNewton.Location = new System.Drawing.Point(31, 740);
      this.numericNewton.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this.numericNewton.Name = "numericNewton";
      this.numericNewton.Size = new System.Drawing.Size(158, 29);
      this.numericNewton.TabIndex = 39;
      this.numericNewton.ValueChanged += new System.EventHandler(this.numericNewton_ValueChanged);
      // 
      // labelNewton
      // 
      this.labelNewton.AutoSize = true;
      this.labelNewton.Location = new System.Drawing.Point(3, 742);
      this.labelNewton.Name = "labelNewton";
      this.labelNewton.Size = new System.Drawing.Size(23, 24);
      this.labelNewton.TabIndex = 38;
      this.labelNewton.Text = "A";
      // 
      // numericControlY
      // 
      this.numericControlY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericControlY.Location = new System.Drawing.Point(31, 710);
      this.numericControlY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numericControlY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.numericControlY.Name = "numericControlY";
      this.numericControlY.Size = new System.Drawing.Size(158, 29);
      this.numericControlY.TabIndex = 37;
      this.numericControlY.ValueChanged += new System.EventHandler(this.numericControlY_ValueChanged);
      // 
      // numericControlX
      // 
      this.numericControlX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericControlX.Location = new System.Drawing.Point(31, 680);
      this.numericControlX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numericControlX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.numericControlX.Name = "numericControlX";
      this.numericControlX.Size = new System.Drawing.Size(158, 29);
      this.numericControlX.TabIndex = 36;
      this.numericControlX.ValueChanged += new System.EventHandler(this.numericControlX_ValueChanged);
      // 
      // labelControlY
      // 
      this.labelControlY.AutoSize = true;
      this.labelControlY.Location = new System.Drawing.Point(3, 712);
      this.labelControlY.Name = "labelControlY";
      this.labelControlY.Size = new System.Drawing.Size(22, 24);
      this.labelControlY.TabIndex = 35;
      this.labelControlY.Text = "Y";
      // 
      // labelControlX
      // 
      this.labelControlX.AutoSize = true;
      this.labelControlX.Location = new System.Drawing.Point(3, 682);
      this.labelControlX.Name = "labelControlX";
      this.labelControlX.Size = new System.Drawing.Size(24, 24);
      this.labelControlX.TabIndex = 34;
      this.labelControlX.Text = "X";
      // 
      // labelExtraInfo
      // 
      this.labelExtraInfo.AutoSize = true;
      this.labelExtraInfo.Location = new System.Drawing.Point(3, 652);
      this.labelExtraInfo.Name = "labelExtraInfo";
      this.labelExtraInfo.Size = new System.Drawing.Size(121, 24);
      this.labelExtraInfo.TabIndex = 33;
      this.labelExtraInfo.Text = "Lisäasetukset";
      // 
      // checkBoxPreview
      // 
      this.checkBoxPreview.AutoSize = true;
      this.checkBoxPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxPreview.Location = new System.Drawing.Point(9, 50);
      this.checkBoxPreview.Name = "checkBoxPreview";
      this.checkBoxPreview.Size = new System.Drawing.Size(153, 28);
      this.checkBoxPreview.TabIndex = 32;
      this.checkBoxPreview.Text = "Automaattisesti";
      this.checkBoxPreview.UseVisualStyleBackColor = true;
      this.checkBoxPreview.CheckedChanged += new System.EventHandler(this.checkBoxPreview_CheckedChanged);
      // 
      // numericIteration
      // 
      this.numericIteration.Location = new System.Drawing.Point(31, 549);
      this.numericIteration.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericIteration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericIteration.Name = "numericIteration";
      this.numericIteration.Size = new System.Drawing.Size(158, 29);
      this.numericIteration.TabIndex = 31;
      this.numericIteration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericIteration.ValueChanged += new System.EventHandler(this.numericIteration_ValueChanged);
      // 
      // numericSizeY
      // 
      this.numericSizeY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericSizeY.Location = new System.Drawing.Point(31, 487);
      this.numericSizeY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numericSizeY.Name = "numericSizeY";
      this.numericSizeY.Size = new System.Drawing.Size(158, 29);
      this.numericSizeY.TabIndex = 30;
      this.numericSizeY.ValueChanged += new System.EventHandler(this.numericSizeY_ValueChanged);
      // 
      // numericSizeX
      // 
      this.numericSizeX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericSizeX.Location = new System.Drawing.Point(31, 457);
      this.numericSizeX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numericSizeX.Name = "numericSizeX";
      this.numericSizeX.Size = new System.Drawing.Size(158, 29);
      this.numericSizeX.TabIndex = 29;
      this.numericSizeX.ValueChanged += new System.EventHandler(this.numericSizeX_ValueChanged);
      // 
      // numericZoomY
      // 
      this.numericZoomY.DecimalPlaces = 2;
      this.numericZoomY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.numericZoomY.Location = new System.Drawing.Point(31, 397);
      this.numericZoomY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numericZoomY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.numericZoomY.Name = "numericZoomY";
      this.numericZoomY.Size = new System.Drawing.Size(158, 29);
      this.numericZoomY.TabIndex = 28;
      this.numericZoomY.ValueChanged += new System.EventHandler(this.numericZoomY_ValueChanged);
      // 
      // numericZoomX
      // 
      this.numericZoomX.DecimalPlaces = 2;
      this.numericZoomX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.numericZoomX.Location = new System.Drawing.Point(31, 367);
      this.numericZoomX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numericZoomX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.numericZoomX.Name = "numericZoomX";
      this.numericZoomX.Size = new System.Drawing.Size(158, 29);
      this.numericZoomX.TabIndex = 27;
      this.numericZoomX.ValueChanged += new System.EventHandler(this.numericZoomX_ValueChanged);
      // 
      // numericCenterY
      // 
      this.numericCenterY.DecimalPlaces = 2;
      this.numericCenterY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericCenterY.Location = new System.Drawing.Point(31, 307);
      this.numericCenterY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numericCenterY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.numericCenterY.Name = "numericCenterY";
      this.numericCenterY.Size = new System.Drawing.Size(158, 29);
      this.numericCenterY.TabIndex = 26;
      this.numericCenterY.ValueChanged += new System.EventHandler(this.numericCenterY_ValueChanged);
      // 
      // numericCenterX
      // 
      this.numericCenterX.DecimalPlaces = 2;
      this.numericCenterX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericCenterX.Location = new System.Drawing.Point(31, 277);
      this.numericCenterX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numericCenterX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.numericCenterX.Name = "numericCenterX";
      this.numericCenterX.Size = new System.Drawing.Size(158, 29);
      this.numericCenterX.TabIndex = 25;
      this.numericCenterX.ValueChanged += new System.EventHandler(this.numericCenterX_ValueChanged);
      // 
      // buttonPalett
      // 
      this.buttonPalett.Location = new System.Drawing.Point(3, 214);
      this.buttonPalett.Name = "buttonPalett";
      this.buttonPalett.Size = new System.Drawing.Size(186, 29);
      this.buttonPalett.TabIndex = 24;
      this.buttonPalett.Text = "Väripaletti";
      this.buttonPalett.UseVisualStyleBackColor = true;
      this.buttonPalett.Click += new System.EventHandler(this.buttonPalett_Click);
      // 
      // checkBoxFilter
      // 
      this.checkBoxFilter.AutoSize = true;
      this.checkBoxFilter.Location = new System.Drawing.Point(3, 618);
      this.checkBoxFilter.Name = "checkBoxFilter";
      this.checkBoxFilter.Size = new System.Drawing.Size(196, 28);
      this.checkBoxFilter.TabIndex = 23;
      this.checkBoxFilter.Text = "Reunanpehmennys";
      this.checkBoxFilter.UseVisualStyleBackColor = true;
      this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.checkBoxFilter_CheckedChanged);
      // 
      // checkBoxInterpolation
      // 
      this.checkBoxInterpolation.AutoSize = true;
      this.checkBoxInterpolation.Location = new System.Drawing.Point(3, 584);
      this.checkBoxInterpolation.Name = "checkBoxInterpolation";
      this.checkBoxInterpolation.Size = new System.Drawing.Size(130, 28);
      this.checkBoxInterpolation.TabIndex = 22;
      this.checkBoxInterpolation.Text = "Interpolaatio";
      this.checkBoxInterpolation.UseVisualStyleBackColor = true;
      this.checkBoxInterpolation.CheckedChanged += new System.EventHandler(this.checkBoxInterpolation_CheckedChanged);
      // 
      // labelIteration
      // 
      this.labelIteration.AutoSize = true;
      this.labelIteration.Location = new System.Drawing.Point(3, 519);
      this.labelIteration.Name = "labelIteration";
      this.labelIteration.Size = new System.Drawing.Size(146, 24);
      this.labelIteration.TabIndex = 20;
      this.labelIteration.Text = "Monimutkaisuus";
      // 
      // labelSizeY
      // 
      this.labelSizeY.AutoSize = true;
      this.labelSizeY.Location = new System.Drawing.Point(3, 489);
      this.labelSizeY.Name = "labelSizeY";
      this.labelSizeY.Size = new System.Drawing.Size(22, 24);
      this.labelSizeY.TabIndex = 17;
      this.labelSizeY.Text = "Y";
      // 
      // labelSizeX
      // 
      this.labelSizeX.AutoSize = true;
      this.labelSizeX.Location = new System.Drawing.Point(3, 459);
      this.labelSizeX.Name = "labelSizeX";
      this.labelSizeX.Size = new System.Drawing.Size(24, 24);
      this.labelSizeX.TabIndex = 16;
      this.labelSizeX.Text = "X";
      // 
      // labelSize
      // 
      this.labelSize.AutoSize = true;
      this.labelSize.Location = new System.Drawing.Point(3, 429);
      this.labelSize.Name = "labelSize";
      this.labelSize.Size = new System.Drawing.Size(53, 24);
      this.labelSize.TabIndex = 15;
      this.labelSize.Text = "Koko";
      // 
      // labelZoomY
      // 
      this.labelZoomY.AutoSize = true;
      this.labelZoomY.Location = new System.Drawing.Point(3, 399);
      this.labelZoomY.Name = "labelZoomY";
      this.labelZoomY.Size = new System.Drawing.Size(22, 24);
      this.labelZoomY.TabIndex = 12;
      this.labelZoomY.Text = "Y";
      // 
      // labelZoomX
      // 
      this.labelZoomX.AutoSize = true;
      this.labelZoomX.Location = new System.Drawing.Point(3, 369);
      this.labelZoomX.Name = "labelZoomX";
      this.labelZoomX.Size = new System.Drawing.Size(24, 24);
      this.labelZoomX.TabIndex = 11;
      this.labelZoomX.Text = "X";
      // 
      // labelZoom
      // 
      this.labelZoom.AutoSize = true;
      this.labelZoom.Location = new System.Drawing.Point(3, 339);
      this.labelZoom.Name = "labelZoom";
      this.labelZoom.Size = new System.Drawing.Size(60, 24);
      this.labelZoom.TabIndex = 10;
      this.labelZoom.Text = "Zoom";
      // 
      // labelCenterY
      // 
      this.labelCenterY.AutoSize = true;
      this.labelCenterY.Location = new System.Drawing.Point(3, 309);
      this.labelCenterY.Name = "labelCenterY";
      this.labelCenterY.Size = new System.Drawing.Size(22, 24);
      this.labelCenterY.TabIndex = 7;
      this.labelCenterY.Text = "Y";
      // 
      // labelCenterX
      // 
      this.labelCenterX.AutoSize = true;
      this.labelCenterX.Location = new System.Drawing.Point(3, 279);
      this.labelCenterX.Name = "labelCenterX";
      this.labelCenterX.Size = new System.Drawing.Size(24, 24);
      this.labelCenterX.TabIndex = 6;
      this.labelCenterX.Text = "X";
      // 
      // labelCenter
      // 
      this.labelCenter.AutoSize = true;
      this.labelCenter.Location = new System.Drawing.Point(3, 249);
      this.labelCenter.Name = "labelCenter";
      this.labelCenter.Size = new System.Drawing.Size(94, 24);
      this.labelCenter.TabIndex = 5;
      this.labelCenter.Text = "Keskipiste";
      // 
      // labelInfo
      // 
      this.labelInfo.AutoSize = true;
      this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelInfo.Location = new System.Drawing.Point(3, 177);
      this.labelInfo.Name = "labelInfo";
      this.labelInfo.Size = new System.Drawing.Size(135, 31);
      this.labelInfo.TabIndex = 4;
      this.labelInfo.Text = "Asetukset";
      // 
      // buttonSaveInfo
      // 
      this.buttonSaveInfo.Location = new System.Drawing.Point(9, 121);
      this.buttonSaveInfo.Name = "buttonSaveInfo";
      this.buttonSaveInfo.Size = new System.Drawing.Size(188, 31);
      this.buttonSaveInfo.TabIndex = 3;
      this.buttonSaveInfo.Text = "Tallenna tiedot";
      this.buttonSaveInfo.UseVisualStyleBackColor = true;
      this.buttonSaveInfo.Click += new System.EventHandler(this.buttonSaveInfo_Click);
      // 
      // buttonSaveImage
      // 
      this.buttonSaveImage.Location = new System.Drawing.Point(9, 84);
      this.buttonSaveImage.Name = "buttonSaveImage";
      this.buttonSaveImage.Size = new System.Drawing.Size(186, 31);
      this.buttonSaveImage.TabIndex = 2;
      this.buttonSaveImage.Text = "Tallenna kuva";
      this.buttonSaveImage.UseVisualStyleBackColor = true;
      this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
      // 
      // buttonRender
      // 
      this.buttonRender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonRender.Location = new System.Drawing.Point(9, 12);
      this.buttonRender.Name = "buttonRender";
      this.buttonRender.Size = new System.Drawing.Size(186, 32);
      this.buttonRender.TabIndex = 1;
      this.buttonRender.Text = "Piirrä";
      this.buttonRender.UseVisualStyleBackColor = true;
      this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(799, 800);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // FractalForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
      this.ClientSize = new System.Drawing.Size(1000, 800);
      this.ControlBox = false;
      this.Controls.Add(this.splitContainer1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FractalForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Activated += new System.EventHandler(this.MDIChild_Activated);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.MDIChild_Closing);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericNewton)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericControlY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericControlX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericIteration)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericSizeY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericSizeX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericZoomY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericZoomX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericCenterY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericCenterX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private void MDIChild_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      //Destroy the corresponding Tabpage when closing MDI child form
      this.TabPage.Dispose();

      //If no Tabpage left
      if (!TabCtrl.HasChildren)
      {
        TabCtrl.Visible = false;
      }
    }

    private void MDIChild_Activated(object sender, System.EventArgs e)
    {
      //Activate the corresponding Tabpage
      TabCtrl.SelectedTab = TabPage;

      if (!TabCtrl.Visible)
      {
        TabCtrl.Visible = true;
      }
    }
    private SplitContainer splitContainer1;
    private Button buttonRender;
    private Button buttonSaveInfo;
    private Button buttonSaveImage;
    private Label labelCenterY;
    private Label labelCenterX;
    private Label labelCenter;
    private Label labelInfo;
    private Label labelZoomY;
    private Label labelZoomX;
    private Label labelZoom;
    private Label labelSizeY;
    private Label labelSizeX;
    private Label labelSize;
    private Label labelIteration;
    private CheckBox checkBoxInterpolation;
    private CheckBox checkBoxFilter;
    private Button buttonPalett;
    private NumericUpDown numericIteration;
    private NumericUpDown numericSizeY;
    private NumericUpDown numericSizeX;
    private NumericUpDown numericZoomY;
    private NumericUpDown numericZoomX;
    private NumericUpDown numericCenterY;
    private NumericUpDown numericCenterX;
    private CheckBox checkBoxPreview;
    private NumericUpDown numericNewton;
    private Label labelNewton;
    private NumericUpDown numericControlY;
    private NumericUpDown numericControlX;
    private Label labelControlY;
    private Label labelControlX;
    private Label labelExtraInfo;
    private PictureBox pictureBox1;
  }
}