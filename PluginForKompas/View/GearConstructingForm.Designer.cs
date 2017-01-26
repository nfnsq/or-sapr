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
            this.buildButton = new System.Windows.Forms.Button();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.depthOfTheHexagonDipTextBox = new System.Windows.Forms.TextBox();
            this.stiffenerDepthTextBox = new System.Windows.Forms.TextBox();
            this.stiffenersWidthTextBox = new System.Windows.Forms.TextBox();
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox = new System.Windows.Forms.TextBox();
            this.diameterOfTheCircumentialHolesTextBox = new System.Windows.Forms.TextBox();
            this.diameterOfTheCenterHoleTextBox = new System.Windows.Forms.TextBox();
            this.rigidityOfGeatUnitTextBox = new System.Windows.Forms.TextBox();
            this.countOfGearTeethTextBox = new System.Windows.Forms.TextBox();
            this.hexagonDepthLabel = new System.Windows.Forms.Label();
            this.stiffenersDepthLabel = new System.Windows.Forms.Label();
            this.stiffenersWidthLabel = new System.Windows.Forms.Label();
            this.circumscribedCircleDiameterLabel = new System.Windows.Forms.Label();
            this.circumentialHolesDiameterLabel = new System.Windows.Forms.Label();
            this.centerHoleDiameterLabel = new System.Windows.Forms.Label();
            this.gearRigidityUnitLabel = new System.Windows.Forms.Label();
            this.teethCountLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.startToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.kompasGroupBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.startKompasLabel = new System.Windows.Forms.Label();
            this.dataGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.kompasGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buildButton
            // 
            this.buildButton.Enabled = false;
            this.buildButton.Location = new System.Drawing.Point(233, 305);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 1;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.depthOfTheHexagonDipTextBox);
            this.dataGroupBox.Controls.Add(this.stiffenerDepthTextBox);
            this.dataGroupBox.Controls.Add(this.stiffenersWidthTextBox);
            this.dataGroupBox.Controls.Add(this.diameterOfTheHeaxagonCircumscribedCircleTextBox);
            this.dataGroupBox.Controls.Add(this.diameterOfTheCircumentialHolesTextBox);
            this.dataGroupBox.Controls.Add(this.diameterOfTheCenterHoleTextBox);
            this.dataGroupBox.Controls.Add(this.rigidityOfGeatUnitTextBox);
            this.dataGroupBox.Controls.Add(this.countOfGearTeethTextBox);
            this.dataGroupBox.Controls.Add(this.hexagonDepthLabel);
            this.dataGroupBox.Controls.Add(this.stiffenersDepthLabel);
            this.dataGroupBox.Controls.Add(this.stiffenersWidthLabel);
            this.dataGroupBox.Controls.Add(this.circumscribedCircleDiameterLabel);
            this.dataGroupBox.Controls.Add(this.circumentialHolesDiameterLabel);
            this.dataGroupBox.Controls.Add(this.centerHoleDiameterLabel);
            this.dataGroupBox.Controls.Add(this.gearRigidityUnitLabel);
            this.dataGroupBox.Controls.Add(this.teethCountLabel);
            this.dataGroupBox.Location = new System.Drawing.Point(12, 65);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(302, 234);
            this.dataGroupBox.TabIndex = 3;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "Data";
            // 
            // depthOfTheHexagonDipTextBox
            // 
            this.depthOfTheHexagonDipTextBox.Enabled = false;
            this.depthOfTheHexagonDipTextBox.Location = new System.Drawing.Point(252, 149);
            this.depthOfTheHexagonDipTextBox.Name = "depthOfTheHexagonDipTextBox";
            this.depthOfTheHexagonDipTextBox.Size = new System.Drawing.Size(44, 20);
            this.depthOfTheHexagonDipTextBox.TabIndex = 15;
            this.depthOfTheHexagonDipTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // stiffenerDepthTextBox
            // 
            this.stiffenerDepthTextBox.Enabled = false;
            this.stiffenerDepthTextBox.Location = new System.Drawing.Point(252, 201);
            this.stiffenerDepthTextBox.Name = "stiffenerDepthTextBox";
            this.stiffenerDepthTextBox.Size = new System.Drawing.Size(44, 20);
            this.stiffenerDepthTextBox.TabIndex = 14;
            this.stiffenerDepthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // stiffenersWidthTextBox
            // 
            this.stiffenersWidthTextBox.Enabled = false;
            this.stiffenersWidthTextBox.Location = new System.Drawing.Point(252, 175);
            this.stiffenersWidthTextBox.Name = "stiffenersWidthTextBox";
            this.stiffenersWidthTextBox.Size = new System.Drawing.Size(44, 20);
            this.stiffenersWidthTextBox.TabIndex = 13;
            this.stiffenersWidthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // diameterOfTheHeaxagonCircumscribedCircleTextBox
            // 
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox.Enabled = false;
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox.Location = new System.Drawing.Point(252, 123);
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox.Name = "diameterOfTheHeaxagonCircumscribedCircleTextBox";
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox.Size = new System.Drawing.Size(44, 20);
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox.TabIndex = 12;
            this.diameterOfTheHeaxagonCircumscribedCircleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // diameterOfTheCircumentialHolesTextBox
            // 
            this.diameterOfTheCircumentialHolesTextBox.Enabled = false;
            this.diameterOfTheCircumentialHolesTextBox.Location = new System.Drawing.Point(252, 97);
            this.diameterOfTheCircumentialHolesTextBox.Name = "diameterOfTheCircumentialHolesTextBox";
            this.diameterOfTheCircumentialHolesTextBox.Size = new System.Drawing.Size(44, 20);
            this.diameterOfTheCircumentialHolesTextBox.TabIndex = 11;
            this.diameterOfTheCircumentialHolesTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // diameterOfTheCenterHoleTextBox
            // 
            this.diameterOfTheCenterHoleTextBox.Enabled = false;
            this.diameterOfTheCenterHoleTextBox.Location = new System.Drawing.Point(252, 71);
            this.diameterOfTheCenterHoleTextBox.Name = "diameterOfTheCenterHoleTextBox";
            this.diameterOfTheCenterHoleTextBox.Size = new System.Drawing.Size(44, 20);
            this.diameterOfTheCenterHoleTextBox.TabIndex = 10;
            this.diameterOfTheCenterHoleTextBox.TextChanged += new System.EventHandler(this.ChangeEnable);
            this.diameterOfTheCenterHoleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // rigidityOfGeatUnitTextBox
            // 
            this.rigidityOfGeatUnitTextBox.Enabled = false;
            this.rigidityOfGeatUnitTextBox.Location = new System.Drawing.Point(252, 45);
            this.rigidityOfGeatUnitTextBox.Name = "rigidityOfGeatUnitTextBox";
            this.rigidityOfGeatUnitTextBox.Size = new System.Drawing.Size(44, 20);
            this.rigidityOfGeatUnitTextBox.TabIndex = 9;
            this.rigidityOfGeatUnitTextBox.TextChanged += new System.EventHandler(this.ChangeEnable);
            this.rigidityOfGeatUnitTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // countOfGearTeethTextBox
            // 
            this.countOfGearTeethTextBox.Enabled = false;
            this.countOfGearTeethTextBox.Location = new System.Drawing.Point(252, 19);
            this.countOfGearTeethTextBox.Name = "countOfGearTeethTextBox";
            this.countOfGearTeethTextBox.Size = new System.Drawing.Size(44, 20);
            this.countOfGearTeethTextBox.TabIndex = 8;
            this.countOfGearTeethTextBox.TextChanged += new System.EventHandler(this.ChangeEnable);
            this.countOfGearTeethTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 336);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(323, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // startToolStripStatusLabel
            // 
            this.startToolStripStatusLabel.Name = "startToolStripStatusLabel";
            this.startToolStripStatusLabel.Size = new System.Drawing.Size(115, 17);
            this.startToolStripStatusLabel.Text = "Please, start Kompas";
            // 
            // kompasGroupBox
            // 
            this.kompasGroupBox.Controls.Add(this.startKompasLabel);
            this.kompasGroupBox.Controls.Add(this.startButton);
            this.kompasGroupBox.Location = new System.Drawing.Point(12, 12);
            this.kompasGroupBox.Name = "kompasGroupBox";
            this.kompasGroupBox.Size = new System.Drawing.Size(302, 47);
            this.kompasGroupBox.TabIndex = 5;
            this.kompasGroupBox.TabStop = false;
            this.kompasGroupBox.Text = "Kompas";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(221, 18);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startKompasLabel
            // 
            this.startKompasLabel.AutoSize = true;
            this.startKompasLabel.Location = new System.Drawing.Point(6, 23);
            this.startKompasLabel.Name = "startKompasLabel";
            this.startKompasLabel.Size = new System.Drawing.Size(124, 13);
            this.startKompasLabel.TabIndex = 1;
            this.startKompasLabel.Text = "Start Kompas application";
            // 
            // GearConstructingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 358);
            this.Controls.Add(this.kompasGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGroupBox);
            this.Controls.Add(this.buildButton);
            this.Name = "GearConstructingForm";
            this.Text = "Gear Creator";
            this.dataGroupBox.ResumeLayout(false);
            this.dataGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.kompasGroupBox.ResumeLayout(false);
            this.kompasGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.TextBox depthOfTheHexagonDipTextBox;
        private System.Windows.Forms.TextBox stiffenerDepthTextBox;
        private System.Windows.Forms.TextBox stiffenersWidthTextBox;
        private System.Windows.Forms.TextBox diameterOfTheHeaxagonCircumscribedCircleTextBox;
        private System.Windows.Forms.TextBox diameterOfTheCircumentialHolesTextBox;
        private System.Windows.Forms.TextBox diameterOfTheCenterHoleTextBox;
        private System.Windows.Forms.TextBox rigidityOfGeatUnitTextBox;
        private System.Windows.Forms.TextBox countOfGearTeethTextBox;
        private System.Windows.Forms.Label hexagonDepthLabel;
        private System.Windows.Forms.Label stiffenersDepthLabel;
        private System.Windows.Forms.Label stiffenersWidthLabel;
        private System.Windows.Forms.Label circumscribedCircleDiameterLabel;
        private System.Windows.Forms.Label circumentialHolesDiameterLabel;
        private System.Windows.Forms.Label centerHoleDiameterLabel;
        private System.Windows.Forms.Label gearRigidityUnitLabel;
        private System.Windows.Forms.Label teethCountLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel startToolStripStatusLabel;
        private System.Windows.Forms.GroupBox kompasGroupBox;
        private System.Windows.Forms.Label startKompasLabel;
        private System.Windows.Forms.Button startButton;
    }
}

