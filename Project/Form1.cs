using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Media;

namespace Project
{
    public partial class Form1 : Form 
    {
       //main form start
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            tone = "ChillingMusic.wav";
            Default();
           
        }

        //declarations

        DateTime dt;
        public int col_index;
        public int row_index;
        public string date;
        public string time;
        public int numC;
        string day;
        string music;
        int Ar = 1;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }
        int a = 0;
       int Row; int col;
        string d;
        string t;
        string text;

        //show value in datagrid view
        
        public void ShowValue()
        {

            try
            {
                string myConnection = "datasource = localhost;port =3306;username=root;password=5835";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select *from `d'database`.new_table ;", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    Row = int.Parse(myReader.GetString("Row"));
                    col = int.Parse(myReader.GetString("col"));
                    d = myReader.GetString("date");
                    t = myReader.GetString("time");
                    text = myReader.GetString("Notes");
                    count = count + 1;
                    for (int i = 1; i < numC; i++)
                    {
                       
                        if (dataGridView.Rows[0].Cells[i].Value.ToString()==d)
                        {
                            // MessageBox.Show(numC+"");
                            dataGridView.Rows[Row].Cells[i].Value = text;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //save data in database

        public void saveDatabase(int Row, int col, string date, string time, string notes)
        {
            
            string constring = "datasource = localhost;port =3306;username=root;password=5835";
            string Query = "insert into `d'database`.new_table (Row, col, date, time, Notes) values ('" + Row + "','" + col + "','" + date + "','" + time + "','" + notes + "');";
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
                
                
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            ShowValue();
            
        }
    

        //initialize

        int countColumn = 0;
        int r = 0;
        int rowIndex;
        int columnIndex;
        string real_text;
        string day1;
        int f = 0;
        public int colindex;
        public int rowindex;
        string Not;

        //data grid view cell click operations
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            col_index = dataGridView.CurrentCell.ColumnIndex;
            row_index = dataGridView.CurrentCell.RowIndex;
            time = dataGridView.Rows[row_index].Cells[0].Value.ToString();
            date = dataGridView.Rows[0].Cells[col_index].Value.ToString();
            if(dataGridView.CurrentCell.Value!= null)
                 Not = dataGridView.Rows[row_index].Cells[col_index].Value.ToString();
           /* if (row_index == 0 || col_index == 0)
            {
            }
            else{
                EntryForm ef = new EntryForm();
                ef.receiveCollumIndex(col_index);
                ef.receiveRowIndex(row_index);
                ef.receiveDate(date);
                ef.receiveTime(time);
              //  ef.giveValue(columnCount, row_index, col_index, day1);
                // this.Hide();
                ef.Show();
            }*/

           
           
            
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        //mouse over & leave with colour change

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DarkKhaki;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.GreenYellow;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DarkKhaki;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.GreenYellow;
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.DarkKhaki;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.GreenYellow;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.DarkKhaki;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.GreenYellow;
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.DarkKhaki;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.GreenYellow;
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            panel6.BackColor = Color.DarkKhaki;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.GreenYellow;
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            panel7.BackColor = Color.DarkKhaki;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.GreenYellow;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
           
        }
       
        int flag = 0;

        //calander date selected
        private void calander_DateSelected(object sender, DateRangeEventArgs e)
        {
            day = e.Start.Date.ToString();
            flag = 1;
        }
        int rowCount = 0;
        int columnCount = 0;

        //operation on panel click

        private void panel1_Click(object sender, EventArgs e)
        {
            numC = 2;
            dataGridView.Rows.Clear();
           

            //dataGridView.ClearSelection();
            if (flag == 0)
                day = DateTime.Now.ToString();
        
            
                dataGridView.RowCount = 25;
                dataGridView.ColumnCount = 2;
                rowCount = 25;
                columnCount = 2;
                day1 = day;
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 2; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() +":00" +  " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() +":00" +  " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());
                ShowValue();
               
           
             
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            numC = 3;
            dataGridView.Rows.Clear();

            if (flag == 0)
                day = DateTime.Now.ToString();

                dataGridView.RowCount = 25;
                day1 = day;
                dataGridView.ColumnCount = 3;
                rowCount = 25;
                columnCount = 3; 
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 3; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() +":00" +  " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() +":00" +  " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());

                ShowValue();
            
        }



        private void panel3_Click(object sender, EventArgs e)
        {
            numC = 4;
            dataGridView.Rows.Clear();

           if (flag == 0)
                day = DateTime.Now.ToString();

                dataGridView.RowCount = 25;
                day1 = day;
                dataGridView.ColumnCount = 4;
                rowCount = 25;
                columnCount = 4; 
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 4; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() + ":00" + " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() + ":00" + " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());
                ShowValue();
           
        }
        public void Default()
        {
            day = DateTime.Now.ToString();

            dataGridView.RowCount = 25;
            day1 = day;
            dataGridView.ColumnCount = 4;
            rowCount = 25;
            columnCount = 4;
            dataGridView.Columns[0].Name = "DAY";
            dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

            dt = DateTime.Parse(day);

            //dataGridView.Rows.Add(dt.Date.ToString());
            for (int i = 1; i < 4; i++)
            {
                dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                dt = dt.AddDays(1);

            }
            dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
            int b = 1;
            for (int i = 2; i <= 12; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = (b.ToString() + ":00" + " AM");
                b++;
            }
            dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
            int a = 1;
            for (int i = 14; i < 25; i++)
            {

                dataGridView.Rows[i].Cells[0].Value = (a.ToString() + ":00" + " PM");
                a++;
            }

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //dataGridView.Rows.Add(dt.Date.ToString());
            ShowValue();
           
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            numC = 5;
            dataGridView.Rows.Clear();

           if (flag == 0)
                day = DateTime.Now.ToString();

                dataGridView.RowCount = 25;
                day1 = day;
                dataGridView.ColumnCount = 5;
                rowCount = 25;
                columnCount = 5; 
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 5; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() +":00" +  " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() +":00" +  " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());
                ShowValue();

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            numC = 6;
            dataGridView.Rows.Clear();

           if (flag == 0)
                day = DateTime.Now.ToString();

                dataGridView.RowCount = 25;
                day1 = day;
                dataGridView.ColumnCount = 6;
                columnCount = 6; 
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 6; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() +":00" +  " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() + ":00" + " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());
                ShowValue();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            numC = 7;
            dataGridView.Rows.Clear();

            if (flag == 0)
                day = DateTime.Now.ToString();

                dataGridView.RowCount = 25;
                day1 = day;
                dataGridView.ColumnCount = 7;
                columnCount = 7; 
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 7; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() + ":00" + " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() +":00" + " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());
                ShowValue();
           
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            
            numC = 8;
            dataGridView.Rows.Clear();

            if (flag == 0)
                day = DateTime.Now.ToString();

                dataGridView.RowCount = 25;
                day1 = day;
                dataGridView.ColumnCount = 8;
                columnCount = 8; 
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < 8; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 9);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12:00 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString()+":00" + " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12:00 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() +":00" + " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                //dataGridView.Rows.Add(dt.Date.ToString());
                ShowValue();
            
        }
       
     
        private void panel5_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_AllowUserToResizeColumnsChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_AutoSizeColumnModeChanged(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
        {
            
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //digital clock, date show 

        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime dateTime = DateTime.Now;
            this.label_time.Text = dateTime.ToShortTimeString();
            this.label_tade.Text = dateTime.Date.ToShortDateString();
            this.label_day.Text = dateTime.DayOfWeek.ToString();
           /* string s = dateTime.ToShortTimeString();
            string di = dateTime.Date.ToShortDateString().Substring(0, 10);
            ReceiveTime(s,di);*/
        }
       // string ti, da;
     

        private void label_time_Click(object sender, EventArgs e)
        {

        }

        //load form

        private void Form1_Load(object sender, EventArgs e)
        {
            
                day = DateTime.Now.ToString();
            if (f == 1)
            {
                dataGridView.RowCount = 25;
                dataGridView.ColumnCount = countColumn;
                
                dataGridView.Columns[0].Name = "DAY";
                dataGridView.Rows[0].Cells[0].Value = "TIME & DATE";

                 dt = DateTime.Parse(day);

                //dataGridView.Rows.Add(dt.Date.ToString());
                for (int i = 1; i < countColumn; i++)
                {
                    dataGridView.Columns[i].Name = dt.DayOfWeek.ToString();
                    dataGridView.Rows[0].Cells[i].Value = dt.Date.ToString().Substring(0, 10);
                    dt = dt.AddDays(1);

                }
                dataGridView.Rows[1].Cells[0].Value = ("12 AM");
                int b = 1;
                for (int i = 2; i <= 12; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = (b.ToString() + " AM");
                    b++;
                }
                dataGridView.Rows[13].Cells[0].Value = ("12 PM");
                int a = 1;
                for (int i = 14; i < 25; i++)
                {

                    dataGridView.Rows[i].Cells[0].Value = (a.ToString() + " PM");
                    a++;
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //loop
                dataGridView.Rows[rowIndex].Cells[columnIndex].Value = real_text;
            }
          
           
        }
       
        //mouse right click
      
       

        private void label_tade_Click(object sender, EventArgs e)
        {

        }

        private void label_day_Click(object sender, EventArgs e)
        {

        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        //search form database
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource = localhost;port =3306;username=root;password=5835";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                // MySqlConnection myConn1 = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select *from `d'database`.new_table1 ;", myConn);
                //MySqlCommand SelectCommand1 = new MySqlCommand("select *from `d'database`.new_table1 ;", myConn1);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    DateTime dateTime = DateTime.Now;
                    string s = dateTime.ToShortTimeString();
                    //  string sx = dateTime.Date.ToShortDateString();
                    string di = dateTime.Date.ToShortDateString();
                    //Row = int.Parse(myReader.GetString("Row"));
                    //col = int.Parse(myReader.GetString("col"));
                    d = myReader.GetString("date");
                    t = myReader.GetString("time");
                    text = myReader.GetString("Notes");
                    // MessageBox.Show("aaa"+s+t + di+d+"aaa");
                    count = count + 1;
                    if (di == d)
                    {
                        if (s == t)
                        {
                            
                            ShowForm sF = new ShowForm();
                            sF.recevieNote(text);
                            sF.Show();
                            player.SoundLocation =tone;
                            player.Play();
                            

                        }
                    }



                }

            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        string tone ="ChillingMusic.wav";
       
        //set alarm tone
        public void SetTone(string  s)
        {
            tone = s;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource = localhost;port =3306;username=root;password=5835";
                MySqlConnection myConn = new MySqlConnection(myConnection);
               // MySqlConnection myConn1 = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select *from `d'database`.new_table ;", myConn);
                //MySqlCommand SelectCommand1 = new MySqlCommand("select *from `d'database`.new_table1 ;", myConn1);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    DateTime dateTime = DateTime.Now;
                    string s = dateTime.ToShortTimeString();
                  //  string sx = dateTime.Date.ToShortDateString();
                    string di = dateTime.Date.ToShortDateString();
                    Row = int.Parse(myReader.GetString("Row"));
                    col = int.Parse(myReader.GetString("col"));
                    d = myReader.GetString("date");
                    t = myReader.GetString("time");
                    text = myReader.GetString("Notes");
                  // MessageBox.Show("aaa"+s+t + di+d+"aaa");
                    count = count + 1;
                    if(di==d)
                    {
                        if (s == t)
                        {

                            ShowForm sF = new ShowForm();
                            sF.recevieNote(text);
                            sF.Show();
                            player.SoundLocation = tone;
                            player.Play();
                            
                           

                        }
                    }
                
                    
               
                }

                }
            
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        

        }

        //stop alarm
        public void stop()
        {
            player.Stop();
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        //operation of add reminder

        private void button1_Click_2(object sender, EventArgs e)
        {
            ReminderForm RF = new ReminderForm();
            RF.Show();
        }

        private void my_menu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntryForm ef = new EntryForm();
            ef.receiveCollumIndex(col_index);
            ef.receiveRowIndex(row_index);
            ef.receiveDate(date);
            ef.receiveTime(time);
            //  ef.giveValue(columnCount, row_index, col_index, day1);
            // this.Hide();
            ef.Show();
        }

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string constring = "datasource = localhost;port =3306;username=root;password=5835";
            string Query = "delete from `d'database`.new_table Where  Notes='" + Not + "';";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            // dataGridView.Rows[Row].Cells[col].Value = text;
            //MySqlDataReader myreader;
            try
            {
                conDatabase.Open();
                //myReader = cmdDatabase.ExecuteReader();
                cmdDatabase.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                // ids.Clear();


                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ShowValue();
        }

        //settings

        private void button2_Click(object sender, EventArgs e)
        {
            Settings se = new Settings();
            se.Show();
        }
    }
}
