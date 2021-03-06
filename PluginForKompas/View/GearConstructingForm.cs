﻿using System;
using System.Windows.Forms;
using PluginForKompas;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// СУщность для создания пользовательского 
    /// интерфейса программы
    /// </summary>
    public partial class GearConstructingForm : Form
    {
        public KompasApp app = new KompasApp();
        private double _rigidity = 0;
        private double _teethCount = 0;
        
        /// <summary>
        /// Конструктор формы, инициализирующий его компоненты
        /// </summary>
        public GearConstructingForm()
        {
            InitializeComponent();
            app.GetActiveApp();
            if (app.Kompas != null)
            {
                GotActiveApp();
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
                    GearBuilder Gear = new GearBuilder(app, param);
                    Gear.CreateGear();
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
                                parameters[length - 1].Value = double.Parse(textbox.Text,
                                    CultureInfo.InvariantCulture);
                                if (textbox.Name == countOfGearTeethTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.Count;
                                if (textbox.Name == rigidityOfGeatUnitTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.Rigidity;
                                if (textbox.Name == diameterOfTheCenterHoleTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.CenterHole;
                                if (textbox.Name == diameterOfTheCircumentialHolesTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.CircumentalHoles;
                                if (textbox.Name == diameterOfTheHeaxagonCircumscribedCircleTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.HexagonDiameter;
                                if (textbox.Name == depthOfTheHexagonDipTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.HexagonDepth;
                                if (textbox.Name == stiffenersWidthTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.StiffenerWidth;
                                if (textbox.Name == stiffenerDepthTextBox.Name)
                                    parameters[length - 1].Descrpiption = PluginForKompas.Properties.Resources.StiffenerDepth;
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
        private void DataValidating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            if ((regex.IsMatch(((TextBox)sender).Text) != true) && (((TextBox)sender).Text != ""))
            {
                MessageBox.Show("Invalid data. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                ((TextBox)sender).Text = "";
            }
        }

        private void enableTextBoxs()
        {
            if ((_rigidity != 0) && (_teethCount != 0))
            {
                diameterOfTheCenterHoleTextBox.Enabled = true;
                diameterOfTheCircumentialHolesTextBox.Enabled = true;
                stiffenerDepthTextBox.Enabled = true;
                stiffenersWidthTextBox.Enabled = true;
                depthOfTheHexagonDipTextBox.Enabled = true;
            }
        }

        private void disableTextBoxs()
        {
            diameterOfTheCenterHoleTextBox.Enabled = false;
            diameterOfTheCircumentialHolesTextBox.Enabled = false;
            stiffenerDepthTextBox.Enabled = false;
            stiffenersWidthTextBox.Enabled = false;
            depthOfTheHexagonDipTextBox.Enabled = false;
        }

        private void ChangeEnable(object sender, EventArgs e)
        {

            if (((TextBox)sender) == countOfGearTeethTextBox)
            {
                if (Regex.IsMatch(((TextBox)sender).Text, "^[0-9]+$"))
                {
                    _teethCount = double.Parse(((TextBox)sender).Text);
                    enableTextBoxs();
                }
                else disableTextBoxs();
            }

            if (((TextBox)sender) == rigidityOfGeatUnitTextBox)
            {
                if (Regex.IsMatch(((TextBox)sender).Text, "^[0-9]+$"))
                {
                    _rigidity = double.Parse(((TextBox)sender).Text);
                    enableTextBoxs();
                }
                else disableTextBoxs();
            }
            if (((TextBox)sender) == diameterOfTheCenterHoleTextBox)
            {
                if (Regex.IsMatch(((TextBox)sender).Text, "^[0-9]+$"))
                {
                    diameterOfTheHeaxagonCircumscribedCircleTextBox.Enabled = true;
                }
                else diameterOfTheHeaxagonCircumscribedCircleTextBox.Enabled = false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startToolStripStatusLabel.Text = "Kompas starting...";
            app.GetActiveApp();
            if (app.Kompas == null)
                app.NewApp();
            GotActiveApp();
        }

        private void GotActiveApp()
        {
            startButton.Enabled = false;
            countOfGearTeethTextBox.Enabled = true;
            rigidityOfGeatUnitTextBox.Enabled = true;
            buildButton.Enabled = true;
            startToolStripStatusLabel.Text = "Kompas started.";
        }
    }
}
