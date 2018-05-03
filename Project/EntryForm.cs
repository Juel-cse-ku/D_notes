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
    public partial class EntryForm : Form 
    {
        public EntryForm()
        {
            InitializeComponent();
        }


        //declaration
        int rowIndex, collumIndex;
        string date, time;
        int countColumn;
        int rowindex;
        int columnIndex;
        string day;


        //receive parametres from main form
        public void receiveRowIndex(int r)
        {
            rowIndex = r;
        }
        
       
       
        public void receiveDate(string d)
        {
            this.date = d;
        }
        public void receiveTime(string t)
        {
            time = t;
        }

        public void receiveCollumIndex(int c)
        {
            collumIndex = c; 
        }

        //saved by main form 
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.saveDatabase(rowIndex, collumIndex, date, time, this.note_txt.Text);
           
            //note_txt.Clear();
            this.Close();
            
            
          
        }
        
        private void note_txt_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EntryForm_Load(object sender, EventArgs e)
        {

        }

        private void button1MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
        }

        private void button1MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void button2MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button2MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }
    }
}
