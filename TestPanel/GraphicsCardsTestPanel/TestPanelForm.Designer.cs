
namespace GraphicsCardsTestPanel
{
    partial class GraphicsCardTestPanel
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
            this.CoreCountButton = new System.Windows.Forms.Button();
            this.NameButton = new System.Windows.Forms.Button();
            this.VbiosButton = new System.Windows.Forms.Button();
            this.VirtualRamButton = new System.Windows.Forms.Button();
            this.PhysicalRamButton = new System.Windows.Forms.Button();
            this.SerialNumberButton = new System.Windows.Forms.Button();
            this.PciInternalIdButton = new System.Windows.Forms.Button();
            this.PciRevButton = new System.Windows.Forms.Button();
            this.PciSubsystemIdButton = new System.Windows.Forms.Button();
            this.PciExternalIdButton = new System.Windows.Forms.Button();
            this.BusIdButton = new System.Windows.Forms.Button();
            this.CoreTempButton = new System.Windows.Forms.Button();
            this.MemoryTempButton = new System.Windows.Forms.Button();
            this.PowerSupplyTempButton = new System.Windows.Forms.Button();
            this.BoardTempButton = new System.Windows.Forms.Button();
            this.FanSpeedButton = new System.Windows.Forms.Button();
            this.GraphicsBaseClockFreqButton = new System.Windows.Forms.Button();
            this.GraphicsCurrentClockFreqButton = new System.Windows.Forms.Button();
            this.GraphicsBoostClockFreqButton = new System.Windows.Forms.Button();
            this.PerfStateButton = new System.Windows.Forms.Button();
            this.MemoryBaseClockFreqButton = new System.Windows.Forms.Button();
            this.MemoryCurrentClockFreqButton = new System.Windows.Forms.Button();
            this.MemoryBoostClockFreqButton = new System.Windows.Forms.Button();
            this.BaseVoltage1Button = new System.Windows.Forms.Button();
            this.SelectLabel = new System.Windows.Forms.Label();
            this.GraphicsCardComboBox = new System.Windows.Forms.ComboBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CoreCountButton
            // 
            this.CoreCountButton.Enabled = false;
            this.CoreCountButton.Location = new System.Drawing.Point(28, 43);
            this.CoreCountButton.Name = "CoreCountButton";
            this.CoreCountButton.Size = new System.Drawing.Size(131, 53);
            this.CoreCountButton.TabIndex = 0;
            this.CoreCountButton.Text = "Get Gpu Core Count";
            this.CoreCountButton.UseVisualStyleBackColor = true;
            this.CoreCountButton.Click += new System.EventHandler(this.CoreCountButton_Click);
            // 
            // NameButton
            // 
            this.NameButton.Enabled = false;
            this.NameButton.Location = new System.Drawing.Point(28, 102);
            this.NameButton.Name = "NameButton";
            this.NameButton.Size = new System.Drawing.Size(131, 53);
            this.NameButton.TabIndex = 1;
            this.NameButton.Text = "Get Name";
            this.NameButton.UseVisualStyleBackColor = true;
            this.NameButton.Click += new System.EventHandler(this.NameButton_Click);
            // 
            // VbiosButton
            // 
            this.VbiosButton.Enabled = false;
            this.VbiosButton.Location = new System.Drawing.Point(28, 161);
            this.VbiosButton.Name = "VbiosButton";
            this.VbiosButton.Size = new System.Drawing.Size(131, 53);
            this.VbiosButton.TabIndex = 2;
            this.VbiosButton.Text = "Get VBIOS Info";
            this.VbiosButton.UseVisualStyleBackColor = true;
            this.VbiosButton.Click += new System.EventHandler(this.VbiosButton_Click);
            // 
            // VirtualRamButton
            // 
            this.VirtualRamButton.Enabled = false;
            this.VirtualRamButton.Location = new System.Drawing.Point(28, 220);
            this.VirtualRamButton.Name = "VirtualRamButton";
            this.VirtualRamButton.Size = new System.Drawing.Size(131, 53);
            this.VirtualRamButton.TabIndex = 3;
            this.VirtualRamButton.Text = "Get Virtual RAM Size";
            this.VirtualRamButton.UseVisualStyleBackColor = true;
            this.VirtualRamButton.Click += new System.EventHandler(this.VirtualRamButton_Click);
            // 
            // PhysicalRamButton
            // 
            this.PhysicalRamButton.Enabled = false;
            this.PhysicalRamButton.Location = new System.Drawing.Point(28, 279);
            this.PhysicalRamButton.Name = "PhysicalRamButton";
            this.PhysicalRamButton.Size = new System.Drawing.Size(131, 53);
            this.PhysicalRamButton.TabIndex = 4;
            this.PhysicalRamButton.Text = "Get Physical RAM Size";
            this.PhysicalRamButton.UseVisualStyleBackColor = true;
            this.PhysicalRamButton.Click += new System.EventHandler(this.PhysicalRamButton_Click);
            // 
            // SerialNumberButton
            // 
            this.SerialNumberButton.Enabled = false;
            this.SerialNumberButton.Location = new System.Drawing.Point(28, 338);
            this.SerialNumberButton.Name = "SerialNumberButton";
            this.SerialNumberButton.Size = new System.Drawing.Size(131, 53);
            this.SerialNumberButton.TabIndex = 5;
            this.SerialNumberButton.Text = "Get Serial Number";
            this.SerialNumberButton.UseVisualStyleBackColor = true;
            this.SerialNumberButton.Click += new System.EventHandler(this.SerialNumberButton_Click);
            // 
            // PciInternalIdButton
            // 
            this.PciInternalIdButton.Enabled = false;
            this.PciInternalIdButton.Location = new System.Drawing.Point(165, 43);
            this.PciInternalIdButton.Name = "PciInternalIdButton";
            this.PciInternalIdButton.Size = new System.Drawing.Size(131, 53);
            this.PciInternalIdButton.TabIndex = 6;
            this.PciInternalIdButton.Text = "Get PCI Internal ID";
            this.PciInternalIdButton.UseVisualStyleBackColor = true;
            this.PciInternalIdButton.Click += new System.EventHandler(this.PciInternalIdButton_Click);
            // 
            // PciRevButton
            // 
            this.PciRevButton.Enabled = false;
            this.PciRevButton.Location = new System.Drawing.Point(165, 102);
            this.PciRevButton.Name = "PciRevButton";
            this.PciRevButton.Size = new System.Drawing.Size(131, 53);
            this.PciRevButton.TabIndex = 7;
            this.PciRevButton.Text = "Get PCI Rev ID";
            this.PciRevButton.UseVisualStyleBackColor = true;
            this.PciRevButton.Click += new System.EventHandler(this.PciRevButton_Click);
            // 
            // PciSubsystemIdButton
            // 
            this.PciSubsystemIdButton.Enabled = false;
            this.PciSubsystemIdButton.Location = new System.Drawing.Point(165, 161);
            this.PciSubsystemIdButton.Name = "PciSubsystemIdButton";
            this.PciSubsystemIdButton.Size = new System.Drawing.Size(131, 53);
            this.PciSubsystemIdButton.TabIndex = 8;
            this.PciSubsystemIdButton.Text = "Get PCI Subsystem ID";
            this.PciSubsystemIdButton.UseVisualStyleBackColor = true;
            this.PciSubsystemIdButton.Click += new System.EventHandler(this.PciSubsystemIdButton_Click);
            // 
            // PciExternalIdButton
            // 
            this.PciExternalIdButton.Enabled = false;
            this.PciExternalIdButton.Location = new System.Drawing.Point(165, 220);
            this.PciExternalIdButton.Name = "PciExternalIdButton";
            this.PciExternalIdButton.Size = new System.Drawing.Size(131, 53);
            this.PciExternalIdButton.TabIndex = 9;
            this.PciExternalIdButton.Text = "Get PCI External ID";
            this.PciExternalIdButton.UseVisualStyleBackColor = true;
            this.PciExternalIdButton.Click += new System.EventHandler(this.PciExternalIdButton_Click);
            // 
            // BusIdButton
            // 
            this.BusIdButton.Enabled = false;
            this.BusIdButton.Location = new System.Drawing.Point(165, 279);
            this.BusIdButton.Name = "BusIdButton";
            this.BusIdButton.Size = new System.Drawing.Size(131, 53);
            this.BusIdButton.TabIndex = 10;
            this.BusIdButton.Text = "Get Bus ID";
            this.BusIdButton.UseVisualStyleBackColor = true;
            this.BusIdButton.Click += new System.EventHandler(this.BusIdButton_Click);
            // 
            // CoreTempButton
            // 
            this.CoreTempButton.Enabled = false;
            this.CoreTempButton.Location = new System.Drawing.Point(302, 43);
            this.CoreTempButton.Name = "CoreTempButton";
            this.CoreTempButton.Size = new System.Drawing.Size(131, 53);
            this.CoreTempButton.TabIndex = 11;
            this.CoreTempButton.Text = "Get GPU Core Temp";
            this.CoreTempButton.UseVisualStyleBackColor = true;
            this.CoreTempButton.Click += new System.EventHandler(this.CoreTempButton_Click);
            // 
            // MemoryTempButton
            // 
            this.MemoryTempButton.Enabled = false;
            this.MemoryTempButton.Location = new System.Drawing.Point(302, 102);
            this.MemoryTempButton.Name = "MemoryTempButton";
            this.MemoryTempButton.Size = new System.Drawing.Size(131, 53);
            this.MemoryTempButton.TabIndex = 12;
            this.MemoryTempButton.Text = "Get Memory Temp";
            this.MemoryTempButton.UseVisualStyleBackColor = true;
            this.MemoryTempButton.Click += new System.EventHandler(this.MemoryTempButton_Click);
            // 
            // PowerSupplyTempButton
            // 
            this.PowerSupplyTempButton.Enabled = false;
            this.PowerSupplyTempButton.Location = new System.Drawing.Point(302, 161);
            this.PowerSupplyTempButton.Name = "PowerSupplyTempButton";
            this.PowerSupplyTempButton.Size = new System.Drawing.Size(130, 53);
            this.PowerSupplyTempButton.TabIndex = 13;
            this.PowerSupplyTempButton.Text = "Get Power Supply Temp";
            this.PowerSupplyTempButton.UseVisualStyleBackColor = true;
            this.PowerSupplyTempButton.Click += new System.EventHandler(this.PowerSupplyTempButton_Click);
            // 
            // BoardTempButton
            // 
            this.BoardTempButton.Enabled = false;
            this.BoardTempButton.Location = new System.Drawing.Point(302, 220);
            this.BoardTempButton.Name = "BoardTempButton";
            this.BoardTempButton.Size = new System.Drawing.Size(130, 53);
            this.BoardTempButton.TabIndex = 14;
            this.BoardTempButton.Text = "Get Board Temp";
            this.BoardTempButton.UseVisualStyleBackColor = true;
            this.BoardTempButton.Click += new System.EventHandler(this.BoardTempButton_Click);
            // 
            // FanSpeedButton
            // 
            this.FanSpeedButton.Enabled = false;
            this.FanSpeedButton.Location = new System.Drawing.Point(165, 337);
            this.FanSpeedButton.Name = "FanSpeedButton";
            this.FanSpeedButton.Size = new System.Drawing.Size(130, 54);
            this.FanSpeedButton.TabIndex = 15;
            this.FanSpeedButton.Text = "Get GPU Fan Speed";
            this.FanSpeedButton.UseVisualStyleBackColor = true;
            this.FanSpeedButton.Click += new System.EventHandler(this.FanSpeedButton_Click);
            // 
            // GraphicsBaseClockFreqButton
            // 
            this.GraphicsBaseClockFreqButton.Enabled = false;
            this.GraphicsBaseClockFreqButton.Location = new System.Drawing.Point(301, 337);
            this.GraphicsBaseClockFreqButton.Name = "GraphicsBaseClockFreqButton";
            this.GraphicsBaseClockFreqButton.Size = new System.Drawing.Size(130, 54);
            this.GraphicsBaseClockFreqButton.TabIndex = 16;
            this.GraphicsBaseClockFreqButton.Text = "Get Graphics Base Clock Frequency";
            this.GraphicsBaseClockFreqButton.UseVisualStyleBackColor = true;
            this.GraphicsBaseClockFreqButton.Click += new System.EventHandler(this.GraphicsBaseClockFreqButton_Click);
            // 
            // GraphicsCurrentClockFreqButton
            // 
            this.GraphicsCurrentClockFreqButton.Enabled = false;
            this.GraphicsCurrentClockFreqButton.Location = new System.Drawing.Point(439, 43);
            this.GraphicsCurrentClockFreqButton.Name = "GraphicsCurrentClockFreqButton";
            this.GraphicsCurrentClockFreqButton.Size = new System.Drawing.Size(130, 53);
            this.GraphicsCurrentClockFreqButton.TabIndex = 17;
            this.GraphicsCurrentClockFreqButton.Text = "Get Graphics Current Clock Frequency";
            this.GraphicsCurrentClockFreqButton.UseVisualStyleBackColor = true;
            this.GraphicsCurrentClockFreqButton.Click += new System.EventHandler(this.GraphicsCurrentClockFreqButton_Click);
            // 
            // GraphicsBoostClockFreqButton
            // 
            this.GraphicsBoostClockFreqButton.Enabled = false;
            this.GraphicsBoostClockFreqButton.Location = new System.Drawing.Point(439, 102);
            this.GraphicsBoostClockFreqButton.Name = "GraphicsBoostClockFreqButton";
            this.GraphicsBoostClockFreqButton.Size = new System.Drawing.Size(130, 53);
            this.GraphicsBoostClockFreqButton.TabIndex = 18;
            this.GraphicsBoostClockFreqButton.Text = "Get Graphics Boost Clock Frequency";
            this.GraphicsBoostClockFreqButton.UseVisualStyleBackColor = true;
            this.GraphicsBoostClockFreqButton.Click += new System.EventHandler(this.GraphicsBoostClockFreqButton_Click);
            // 
            // PerfStateButton
            // 
            this.PerfStateButton.Enabled = false;
            this.PerfStateButton.Location = new System.Drawing.Point(302, 279);
            this.PerfStateButton.Name = "PerfStateButton";
            this.PerfStateButton.Size = new System.Drawing.Size(130, 53);
            this.PerfStateButton.TabIndex = 19;
            this.PerfStateButton.Text = "Get Current Performance State";
            this.PerfStateButton.UseVisualStyleBackColor = true;
            this.PerfStateButton.Click += new System.EventHandler(this.PerfStateButton_Click);
            // 
            // MemoryBaseClockFreqButton
            // 
            this.MemoryBaseClockFreqButton.Enabled = false;
            this.MemoryBaseClockFreqButton.Location = new System.Drawing.Point(439, 161);
            this.MemoryBaseClockFreqButton.Name = "MemoryBaseClockFreqButton";
            this.MemoryBaseClockFreqButton.Size = new System.Drawing.Size(130, 53);
            this.MemoryBaseClockFreqButton.TabIndex = 20;
            this.MemoryBaseClockFreqButton.Text = "Get Memory Base Clock Frequency";
            this.MemoryBaseClockFreqButton.UseVisualStyleBackColor = true;
            this.MemoryBaseClockFreqButton.Click += new System.EventHandler(this.MemoryBaseClockFreqButton_Click);
            // 
            // MemoryCurrentClockFreqButton
            // 
            this.MemoryCurrentClockFreqButton.Enabled = false;
            this.MemoryCurrentClockFreqButton.Location = new System.Drawing.Point(439, 220);
            this.MemoryCurrentClockFreqButton.Name = "MemoryCurrentClockFreqButton";
            this.MemoryCurrentClockFreqButton.Size = new System.Drawing.Size(131, 53);
            this.MemoryCurrentClockFreqButton.TabIndex = 21;
            this.MemoryCurrentClockFreqButton.Text = "Get Memory Current Clock Frequency";
            this.MemoryCurrentClockFreqButton.UseVisualStyleBackColor = true;
            this.MemoryCurrentClockFreqButton.Click += new System.EventHandler(this.MemoryCurrentClockFreqButton_Click);
            // 
            // MemoryBoostClockFreqButton
            // 
            this.MemoryBoostClockFreqButton.Enabled = false;
            this.MemoryBoostClockFreqButton.Location = new System.Drawing.Point(440, 279);
            this.MemoryBoostClockFreqButton.Name = "MemoryBoostClockFreqButton";
            this.MemoryBoostClockFreqButton.Size = new System.Drawing.Size(130, 53);
            this.MemoryBoostClockFreqButton.TabIndex = 22;
            this.MemoryBoostClockFreqButton.Text = "Get Memory Boost Clock Frequency";
            this.MemoryBoostClockFreqButton.UseVisualStyleBackColor = true;
            this.MemoryBoostClockFreqButton.Click += new System.EventHandler(this.MemoryBoostClockFreqButton_Click);
            // 
            // BaseVoltage1Button
            // 
            this.BaseVoltage1Button.Enabled = false;
            this.BaseVoltage1Button.Location = new System.Drawing.Point(440, 337);
            this.BaseVoltage1Button.Name = "BaseVoltage1Button";
            this.BaseVoltage1Button.Size = new System.Drawing.Size(130, 54);
            this.BaseVoltage1Button.TabIndex = 23;
            this.BaseVoltage1Button.Text = "Get Base Voltage 1";
            this.BaseVoltage1Button.UseVisualStyleBackColor = true;
            this.BaseVoltage1Button.Click += new System.EventHandler(this.BaseVoltage1Button_Click);
            // 
            // SelectLabel
            // 
            this.SelectLabel.AutoSize = true;
            this.SelectLabel.Location = new System.Drawing.Point(25, 19);
            this.SelectLabel.Name = "SelectLabel";
            this.SelectLabel.Size = new System.Drawing.Size(142, 13);
            this.SelectLabel.TabIndex = 24;
            this.SelectLabel.Text = "Select Graphics Card to test:";
            // 
            // GraphicsCardComboBox
            // 
            this.GraphicsCardComboBox.FormattingEnabled = true;
            this.GraphicsCardComboBox.Location = new System.Drawing.Point(173, 16);
            this.GraphicsCardComboBox.Name = "GraphicsCardComboBox";
            this.GraphicsCardComboBox.Size = new System.Drawing.Size(303, 21);
            this.GraphicsCardComboBox.TabIndex = 25;
            this.GraphicsCardComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphicsCardComboBox_SelectedIndexChanged);
            // 
            // TestButton
            // 
            this.TestButton.Enabled = false;
            this.TestButton.Location = new System.Drawing.Point(483, 14);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 26;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(165, 397);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(130, 50);
            this.ResetButton.TabIndex = 27;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(302, 397);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(129, 50);
            this.ExitButton.TabIndex = 28;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // GraphicsCardTestPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 459);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.GraphicsCardComboBox);
            this.Controls.Add(this.SelectLabel);
            this.Controls.Add(this.BaseVoltage1Button);
            this.Controls.Add(this.MemoryBoostClockFreqButton);
            this.Controls.Add(this.MemoryCurrentClockFreqButton);
            this.Controls.Add(this.MemoryBaseClockFreqButton);
            this.Controls.Add(this.PerfStateButton);
            this.Controls.Add(this.GraphicsBoostClockFreqButton);
            this.Controls.Add(this.GraphicsCurrentClockFreqButton);
            this.Controls.Add(this.GraphicsBaseClockFreqButton);
            this.Controls.Add(this.FanSpeedButton);
            this.Controls.Add(this.BoardTempButton);
            this.Controls.Add(this.PowerSupplyTempButton);
            this.Controls.Add(this.MemoryTempButton);
            this.Controls.Add(this.CoreTempButton);
            this.Controls.Add(this.BusIdButton);
            this.Controls.Add(this.PciExternalIdButton);
            this.Controls.Add(this.PciSubsystemIdButton);
            this.Controls.Add(this.PciRevButton);
            this.Controls.Add(this.PciInternalIdButton);
            this.Controls.Add(this.SerialNumberButton);
            this.Controls.Add(this.PhysicalRamButton);
            this.Controls.Add(this.VirtualRamButton);
            this.Controls.Add(this.VbiosButton);
            this.Controls.Add(this.NameButton);
            this.Controls.Add(this.CoreCountButton);
            this.Name = "GraphicsCardTestPanel";
            this.Text = "Graphics Card Driver Test Panel, Version 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CoreCountButton;
        private System.Windows.Forms.Button NameButton;
        private System.Windows.Forms.Button VbiosButton;
        private System.Windows.Forms.Button VirtualRamButton;
        private System.Windows.Forms.Button PhysicalRamButton;
        private System.Windows.Forms.Button SerialNumberButton;
        private System.Windows.Forms.Button PciInternalIdButton;
        private System.Windows.Forms.Button PciRevButton;
        private System.Windows.Forms.Button PciSubsystemIdButton;
        private System.Windows.Forms.Button PciExternalIdButton;
        private System.Windows.Forms.Button BusIdButton;
        private System.Windows.Forms.Button CoreTempButton;
        private System.Windows.Forms.Button MemoryTempButton;
        private System.Windows.Forms.Button PowerSupplyTempButton;
        private System.Windows.Forms.Button BoardTempButton;
        private System.Windows.Forms.Button FanSpeedButton;
        private System.Windows.Forms.Button GraphicsBaseClockFreqButton;
        private System.Windows.Forms.Button GraphicsCurrentClockFreqButton;
        private System.Windows.Forms.Button GraphicsBoostClockFreqButton;
        private System.Windows.Forms.Button PerfStateButton;
        private System.Windows.Forms.Button MemoryBaseClockFreqButton;
        private System.Windows.Forms.Button MemoryCurrentClockFreqButton;
        private System.Windows.Forms.Button MemoryBoostClockFreqButton;
        private System.Windows.Forms.Button BaseVoltage1Button;
        private System.Windows.Forms.Label SelectLabel;
        private System.Windows.Forms.ComboBox GraphicsCardComboBox;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

