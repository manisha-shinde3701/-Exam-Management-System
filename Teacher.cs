using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class Teacher : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        Int64 questionNo = 1;
        bool isSetChanging = false;

        public Teacher()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_AddNewQuestion1.Visible = true;
            uC_AddNewQuestion1.BringToFront();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            uC_AddNewQuestion1.Visible = false;
        }

        private void uC_AddNewQuestion1_Paint(object sender, PaintEventArgs e)
        {
            if (!isSetChanging)
            {
                if (string.IsNullOrEmpty(txtSet.Text))
                {
                    query = "SELECT MAX(qSet) FROM questions";
                    ds = fn.GetData(query);

                    if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        Int64 id = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                        txtSet.Text = (id + 1).ToString();
                    }
                    else
                    {
                        txtSet.Text = "1";
                    }
                }

                QuestionLabel.Text = questionNo.ToString();
                labelNOSET.Visible = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string qSet = txtSet.Text;
            string qNo = questionNo.ToString();
            string question = txtQuestion.Text;
            string option1 = txtOption1.Text;
            string option2 = txtOption2.Text;
            string option3 = txtOption3.Text;
            string option4 = txtOption4.Text;
            string ans = txtAnswer.Text;

            if (string.IsNullOrWhiteSpace(qSet) || string.IsNullOrWhiteSpace(qNo))
            {
                MessageBox.Show("Question Set or Question Number cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Use parameterized query to prevent SQL injection
                query = "INSERT INTO questions (qSet, qNo, question, OptionA, OptionB, OptionC, OptionD, ans) " +
                        "VALUES (@qSet, @qNo, @question, @OptionA, @OptionB, @OptionC, @OptionD, @ans)";

                var parameters = new Dictionary<string, object>
                {
                    { "@qSet", qSet },
                    { "@qNo", qNo },
                    { "@question", question },
                    { "@OptionA", option1 },
                    { "@OptionB", option2 },
                    { "@OptionC", option3 },
                    { "@OptionD", option4 },
                    { "@ans", ans }
                };

                fn.setData(query, parameters);
                MessageBox.Show("Question Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearAll();
                questionNo++;
                QuestionLabel.Text = questionNo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding question: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearAll()
        {
            txtQuestion.Clear();
            txtOption1.Clear();
            txtOption2.Clear();
            txtOption3.Clear();
            txtOption4.Clear();
            txtAnswer.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data will be Lost", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearAll();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Set will be changed", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                txtSet.Text = (Int64.Parse(txtSet.Text) + 1).ToString();
                questionNo = 1; // Resetting question number
                QuestionLabel.Text = questionNo.ToString();
            }
        }

        private void txtSet_TextChanged(object sender, EventArgs e)
        {
            if (!isSetChanging && !string.IsNullOrEmpty(txtSet.Text))
            {
                try
                {
                    isSetChanging = true;
                    clearAll();

                    query = $"SELECT qNo FROM questions WHERE qSet = @qSet";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@qSet", txtSet.Text }
                    };

                    ds = fn.GetData(query, parameters);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        QuestionLabel.Text = (ds.Tables[0].Rows.Count + 1).ToString();
                        questionNo = Int64.Parse(QuestionLabel.Text);
                    }
                    else
                    {
                        QuestionLabel.Text = "1";
                        questionNo = 1;
                        labelNOSET.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading question set: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    isSetChanging = false;
                }
            }
        }

        private void btn_UpdateQuestion_Click(object sender, EventArgs e)
        {
            updateQuestionsForm firstForm = new updateQuestionsForm();
            firstForm.Show();
            this.Close();
        }

        private void btn_ViewDeleteQuestion_Click_1(object sender, EventArgs e)
        {
            ViewAndDelQuestionsForm viewDelForm = new ViewAndDelQuestionsForm();
            viewDelForm.Show();
            this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            StudentResultForm studentResult = new StudentResultForm();
            studentResult.Show();
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form1 firstForm = new Form1();
            firstForm.Show();
            this.Close();
        }
    }
}
