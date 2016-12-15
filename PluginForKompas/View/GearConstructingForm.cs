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
        private static double rigidity = 0;
        private static double teethCount = 0;

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
                KompasApp.GetActiveApp();
            
            if (!kompasCheckBox.Checked)
                KompasApp.Exit();
        }

        /// <summary>
        /// Создать новую деталь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            double[] param = ReadData();
            if (param != null)
            {
                GearBuilder Gear = new GearBuilder(param);
                Gear.New();
            }
        }

        /// <summary>
        /// Метод возвращает динамический массив введенных данных 
        /// </summary>
        private double[] ReadData()
        {
            try
            {
                int length = 0;
                double[] parameters = new double[length];
        
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
                                Array.Resize<double>(ref parameters, length);
                                parameters[length - 1] = double.Parse(textbox.Text,
                                    CultureInfo.InvariantCulture);
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
                MessageBox.Show("Oops! There are empty fields. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void CheckData(Regex regex, string text, CancelEventArgs e)
        {
            if ((regex.IsMatch(text) != true) && (text != ""))
            {
                MessageBox.Show("Invalid data. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                text = "";
            }
        }

        private void CheckData(string text, double a, double b, CancelEventArgs e)
        {
            Regex regex = new Regex("^[1-9]{1}[0-9]{0,2}$");
            if ((regex.IsMatch(text) != true) && (text != ""))
            {
                MessageBox.Show("Format exception. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                if (text != "")
                {
                    double d = double.Parse(text);
                    if ((d < a) || (d > b))
                    {
                        MessageBox.Show("Format overflow. Please, try again.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void CheckDepth(string text, CancelEventArgs e)
        {
            double min = 0;
            double max = rigidity * teethCount * 0.1;
            CheckData(text, min, max, e);
        }

        private void teethCountTextBox_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[1-9]{1}[0-9]{0,1}$");
            CheckData(regex, teethCountTextBox.Text, e);
        }

        private void rigidityUnitTextBox_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[1-5]{1}[0-9]{0,1}\\.{0,1}[0-9]{0,1}5{0,1}$");
            CheckData(regex, rigidityUnitTextBox.Text, e);
        }

        private void centerHoleDiamTextBox_Validating(object sender, CancelEventArgs e)
        {
            double min = 5;
            double max = (0.25 * rigidity * (teethCount + 2) - 10) * Math.Cos(30 * Math.PI / 180);
            CheckData(centerHoleDiamTextBox.Text, min, max, e);
        }

        private void circHolesDiamTextBox_Validating(object sender, CancelEventArgs e)
        {
            double min = 5;
            double max = 0.9 * rigidity * (teethCount - 2.5) - 0.24 * rigidity * (teethCount + 2) - 10;
            CheckData(circHolesDiamTextBox.Text, min, max, e);
        }

        private void hexDiamTextBox_Validating(object sender, CancelEventArgs e)
        {
            double d1 = double.Parse(centerHoleDiamTextBox.Text);
            double min = d1 / Math.Cos(30 * Math.PI / 180);
            double max = 0.25 * rigidity * (teethCount + 2) - 10;
            CheckData(hexDiamTextBox.Text, min, max, e);
        }

        private void hexDipDepthTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckDepth(hexDipDepthTextBox.Text, e);
        }

        private void stiffWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            double min = 12;
            double max = 22;
            CheckData(stiffWidthTextBox.Text, min, max, e);
        }

        private void stiffDepthTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckDepth(hexDipDepthTextBox.Text, e);
        }

        private void centerHoleDiamTextBox_Validated(object sender, EventArgs e)
        {
            if (centerHoleDiamTextBox.Text != "")
            hexDiamTextBox.Enabled = true;
        }

        private void rigidityUnitTextBox_Validated(object sender, EventArgs e)
        {
            if (rigidityUnitTextBox.Text != "")
            {
                rigidity = double.Parse(rigidityUnitTextBox.Text);
                enableTextBoxs();
            }
        }

        private void teethCountTextBox_Validated(object sender, EventArgs e)
        {
            if (teethCountTextBox.Text != "")
            {
                teethCount = double.Parse(teethCountTextBox.Text);
                enableTextBoxs();
            }
        }

        private void enableTextBoxs()
        {
            if ((rigidity != 0) && (teethCount != 0))
            {
                centerHoleDiamTextBox.Enabled = true;
                circHolesDiamTextBox.Enabled = true;
                stiffDepthTextBox.Enabled = true;
                stiffWidthTextBox.Enabled = true;
                hexDipDepthTextBox.Enabled = true;
            }
        }
    }
}
