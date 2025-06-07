using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class ExamDetailsForm : Form
    {
        public string StudentName { get; set; }
        public string RollNumber { get; set; }

        private function fn = new function();  // Assuming 'function' is a class that handles DB operations.
        private int currentQuestionIndex = 0;
        private int totalQuestions;
        private DataSet questionDataSet;
        private int remainingTime;  // Remaining time in seconds
        private Timer countdownTimer;  // Timer object
        private int score = 0;  // Score variable
        private List<string> userAnswers = new List<string>();  // Store user answers

        public ExamDetailsForm(string name, string rollNumber)
        {
            InitializeComponent();

            // Assign the constructor parameters to the properties
            this.StudentName = name;
            this.RollNumber = rollNumber;

            // Display the name and roll number in labels
            lblStudentName.Text = this.StudentName;
            lblRollNumber.Text = this.RollNumber;

            comboQuestionSet.SelectedIndexChanged += comboQuestionSet_SelectedIndexChanged;
            LoadQuestionSets();
            btnNext5.Click += new EventHandler(btnNext5_Click);
            this.prevBtn.Click += new EventHandler(this.prevBtn_Click);
            this.btnFinish.Click += new EventHandler(this.btnFinish_Click);
            this.Load += ExamDetailsForm_Load;

        }


        private void LoadQuestionSets()
        {
            try
            {
                comboQuestionSet.Items.Clear(); // Clear existing items
                string query1 = "SELECT DISTINCT qSet FROM questions"; // Query to get distinct question sets
                DataSet ds = fn.GetData(query1);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        comboQuestionSet.Items.Add(row["qSet"].ToString());
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

        private void ExamDetailsForm_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = StudentName;
            lblRollNumber.Text = RollNumber;
            lblExamDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            remainingTime = 10 * 60;  // Set remaining time to 60 minutes (3600 seconds)
            lblTotalTime.Text = "10 minutes";
            lblRemainingTime.Text = "10 minutes";

            InitializeCountdownTimer();
        }

        private void InitializeCountdownTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1000 ms = 1 second
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;  // Decrease remaining time by 1 second
                TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);

                lblRemainingTime.Text = $"Remaining Time: {timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
            }
            else
            {
                countdownTimer.Stop();  // Stop the timer when time is up
                MessageBox.Show("Time is up!", "Time Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FinishExam();
            }
        }

        private void comboQuestionSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchQuestions();
        }

        private void FetchQuestions()
        {
            try
            {
                if (comboQuestionSet.SelectedItem == null)
                {
                    MessageBox.Show("Please select a question set.");
                    return;
                }

                string selectedQuestionSet = comboQuestionSet.SelectedItem.ToString();
                string query = $"SELECT * FROM questions WHERE qSet = '{selectedQuestionSet}' ORDER BY qNo";
                questionDataSet = fn.GetData(query);

                totalQuestions = questionDataSet.Tables[0].Rows.Count;
                lblTotalQuestions.Text = totalQuestions.ToString();

                if (totalQuestions > 0)
                {
                    currentQuestionIndex = 0;
                    DisplayQuestion();
                }
                else
                {
                    MessageBox.Show("No questions available for the selected set.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching questions: {ex.Message}");
            }
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex >= 0 && currentQuestionIndex <= totalQuestions)
            {
                DataRow questionRow = questionDataSet.Tables[0].Rows[currentQuestionIndex];

                lblQuestion5.Text = questionRow["Question"]?.ToString() ?? "No question available";
                label5.Text = $"{currentQuestionIndex + 1} of {totalQuestions}";

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                radioButton1.Text = questionRow["OptionA"]?.ToString() ?? string.Empty;
                radioButton2.Text = questionRow["OptionB"]?.ToString() ?? string.Empty;
                radioButton3.Text = questionRow["OptionC"]?.ToString() ?? string.Empty;
                radioButton4.Text = questionRow["OptionD"]?.ToString() ?? string.Empty;

                prevBtn.Enabled = currentQuestionIndex > 0;
                btnNext5.Enabled = currentQuestionIndex < totalQuestions - 1;
            }
            else
            {
                MessageBox.Show("No more questions available.");
            }
        }

        private void btnNext5_Click(object sender, EventArgs e)
        {
            // Calculate marks for the current question, including the last one.
            CalculateMarksForCurrentQuestion();

            // Check if the current question is the last one in the set
            if (currentQuestionIndex < totalQuestions - 1)
            {
                currentQuestionIndex++;
                DisplayQuestion();
            }
            else
            {
                // Show message box for finishing the question set and display the score
                MessageBox.Show($"You have finished this question set!\nTotal Marks Obtained: {score}/{totalQuestions}",
                                "End of Set", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Move to the next question set if available, or finish the exam
                int selectedIndex = comboQuestionSet.SelectedIndex;
                if (selectedIndex < comboQuestionSet.Items.Count - 1)
                {
                    comboQuestionSet.SelectedIndex = selectedIndex + 1;
                    FetchQuestions();
                }
                else
                {
                    // Display final message if no more question sets are left and call FinishExam
                    MessageBox.Show($"Exam completed!\nFinal Score: {score}/{totalQuestions}", "Exam Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnFinish.PerformClick(); // Triggers the finish button to end the exam
                }
            }
        }



        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                DisplayQuestion();
            }
        }

        private void CalculateMarksForCurrentQuestion()
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Please select an answer before proceeding.", "No Answer Selected", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow questionRow = questionDataSet.Tables[0].Rows[currentQuestionIndex];
            string correctAnswer = questionRow["ans"].ToString().Trim();

            string userAnswer = "";
            if (radioButton1.Checked) userAnswer = radioButton1.Text.Trim();
            else if (radioButton2.Checked) userAnswer = radioButton2.Text.Trim();
            else if (radioButton3.Checked) userAnswer = radioButton3.Text.Trim();
            else if (radioButton4.Checked) userAnswer = radioButton4.Text.Trim();

            userAnswers.Add(userAnswer);

            if (userAnswer.Trim().Equals(correctAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                score++;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            // Calculate marks for the current question (last question) before finishing
            CalculateMarksForCurrentQuestion();

            if (MessageBox.Show("Are you sure you want to finish the exam?", "Finish Exam", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FinishExam();
            }
        }


        private void FinishExam()
        {
            try
            {
                DialogResult result = MessageBox.Show($"Exam finished!\nTotal Marks Obtained: {score}/{totalQuestions}",
                    "Exam Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Close();
                }

                // Prepare SQL query to insert exam results
                string query = "INSERT INTO exam_results (RollNumber, StudentName, ExamDate, TotalQuestions, ObtainedMarks) " +
                               "VALUES (@RollNumber, @StudentName, @ExamDate, @TotalQuestions, @ObtainedMarks)";

                // Prepare parameters
                var parameters = new Dictionary<string, object>
                {
                    {"@RollNumber", RollNumber},
                    {"@StudentName", StudentName},
                    {"@ExamDate", DateTime.Now},
                    {"@TotalQuestions", totalQuestions},
                    {"@ObtainedMarks", score}
                };

                // Call function to execute the query with parameters
                fn.setData(query, parameters);
                //fn.SetData(query, parameters, "Exam results saved successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving exam results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
