﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project__PHASE_1
{
    public partial class Remove : Form
    {
        string Author = "\0";
        string Category = "\0";
        int Quantity = 0;

        string connectionString = @"Data Source=DESKTOP-K9UJB8G;Initial Catalog=PorjectDataBase;Integrated Security=True";
        public Remove(Color BackGround, Color ForeGround, Color PanelBack)
        {
            InitializeComponent();
            this.BackColor = BackGround;
            this.ForeColor = ForeGround;
            RemovePanel.BackColor = PanelBack;
            RemovePanel.ForeColor = ForeGround;
            RemoveBtn.BackColor = BackGround;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(275, 117);
            empty.Visible = false;
            removeConfirm.Visible = false;
            
        }


        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        

        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (bookTitleTxt.Text == String.Empty || QuantityToRemoveTxt.Text == String.Empty)
            {
                empty.Visible = true;
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {

                    SqlCommand removeStateNow = new SqlCommand("Delete From BookInfo Where BookName=@BookName and AuthorName=@AuthorName", connection);
                    removeStateNow.Parameters.Add("@BookName", this.bookTitleTxt.Text);
                    removeStateNow.Parameters.Add("@AuthorName", this.AuthorNametxt.Text);

                    if (Quantity < Convert.ToInt32(QuantityToRemoveTxt.Text))
                    {
                        more.Visible = true;
                        return;
                    }
                    else if (Quantity > Convert.ToInt32(QuantityToRemoveTxt.Text))
                    {
                        SqlCommand sql = new SqlCommand("update BookInfo set Quantity=Quantity-@Quantity Where BookName=@BookName and AuthorName=@AuthorName", connection);
                        sql.Parameters.Add("@BookName", this.bookTitleTxt.Text);
                        sql.Parameters.Add("@AuthorName", this.AuthorNametxt.Text);
                        sql.Parameters.Add("@Quantity", Convert.ToInt32(this.QuantityToRemoveTxt.Text));
                        sql.ExecuteNonQuery();
                        removeConfirm.Visible = true;
                        return;
                    }
                    removeStateNow.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("connection failed");

                }
                connection.Close();
            }
        }

        private void Remove_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("Select * From BookInfo", connection);
                SqlDataReader data = cmd.ExecuteReader();
                AutoCompleteStringCollection autoString = new AutoCompleteStringCollection();

                while (data.Read())
                {
                    autoString.Add(data.GetString(1));

                }
                bookTitleTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
                bookTitleTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                bookTitleTxt.AutoCompleteCustomSource = autoString;
            }
            else
            {
                MessageBox.Show("connection failed");

            }
            connection.Close();
            if (this.ForeColor == Color.FromArgb(240, 240, 240))  //light mode
            {
                exit.Image = Image.FromFile("C:\\Users\\shahz\\OneDrive\\Documents\\GitHub\\Libaray-System\\Project Pictures\\icons\\exit_White.png");
            }
            else
            {
                exit.Image = Image.FromFile("C:\\Users\\shahz\\OneDrive\\Documents\\GitHub\\Libaray-System\\Project Pictures\\icons\\exit_Black.png");
            }
        }

        private void bookTitleTxt_TextChanged(object sender, EventArgs e)
        {

           
            
            
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("Select * From BookInfo Where BookName='" + bookTitleTxt.Text + "'", connection);
                    SqlDataReader data = cmd.ExecuteReader();

                    while (data.Read())
                    {
                        Author = data.GetString(2);
                        Category = data.GetString(3);
                        Quantity = data.GetInt32(4);

                    }

                    AuthorNametxt.Text = Author;
                    CategoryTxt.Text = Category;
                    QuantityAvaTxt.Text = Convert.ToString(Quantity);
                    //User Can not Change now
                    AuthorNametxt.ReadOnly = true;
                    CategoryTxt.ReadOnly = true;
                    QuantityAvaTxt.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("connection failed");

                }
                connection.Close();
            
        }

        private void RemoveSuccess_Click(object sender, EventArgs e)
        {
           
            removeConfirm.Visible = false;
            bookTitleTxt.Text = String.Empty;
            AuthorNametxt.Text = String.Empty;
            CategoryTxt.Text = String.Empty;
            QuantityAvaTxt.Text = String.Empty;
            QuantityToRemoveTxt.Text = String.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            empty.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            more.Visible = false;
            QuantityToRemoveTxt.Text = String.Empty;
        }
    }
}
