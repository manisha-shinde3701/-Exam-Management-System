using QuizManagementSystem_1.Teacher_UC;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void panel2_Paint(object sender, PaintEventArgs e)
        //{
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            wrongLabel.Visible = false;
        }

        private void txtSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSelectUser.SelectedIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
            else if (txtSelectUser.SelectedIndex == 1)
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }
        }

        private void checkBoxShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowHide.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
                checkBoxShowHide.Text = "Hide Password";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                checkBoxShowHide.Text = "Show Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "manisha" && txtPassword.Text == "Manisha")
            {
                wrongLabel.Visible = false;
                Teacher te = new Teacher();
                te.Show();
                this.Hide();
            }
            else
            {
                wrongLabel.Visible = true;
            }
        }

        private void btnStudentLogin_Click(object sender, EventArgs e)
        {
            string rollNumber = txtEnrollmentNo.Text.Trim();

            // Check if the roll number exists in the database
            string query = $"SELECT name FROM students WHERE RollNumber = '{rollNumber}'"; // Adjust table and column names as per your database

            DataSet ds = fn.GetData(query); // Assuming fn.GetData runs the query and returns a DataSet

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string studentName = ds.Tables[0].Rows[0]["name"].ToString();

                // Open the InstructionsForm and pass the student details
                InstructionsForm instructionsForm = new InstructionsForm(studentName, rollNumber);
                instructionsForm.Show();
                this.Hide();  // Hide the login form after successful login
            }
            else
            {
                MessageBox.Show("Roll number not found. Please register.");
            }
        }



        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
            this.Hide();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
