using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class StudentResultForm : Form
    {
        private function fn = new function();
        private string query;
        private int rollNumber;
        private int totalsets = 10;
        private int currentSet = 1;

        public StudentResultForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(StudentResultForm_Load);
            combo_studentName.SelectedIndexChanged += new EventHandler(combo_studentName_SelectedIndexChanged);
            progressBarResult.Maximum = totalsets;
            progressBarResult.Step = 1;
        }

        public void completeSet()
        {
            if(currentSet<totalsets)
            {
                currentSet++;
                progressBarResult.PerformStep();
                lblProgress.Text = $"Progress : {(currentSet * 10) / totalsets}%";
            }
            if(currentSet==totalsets)
            {
                MessageBox.Show("All sets Completed","quiz Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Load all registered students into the ComboBox when the form loads
        private void StudentResultForm_Load(object sender, EventArgs e)
        {
            LoadStudentNames();
        }

        // Method to load student names from the database into the ComboBox
        private void LoadStudentNames()
        {
            combo_studentName.Items.Clear();
            combo_studentName.Items.Add("Select Student");

            query = "SELECT DISTINCT RollNumber, Name FROM students"; // Query to get roll number and name of each student
            DataSet ds = fn.GetData(query);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string displayText = $"{row["RollNumber"]} - {row["Name"]}"; // Concatenate RollNumber and Name
                    combo_studentName.Items.Add(displayText);
                }
            }
            else
            {
                MessageBox.Show("No student names found in the database.");
            }
        }

        // Display student information and exam result when a student is selected from the ComboBox
        // Corrected Event Handler
        private void combo_studentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_studentName.SelectedIndex > 0) // Ensure a valid student is selected
            {
                // Extract name from the combo box item (RollNumber - Name)
                string selectedStudentName = combo_studentName.Text.Split('-')[1].Trim();
                query = @"SELECT 
                        students.RollNumber AS [Roll Number], students.Name AS [Student Name], 
                        students.FatherName AS [Father's Name], students.MotherName AS [Mother's Name], 
                        students.Gender AS Gender, students.ContactNumber AS [Contact Number], 
                        students.Email AS Email, exam_results.ExamDate AS [Exam Date], 
                        exam_results.ObtainedMarks AS [Marks Obtained]  
                        FROM students 
                        LEFT JOIN exam_results 
                        ON students.RollNumber = exam_results.RollNumber 
                        WHERE students.Name = @Name";
                var parameters = new Dictionary<string, object>
                    {
                        { "@Name", selectedStudentName }
                    };

                DataSet ds = fn.GetData(query, parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gridView2.DataSource = ds.Tables[0];
                    gridView2.Refresh(); // Refresh the grid to display the data
                }
                else
                {
                    MessageBox.Show("No data found for the selected student.");
                    gridView2.DataSource = null;
                    gridView2.Refresh(); // Clear and refresh the grid if no data
                }
            }
            else
            {
                gridView2.DataSource = null; // Clear grid if no valid selection
                gridView2.Refresh();
            }
        }


        // Capture student information on grid cell click (if needed for further operations)
        private void gridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                try
                {
                    // Check for null and handle it to avoid exceptions
                    var value = gridView2.Rows[e.RowIndex].Cells[0].Value;
                    if (value != null)
                    {
                        rollNumber = int.Parse(value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("No Roll Number available for this entry.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving data: " + ex.Message);
                }
            }
        }

        // Button to return to the Teacher form
        private void button1_Click(object sender, EventArgs e)
        {
            Teacher teacherForm = new Teacher();
            teacherForm.Show();
            this.Hide(); // Hide the current form
        }

        //private void StudentResultForm_Load_1(object sender, EventArgs e)
        //{

        //}
    }
}
