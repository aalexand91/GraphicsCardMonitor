namespace GraphicsCardMonitor
{
    partial class GraphicsCardMonitorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsCardMonitorForm));
            this.CoreCountLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.VBiosLabel = new System.Windows.Forms.Label();
            this.VirtualRamLabel = new System.Windows.Forms.Label();
            this.PhysicalRamLabel = new System.Windows.Forms.Label();
            this.CardInfoLabel = new System.Windows.Forms.Label();
            this.PciInternalIdLabel = new System.Windows.Forms.Label();
            this.PciRevIDLabel = new System.Windows.Forms.Label();
            this.GraphicsCardComboBox = new System.Windows.Forms.ComboBox();
            this.PciGroupBox = new System.Windows.Forms.GroupBox();
            this.PciExternalIdTextBox = new System.Windows.Forms.TextBox();
            this.PciSubsystemTextBox = new System.Windows.Forms.TextBox();
            this.PciExternalIdLabel = new System.Windows.Forms.Label();
            this.PciSubsystemIdLabel = new System.Windows.Forms.Label();
            this.PciRevTextBox = new System.Windows.Forms.TextBox();
            this.PciInternalIdTextBox = new System.Windows.Forms.TextBox();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.BusIdTextBox = new System.Windows.Forms.TextBox();
            this.CoreTempTextBox = new System.Windows.Forms.TextBox();
            this.GpuCoresTextBox = new System.Windows.Forms.TextBox();
            this.CoreTempLabel = new System.Windows.Forms.Label();
            this.VirtualRamTextBox = new System.Windows.Forms.TextBox();
            this.PhysRamTextBox = new System.Windows.Forms.TextBox();
            this.VbiosTextBox = new System.Windows.Forms.TextBox();
            this.SerialNumTextBox = new System.Windows.Forms.TextBox();
            this.BusIdLabel = new System.Windows.Forms.Label();
            this.GraphicsBoostClockSpeedTextBox = new System.Windows.Forms.TextBox();
            this.GraphicsBoostClockSpeedLabel = new System.Windows.Forms.Label();
            this.GraphicsBaseClockSpeedTextBox = new System.Windows.Forms.TextBox();
            this.GraphicsCurrentClockSpeedTextBox = new System.Windows.Forms.TextBox();
            this.GraphicsBaseClockSpeedLabel = new System.Windows.Forms.Label();
            this.GraphicsCurrentClockSpeedLabel = new System.Windows.Forms.Label();
            this.PerfStateLabel = new System.Windows.Forms.Label();
            this.BaseVoltage1Label = new System.Windows.Forms.Label();
            this.BaseVoltage2Label = new System.Windows.Forms.Label();
            this.PerformanceGroupBox = new System.Windows.Forms.GroupBox();
            this.BaseVoltageTextBox4 = new System.Windows.Forms.TextBox();
            this.BaseVoltageLabel4 = new System.Windows.Forms.Label();
            this.BaseVoltageTextBox3 = new System.Windows.Forms.TextBox();
            this.BaseVoltageLabel3 = new System.Windows.Forms.Label();
            this.BaseVoltageTextBox2 = new System.Windows.Forms.TextBox();
            this.BaseVoltageTextBox1 = new System.Windows.Forms.TextBox();
            this.PerfStateTextBox = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExitToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ClockFreqGroupBox = new System.Windows.Forms.GroupBox();
            this.MemoryBoostClockSpeedTextBox = new System.Windows.Forms.TextBox();
            this.MemoryBaseClockSpeedTextBox = new System.Windows.Forms.TextBox();
            this.MemoryBoostClockSpeedLabel = new System.Windows.Forms.Label();
            this.MemoryCurrentClockSpeedTextBox = new System.Windows.Forms.TextBox();
            this.MemoryBaseClockSpeedLabel = new System.Windows.Forms.Label();
            this.MemoryCurrentClockSpeedLabel = new System.Windows.Forms.Label();
            this.serialNumBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.vbiosBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.physRamBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.vRamBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.numCoresBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.busIdBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.coreTempBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pciInternalBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pciRevBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pciSubsystemBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pciExternalBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.graphicsCurrentClockSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.graphicsBaseClockSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.graphicsBoostClockSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.memoryCurrentClockSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.memoryBaseClockSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.memoryBoostClockSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.perfStateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.baseVoltage1BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.baseVoltage2BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.baseVoltage3BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.baseVoltage4BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.FanSpeedLabel = new System.Windows.Forms.Label();
            this.FanSpeedTextBox = new System.Windows.Forms.TextBox();
            this.fanSpeedBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PciGroupBox.SuspendLayout();
            this.GeneralGroupBox.SuspendLayout();
            this.PerformanceGroupBox.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.ClockFreqGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CoreCountLabel
            // 
            this.CoreCountLabel.AutoSize = true;
            this.CoreCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreCountLabel.Location = new System.Drawing.Point(6, 126);
            this.CoreCountLabel.Name = "CoreCountLabel";
            this.CoreCountLabel.Size = new System.Drawing.Size(61, 13);
            this.CoreCountLabel.TabIndex = 0;
            this.CoreCountLabel.Text = "# Of Cores:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(12, 31);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(131, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Select Graphics Card:";
            // 
            // VBiosLabel
            // 
            this.VBiosLabel.AutoSize = true;
            this.VBiosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VBiosLabel.Location = new System.Drawing.Point(6, 47);
            this.VBiosLabel.Name = "VBiosLabel";
            this.VBiosLabel.Size = new System.Drawing.Size(63, 13);
            this.VBiosLabel.TabIndex = 2;
            this.VBiosLabel.Text = "VBIOS Info:";
            // 
            // VirtualRamLabel
            // 
            this.VirtualRamLabel.AutoSize = true;
            this.VirtualRamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VirtualRamLabel.Location = new System.Drawing.Point(6, 100);
            this.VirtualRamLabel.Name = "VirtualRamLabel";
            this.VirtualRamLabel.Size = new System.Drawing.Size(112, 13);
            this.VirtualRamLabel.TabIndex = 3;
            this.VirtualRamLabel.Text = "Virtual RAM Size (KB):";
            // 
            // PhysicalRamLabel
            // 
            this.PhysicalRamLabel.AutoSize = true;
            this.PhysicalRamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhysicalRamLabel.Location = new System.Drawing.Point(6, 73);
            this.PhysicalRamLabel.Name = "PhysicalRamLabel";
            this.PhysicalRamLabel.Size = new System.Drawing.Size(122, 13);
            this.PhysicalRamLabel.TabIndex = 4;
            this.PhysicalRamLabel.Text = "Physical RAM Size (KB):";
            // 
            // CardInfoLabel
            // 
            this.CardInfoLabel.AutoSize = true;
            this.CardInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardInfoLabel.Location = new System.Drawing.Point(6, 24);
            this.CardInfoLabel.Name = "CardInfoLabel";
            this.CardInfoLabel.Size = new System.Drawing.Size(76, 13);
            this.CardInfoLabel.TabIndex = 5;
            this.CardInfoLabel.Text = "Serial Number:";
            // 
            // PciInternalIdLabel
            // 
            this.PciInternalIdLabel.AutoSize = true;
            this.PciInternalIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciInternalIdLabel.Location = new System.Drawing.Point(17, 20);
            this.PciInternalIdLabel.Name = "PciInternalIdLabel";
            this.PciInternalIdLabel.Size = new System.Drawing.Size(59, 13);
            this.PciInternalIdLabel.TabIndex = 6;
            this.PciInternalIdLabel.Text = "Internal ID:";
            // 
            // PciRevIDLabel
            // 
            this.PciRevIDLabel.AutoSize = true;
            this.PciRevIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciRevIDLabel.Location = new System.Drawing.Point(32, 47);
            this.PciRevIDLabel.Name = "PciRevIDLabel";
            this.PciRevIDLabel.Size = new System.Drawing.Size(44, 13);
            this.PciRevIDLabel.TabIndex = 7;
            this.PciRevIDLabel.Text = "Rev ID:";
            // 
            // GraphicsCardComboBox
            // 
            this.GraphicsCardComboBox.FormattingEnabled = true;
            this.GraphicsCardComboBox.Location = new System.Drawing.Point(149, 28);
            this.GraphicsCardComboBox.Name = "GraphicsCardComboBox";
            this.GraphicsCardComboBox.Size = new System.Drawing.Size(146, 21);
            this.GraphicsCardComboBox.TabIndex = 8;
            this.GraphicsCardComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphicsCardComboBox_SelectedIndexChanged);
            // 
            // PciGroupBox
            // 
            this.PciGroupBox.Controls.Add(this.PciExternalIdTextBox);
            this.PciGroupBox.Controls.Add(this.PciSubsystemTextBox);
            this.PciGroupBox.Controls.Add(this.PciExternalIdLabel);
            this.PciGroupBox.Controls.Add(this.PciSubsystemIdLabel);
            this.PciGroupBox.Controls.Add(this.PciRevTextBox);
            this.PciGroupBox.Controls.Add(this.PciInternalIdTextBox);
            this.PciGroupBox.Controls.Add(this.PciInternalIdLabel);
            this.PciGroupBox.Controls.Add(this.PciRevIDLabel);
            this.PciGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciGroupBox.Location = new System.Drawing.Point(316, 57);
            this.PciGroupBox.Name = "PciGroupBox";
            this.PciGroupBox.Size = new System.Drawing.Size(194, 176);
            this.PciGroupBox.TabIndex = 9;
            this.PciGroupBox.TabStop = false;
            this.PciGroupBox.Text = "PCI Information";
            // 
            // PciExternalIdTextBox
            // 
            this.PciExternalIdTextBox.Enabled = false;
            this.PciExternalIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciExternalIdTextBox.Location = new System.Drawing.Point(82, 100);
            this.PciExternalIdTextBox.Name = "PciExternalIdTextBox";
            this.PciExternalIdTextBox.Size = new System.Drawing.Size(105, 20);
            this.PciExternalIdTextBox.TabIndex = 12;
            this.PciExternalIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PciSubsystemTextBox
            // 
            this.PciSubsystemTextBox.Enabled = false;
            this.PciSubsystemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciSubsystemTextBox.Location = new System.Drawing.Point(82, 70);
            this.PciSubsystemTextBox.Name = "PciSubsystemTextBox";
            this.PciSubsystemTextBox.Size = new System.Drawing.Size(105, 20);
            this.PciSubsystemTextBox.TabIndex = 11;
            this.PciSubsystemTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PciExternalIdLabel
            // 
            this.PciExternalIdLabel.AutoSize = true;
            this.PciExternalIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciExternalIdLabel.Location = new System.Drawing.Point(14, 103);
            this.PciExternalIdLabel.Name = "PciExternalIdLabel";
            this.PciExternalIdLabel.Size = new System.Drawing.Size(62, 13);
            this.PciExternalIdLabel.TabIndex = 10;
            this.PciExternalIdLabel.Text = "External ID:";
            // 
            // PciSubsystemIdLabel
            // 
            this.PciSubsystemIdLabel.AutoSize = true;
            this.PciSubsystemIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciSubsystemIdLabel.Location = new System.Drawing.Point(6, 73);
            this.PciSubsystemIdLabel.Name = "PciSubsystemIdLabel";
            this.PciSubsystemIdLabel.Size = new System.Drawing.Size(75, 13);
            this.PciSubsystemIdLabel.TabIndex = 9;
            this.PciSubsystemIdLabel.Text = "Subsystem ID:";
            // 
            // PciRevTextBox
            // 
            this.PciRevTextBox.Enabled = false;
            this.PciRevTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciRevTextBox.Location = new System.Drawing.Point(82, 44);
            this.PciRevTextBox.Name = "PciRevTextBox";
            this.PciRevTextBox.Size = new System.Drawing.Size(105, 20);
            this.PciRevTextBox.TabIndex = 8;
            this.PciRevTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PciInternalIdTextBox
            // 
            this.PciInternalIdTextBox.Enabled = false;
            this.PciInternalIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciInternalIdTextBox.Location = new System.Drawing.Point(82, 17);
            this.PciInternalIdTextBox.Name = "PciInternalIdTextBox";
            this.PciInternalIdTextBox.Size = new System.Drawing.Size(105, 20);
            this.PciInternalIdTextBox.TabIndex = 7;
            this.PciInternalIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.Controls.Add(this.FanSpeedTextBox);
            this.GeneralGroupBox.Controls.Add(this.FanSpeedLabel);
            this.GeneralGroupBox.Controls.Add(this.BusIdTextBox);
            this.GeneralGroupBox.Controls.Add(this.CoreTempTextBox);
            this.GeneralGroupBox.Controls.Add(this.GpuCoresTextBox);
            this.GeneralGroupBox.Controls.Add(this.CoreTempLabel);
            this.GeneralGroupBox.Controls.Add(this.VirtualRamTextBox);
            this.GeneralGroupBox.Controls.Add(this.PhysRamTextBox);
            this.GeneralGroupBox.Controls.Add(this.VbiosTextBox);
            this.GeneralGroupBox.Controls.Add(this.SerialNumTextBox);
            this.GeneralGroupBox.Controls.Add(this.CardInfoLabel);
            this.GeneralGroupBox.Controls.Add(this.VBiosLabel);
            this.GeneralGroupBox.Controls.Add(this.VirtualRamLabel);
            this.GeneralGroupBox.Controls.Add(this.PhysicalRamLabel);
            this.GeneralGroupBox.Controls.Add(this.CoreCountLabel);
            this.GeneralGroupBox.Controls.Add(this.BusIdLabel);
            this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralGroupBox.Location = new System.Drawing.Point(15, 55);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(295, 178);
            this.GeneralGroupBox.TabIndex = 10;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "General Information";
            // 
            // BusIdTextBox
            // 
            this.BusIdTextBox.Enabled = false;
            this.BusIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusIdTextBox.Location = new System.Drawing.Point(235, 122);
            this.BusIdTextBox.Name = "BusIdTextBox";
            this.BusIdTextBox.Size = new System.Drawing.Size(52, 20);
            this.BusIdTextBox.TabIndex = 25;
            this.BusIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoreTempTextBox
            // 
            this.CoreTempTextBox.Enabled = false;
            this.CoreTempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreTempTextBox.Location = new System.Drawing.Point(86, 152);
            this.CoreTempTextBox.Name = "CoreTempTextBox";
            this.CoreTempTextBox.Size = new System.Drawing.Size(42, 20);
            this.CoreTempTextBox.TabIndex = 0;
            this.CoreTempTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GpuCoresTextBox
            // 
            this.GpuCoresTextBox.Enabled = false;
            this.GpuCoresTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpuCoresTextBox.Location = new System.Drawing.Point(86, 123);
            this.GpuCoresTextBox.Name = "GpuCoresTextBox";
            this.GpuCoresTextBox.Size = new System.Drawing.Size(42, 20);
            this.GpuCoresTextBox.TabIndex = 24;
            this.GpuCoresTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoreTempLabel
            // 
            this.CoreTempLabel.AutoSize = true;
            this.CoreTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreTempLabel.Location = new System.Drawing.Point(6, 155);
            this.CoreTempLabel.Name = "CoreTempLabel";
            this.CoreTempLabel.Size = new System.Drawing.Size(74, 13);
            this.CoreTempLabel.TabIndex = 12;
            this.CoreTempLabel.Text = "GPU Core (C):";
            // 
            // VirtualRamTextBox
            // 
            this.VirtualRamTextBox.Enabled = false;
            this.VirtualRamTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VirtualRamTextBox.Location = new System.Drawing.Point(124, 96);
            this.VirtualRamTextBox.Name = "VirtualRamTextBox";
            this.VirtualRamTextBox.Size = new System.Drawing.Size(165, 20);
            this.VirtualRamTextBox.TabIndex = 22;
            this.VirtualRamTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PhysRamTextBox
            // 
            this.PhysRamTextBox.Enabled = false;
            this.PhysRamTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhysRamTextBox.Location = new System.Drawing.Point(134, 70);
            this.PhysRamTextBox.Name = "PhysRamTextBox";
            this.PhysRamTextBox.Size = new System.Drawing.Size(155, 20);
            this.PhysRamTextBox.TabIndex = 21;
            this.PhysRamTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VbiosTextBox
            // 
            this.VbiosTextBox.Enabled = false;
            this.VbiosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VbiosTextBox.Location = new System.Drawing.Point(75, 44);
            this.VbiosTextBox.Name = "VbiosTextBox";
            this.VbiosTextBox.Size = new System.Drawing.Size(214, 20);
            this.VbiosTextBox.TabIndex = 20;
            this.VbiosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SerialNumTextBox
            // 
            this.SerialNumTextBox.Enabled = false;
            this.SerialNumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialNumTextBox.Location = new System.Drawing.Point(88, 19);
            this.SerialNumTextBox.Name = "SerialNumTextBox";
            this.SerialNumTextBox.Size = new System.Drawing.Size(201, 20);
            this.SerialNumTextBox.TabIndex = 6;
            this.SerialNumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BusIdLabel
            // 
            this.BusIdLabel.AutoSize = true;
            this.BusIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusIdLabel.Location = new System.Drawing.Point(187, 126);
            this.BusIdLabel.Name = "BusIdLabel";
            this.BusIdLabel.Size = new System.Drawing.Size(42, 13);
            this.BusIdLabel.TabIndex = 11;
            this.BusIdLabel.Text = "Bus ID:";
            // 
            // GraphicsBoostClockSpeedTextBox
            // 
            this.GraphicsBoostClockSpeedTextBox.Enabled = false;
            this.GraphicsBoostClockSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsBoostClockSpeedTextBox.Location = new System.Drawing.Point(196, 65);
            this.GraphicsBoostClockSpeedTextBox.Name = "GraphicsBoostClockSpeedTextBox";
            this.GraphicsBoostClockSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.GraphicsBoostClockSpeedTextBox.TabIndex = 31;
            this.GraphicsBoostClockSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GraphicsBoostClockSpeedLabel
            // 
            this.GraphicsBoostClockSpeedLabel.AutoSize = true;
            this.GraphicsBoostClockSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsBoostClockSpeedLabel.Location = new System.Drawing.Point(6, 68);
            this.GraphicsBoostClockSpeedLabel.Name = "GraphicsBoostClockSpeedLabel";
            this.GraphicsBoostClockSpeedLabel.Size = new System.Drawing.Size(177, 13);
            this.GraphicsBoostClockSpeedLabel.TabIndex = 30;
            this.GraphicsBoostClockSpeedLabel.Text = "Graphics Boost Clock Speed (MHz):";
            // 
            // GraphicsBaseClockSpeedTextBox
            // 
            this.GraphicsBaseClockSpeedTextBox.Enabled = false;
            this.GraphicsBaseClockSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsBaseClockSpeedTextBox.Location = new System.Drawing.Point(196, 39);
            this.GraphicsBaseClockSpeedTextBox.Name = "GraphicsBaseClockSpeedTextBox";
            this.GraphicsBaseClockSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.GraphicsBaseClockSpeedTextBox.TabIndex = 29;
            this.GraphicsBaseClockSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GraphicsCurrentClockSpeedTextBox
            // 
            this.GraphicsCurrentClockSpeedTextBox.Enabled = false;
            this.GraphicsCurrentClockSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsCurrentClockSpeedTextBox.Location = new System.Drawing.Point(196, 13);
            this.GraphicsCurrentClockSpeedTextBox.Name = "GraphicsCurrentClockSpeedTextBox";
            this.GraphicsCurrentClockSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.GraphicsCurrentClockSpeedTextBox.TabIndex = 28;
            this.GraphicsCurrentClockSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GraphicsBaseClockSpeedLabel
            // 
            this.GraphicsBaseClockSpeedLabel.AutoSize = true;
            this.GraphicsBaseClockSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsBaseClockSpeedLabel.Location = new System.Drawing.Point(6, 42);
            this.GraphicsBaseClockSpeedLabel.Name = "GraphicsBaseClockSpeedLabel";
            this.GraphicsBaseClockSpeedLabel.Size = new System.Drawing.Size(174, 13);
            this.GraphicsBaseClockSpeedLabel.TabIndex = 27;
            this.GraphicsBaseClockSpeedLabel.Text = "Graphics Base Clock Speed (MHz):";
            // 
            // GraphicsCurrentClockSpeedLabel
            // 
            this.GraphicsCurrentClockSpeedLabel.AutoSize = true;
            this.GraphicsCurrentClockSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsCurrentClockSpeedLabel.Location = new System.Drawing.Point(6, 16);
            this.GraphicsCurrentClockSpeedLabel.Name = "GraphicsCurrentClockSpeedLabel";
            this.GraphicsCurrentClockSpeedLabel.Size = new System.Drawing.Size(184, 13);
            this.GraphicsCurrentClockSpeedLabel.TabIndex = 26;
            this.GraphicsCurrentClockSpeedLabel.Text = "Graphics Current Clock Speed (MHz):";
            // 
            // PerfStateLabel
            // 
            this.PerfStateLabel.AutoSize = true;
            this.PerfStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerfStateLabel.Location = new System.Drawing.Point(6, 23);
            this.PerfStateLabel.Name = "PerfStateLabel";
            this.PerfStateLabel.Size = new System.Drawing.Size(35, 13);
            this.PerfStateLabel.TabIndex = 16;
            this.PerfStateLabel.Text = "State:";
            // 
            // BaseVoltage1Label
            // 
            this.BaseVoltage1Label.AutoSize = true;
            this.BaseVoltage1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltage1Label.Location = new System.Drawing.Point(2, 50);
            this.BaseVoltage1Label.Name = "BaseVoltage1Label";
            this.BaseVoltage1Label.Size = new System.Drawing.Size(65, 13);
            this.BaseVoltage1Label.TabIndex = 17;
            this.BaseVoltage1Label.Text = "Vbase 1 (V):";
            // 
            // BaseVoltage2Label
            // 
            this.BaseVoltage2Label.AutoSize = true;
            this.BaseVoltage2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltage2Label.Location = new System.Drawing.Point(2, 76);
            this.BaseVoltage2Label.Name = "BaseVoltage2Label";
            this.BaseVoltage2Label.Size = new System.Drawing.Size(65, 13);
            this.BaseVoltage2Label.TabIndex = 18;
            this.BaseVoltage2Label.Text = "Vbase 2 (V):";
            // 
            // PerformanceGroupBox
            // 
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltageTextBox4);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltageLabel4);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltageTextBox3);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltageLabel3);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltageTextBox2);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltage2Label);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltageTextBox1);
            this.PerformanceGroupBox.Controls.Add(this.BaseVoltage1Label);
            this.PerformanceGroupBox.Controls.Add(this.PerfStateTextBox);
            this.PerformanceGroupBox.Controls.Add(this.PerfStateLabel);
            this.PerformanceGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerformanceGroupBox.Location = new System.Drawing.Point(335, 239);
            this.PerformanceGroupBox.Name = "PerformanceGroupBox";
            this.PerformanceGroupBox.Size = new System.Drawing.Size(175, 173);
            this.PerformanceGroupBox.TabIndex = 19;
            this.PerformanceGroupBox.TabStop = false;
            this.PerformanceGroupBox.Text = "Performance State";
            // 
            // BaseVoltageTextBox4
            // 
            this.BaseVoltageTextBox4.Enabled = false;
            this.BaseVoltageTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltageTextBox4.Location = new System.Drawing.Point(74, 125);
            this.BaseVoltageTextBox4.Name = "BaseVoltageTextBox4";
            this.BaseVoltageTextBox4.Size = new System.Drawing.Size(71, 20);
            this.BaseVoltageTextBox4.TabIndex = 22;
            this.BaseVoltageTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseVoltageLabel4
            // 
            this.BaseVoltageLabel4.AutoSize = true;
            this.BaseVoltageLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltageLabel4.Location = new System.Drawing.Point(3, 128);
            this.BaseVoltageLabel4.Name = "BaseVoltageLabel4";
            this.BaseVoltageLabel4.Size = new System.Drawing.Size(65, 13);
            this.BaseVoltageLabel4.TabIndex = 21;
            this.BaseVoltageLabel4.Text = "Vbase 4 (V):";
            // 
            // BaseVoltageTextBox3
            // 
            this.BaseVoltageTextBox3.Enabled = false;
            this.BaseVoltageTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltageTextBox3.Location = new System.Drawing.Point(74, 99);
            this.BaseVoltageTextBox3.Name = "BaseVoltageTextBox3";
            this.BaseVoltageTextBox3.Size = new System.Drawing.Size(71, 20);
            this.BaseVoltageTextBox3.TabIndex = 20;
            this.BaseVoltageTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseVoltageLabel3
            // 
            this.BaseVoltageLabel3.AutoSize = true;
            this.BaseVoltageLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltageLabel3.Location = new System.Drawing.Point(3, 102);
            this.BaseVoltageLabel3.Name = "BaseVoltageLabel3";
            this.BaseVoltageLabel3.Size = new System.Drawing.Size(65, 13);
            this.BaseVoltageLabel3.TabIndex = 19;
            this.BaseVoltageLabel3.Text = "Vbase 3 (V):";
            // 
            // BaseVoltageTextBox2
            // 
            this.BaseVoltageTextBox2.Enabled = false;
            this.BaseVoltageTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltageTextBox2.Location = new System.Drawing.Point(73, 73);
            this.BaseVoltageTextBox2.Name = "BaseVoltageTextBox2";
            this.BaseVoltageTextBox2.Size = new System.Drawing.Size(72, 20);
            this.BaseVoltageTextBox2.TabIndex = 2;
            this.BaseVoltageTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseVoltageTextBox1
            // 
            this.BaseVoltageTextBox1.Enabled = false;
            this.BaseVoltageTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseVoltageTextBox1.Location = new System.Drawing.Point(73, 47);
            this.BaseVoltageTextBox1.Name = "BaseVoltageTextBox1";
            this.BaseVoltageTextBox1.Size = new System.Drawing.Size(72, 20);
            this.BaseVoltageTextBox1.TabIndex = 1;
            this.BaseVoltageTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PerfStateTextBox
            // 
            this.PerfStateTextBox.Enabled = false;
            this.PerfStateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerfStateTextBox.Location = new System.Drawing.Point(47, 21);
            this.PerfStateTextBox.Name = "PerfStateTextBox";
            this.PerfStateTextBox.Size = new System.Drawing.Size(98, 20);
            this.PerfStateTextBox.TabIndex = 0;
            this.PerfStateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(301, 26);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(97, 23);
            this.RefreshButton.TabIndex = 21;
            this.RefreshButton.Text = "Refresh";
            this.RefreshToolTip.SetToolTip(this.RefreshButton, "Refresh the application");
            this.ExitToolTip.SetToolTip(this.RefreshButton, "Exits the application");
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(404, 26);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(90, 23);
            this.ExitButton.TabIndex = 22;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(528, 24);
            this.MenuStrip.TabIndex = 23;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.RefreshToolStripMenuItem.Text = "Refresh (F5)";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionsToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // InstructionsToolStripMenuItem
            // 
            this.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem";
            this.InstructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.InstructionsToolStripMenuItem.Text = "Instructions";
            this.InstructionsToolStripMenuItem.Click += new System.EventHandler(this.InstructionsToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ClockFreqGroupBox
            // 
            this.ClockFreqGroupBox.Controls.Add(this.MemoryBoostClockSpeedTextBox);
            this.ClockFreqGroupBox.Controls.Add(this.MemoryBaseClockSpeedTextBox);
            this.ClockFreqGroupBox.Controls.Add(this.MemoryBoostClockSpeedLabel);
            this.ClockFreqGroupBox.Controls.Add(this.MemoryCurrentClockSpeedTextBox);
            this.ClockFreqGroupBox.Controls.Add(this.MemoryBaseClockSpeedLabel);
            this.ClockFreqGroupBox.Controls.Add(this.MemoryCurrentClockSpeedLabel);
            this.ClockFreqGroupBox.Controls.Add(this.GraphicsBoostClockSpeedTextBox);
            this.ClockFreqGroupBox.Controls.Add(this.GraphicsCurrentClockSpeedLabel);
            this.ClockFreqGroupBox.Controls.Add(this.GraphicsBoostClockSpeedLabel);
            this.ClockFreqGroupBox.Controls.Add(this.GraphicsCurrentClockSpeedTextBox);
            this.ClockFreqGroupBox.Controls.Add(this.GraphicsBaseClockSpeedTextBox);
            this.ClockFreqGroupBox.Controls.Add(this.GraphicsBaseClockSpeedLabel);
            this.ClockFreqGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClockFreqGroupBox.Location = new System.Drawing.Point(15, 239);
            this.ClockFreqGroupBox.Name = "ClockFreqGroupBox";
            this.ClockFreqGroupBox.Size = new System.Drawing.Size(307, 175);
            this.ClockFreqGroupBox.TabIndex = 24;
            this.ClockFreqGroupBox.TabStop = false;
            this.ClockFreqGroupBox.Text = "Processor Clock Frequencies";
            // 
            // MemoryBoostClockSpeedTextBox
            // 
            this.MemoryBoostClockSpeedTextBox.Enabled = false;
            this.MemoryBoostClockSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryBoostClockSpeedTextBox.Location = new System.Drawing.Point(196, 143);
            this.MemoryBoostClockSpeedTextBox.Name = "MemoryBoostClockSpeedTextBox";
            this.MemoryBoostClockSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.MemoryBoostClockSpeedTextBox.TabIndex = 37;
            this.MemoryBoostClockSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemoryBaseClockSpeedTextBox
            // 
            this.MemoryBaseClockSpeedTextBox.Enabled = false;
            this.MemoryBaseClockSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryBaseClockSpeedTextBox.Location = new System.Drawing.Point(196, 117);
            this.MemoryBaseClockSpeedTextBox.Name = "MemoryBaseClockSpeedTextBox";
            this.MemoryBaseClockSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.MemoryBaseClockSpeedTextBox.TabIndex = 36;
            this.MemoryBaseClockSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemoryBoostClockSpeedLabel
            // 
            this.MemoryBoostClockSpeedLabel.AutoSize = true;
            this.MemoryBoostClockSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryBoostClockSpeedLabel.Location = new System.Drawing.Point(6, 146);
            this.MemoryBoostClockSpeedLabel.Name = "MemoryBoostClockSpeedLabel";
            this.MemoryBoostClockSpeedLabel.Size = new System.Drawing.Size(172, 13);
            this.MemoryBoostClockSpeedLabel.TabIndex = 35;
            this.MemoryBoostClockSpeedLabel.Text = "Memory Boost Clock Speed (MHz):";
            // 
            // MemoryCurrentClockSpeedTextBox
            // 
            this.MemoryCurrentClockSpeedTextBox.Enabled = false;
            this.MemoryCurrentClockSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryCurrentClockSpeedTextBox.Location = new System.Drawing.Point(196, 91);
            this.MemoryCurrentClockSpeedTextBox.Name = "MemoryCurrentClockSpeedTextBox";
            this.MemoryCurrentClockSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.MemoryCurrentClockSpeedTextBox.TabIndex = 34;
            this.MemoryCurrentClockSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemoryBaseClockSpeedLabel
            // 
            this.MemoryBaseClockSpeedLabel.AutoSize = true;
            this.MemoryBaseClockSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryBaseClockSpeedLabel.Location = new System.Drawing.Point(6, 120);
            this.MemoryBaseClockSpeedLabel.Name = "MemoryBaseClockSpeedLabel";
            this.MemoryBaseClockSpeedLabel.Size = new System.Drawing.Size(169, 13);
            this.MemoryBaseClockSpeedLabel.TabIndex = 33;
            this.MemoryBaseClockSpeedLabel.Text = "Memory Base Clock Speed (MHz):";
            // 
            // MemoryCurrentClockSpeedLabel
            // 
            this.MemoryCurrentClockSpeedLabel.AutoSize = true;
            this.MemoryCurrentClockSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryCurrentClockSpeedLabel.Location = new System.Drawing.Point(6, 94);
            this.MemoryCurrentClockSpeedLabel.Name = "MemoryCurrentClockSpeedLabel";
            this.MemoryCurrentClockSpeedLabel.Size = new System.Drawing.Size(179, 13);
            this.MemoryCurrentClockSpeedLabel.TabIndex = 32;
            this.MemoryCurrentClockSpeedLabel.Text = "Memory Current Clock Speed (MHz):";
            // 
            // serialNumBackgroundWorker
            // 
            this.serialNumBackgroundWorker.WorkerSupportsCancellation = true;
            this.serialNumBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serialNumBackgroundWorker_DoWork);
            this.serialNumBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.serialNumBackgroundWorker_RunWorkerCompleted);
            // 
            // vbiosBackgroundWorker
            // 
            this.vbiosBackgroundWorker.WorkerSupportsCancellation = true;
            this.vbiosBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.vbiosBackgroundWorker_DoWork);
            this.vbiosBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.vbiosBackgroundWorker_RunWorkerCompleted);
            // 
            // physRamBackgroundWorker
            // 
            this.physRamBackgroundWorker.WorkerSupportsCancellation = true;
            this.physRamBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.physRamBackgroundWorker_DoWork);
            this.physRamBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.physRamBackgroundWorker_RunWorkerCompleted);
            // 
            // vRamBackgroundWorker
            // 
            this.vRamBackgroundWorker.WorkerSupportsCancellation = true;
            this.vRamBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.vRamBackgroundWorker_DoWork);
            this.vRamBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.vRamBackgroundWorker_RunWorkerCompleted);
            // 
            // numCoresBackgroundWorker
            // 
            this.numCoresBackgroundWorker.WorkerSupportsCancellation = true;
            this.numCoresBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.numCoresBackgroundWorker_DoWork);
            this.numCoresBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.numCoresBackgroundWorker_RunWorkerCompleted);
            // 
            // busIdBackgroundWorker
            // 
            this.busIdBackgroundWorker.WorkerSupportsCancellation = true;
            this.busIdBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.busIdBackgroundWorker_DoWork);
            this.busIdBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.busIdBackgroundWorker_RunWorkerCompleted);
            // 
            // coreTempBackgroundWorker
            // 
            this.coreTempBackgroundWorker.WorkerSupportsCancellation = true;
            this.coreTempBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.coreTempBackgroundWorker_DoWork);
            this.coreTempBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.coreTempBackgroundWorker_RunWorkerCompleted);
            // 
            // pciInternalBackgroundWorker
            // 
            this.pciInternalBackgroundWorker.WorkerSupportsCancellation = true;
            this.pciInternalBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pciInternalBackgroundWorker_DoWork);
            this.pciInternalBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pciInternalBackgroundWorker_RunWorkerCompleted);
            // 
            // pciRevBackgroundWorker
            // 
            this.pciRevBackgroundWorker.WorkerSupportsCancellation = true;
            this.pciRevBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pciRevBackgroundWorker_DoWork);
            this.pciRevBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pciRevBackgroundWorker_RunWorkerCompleted);
            // 
            // pciSubsystemBackgroundWorker
            // 
            this.pciSubsystemBackgroundWorker.WorkerSupportsCancellation = true;
            this.pciSubsystemBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pciSubsystemBackgroundWorker_DoWork);
            this.pciSubsystemBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pciSubsystemBackgroundWorker_RunWorkerCompleted);
            // 
            // pciExternalBackgroundWorker
            // 
            this.pciExternalBackgroundWorker.WorkerSupportsCancellation = true;
            this.pciExternalBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pciExternalBackgroundWorker_DoWork);
            this.pciExternalBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pciExternalBackgroundWorker_RunWorkerCompleted);
            // 
            // graphicsCurrentClockSpeedBackgroundWorker
            // 
            this.graphicsCurrentClockSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.graphicsCurrentClockSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.graphicsCurrentClockSpeedBackgroundWorker_DoWork);
            this.graphicsCurrentClockSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.graphicsCurrentClockSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // graphicsBaseClockSpeedBackgroundWorker
            // 
            this.graphicsBaseClockSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.graphicsBaseClockSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.graphicsBaseClockSpeedBackgroundWorker_DoWork);
            this.graphicsBaseClockSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.graphicsBaseClockSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // graphicsBoostClockSpeedBackgroundWorker
            // 
            this.graphicsBoostClockSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.graphicsBoostClockSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.graphicsBoostClockSpeedBackgroundWorker_DoWork);
            this.graphicsBoostClockSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.graphicsBoostClockSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // memoryCurrentClockSpeedBackgroundWorker
            // 
            this.memoryCurrentClockSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.memoryCurrentClockSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.memoryCurrentClockSpeedBackgroundWorker_DoWork);
            this.memoryCurrentClockSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.memoryCurrentClockSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // memoryBaseClockSpeedBackgroundWorker
            // 
            this.memoryBaseClockSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.memoryBaseClockSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.memoryBaseClockSpeedBackgroundWorker_DoWork);
            this.memoryBaseClockSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.memoryBaseClockSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // memoryBoostClockSpeedBackgroundWorker
            // 
            this.memoryBoostClockSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.memoryBoostClockSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.memoryBoostClockSpeedBackgroundWorker_DoWork);
            this.memoryBoostClockSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.memoryBoostClockSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // perfStateBackgroundWorker
            // 
            this.perfStateBackgroundWorker.WorkerSupportsCancellation = true;
            this.perfStateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.perfStateBackgroundWorker_DoWork);
            this.perfStateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.perfStateBackgroundWorker_RunWorkerCompleted);
            // 
            // baseVoltage1BackgroundWorker
            // 
            this.baseVoltage1BackgroundWorker.WorkerSupportsCancellation = true;
            this.baseVoltage1BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.baseVoltage1BackgroundWorker_DoWork);
            this.baseVoltage1BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.baseVoltage1BackgroundWorker_RunWorkerCompleted);
            // 
            // baseVoltage2BackgroundWorker
            // 
            this.baseVoltage2BackgroundWorker.WorkerSupportsCancellation = true;
            this.baseVoltage2BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.baseVoltage2BackgroundWorker_DoWork);
            this.baseVoltage2BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.baseVoltage2BackgroundWorker_RunWorkerCompleted);
            // 
            // baseVoltage3BackgroundWorker
            // 
            this.baseVoltage3BackgroundWorker.WorkerSupportsCancellation = true;
            this.baseVoltage3BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.baseVoltage3BackgroundWorker_DoWork);
            this.baseVoltage3BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.baseVoltage3BackgroundWorker_RunWorkerCompleted);
            // 
            // baseVoltage4BackgroundWorker
            // 
            this.baseVoltage4BackgroundWorker.WorkerSupportsCancellation = true;
            this.baseVoltage4BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.baseVoltage4BackgroundWorker_DoWork);
            this.baseVoltage4BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.baseVoltage4BackgroundWorker_RunWorkerCompleted);
            // 
            // FanSpeedLabel
            // 
            this.FanSpeedLabel.AutoSize = true;
            this.FanSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FanSpeedLabel.Location = new System.Drawing.Point(134, 155);
            this.FanSpeedLabel.Name = "FanSpeedLabel";
            this.FanSpeedLabel.Size = new System.Drawing.Size(95, 13);
            this.FanSpeedLabel.TabIndex = 26;
            this.FanSpeedLabel.Text = "Fan Speed (RPM):";
            // 
            // FanSpeedTextBox
            // 
            this.FanSpeedTextBox.Enabled = false;
            this.FanSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FanSpeedTextBox.Location = new System.Drawing.Point(235, 152);
            this.FanSpeedTextBox.Name = "FanSpeedTextBox";
            this.FanSpeedTextBox.Size = new System.Drawing.Size(54, 20);
            this.FanSpeedTextBox.TabIndex = 27;
            this.FanSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fanSpeedBackgroundWorker
            // 
            this.fanSpeedBackgroundWorker.WorkerSupportsCancellation = true;
            this.fanSpeedBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fanSpeedBackgroundWorker_DoWork);
            this.fanSpeedBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fanSpeedBackgroundWorker_RunWorkerCompleted);
            // 
            // GraphicsCardMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 424);
            this.Controls.Add(this.ClockFreqGroupBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.PerformanceGroupBox);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.PciGroupBox);
            this.Controls.Add(this.GraphicsCardComboBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "GraphicsCardMonitorForm";
            this.Text = "Graphics Card Monitor 1.0.0";
            this.PciGroupBox.ResumeLayout(false);
            this.PciGroupBox.PerformLayout();
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.PerformanceGroupBox.ResumeLayout(false);
            this.PerformanceGroupBox.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ClockFreqGroupBox.ResumeLayout(false);
            this.ClockFreqGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CoreCountLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label VBiosLabel;
        private System.Windows.Forms.Label VirtualRamLabel;
        private System.Windows.Forms.Label PhysicalRamLabel;
        private System.Windows.Forms.Label CardInfoLabel;
        private System.Windows.Forms.Label PciInternalIdLabel;
        private System.Windows.Forms.Label PciRevIDLabel;
        private System.Windows.Forms.ComboBox GraphicsCardComboBox;
        private System.Windows.Forms.GroupBox PciGroupBox;
        private System.Windows.Forms.TextBox PciSubsystemTextBox;
        private System.Windows.Forms.Label PciExternalIdLabel;
        private System.Windows.Forms.Label PciSubsystemIdLabel;
        private System.Windows.Forms.TextBox PciRevTextBox;
        private System.Windows.Forms.TextBox PciInternalIdTextBox;
        private System.Windows.Forms.TextBox PciExternalIdTextBox;
        private System.Windows.Forms.GroupBox GeneralGroupBox;
        private System.Windows.Forms.Label BusIdLabel;
        private System.Windows.Forms.Label CoreTempLabel;
        private System.Windows.Forms.TextBox SerialNumTextBox;
        private System.Windows.Forms.Label PerfStateLabel;
        private System.Windows.Forms.Label BaseVoltage1Label;
        private System.Windows.Forms.Label BaseVoltage2Label;
        private System.Windows.Forms.TextBox BusIdTextBox;
        private System.Windows.Forms.TextBox GpuCoresTextBox;
        private System.Windows.Forms.TextBox VirtualRamTextBox;
        private System.Windows.Forms.TextBox PhysRamTextBox;
        private System.Windows.Forms.TextBox VbiosTextBox;
        private System.Windows.Forms.GroupBox PerformanceGroupBox;
        private System.Windows.Forms.TextBox BaseVoltageTextBox1;
        private System.Windows.Forms.TextBox PerfStateTextBox;
        private System.Windows.Forms.TextBox BaseVoltageTextBox2;
        private System.Windows.Forms.TextBox CoreTempTextBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InstructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip RefreshToolTip;
        private System.Windows.Forms.ToolTip ExitToolTip;
        private System.Windows.Forms.TextBox BaseVoltageTextBox3;
        private System.Windows.Forms.Label BaseVoltageLabel3;
        private System.Windows.Forms.TextBox BaseVoltageTextBox4;
        private System.Windows.Forms.Label BaseVoltageLabel4;
        private System.Windows.Forms.TextBox GraphicsBoostClockSpeedTextBox;
        private System.Windows.Forms.Label GraphicsBoostClockSpeedLabel;
        private System.Windows.Forms.TextBox GraphicsBaseClockSpeedTextBox;
        private System.Windows.Forms.TextBox GraphicsCurrentClockSpeedTextBox;
        private System.Windows.Forms.Label GraphicsBaseClockSpeedLabel;
        private System.Windows.Forms.Label GraphicsCurrentClockSpeedLabel;
        private System.Windows.Forms.GroupBox ClockFreqGroupBox;
        private System.Windows.Forms.Label MemoryCurrentClockSpeedLabel;
        private System.Windows.Forms.Label MemoryBaseClockSpeedLabel;
        private System.Windows.Forms.TextBox MemoryBoostClockSpeedTextBox;
        private System.Windows.Forms.TextBox MemoryBaseClockSpeedTextBox;
        private System.Windows.Forms.Label MemoryBoostClockSpeedLabel;
        private System.Windows.Forms.TextBox MemoryCurrentClockSpeedTextBox;
        private System.ComponentModel.BackgroundWorker serialNumBackgroundWorker;
        private System.ComponentModel.BackgroundWorker vbiosBackgroundWorker;
        private System.ComponentModel.BackgroundWorker physRamBackgroundWorker;
        private System.ComponentModel.BackgroundWorker vRamBackgroundWorker;
        private System.ComponentModel.BackgroundWorker numCoresBackgroundWorker;
        private System.ComponentModel.BackgroundWorker busIdBackgroundWorker;
        private System.ComponentModel.BackgroundWorker coreTempBackgroundWorker;
        private System.ComponentModel.BackgroundWorker pciInternalBackgroundWorker;
        private System.ComponentModel.BackgroundWorker pciRevBackgroundWorker;
        private System.ComponentModel.BackgroundWorker pciSubsystemBackgroundWorker;
        private System.ComponentModel.BackgroundWorker pciExternalBackgroundWorker;
        private System.ComponentModel.BackgroundWorker graphicsCurrentClockSpeedBackgroundWorker;
        private System.ComponentModel.BackgroundWorker graphicsBaseClockSpeedBackgroundWorker;
        private System.ComponentModel.BackgroundWorker graphicsBoostClockSpeedBackgroundWorker;
        private System.ComponentModel.BackgroundWorker memoryCurrentClockSpeedBackgroundWorker;
        private System.ComponentModel.BackgroundWorker memoryBaseClockSpeedBackgroundWorker;
        private System.ComponentModel.BackgroundWorker memoryBoostClockSpeedBackgroundWorker;
        private System.ComponentModel.BackgroundWorker perfStateBackgroundWorker;
        private System.ComponentModel.BackgroundWorker baseVoltage1BackgroundWorker;
        private System.ComponentModel.BackgroundWorker baseVoltage2BackgroundWorker;
        private System.ComponentModel.BackgroundWorker baseVoltage3BackgroundWorker;
        private System.ComponentModel.BackgroundWorker baseVoltage4BackgroundWorker;
        private System.Windows.Forms.TextBox FanSpeedTextBox;
        private System.Windows.Forms.Label FanSpeedLabel;
        private System.ComponentModel.BackgroundWorker fanSpeedBackgroundWorker;
    }
}

