using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            // Remove the focus from the textboxes
            this.ActiveControl = label1;
        }

        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if(fname.Equals("First Name"))
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.Black;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.Equals("First Name"))
            {
                textBoxFirstName.Text = "First Name";
                textBoxFirstName.ForeColor = Color.White;
            }
        }

        private void textBoxLastName_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastName.Text;
            if (lname.Equals("Last Name"))
            {
                textBoxLastName.Text = "";
                textBoxLastName.ForeColor = Color.Black;
            }
        }

        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastName.Text;
            if (lname.Equals("Last Name"))
            {
                textBoxLastName.Text = "Last Name";
                textBoxLastName.ForeColor = Color.White;
            }
        }

        private void textBoxOtherName_Enter(object sender, EventArgs e)
        {
            String oname = textBoxOtherName.Text;
            if (oname.Equals("Other Name"))
            {
                textBoxOtherName.Text = "";
                textBoxOtherName.ForeColor = Color.Black;
            }
        }

        private void textBoxOtherName_Leave(object sender, EventArgs e)
        {
            String oname = textBoxOtherName.Text;
            if (oname.Equals("Other Name"))
            {
                textBoxOtherName.Text = "Other Name";
                textBoxOtherName.ForeColor = Color.White;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.Equals("E-Mail"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.Equals("E-Mail"))
            {
                textBoxEmail.Text = "E-Mail";
                textBoxEmail.ForeColor = Color.White;
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.Equals("Username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.Equals("Username"))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.White;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.Equals("Password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.Equals("Password"))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.White;
            }
        }

        private void textBoxPasswordConfirm_Enter(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.Equals("Confirm Password"))
            {
                textBoxPasswordConfirm.Text = "";
                textBoxPasswordConfirm.UseSystemPasswordChar = true;
                textBoxPasswordConfirm.ForeColor = Color.Black;
            }
        }

        private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.Equals("Confirm Password"))
            {
                textBoxPasswordConfirm.Text = "Confirm Password";
                textBoxPasswordConfirm.UseSystemPasswordChar = true;
                textBoxPasswordConfirm.ForeColor = Color.White;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void label2_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            //Add New User
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `othername`, `emailaddress`, `username`, `password`) VALUES (@fn, @ln, @on, @email, @usn, @pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstName.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastName.Text;
            command.Parameters.Add("@on", MySqlDbType.VarChar).Value = textBoxOtherName.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            //Open connection
            db.openConnection();

            //Check if textboxes are contains the default values
            if(!checkTextBoxesValues())
            {
                //Check if Password is the same
                if (textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                {
                    //Check if username already exists
                    if (checkUsername())
                    {
                        MessageBox.Show("USERNAME ALREADY EXISTS, CHOSE NEW ONE", "DUPLICATE USERNAME", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }

                    else
                    {
                        //Execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("YOUR ACCOUNT HAS BEEN CREATED","ACCOUNT CREATED",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("INCORRECT ENTRY");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("WRONG CONFIRMATION PASSWORD","PASSWORD ERROR",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ENTER YOUR RECORDS FIRST","EMPTY DATA",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }

            //Close connection
            db.closeConnction();
        }

        // Check if username already exits
        public Boolean checkUsername()
        {
            DB db = new DB();
            String username = textBoxUsername.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //Check if the username already exists
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check if the textboxes contains the default values
        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String oname = textBoxOtherName.Text;
            String email = textBoxEmail.Text;
            String usern = textBoxUsername.Text;
            String pass = textBoxPassword.Text;

            if(fname.Equals("First Name") || lname.Equals("Last Name") ||
                oname.Equals("Other Name") || email.Equals("E-Mail") || usern.Equals("Username")
                || pass.Equals("Password"))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void labelGoToLogin_MouseEnter(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.Green;
        }

        private void labelGoToLogin_MouseLeave(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.White;
        }

        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}
