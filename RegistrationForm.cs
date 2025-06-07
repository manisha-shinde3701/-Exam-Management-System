using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister1_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(txtRollNumber.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtFatherName.Text) ||
                string.IsNullOrWhiteSpace(txtMotherName.Text) ||
                cmbGender.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txt10thPercentage.Text) ||
                string.IsNullOrWhiteSpace(txt12thPercentage.Text) ||
                string.IsNullOrWhiteSpace(txtGraduationPercentage.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("All fields are mandatory!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Collect student details
            string rollNumber = txtRollNumber.Text;
            string name = txtName.Text;
            string fatherName = txtFatherName.Text;
            string motherName = txtMotherName.Text;
            string gender = cmbGender.SelectedItem.ToString();
            string contactNumber = txtContactNumber.Text;
            string email = txtEmail.Text;
            decimal tenthPercentage = decimal.Parse(txt10thPercentage.Text);
            decimal twelfthPercentage = decimal.Parse(txt12thPercentage.Text);
            decimal graduationPercentage = decimal.Parse(txtGraduationPercentage.Text);
            string address = txtAddress.Text;

            // Insert into database
            string connectionString = "Data Source=MANISHASHINDE37\\SQLEXPRESS;Initial Catalog=Quiz1;Integrated Security=True;"; // replace with your database connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO students (RollNumber, Name, FatherName, MotherName, Gender, ContactNumber, Email, TenthPercentage, TwelfthPercentage, GraduationPercentage, Address) " +
                               "VALUES (@RollNumber, @Name, @FatherName, @MotherName, @Gender, @ContactNumber, @Email, @TenthPercentage, @TwelfthPercentage, @GraduationPercentage, @Address)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RollNumber", rollNumber);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@FatherName", fatherName);
                    cmd.Parameters.AddWithValue("@MotherName", motherName);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@TenthPercentage", tenthPercentage);
                    cmd.Parameters.AddWithValue("@TwelfthPercentage", twelfthPercentage);
                    cmd.Parameters.AddWithValue("@GraduationPercentage", graduationPercentage);
                    cmd.Parameters.AddWithValue("@Address", address);

                    try
                    {
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student registration successful! Click OK to proceed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Proceed to InstructionsForm
                            InstructionsForm instruct = new InstructionsForm(name, rollNumber); // Pass name and roll number
                            this.Hide();
                            instruct.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not save registration details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
