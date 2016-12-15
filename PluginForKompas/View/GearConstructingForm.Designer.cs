namespace View
{
    partial class GearConstructingForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.kompasCheckGroupBox = new System.Windows.Forms.GroupBox();
            this.kompasCheckBox = new System.Windows.Forms.CheckBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.rebuildButton = new System.Windows.Forms.Button();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.hexDipDepthTextBox = new System.Windows.Forms.TextBox();
            this.stiffDepthTextBox = new System.Windows.Forms.TextBox();
            this.stiffWidthTextBox = new System.Windows.Forms.TextBox();
            this.hexDiamTextBox = new System.Windows.Forms.TextBox();
            this.circHolesDiamTextBox = new System.Windows.Forms.TextBox();
            this.centerHoleDiamTextBox = new System.Windows.Forms.TextBox();
            this.rigidityUnitTextBox = new System.Windows.Forms.TextBox();
            this.teethCountTextBox = new System.Windows.Forms.TextBox();
            this.hexagonDepthLabel = new System.Windows.Forms.Label();
            this.stiffenersDepthLabel = new System.Windows.Forms.Label();
            this.stiffenersWidthLabel = new System.Windows.Forms.Label();
            this.circumscribedCircleDiameterLabel = new System.Windows.Forms.Label();
            this.circumentialHolesDiameterLabel = new System.Windows.Forms.Label();
            this.centerHoleDiameterLabel = new System.Windows.Forms.Label();
            this.gearRigidityUnitLabel = new System.Windows.Forms.Label();
            this.teethCountLabel = new System.Windows.Forms.Label();
            this.kompasCheckGroupBox.SuspendLayout();
            this.dataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // kompasCheckGroupBox
            // 
            this.kompasCheckGroupBox.Controls.Add(this.kompasCheckBox);
            this.kompasCheckGroupBox.Location = new System.Drawing.Point(12, 12);
            this.kompasCheckGroupBox.Name = "kompasCheckGroupBox";
            this.kompasCheckGroupBox.Size = new System.Drawing.Size(304, 46);
            this.kompasCheckGroupBox.TabIndex = 0;
            this.kompasCheckGroupBox.TabStop = false;
            this.kompasCheckGroupBox.Text = "Kompas";
            // 
            // kompasCheckBox
            // 
            this.kompasCheckBox.AutoSize = true;
            this.kompasCheckBox.Location = new System.Drawing.Point(6, 19);
            this.kompasCheckBox.Name = "kompasCheckBox";
            this.kompasCheckBox.Size = new System.Drawing.Size(87, 17);
            this.kompasCheckBox.TabIndex = 0;
            this.kompasCheckBox.Text = "Run Kompas";
            this.kompasCheckBox.UseVisualStyleBackColor = true;
            this.kompasCheckBox.CheckedChanged += new System.EventHandler(this.kompasCheckBox_CheckedChanged);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(241, 313);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 1;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // rebuildButton
            // 
            this.rebuildButton.Enabled = false;
            this.rebuildButton.Location = new System.Drawing.Point(160, 313);
            this.rebuildButton.Name = "rebuildButton";
            this.rebuildButton.Size = new System.Drawing.Size(75, 23);
            this.rebuildButton.TabIndex = 2;
            this.rebuildButton.Text = "Rebuild";
            this.rebuildButton.UseVisualStyleBackColor = true;
            this.rebuildButton.Click += new System.EventHandler(this.rebuildButton_Click);
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.hexDipDepthTextBox);
            this.dataGroupBox.Controls.Add(this.stiffDepthTextBox);
            this.dataGroupBox.Controls.Add(this.stiffWidthTextBox);
            this.dataGroupBox.Controls.Add(this.hexDiamTextBox);
            this.dataGroupBox.Controls.Add(this.circHolesDiamTextBox);
            this.dataGroupBox.Controls.Add(this.centerHoleDiamTextBox);
            this.dataGroupBox.Controls.Add(this.rigidityUnitTextBox);
            this.dataGroupBox.Controls.Add(this.teethCountTextBox);
            this.dataGroupBox.Controls.Add(this.hexagonDepthLabel);
            this.dataGroupBox.Controls.Add(this.stiffenersDepthLabel);
            this.dataGroupBox.Controls.Add(this.stiffenersWidthLabel);
            this.dataGroupBox.Controls.Add(this.circumscribedCircleDiameterLabel);
            this.dataGroupBox.Controls.Add(this.circumentialHolesDiameterLabel);
            this.dataGroupBox.Controls.Add(this.centerHoleDiameterLabel);
            this.dataGroupBox.Controls.Add(this.gearRigidityUnitLabel);
            this.dataGroupBox.Controls.Add(this.teethCountLabel);
            this.dataGroupBox.Location = new System.Drawing.Point(14, 71);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(302, 234);
            this.dataGroupBox.TabIndex = 3;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "Data";
            // 
            // hexDipDepthTextBox
            // 
            this.hexDipDepthTextBox.Enabled = false;
            this.hexDipDepthTextBox.Location = new System.Drawing.Point(252, 149);
            this.hexDipDepthTextBox.Name = "hexDipDepthTextBox";
            this.hexDipDepthTextBox.Size = new System.Drawing.Size(44, 20);
            this.hexDipDepthTextBox.TabIndex = 15;
            this.hexDipDepthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.hexDipDepthTextBox_Validating);
            // 
            // stiffDepthTextBox
            // 
            this.stiffDepthTextBox.Enabled = false;
            this.stiffDepthTextBox.Location = new System.Drawing.Point(252, 201);
            this.stiffDepthTextBox.Name = "stiffDepthTextBox";
            this.stiffDepthTextBox.Size = new System.Drawing.Size(44, 20);
            this.stiffDepthTextBox.TabIndex = 14;
            this.stiffDepthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.stiffDepthTextBox_Validating);
            // 
            // stiffWidthTextBox
            // 
            this.stiffWidthTextBox.Enabled = false;
            this.stiffWidthTextBox.Location = new System.Drawing.Point(252, 175);
            this.stiffWidthTextBox.Name = "stiffWidthTextBox";
            this.stiffWidthTextBox.Size = new System.Drawing.Size(44, 20);
            this.stiffWidthTextBox.TabIndex = 13;
            this.stiffWidthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.stiffWidthTextBox_Validating);
            // 
            // hexDiamTextBox
            // 
            this.hexDiamTextBox.Enabled = false;
            this.hexDiamTextBox.Location = new System.Drawing.Point(252, 123);
            this.hexDiamTextBox.Name = "hexDiamTextBox";
            this.hexDiamTextBox.Size = new System.Drawing.Size(44, 20);
            this.hexDiamTextBox.TabIndex = 12;
            this.hexDiamTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.hexDiamTextBox_Validating);
            // 
            // circHolesDiamTextBox
            // 
            this.circHolesDiamTextBox.Enabled = false;
            this.circHolesDiamTextBox.Location = new System.Drawing.Point(252, 97);
            this.circHolesDiamTextBox.Name = "circHolesDiamTextBox";
            this.circHolesDiamTextBox.Size = new System.Drawing.Size(44, 20);
            this.circHolesDiamTextBox.TabIndex = 11;
            this.circHolesDiamTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.circHolesDiamTextBox_Validating);
            // 
            // centerHoleDiamTextBox
            // 
            this.centerHoleDiamTextBox.Enabled = false;
            this.centerHoleDiamTextBox.Location = new System.Drawing.Point(252, 71);
            this.centerHoleDiamTextBox.Name = "centerHoleDiamTextBox";
            this.centerHoleDiamTextBox.Size = new System.Drawing.Size(44, 20);
            this.centerHoleDiamTextBox.TabIndex = 10;
            this.centerHoleDiamTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.centerHoleDiamTextBox_Validating);
            this.centerHoleDiamTextBox.Validated += new System.EventHandler(this.centerHoleDiamTextBox_Validated);
            // 
            // rigidityUnitTextBox
            // 
            this.rigidityUnitTextBox.Location = new System.Drawing.Point(252, 45);
            this.rigidityUnitTextBox.Name = "rigidityUnitTextBox";
            this.rigidityUnitTextBox.Size = new System.Drawing.Size(44, 20);
            this.rigidityUnitTextBox.TabIndex = 9;
            this.rigidityUnitTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.rigidityUnitTextBox_Validating);
            this.rigidityUnitTextBox.Validated += new System.EventHandler(this.rigidityUnitTextBox_Validated);
            // 
            // teethCountTextBox
            // 
            this.teethCountTextBox.Location = new System.Drawing.Point(252, 19);
            this.teethCountTextBox.Name = "teethCountTextBox";
            this.teethCountTextBox.Size = new System.Drawing.Size(44, 20);
            this.teethCountTextBox.TabIndex = 8;
            this.teethCountTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.teethCountTextBox_Validating);
            this.teethCountTextBox.Validated += new System.EventHandler(this.teethCountTextBox_Validated);
            // 
            // hexagonDepthLabel
            // 
            this.hexagonDepthLabel.AutoSize = true;
            this.hexagonDepthLabel.Location = new System.Drawing.Point(6, 152);
            this.hexagonDepthLabel.Name = "hexagonDepthLabel";
            this.hexagonDepthLabel.Size = new System.Drawing.Size(127, 13);
            this.hexagonDepthLabel.TabIndex = 7;
            this.hexagonDepthLabel.Text = "Depth of the hexagon dip";
            // 
            // stiffenersDepthLabel
            // 
            this.stiffenersDepthLabel.AutoSize = true;
            this.stiffenersDepthLabel.Location = new System.Drawing.Point(6, 204);
            this.stiffenersDepthLabel.Name = "stiffenersDepthLabel";
            this.stiffenersDepthLabel.Size = new System.Drawing.Size(76, 13);
            this.stiffenersDepthLabel.TabIndex = 6;
            this.stiffenersDepthLabel.Text = "Stiffener depth";
            // 
            // stiffenersWidthLabel
            // 
            this.stiffenersWidthLabel.AutoSize = true;
            this.stiffenersWidthLabel.Location = new System.Drawing.Point(6, 178);
            this.stiffenersWidthLabel.Name = "stiffenersWidthLabel";
            this.stiffenersWidthLabel.Size = new System.Drawing.Size(79, 13);
            this.stiffenersWidthLabel.TabIndex = 5;
            this.stiffenersWidthLabel.Text = "Stiffeners width";
            // 
            // circumscribedCircleDiameterLabel
            // 
            this.circumscribedCircleDiameterLabel.AutoSize = true;
            this.circumscribedCircleDiameterLabel.Location = new System.Drawing.Point(6, 126);
            this.circumscribedCircleDiameterLabel.Name = "circumscribedCircleDiameterLabel";
            this.circumscribedCircleDiameterLabel.Size = new System.Drawing.Size(219, 13);
            this.circumscribedCircleDiameterLabel.TabIndex = 4;
            this.circumscribedCircleDiameterLabel.Text = "Diameter of the hexagon circumscribed circle";
            // 
            // circumentialHolesDiameterLabel
            // 
            this.circumentialHolesDiameterLabel.AutoSize = true;
            this.circumentialHolesDiameterLabel.Location = new System.Drawing.Point(6, 100);
            this.circumentialHolesDiameterLabel.Name = "circumentialHolesDiameterLabel";
            this.circumentialHolesDiameterLabel.Size = new System.Drawing.Size(160, 13);
            this.circumentialHolesDiameterLabel.TabIndex = 3;
            this.circumentialHolesDiameterLabel.Text = "Diamerer of the circumetial holes";
            // 
            // centerHoleDiameterLabel
            // 
            this.centerHoleDiameterLabel.AutoSize = true;
            this.centerHoleDiameterLabel.Location = new System.Drawing.Point(6, 74);
            this.centerHoleDiameterLabel.Name = "centerHoleDiameterLabel";
            this.centerHoleDiameterLabel.Size = new System.Drawing.Size(135, 13);
            this.centerHoleDiameterLabel.TabIndex = 2;
            this.centerHoleDiameterLabel.Text = "Diameter of the center hole";
            // 
            // gearRigidityUnitLabel
            // 
            this.gearRigidityUnitLabel.AutoSize = true;
            this.gearRigidityUnitLabel.Location = new System.Drawing.Point(6, 48);
            this.gearRigidityUnitLabel.Name = "gearRigidityUnitLabel";
            this.gearRigidityUnitLabel.Size = new System.Drawing.Size(97, 13);
            this.gearRigidityUnitLabel.TabIndex = 1;
            this.gearRigidityUnitLabel.Text = "Rigidity of geat unit";
            // 
            // teethCountLabel
            // 
            this.teethCountLabel.AutoSize = true;
            this.teethCountLabel.Location = new System.Drawing.Point(6, 22);
            this.teethCountLabel.Name = "teethCountLabel";
            this.teethCountLabel.Size = new System.Drawing.Size(98, 13);
            this.teethCountLabel.TabIndex = 0;
            this.teethCountLabel.Text = "Count of gear teeth";
            // 
            // GearConstructingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 348);
            this.Controls.Add(this.dataGroupBox);
            this.Controls.Add(this.rebuildButton);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.kompasCheckGroupBox);
            this.Name = "GearConstructingForm";
            this.Text = "Form1";
            this.kompasCheckGroupBox.ResumeLayout(false);
            this.kompasCheckGroupBox.PerformLayout();
            this.dataGroupBox.ResumeLayout(false);
            this.dataGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox kompasCheckGroupBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.CheckBox kompasCheckBox;
        private System.Windows.Forms.Button rebuildButton;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.TextBox hexDipDepthTextBox;
        private System.Windows.Forms.TextBox stiffDepthTextBox;
        private System.Windows.Forms.TextBox stiffWidthTextBox;
        private System.Windows.Forms.TextBox hexDiamTextBox;
        private System.Windows.Forms.TextBox circHolesDiamTextBox;
        private System.Windows.Forms.TextBox centerHoleDiamTextBox;
        private System.Windows.Forms.TextBox rigidityUnitTextBox;
        private System.Windows.Forms.TextBox teethCountTextBox;
        private System.Windows.Forms.Label hexagonDepthLabel;
        private System.Windows.Forms.Label stiffenersDepthLabel;
        private System.Windows.Forms.Label stiffenersWidthLabel;
        private System.Windows.Forms.Label circumscribedCircleDiameterLabel;
        private System.Windows.Forms.Label circumentialHolesDiameterLabel;
        private System.Windows.Forms.Label centerHoleDiameterLabel;
        private System.Windows.Forms.Label gearRigidityUnitLabel;
        private System.Windows.Forms.Label teethCountLabel;
    }
}

