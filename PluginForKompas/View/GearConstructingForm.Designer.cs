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
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.depth_of_the_hexagon_dip = new System.Windows.Forms.TextBox();
            this.stiffener_depth = new System.Windows.Forms.TextBox();
            this.stiffeners_width = new System.Windows.Forms.TextBox();
            this.diameter_of_the_heaxagon_circumscribed_circle = new System.Windows.Forms.TextBox();
            this.diameter_of_the_circumential_holes = new System.Windows.Forms.TextBox();
            this.diameter_of_the_center_hole = new System.Windows.Forms.TextBox();
            this.rigidity_of_geat_unit = new System.Windows.Forms.TextBox();
            this.count_of_gear_teeth = new System.Windows.Forms.TextBox();
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
            this.buildButton.Enabled = false;
            this.buildButton.Location = new System.Drawing.Point(241, 313);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 1;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.depth_of_the_hexagon_dip);
            this.dataGroupBox.Controls.Add(this.stiffener_depth);
            this.dataGroupBox.Controls.Add(this.stiffeners_width);
            this.dataGroupBox.Controls.Add(this.diameter_of_the_heaxagon_circumscribed_circle);
            this.dataGroupBox.Controls.Add(this.diameter_of_the_circumential_holes);
            this.dataGroupBox.Controls.Add(this.diameter_of_the_center_hole);
            this.dataGroupBox.Controls.Add(this.rigidity_of_geat_unit);
            this.dataGroupBox.Controls.Add(this.count_of_gear_teeth);
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
            // depth_of_the_hexagon_dip
            // 
            this.depth_of_the_hexagon_dip.Enabled = false;
            this.depth_of_the_hexagon_dip.Location = new System.Drawing.Point(252, 149);
            this.depth_of_the_hexagon_dip.Name = "depth_of_the_hexagon_dip";
            this.depth_of_the_hexagon_dip.Size = new System.Drawing.Size(44, 20);
            this.depth_of_the_hexagon_dip.TabIndex = 15;
            this.depth_of_the_hexagon_dip.Validating += new System.ComponentModel.CancelEventHandler(this.hexDipDepthTextBox_Validating);
            // 
            // stiffener_depth
            // 
            this.stiffener_depth.Enabled = false;
            this.stiffener_depth.Location = new System.Drawing.Point(252, 201);
            this.stiffener_depth.Name = "stiffener_depth";
            this.stiffener_depth.Size = new System.Drawing.Size(44, 20);
            this.stiffener_depth.TabIndex = 14;
            this.stiffener_depth.Validating += new System.ComponentModel.CancelEventHandler(this.stiffDepthTextBox_Validating);
            // 
            // stiffeners_width
            // 
            this.stiffeners_width.Enabled = false;
            this.stiffeners_width.Location = new System.Drawing.Point(252, 175);
            this.stiffeners_width.Name = "stiffeners_width";
            this.stiffeners_width.Size = new System.Drawing.Size(44, 20);
            this.stiffeners_width.TabIndex = 13;
            this.stiffeners_width.Validating += new System.ComponentModel.CancelEventHandler(this.stiffWidthTextBox_Validating);
            // 
            // diameter_of_the_heaxagon_circumscribed_circle
            // 
            this.diameter_of_the_heaxagon_circumscribed_circle.Enabled = false;
            this.diameter_of_the_heaxagon_circumscribed_circle.Location = new System.Drawing.Point(252, 123);
            this.diameter_of_the_heaxagon_circumscribed_circle.Name = "diameter_of_the_heaxagon_circumscribed_circle";
            this.diameter_of_the_heaxagon_circumscribed_circle.Size = new System.Drawing.Size(44, 20);
            this.diameter_of_the_heaxagon_circumscribed_circle.TabIndex = 12;
            this.diameter_of_the_heaxagon_circumscribed_circle.TextChanged += new System.EventHandler(this.hexDiamTextBox_TextChanged);
            this.diameter_of_the_heaxagon_circumscribed_circle.Validating += new System.ComponentModel.CancelEventHandler(this.hexDiamTextBox_Validating);
            // 
            // diameter_of_the_circumential_holes
            // 
            this.diameter_of_the_circumential_holes.Enabled = false;
            this.diameter_of_the_circumential_holes.Location = new System.Drawing.Point(252, 97);
            this.diameter_of_the_circumential_holes.Name = "diameter_of_the_circumential_holes";
            this.diameter_of_the_circumential_holes.Size = new System.Drawing.Size(44, 20);
            this.diameter_of_the_circumential_holes.TabIndex = 11;
            this.diameter_of_the_circumential_holes.Validating += new System.ComponentModel.CancelEventHandler(this.circHolesDiamTextBox_Validating);
            // 
            // diameter_of_the_center_hole
            // 
            this.diameter_of_the_center_hole.Enabled = false;
            this.diameter_of_the_center_hole.Location = new System.Drawing.Point(252, 71);
            this.diameter_of_the_center_hole.Name = "diameter_of_the_center_hole";
            this.diameter_of_the_center_hole.Size = new System.Drawing.Size(44, 20);
            this.diameter_of_the_center_hole.TabIndex = 10;
            this.diameter_of_the_center_hole.TextChanged += new System.EventHandler(this.centerHoleDiamTextBox_TextChanged);
            this.diameter_of_the_center_hole.Validating += new System.ComponentModel.CancelEventHandler(this.centerHoleDiamTextBox_Validating);
            // 
            // rigidity_of_geat_unit
            // 
            this.rigidity_of_geat_unit.Enabled = false;
            this.rigidity_of_geat_unit.Location = new System.Drawing.Point(252, 45);
            this.rigidity_of_geat_unit.Name = "rigidity_of_geat_unit";
            this.rigidity_of_geat_unit.Size = new System.Drawing.Size(44, 20);
            this.rigidity_of_geat_unit.TabIndex = 9;
            this.rigidity_of_geat_unit.TextChanged += new System.EventHandler(this.rigidityUnitTextBox_TextChanged);
            this.rigidity_of_geat_unit.Validating += new System.ComponentModel.CancelEventHandler(this.rigidityUnitTextBox_Validating);
            // 
            // count_of_gear_teeth
            // 
            this.count_of_gear_teeth.Enabled = false;
            this.count_of_gear_teeth.Location = new System.Drawing.Point(252, 19);
            this.count_of_gear_teeth.Name = "count_of_gear_teeth";
            this.count_of_gear_teeth.Size = new System.Drawing.Size(44, 20);
            this.count_of_gear_teeth.TabIndex = 8;
            this.count_of_gear_teeth.TextChanged += new System.EventHandler(this.teethCountTextBox_TextChanged);
            this.count_of_gear_teeth.Validating += new System.ComponentModel.CancelEventHandler(this.teethCountTextBox_Validating);
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
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.kompasCheckGroupBox);
            this.Name = "GearConstructingForm";
            this.Text = "Gear Creator";
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
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.TextBox depth_of_the_hexagon_dip;
        private System.Windows.Forms.TextBox stiffener_depth;
        private System.Windows.Forms.TextBox stiffeners_width;
        private System.Windows.Forms.TextBox diameter_of_the_heaxagon_circumscribed_circle;
        private System.Windows.Forms.TextBox diameter_of_the_circumential_holes;
        private System.Windows.Forms.TextBox diameter_of_the_center_hole;
        private System.Windows.Forms.TextBox rigidity_of_geat_unit;
        private System.Windows.Forms.TextBox count_of_gear_teeth;
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

