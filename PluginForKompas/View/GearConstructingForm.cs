using System;
using System.Windows.Forms;
using PluginForKompas;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace View
{
    public partial class GearConstructingForm : Form
    {
        private double rigidity = 0;
        private double teethCount = 0;

        public GearConstructingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запуск приложения КОМПАС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kompasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (kompasCheckBox.Checked)
            {
                KompasApp.GetActiveApp();
                count_of_gear_teeth.Enabled = true;
                rigidity_of_geat_unit.Enabled = true;
                buildButton.Enabled = true;
            }

            if (!kompasCheckBox.Checked)
            {
                KompasApp.Exit();
                foreach (Control groupBoxData in this.Controls)
                {
                    if ((groupBoxData is GroupBox)
                        && (groupBoxData.Name == "dataGroupBox"))
                    {
                        foreach (Control textbox in groupBoxData.Controls)
                        {
                            if (textbox is TextBox)
                            {
                                textbox.Enabled = false;
                            }
                        }
                    }
                }
                buildButton.Enabled = false;
            }
        }

        /// <summary>
        /// Создать новую деталь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            Parameter[] param = new Parameter[0];
                param = ReadData();
            if (param != null)
            {
                try
                {
                    GearBuilder Gear = new GearBuilder(param);
                    Gear.New();
                }
                catch
                {
                    MessageBox.Show("Object wasn't created.");
                }
            }
        }

        /// <summary>
        /// Метод возвращает динамический массив введенных данных 
        /// </summary>
        private Parameter[] ReadData()
        {
            try
            {
                int length = 0;
                Parameter[] parameters = new Parameter[length];
        
                foreach (Control groupBoxData in this.Controls)
                {
                    if ((groupBoxData is GroupBox)
                        && (groupBoxData.Name == "dataGroupBox"))
                    {
                        foreach (Control textbox in groupBoxData.Controls)
                        {
                            if (textbox is TextBox)
                            {
                                length++;
                                Array.Resize<Parameter>(ref parameters, length);
                                parameters[length - 1].value = double.Parse(textbox.Text,
                                    CultureInfo.InvariantCulture);
                                parameters[length - 1].descrpiption = textbox.Name;
                            }
                        }
                    }
                }
                if (length != 8)
                    throw new Exception();
                return parameters;
            }
            catch (Exception)
            {
                MessageBox.Show("There are empty fields. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Метод для проверки основных параметров шестерни
        /// </summary>
        /// <param name="regex">Регулярное выражение</param>
        /// <param name="text">Проверяемая строка</param>
        /// <param name="e">Данные отменяемого события</param>
        private void CheckData(string text, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            if ((regex.IsMatch(text) != true) && (text != ""))
            {
                MessageBox.Show("Invalid data. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                text = "";
            }
        }

        private void teethCountTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(count_of_gear_teeth.Text, e);
        }

        private void rigidityUnitTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(rigidity_of_geat_unit.Text, e);
        }

        private void centerHoleDiamTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(diameter_of_the_center_hole.Text, e);
        }

        private void circHolesDiamTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(diameter_of_the_circumential_holes.Text, e);
        }

        private void hexDiamTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(diameter_of_the_heaxagon_circumscribed_circle.Text, e);
        }

        private void hexDipDepthTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(depth_of_the_hexagon_dip.Text, e);
        }

        private void stiffWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(stiffeners_width.Text, e);
        }

        private void stiffDepthTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckData(depth_of_the_hexagon_dip.Text, e);
        }

        private void enableTextBoxs()
        {
            if ((rigidity != 0) && (teethCount != 0))
            {
                diameter_of_the_center_hole.Enabled = true;
                diameter_of_the_circumential_holes.Enabled = true;
                stiffener_depth.Enabled = true;
                stiffeners_width.Enabled = true;
                depth_of_the_hexagon_dip.Enabled = true;
            }
        }

        private void disableTextBoxs()
        {
            diameter_of_the_center_hole.Enabled = false;
            diameter_of_the_circumential_holes.Enabled = false;
            stiffener_depth.Enabled = false;
            stiffeners_width.Enabled = false;
            depth_of_the_hexagon_dip.Enabled = false;
        }

        private void teethCountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(count_of_gear_teeth.Text, "^[0-9]+$"))
            {
                teethCount = double.Parse(count_of_gear_teeth.Text);
                enableTextBoxs();
            }
            else
            {
                disableTextBoxs();
            }
        }
        
        private void rigidityUnitTextBox_TextChanged(object sender, EventArgs e)

        {
            if (Regex.IsMatch(rigidity_of_geat_unit.Text, "^[0-9]+$"))
            {
                rigidity = double.Parse(rigidity_of_geat_unit.Text);
                enableTextBoxs();
            }
            else
            {
                disableTextBoxs();
            }
        }

        private void centerHoleDiamTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(diameter_of_the_center_hole.Text, "^[0-9]+$"))
            {
                diameter_of_the_heaxagon_circumscribed_circle.Enabled = true;
            }
            else
            {
                diameter_of_the_heaxagon_circumscribed_circle.Enabled = false;
            }
        }

        private void hexDiamTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
