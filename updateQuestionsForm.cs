using System;
using System.Linq;
using System.Windows.Forms;
using QuizManagementSystem_1.Models;
using Microsoft.EntityFrameworkCore;


namespace QuizManagementSystem_1
{
    public partial class updateQuestionsForm : Form
    {
        private QuizDbContext _context;

        public updateQuestionsForm()
        {
            InitializeComponent();

            // Initialize DbContext
            _context = new QuizDbContext();

            // Add event handlers
            comboSet5.SelectedIndexChanged += comboSet5_SelectedIndexChanged;
            comboQuestion5.SelectedIndexChanged += comboQuestion5_SelectedIndexChanged;
            btnUpdate5.Click += btnUpdate5_Click;
            btnReset5.Click += btnReset5_Click;
           // update_Goback.Click += update_Goback_Click;


            // Load question sets
            LoadQuestionSets();
        }

        // Load all question sets into comboSet5
        private void LoadQuestionSets()
        {
            try
            {
                comboSet5.Items.Clear();

                // Check if `_context.Questions` contains records
                if (_context.Questions == null)
                {
                    MessageBox.Show("No data found in Questions table.");
                    return;
                }

                // Fetch distinct question sets
                var questionSets = _context.Questions
                    .Select(q => q.QSet)
                    .Distinct()
                    .ToList();

                if (questionSets.Any())
                {
                    foreach (var set in questionSets)
                    {
                        comboSet5.Items.Add(set);
                    }
                }
                else
                {
                    MessageBox.Show("No question sets found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading question sets: {ex.Message}");
            }
        }


        // Load all questions for the selected set into comboQuestion5
        private void comboSet5_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllQuestions();
        }

        private void LoadAllQuestions()
        {
            comboQuestion5.Items.Clear();
            string selectedSet = comboSet5.Text;

            var questions = _context.Questions
                .Where(q => q.QSet == selectedSet)
                .Select(q => q.QNo)
                .ToList();

            if (questions.Any())
            {
                foreach (var qNo in questions)
                {
                    comboQuestion5.Items.Add(qNo);
                }
            }
            else
            {
                MessageBox.Show("No questions found for this set.");
            }
        }

        // Display the selected question details
        private void comboQuestion5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedQuestionDetails();
        }

        private void DisplaySelectedQuestionDetails()
        {
            if (comboQuestion5.SelectedIndex != -1)
            {
                int qNo = int.Parse(comboQuestion5.SelectedItem.ToString());
                string qSet = comboSet5.Text;

                var question = _context.Questions
                    .FirstOrDefault(q => q.QSet == qSet && q.QNo == qNo);

                if (question != null)
                {
                    txtQuestions5.Text = question.question;
                    txtOptions11.Text = question.OptionA;
                    txtOptions12.Text = question.OptionB;
                    txtOptions13.Text = question.OptionC;
                    txtOptions14.Text = question.OptionD;
                    txtAns5.Text = question.ans;
                }
                else
                {
                    MessageBox.Show("No question found for the selected number.");
                }
            }
        }

        // Update button event handler
        private void btnUpdate5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestions5.Text) || string.IsNullOrWhiteSpace(txtOptions11.Text) ||
                string.IsNullOrWhiteSpace(txtOptions12.Text) || string.IsNullOrWhiteSpace(txtOptions13.Text) ||
                string.IsNullOrWhiteSpace(txtOptions14.Text) || string.IsNullOrWhiteSpace(txtAns5.Text))
            {
                MessageBox.Show("Please fill all fields before updating.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qNo = int.Parse(comboQuestion5.SelectedItem.ToString());
            string qSet = comboSet5.Text;

            var question = _context.Questions
                .FirstOrDefault(q => q.QSet == qSet && q.QNo == qNo);

            if (question != null)
            {
                // Update properties
                question.question = txtQuestions5.Text;
                question.OptionA = txtOptions11.Text;
                question.OptionB = txtOptions12.Text;
                question.OptionC = txtOptions13.Text;
                question.OptionD = txtOptions14.Text;
                question.ans = txtAns5.Text;

                // Mark entity as modified if necessary
                _context.Entry(question).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                    MessageBox.Show("Question Updated Successfully!");

                    // Clear fields
                    Update_clearAll();

                    // Refresh ViewAndDelQuestionsForm if it's open
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm is ViewAndDelQuestionsForm viewAndDelForm)
                        {
                            viewAndDelForm.RefreshQuestionsGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Question not found. Update failed.");
            }
        }



        private void Update_clearAll()
        {
            txtQuestions5.Clear();
            txtOptions11.Clear();
            txtOptions12.Clear();
            txtOptions13.Clear();
            txtOptions14.Clear();
            txtAns5.Clear();
            comboQuestion5.SelectedIndex = -1;
        }

        private void btnReset5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved data will be lost. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Update_clearAll();
            }
        }

        private void update_Goback_Click(object sender, EventArgs e)
        {
            Teacher teacherForm = new Teacher();
            teacherForm.Show();
            this.Hide();

        }
    }
}
