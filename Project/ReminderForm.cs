using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class ReminderForm : Form
    {
        public ReminderForm()
        {
            InitializeComponent();
        }

        //declaration 

        DateTime dt;
        string day;
        int f = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //close form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //save data in database

        private void button1_Click(object sender, EventArgs e)
        {
            if (f == 1)
            {
                    string time = comboBoxHour.Text + ":" + comboBoxMin.Text +" " + comboBoxAM.Text;
                    dt = DateTime.Parse(day);
                    string s = dt.Date.ToString().Substring(0, 9);
                    string constring = "datasource = localhost;port =3306;username=root;password=5835";
                    string Query = "insert into `d'database`.new_table1 (date, time, Notes) values ('" + s.ToString() + "','" + time + "','" + textBox1.Text + "');";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    // dataGridView.Rows[Row].Cells[col].Value = text;
                    //MySqlDataReader myreader;
                    try
                    {
                        conDatabase.Open();
                        //myReader = cmdDatabase.ExecuteReader();
                        cmdDatabase.ExecuteNonQuery();
                        MessageBox.Show("Saved");
                        // ids.Clear();
                       // textBox1.Clear();
                       // textBox2.Clear();
                        conDatabase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.Close();
                
            }
            else
                MessageBox.Show("Select a date");
            
           
        }

        //date selected
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            day = e.Start.Date.ToString();
            f = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
        }

        private void button2MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button1MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
        }

        private void button1MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }
    }
}
