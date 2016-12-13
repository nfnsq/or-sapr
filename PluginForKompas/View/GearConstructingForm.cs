using System;
using System.Windows.Forms;
using PluginForKompas;

namespace View
{
    public partial class GearConstructingForm : Form
    {
        public GearConstructingForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Запуск приложения КОМПАС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                KompasApp.GetActiveApp();
            
            if (!checkBox1.Checked)
                KompasApp.Exit();
        }

        /// <summary>
        /// Создать новую деталь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GearBuilder Gear = new GearBuilder();
            Gear.New();
        }

        /// <summary>
        /// Изменить деталь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            GearBuilder Gear = new GearBuilder();
            Gear.Update();
        }
    }
}
