﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace HomeFitness.Controls.MainPanel
{
    public partial class MainControl : UserControl
    {
        string conS1;
        //int c=0;
        
        public MainControl()
        {
            InitializeComponent();
            conS1 = ConfigurationManager.ConnectionStrings["HomeFitness.Properties.Settings.bazaConnectionString"].ConnectionString;
            najblizszytrening();
            {
                
            }


        }
        private void najblizszytrening () // poka poka baze mi
        {
            int c = 0;
            SqlConnection cn = new SqlConnection(conS1);
            cn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Plan_treningu order by Dzien asc", cn);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (c == 0)
                {  
                    kiedytr.Text= dr["Dzien"].ToString() + "  "+ (dr["godzina"].ToString());
                }
                c++;
            }




           
            String nr = "1";
            float cel = 0;
            float ob = 0;

            SqlDataAdapter d = new SqlDataAdapter("Select Obecna from Waga where Id='" + nr + "' ", cn);
            d.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pomocniczy.Text = dr["obecna"].ToString();
            }

            ob = float.Parse(pomocniczy.Text);

            SqlDataAdapter dd = new SqlDataAdapter("Select Cel from Waga where Id='" + nr + "' ", cn);
            dd.Fill(dt);
            //DataTable dtt = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                pomocniczy.Text = dr["Cel"].ToString();
            }

            cel = float.Parse(pomocniczy.Text);

            label8.Text = (ob - cel).ToString();


          
            d = new SqlDataAdapter("Select sum(czas) as czas from czas ", cn);
            d.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               
                    pomocniczy.Text = dr["czas"].ToString();
               
            }




            int czas = Int32.Parse(pomocniczy.Text);
             d = new SqlDataAdapter("Select sum(kalorie) as kalorie from czas ", cn);
            d.Fill(dt);
            
            foreach (DataRow dr in dt.Rows)
            {
                
                    pomocniczy.Text = dr["kalorie"].ToString();
                
            }

 int kcal = Int32.Parse(pomocniczy.Text);


           
            double wartosc = czas * 0.3 + kcal * 0.1;
            label7.Text = wartosc.ToString()+" pkt";
            if (wartosc <= 100)
            {
                label5.Text = "Początkujący";
            }
            else if (wartosc > 100 && wartosc <= 300)
            {
                label5.Text = "Średniozaawansowany";
            }
            else if (wartosc > 300)
            {
                {
                    label5.Text = "Zaawansowany";
                }
            }

   

            cn.Close();



        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MainControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kiedytr_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pomocniczy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
