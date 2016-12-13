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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.teethCountLabel = new System.Windows.Forms.Label();
            this.gearRigidityUnitLabel = new System.Windows.Forms.Label();
            this.centerHoleDiameterLabel = new System.Windows.Forms.Label();
            this.circumentialHolesDiameterLabel = new System.Windows.Forms.Label();
            this.circumscribedCircleDiameterLabel = new System.Windows.Forms.Label();
            this.stiffenersWidthLabel = new System.Windows.Forms.Label();
            this.stiffenersDepthLabel = new System.Windows.Forms.Label();
            this.hexagonDepthLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.hexagonDepthLabel);
            this.groupBox2.Controls.Add(this.stiffenersDepthLabel);
            this.groupBox2.Controls.Add(this.stiffenersWidthLabel);
            this.groupBox2.Controls.Add(this.circumscribedCircleDiameterLabel);
            this.groupBox2.Controls.Add(this.circumentialHolesDiameterLabel);
            this.groupBox2.Controls.Add(this.centerHoleDiameterLabel);
            this.groupBox2.Controls.Add(this.gearRigidityUnitLabel);
            this.groupBox2.Controls.Add(this.teethCountLabel);
            this.groupBox2.Location = new System.Drawing.Point(14, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 234);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
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
            // gearRigidityUnitLabel
            // 
            this.gearRigidityUnitLabel.AutoSize = true;
            this.gearRigidityUnitLabel.Location = new System.Drawing.Point(6, 48);
            this.gearRigidityUnitLabel.Name = "gearRigidityUnitLabel";
            this.gearRigidityUnitLabel.Size = new System.Drawing.Size(97, 13);
            this.gearRigidityUnitLabel.TabIndex = 1;
            this.gearRigidityUnitLabel.Text = "Rigidity of geat unit";
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
            // circumentialHolesDiameterLabel
            // 
            this.circumentialHolesDiameterLabel.AutoSize = true;
            this.circumentialHolesDiameterLabel.Location = new System.Drawing.Point(6, 100);
            this.circumentialHolesDiameterLabel.Name = "circumentialHolesDiameterLabel";
            this.circumentialHolesDiameterLabel.Size = new System.Drawing.Size(160, 13);
            this.circumentialHolesDiameterLabel.TabIndex = 3;
            this.circumentialHolesDiameterLabel.Text = "Diamerer of the circumetial holes";
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
            // stiffenersWidthLabel
            // 
            this.stiffenersWidthLabel.AutoSize = true;
            this.stiffenersWidthLabel.Location = new System.Drawing.Point(6, 152);
            this.stiffenersWidthLabel.Name = "stiffenersWidthLabel";
            this.stiffenersWidthLabel.Size = new System.Drawing.Size(79, 13);
            this.stiffenersWidthLabel.TabIndex = 5;
            this.stiffenersWidthLabel.Text = "Stiffeners width";
            // 
            // stiffenersDepthLabel
            // 
            this.stiffenersDepthLabel.AutoSize = true;
            this.stiffenersDepthLabel.Location = new System.Drawing.Point(6, 178);
            this.stiffenersDepthLabel.Name = "stiffenersDepthLabel";
            this.stiffenersDepthLabel.Size = new System.Drawing.Size(76, 13);
            this.stiffenersDepthLabel.TabIndex = 6;
            this.stiffenersDepthLabel.Text = "Stiffener depth";
            // 
            // hexagonDepthLabel
            // 
            this.hexagonDepthLabel.AutoSize = true;
            this.hexagonDepthLabel.Location = new System.Drawing.Point(6, 204);
            this.hexagonDepthLabel.Name = "hexagonDepthLabel";
            this.hexagonDepthLabel.Size = new System.Drawing.Size(127, 13);
            this.hexagonDepthLabel.TabIndex = 7;
            this.hexagonDepthLabel.Text = "Depth of the hexagon dip";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(250, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(250, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(250, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(250, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(250, 149);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 13;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(250, 175);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 14;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(250, 201);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 15;
            // 
            // GearConstructingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 342);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "GearConstructingForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
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

