using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ePLData.League_stats". При необходимости она может быть перемещена или удалена.
            this.league_statsTableAdapter.Fill(this.ePLData.League_stats);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ePLData.Player". При необходимости она может быть перемещена или удалена.
            this.playerTableAdapter.Fill(this.ePLData.Player);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ePLData.League_stats". При необходимости она может быть перемещена или удалена.
            this.league_statsTableAdapter.Fill(this.ePLData.League_stats);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ePLData.General_Team_Info". При необходимости она может быть перемещена или удалена.
            this.general_Team_InfoTableAdapter.Fill(this.ePLData.General_Team_Info);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.general_Team_InfoTableAdapter.Fill(this.ePLData.General_Team_Info);
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            EPLDataTableAdapters.General_Team_InfoTableAdapter GTITableAdapter = new EPLDataTableAdapters.General_Team_InfoTableAdapter();
            GTITableAdapter.Insert(textBox1.Text, textBox2.Text);
            this.general_Team_InfoTableAdapter.Fill(this.ePLData.General_Team_Info);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EPLData.General_Team_InfoRow GTIRow;
            GTIRow = ePLData.General_Team_Info.FindByid_team(Convert.ToInt16(textBox3.Text));
            GTIRow.manager = textBox4.Text;
            this.general_Team_InfoTableAdapter.Update(this.ePLData.General_Team_Info);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EPLData.General_Team_InfoRow GTIRow;
            GTIRow = ePLData.General_Team_Info.FindByid_team(Convert.ToInt16(textBox5.Text));
            GTIRow.Delete();
            this.general_Team_InfoTableAdapter.Update(this.ePLData.General_Team_Info);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            EPLData.PlayerRow PlayerRow;
            PlayerRow = ePLData.Player.FindByid_player(Convert.ToInt16(textBox6.Text));
            PlayerRow.id_team = Convert.ToInt16(textBox8.Text);
            this.playerTableAdapter.Update(this.ePLData.Player);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chart1.Series["Goals"].Points.Clear();
            chart2.Series["Assists"].Points.Clear();
            for (int i = 0; i < dataGridView2.RowCount - 1; i++ )
            {
                chart1.Series["Goals"].Points.AddXY(dataGridView2[1, i].Value.ToString(), dataGridView2[6, i].Value.ToString());
            }
            chart1.DataBind();

            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                chart2.Series["Assists"].Points.AddXY(dataGridView2[1, i].Value.ToString(), dataGridView2[7, i].Value.ToString());
            }
            chart2.DataBind();
        }
    }
}
