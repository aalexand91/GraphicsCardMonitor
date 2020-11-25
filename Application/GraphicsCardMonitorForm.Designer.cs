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
            this.GpuCoresTextBox = new System.Windows.Forms.TextBox();
            this.CoreVoltageTextBox = new System.Windows.Forms.TextBox();
            this.VirtualRamTextBox = new System.Windows.Forms.TextBox();
            this.PhysRamTextBox = new System.Windows.Forms.TextBox();
            this.VbiosTextBox = new System.Windows.Forms.TextBox();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.CardInfoTextBox = new System.Windows.Forms.TextBox();
            this.BusIdLabel = new System.Windows.Forms.Label();
            this.CoreTempLabel = new System.Windows.Forms.Label();
            this.MemoryTempLabel = new System.Windows.Forms.Label();
            this.SupplyTempLabel = new System.Windows.Forms.Label();
            this.BoardTempLabel = new System.Windows.Forms.Label();
            this.Max3dLabel = new System.Windows.Forms.Label();
            this.Balance3dLabel = new System.Windows.Forms.Label();
            this.HdLabel = new System.Windows.Forms.Label();
            this.VideoGroupBox = new System.Windows.Forms.GroupBox();
            this.HdTextBox = new System.Windows.Forms.TextBox();
            this.Balanced3dTextBox = new System.Windows.Forms.TextBox();
            this.Max3dTextBox = new System.Windows.Forms.TextBox();
            this.TemperatureGroupBox = new System.Windows.Forms.GroupBox();
            this.SupplyTempTextBox = new System.Windows.Forms.TextBox();
            this.MemoryTempTextBox = new System.Windows.Forms.TextBox();
            this.BoardTempTextBox = new System.Windows.Forms.TextBox();
            this.CoreTempTextBox = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExitToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ApiBackGroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PciGroupBox.SuspendLayout();
            this.GeneralGroupBox.SuspendLayout();
            this.VideoGroupBox.SuspendLayout();
            this.TemperatureGroupBox.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CoreCountLabel
            // 
            this.CoreCountLabel.AutoSize = true;
            this.CoreCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreCountLabel.Location = new System.Drawing.Point(6, 157);
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
            this.CardInfoLabel.Size = new System.Drawing.Size(53, 13);
            this.CardInfoLabel.TabIndex = 5;
            this.CardInfoLabel.Text = "Card Info:";
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
            this.PciGroupBox.Location = new System.Drawing.Point(301, 200);
            this.PciGroupBox.Name = "PciGroupBox";
            this.PciGroupBox.Size = new System.Drawing.Size(193, 139);
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
            // 
            // PciSubsystemTextBox
            // 
            this.PciSubsystemTextBox.Enabled = false;
            this.PciSubsystemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PciSubsystemTextBox.Location = new System.Drawing.Point(82, 70);
            this.PciSubsystemTextBox.Name = "PciSubsystemTextBox";
            this.PciSubsystemTextBox.Size = new System.Drawing.Size(105, 20);
            this.PciSubsystemTextBox.TabIndex = 11;
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
            this.GeneralGroupBox.Controls.Add(this.BusIdTextBox);
            this.GeneralGroupBox.Controls.Add(this.GpuCoresTextBox);
            this.GeneralGroupBox.Controls.Add(this.CoreVoltageTextBox);
            this.GeneralGroupBox.Controls.Add(this.VirtualRamTextBox);
            this.GeneralGroupBox.Controls.Add(this.PhysRamTextBox);
            this.GeneralGroupBox.Controls.Add(this.VbiosTextBox);
            this.GeneralGroupBox.Controls.Add(this.VoltageLabel);
            this.GeneralGroupBox.Controls.Add(this.CardInfoTextBox);
            this.GeneralGroupBox.Controls.Add(this.CardInfoLabel);
            this.GeneralGroupBox.Controls.Add(this.VBiosLabel);
            this.GeneralGroupBox.Controls.Add(this.VirtualRamLabel);
            this.GeneralGroupBox.Controls.Add(this.PhysicalRamLabel);
            this.GeneralGroupBox.Controls.Add(this.CoreCountLabel);
            this.GeneralGroupBox.Controls.Add(this.BusIdLabel);
            this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralGroupBox.Location = new System.Drawing.Point(15, 55);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(280, 178);
            this.GeneralGroupBox.TabIndex = 10;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "General Information";
            // 
            // BusIdTextBox
            // 
            this.BusIdTextBox.Enabled = false;
            this.BusIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusIdTextBox.Location = new System.Drawing.Point(178, 152);
            this.BusIdTextBox.Name = "BusIdTextBox";
            this.BusIdTextBox.Size = new System.Drawing.Size(52, 20);
            this.BusIdTextBox.TabIndex = 25;
            // 
            // GpuCoresTextBox
            // 
            this.GpuCoresTextBox.Enabled = false;
            this.GpuCoresTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpuCoresTextBox.Location = new System.Drawing.Point(73, 152);
            this.GpuCoresTextBox.Name = "GpuCoresTextBox";
            this.GpuCoresTextBox.Size = new System.Drawing.Size(51, 20);
            this.GpuCoresTextBox.TabIndex = 24;
            // 
            // CoreVoltageTextBox
            // 
            this.CoreVoltageTextBox.Enabled = false;
            this.CoreVoltageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreVoltageTextBox.Location = new System.Drawing.Point(124, 126);
            this.CoreVoltageTextBox.Name = "CoreVoltageTextBox";
            this.CoreVoltageTextBox.Size = new System.Drawing.Size(135, 20);
            this.CoreVoltageTextBox.TabIndex = 23;
            // 
            // VirtualRamTextBox
            // 
            this.VirtualRamTextBox.Enabled = false;
            this.VirtualRamTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VirtualRamTextBox.Location = new System.Drawing.Point(124, 96);
            this.VirtualRamTextBox.Name = "VirtualRamTextBox";
            this.VirtualRamTextBox.Size = new System.Drawing.Size(135, 20);
            this.VirtualRamTextBox.TabIndex = 22;
            // 
            // PhysRamTextBox
            // 
            this.PhysRamTextBox.Enabled = false;
            this.PhysRamTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhysRamTextBox.Location = new System.Drawing.Point(134, 70);
            this.PhysRamTextBox.Name = "PhysRamTextBox";
            this.PhysRamTextBox.Size = new System.Drawing.Size(125, 20);
            this.PhysRamTextBox.TabIndex = 21;
            // 
            // VbiosTextBox
            // 
            this.VbiosTextBox.Enabled = false;
            this.VbiosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VbiosTextBox.Location = new System.Drawing.Point(75, 44);
            this.VbiosTextBox.Name = "VbiosTextBox";
            this.VbiosTextBox.Size = new System.Drawing.Size(184, 20);
            this.VbiosTextBox.TabIndex = 20;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.AutoSize = true;
            this.VoltageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageLabel.Location = new System.Drawing.Point(6, 129);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(114, 13);
            this.VoltageLabel.TabIndex = 19;
            this.VoltageLabel.Text = "Base Core Voltage (V):";
            // 
            // CardInfoTextBox
            // 
            this.CardInfoTextBox.Enabled = false;
            this.CardInfoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardInfoTextBox.Location = new System.Drawing.Point(65, 19);
            this.CardInfoTextBox.Name = "CardInfoTextBox";
            this.CardInfoTextBox.Size = new System.Drawing.Size(194, 20);
            this.CardInfoTextBox.TabIndex = 6;
            // 
            // BusIdLabel
            // 
            this.BusIdLabel.AutoSize = true;
            this.BusIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusIdLabel.Location = new System.Drawing.Point(130, 157);
            this.BusIdLabel.Name = "BusIdLabel";
            this.BusIdLabel.Size = new System.Drawing.Size(42, 13);
            this.BusIdLabel.TabIndex = 11;
            this.BusIdLabel.Text = "Bus ID:";
            // 
            // CoreTempLabel
            // 
            this.CoreTempLabel.AutoSize = true;
            this.CoreTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreTempLabel.Location = new System.Drawing.Point(7, 27);
            this.CoreTempLabel.Name = "CoreTempLabel";
            this.CoreTempLabel.Size = new System.Drawing.Size(74, 13);
            this.CoreTempLabel.TabIndex = 12;
            this.CoreTempLabel.Text = "GPU Core (C):";
            // 
            // MemoryTempLabel
            // 
            this.MemoryTempLabel.AutoSize = true;
            this.MemoryTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryTempLabel.Location = new System.Drawing.Point(7, 81);
            this.MemoryTempLabel.Name = "MemoryTempLabel";
            this.MemoryTempLabel.Size = new System.Drawing.Size(63, 13);
            this.MemoryTempLabel.TabIndex = 13;
            this.MemoryTempLabel.Text = "Memory (C):";
            // 
            // SupplyTempLabel
            // 
            this.SupplyTempLabel.AutoSize = true;
            this.SupplyTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplyTempLabel.Location = new System.Drawing.Point(6, 108);
            this.SupplyTempLabel.Name = "SupplyTempLabel";
            this.SupplyTempLabel.Size = new System.Drawing.Size(91, 13);
            this.SupplyTempLabel.TabIndex = 14;
            this.SupplyTempLabel.Text = "Power Supply (C):";
            // 
            // BoardTempLabel
            // 
            this.BoardTempLabel.AutoSize = true;
            this.BoardTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardTempLabel.Location = new System.Drawing.Point(6, 54);
            this.BoardTempLabel.Name = "BoardTempLabel";
            this.BoardTempLabel.Size = new System.Drawing.Size(54, 13);
            this.BoardTempLabel.TabIndex = 15;
            this.BoardTempLabel.Text = "Board (C):";
            // 
            // Max3dLabel
            // 
            this.Max3dLabel.AutoSize = true;
            this.Max3dLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Max3dLabel.Location = new System.Drawing.Point(6, 23);
            this.Max3dLabel.Name = "Max3dLabel";
            this.Max3dLabel.Size = new System.Drawing.Size(47, 13);
            this.Max3dLabel.TabIndex = 16;
            this.Max3dLabel.Text = "Max 3D:";
            // 
            // Balance3dLabel
            // 
            this.Balance3dLabel.AutoSize = true;
            this.Balance3dLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balance3dLabel.Location = new System.Drawing.Point(6, 50);
            this.Balance3dLabel.Name = "Balance3dLabel";
            this.Balance3dLabel.Size = new System.Drawing.Size(72, 13);
            this.Balance3dLabel.TabIndex = 17;
            this.Balance3dLabel.Text = "Balanced 3D:";
            // 
            // HdLabel
            // 
            this.HdLabel.AutoSize = true;
            this.HdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HdLabel.Location = new System.Drawing.Point(6, 77);
            this.HdLabel.Name = "HdLabel";
            this.HdLabel.Size = new System.Drawing.Size(73, 13);
            this.HdLabel.TabIndex = 18;
            this.HdLabel.Text = "HD Playback:";
            // 
            // VideoGroupBox
            // 
            this.VideoGroupBox.Controls.Add(this.HdTextBox);
            this.VideoGroupBox.Controls.Add(this.HdLabel);
            this.VideoGroupBox.Controls.Add(this.Balanced3dTextBox);
            this.VideoGroupBox.Controls.Add(this.Balance3dLabel);
            this.VideoGroupBox.Controls.Add(this.Max3dTextBox);
            this.VideoGroupBox.Controls.Add(this.Max3dLabel);
            this.VideoGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoGroupBox.Location = new System.Drawing.Point(15, 239);
            this.VideoGroupBox.Name = "VideoGroupBox";
            this.VideoGroupBox.Size = new System.Drawing.Size(280, 100);
            this.VideoGroupBox.TabIndex = 19;
            this.VideoGroupBox.TabStop = false;
            this.VideoGroupBox.Text = "Video Performance";
            // 
            // HdTextBox
            // 
            this.HdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HdTextBox.Location = new System.Drawing.Point(85, 74);
            this.HdTextBox.Name = "HdTextBox";
            this.HdTextBox.Size = new System.Drawing.Size(174, 20);
            this.HdTextBox.TabIndex = 2;
            // 
            // Balanced3dTextBox
            // 
            this.Balanced3dTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balanced3dTextBox.Location = new System.Drawing.Point(84, 47);
            this.Balanced3dTextBox.Name = "Balanced3dTextBox";
            this.Balanced3dTextBox.Size = new System.Drawing.Size(175, 20);
            this.Balanced3dTextBox.TabIndex = 1;
            // 
            // Max3dTextBox
            // 
            this.Max3dTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Max3dTextBox.Location = new System.Drawing.Point(59, 20);
            this.Max3dTextBox.Name = "Max3dTextBox";
            this.Max3dTextBox.Size = new System.Drawing.Size(200, 20);
            this.Max3dTextBox.TabIndex = 0;
            // 
            // TemperatureGroupBox
            // 
            this.TemperatureGroupBox.Controls.Add(this.SupplyTempTextBox);
            this.TemperatureGroupBox.Controls.Add(this.MemoryTempTextBox);
            this.TemperatureGroupBox.Controls.Add(this.BoardTempTextBox);
            this.TemperatureGroupBox.Controls.Add(this.CoreTempTextBox);
            this.TemperatureGroupBox.Controls.Add(this.CoreTempLabel);
            this.TemperatureGroupBox.Controls.Add(this.SupplyTempLabel);
            this.TemperatureGroupBox.Controls.Add(this.BoardTempLabel);
            this.TemperatureGroupBox.Controls.Add(this.MemoryTempLabel);
            this.TemperatureGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureGroupBox.Location = new System.Drawing.Point(301, 55);
            this.TemperatureGroupBox.Name = "TemperatureGroupBox";
            this.TemperatureGroupBox.Size = new System.Drawing.Size(193, 139);
            this.TemperatureGroupBox.TabIndex = 20;
            this.TemperatureGroupBox.TabStop = false;
            this.TemperatureGroupBox.Text = "Temperature Readings";
            // 
            // SupplyTempTextBox
            // 
            this.SupplyTempTextBox.Enabled = false;
            this.SupplyTempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplyTempTextBox.Location = new System.Drawing.Point(103, 105);
            this.SupplyTempTextBox.Name = "SupplyTempTextBox";
            this.SupplyTempTextBox.Size = new System.Drawing.Size(84, 20);
            this.SupplyTempTextBox.TabIndex = 18;
            // 
            // MemoryTempTextBox
            // 
            this.MemoryTempTextBox.Enabled = false;
            this.MemoryTempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryTempTextBox.Location = new System.Drawing.Point(76, 78);
            this.MemoryTempTextBox.Name = "MemoryTempTextBox";
            this.MemoryTempTextBox.Size = new System.Drawing.Size(111, 20);
            this.MemoryTempTextBox.TabIndex = 17;
            // 
            // BoardTempTextBox
            // 
            this.BoardTempTextBox.Enabled = false;
            this.BoardTempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardTempTextBox.Location = new System.Drawing.Point(67, 51);
            this.BoardTempTextBox.Name = "BoardTempTextBox";
            this.BoardTempTextBox.Size = new System.Drawing.Size(120, 20);
            this.BoardTempTextBox.TabIndex = 16;
            // 
            // CoreTempTextBox
            // 
            this.CoreTempTextBox.Enabled = false;
            this.CoreTempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreTempTextBox.Location = new System.Drawing.Point(87, 24);
            this.CoreTempTextBox.Name = "CoreTempTextBox";
            this.CoreTempTextBox.Size = new System.Drawing.Size(100, 20);
            this.CoreTempTextBox.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(301, 26);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(97, 23);
            this.RefreshButton.TabIndex = 21;
            this.RefreshButton.Text = "Refresh";
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
            this.MenuStrip.Size = new System.Drawing.Size(508, 24);
            this.MenuStrip.TabIndex = 23;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshF5ToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // refreshF5ToolStripMenuItem
            // 
            this.refreshF5ToolStripMenuItem.Name = "refreshF5ToolStripMenuItem";
            this.refreshF5ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.refreshF5ToolStripMenuItem.Text = "Refresh (F5)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ApiBackGroundWorker
            // 
            this.ApiBackGroundWorker.WorkerSupportsCancellation = true;
            this.ApiBackGroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ApiBackGroundWorker_DoWork);
            // 
            // GraphicsCardMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 351);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.TemperatureGroupBox);
            this.Controls.Add(this.VideoGroupBox);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.PciGroupBox);
            this.Controls.Add(this.GraphicsCardComboBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "GraphicsCardMonitorForm";
            this.Text = "Graphics Card Monitor 1.0";
            this.PciGroupBox.ResumeLayout(false);
            this.PciGroupBox.PerformLayout();
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.VideoGroupBox.ResumeLayout(false);
            this.VideoGroupBox.PerformLayout();
            this.TemperatureGroupBox.ResumeLayout(false);
            this.TemperatureGroupBox.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
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
        private System.Windows.Forms.Label MemoryTempLabel;
        private System.Windows.Forms.TextBox CardInfoTextBox;
        private System.Windows.Forms.Label SupplyTempLabel;
        private System.Windows.Forms.Label BoardTempLabel;
        private System.Windows.Forms.Label Max3dLabel;
        private System.Windows.Forms.Label Balance3dLabel;
        private System.Windows.Forms.Label HdLabel;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.TextBox BusIdTextBox;
        private System.Windows.Forms.TextBox GpuCoresTextBox;
        private System.Windows.Forms.TextBox CoreVoltageTextBox;
        private System.Windows.Forms.TextBox VirtualRamTextBox;
        private System.Windows.Forms.TextBox PhysRamTextBox;
        private System.Windows.Forms.TextBox VbiosTextBox;
        private System.Windows.Forms.GroupBox VideoGroupBox;
        private System.Windows.Forms.TextBox Balanced3dTextBox;
        private System.Windows.Forms.TextBox Max3dTextBox;
        private System.Windows.Forms.TextBox HdTextBox;
        private System.Windows.Forms.GroupBox TemperatureGroupBox;
        private System.Windows.Forms.TextBox SupplyTempTextBox;
        private System.Windows.Forms.TextBox MemoryTempTextBox;
        private System.Windows.Forms.TextBox BoardTempTextBox;
        private System.Windows.Forms.TextBox CoreTempTextBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshF5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip RefreshToolTip;
        private System.Windows.Forms.ToolTip ExitToolTip;
        private System.ComponentModel.BackgroundWorker ApiBackGroundWorker;
    }
}

