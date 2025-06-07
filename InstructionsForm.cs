using System;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class InstructionsForm : Form
    {
        private string studentName;
        private string studentRollNumber;

        // Constructor to receive name and roll number
        public InstructionsForm(string name, string rollNumber)
        {
            InitializeComponent();
            studentName = name;
            studentRollNumber = rollNumber;

            // Attach event handler for btnStartExam
            btnStartExam.Click += new EventHandler(btnStartExam_Click);
        }

        private void InstructionsForm_Load(object sender, EventArgs e)
        {
            // Initialization logic for when the form loads
        }

        private void btnStartExam_Click(object sender, EventArgs e)
        {
            // Pass the stored name and roll number to ExamDetailsForm
            ExamDetailsForm examForm = new ExamDetailsForm(studentName, studentRollNumber);
            examForm.Show();
            this.Hide();
        }
    }
}
