﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        //MySql Connetion
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=donor_db");
        public Form1()
        {
            InitializeComponent();

            //this.textBoxPassword.AutoSize = false;
            //this.textBoxPassword.Size = new Size(this.textBoxPassword.Size.Width, 50);
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //Check if the user exeits or not
            if(table.Rows.Count > 0)
            {
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
            else
            {
                if (password.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER USERNAME TO LOGIN","EMPTY USERNAME",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                else if (username.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER PASSWORD TO LOGIN", "EMPTY PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD", "WRONG DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

        private void labelGoToSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Green;
        }

        private void labelGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.White;
        }
    }
}
