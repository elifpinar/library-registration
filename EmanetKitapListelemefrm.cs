﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public partial class EmanetKitapListelemefrm : Form
    {
        public EmanetKitapListelemefrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FEBFK33\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonDatabase;Integrated Security=True");  // "\" hata verdiği için başına @ ekledim
        DataSet daset= new DataSet();
        private void EmanetKitapListelemefrm_Load(object sender, EventArgs e)
        {
            EmanetListele();
            comboBox1.SelectedIndex = 0;
        }

        private void EmanetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from EmanetKitaplar", baglanti);
            adtr.Fill(daset, "EmanetKitaplar");
            dataGridView1.DataSource = daset.Tables["EmanetKitaplar"];
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            daset.Tables["EmanetKitaplar"].Clear();
            if (comboBox1.SelectedIndex==0)
            {
                EmanetListele();
            }
            else if(comboBox1.SelectedIndex==1)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select *from EmanetKitaplar where'"+DateTime.Now.ToShortDateString()+"'>iadetarihi", baglanti);
                adtr.Fill(daset, "EmanetKitaplar");
                dataGridView1.DataSource = daset.Tables["EmanetKitaplar"];
                baglanti.Close();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select *from EmanetKitaplar where'" + DateTime.Now.ToShortDateString() + "'<=iadetarihi", baglanti);
                adtr.Fill(daset, "EmanetKitaplar");
                dataGridView1.DataSource = daset.Tables["EmanetKitaplar"];
                baglanti.Close();
            }
        }
    }
}
