using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuizManagementSystem_1
{
    public partial class ViewAndDelQuestionsForm : Form
    {
        function fn = new function();
        string query;
        int questionNo;

        public ViewAndDelQuestionsForm()
        {
            InitializeComponent();
        }
        public void RefreshQuestionsGrid()
        {
            query = "select qNo, qSet, question, optionA, optionB, optionC, optionD, ans from questions";
            if (viewDel_setCombo.SelectedIndex != 0 && viewDel_setCombo.SelectedItem != null)
            {
                query += " where qSet = '" + viewDel_setCombo.Text + "'";
            }
            DataSet ds = fn.GetData(query);
            gridView1.DataSource = ds.Tables[0];
        }


        private void ViewAndDelQuestionsForm_Load(object sender, EventArgs e)
        {
            viewDel_setCombo.Items.Clear();
            viewDel_setCombo.Items.Add("All Questions");

            query = "select distinct qSet from questions";
            DataSet ds = fn.GetData(query);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                viewDel_setCombo.Items.Add(row[0].ToString());
            }

            // Load the questions in gridView1
            RefreshQuestionsGrid();
        }

        private void viewDel_setCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select qNo,qSet, question, optionA, optionB, optionC, optionD, ans from questions";
            if (viewDel_setCombo.SelectedIndex != 0)
            {
                query += " where qSet = '" + viewDel_setCombo.Text + "'";
            }
            DataSet ds = fn.GetData(query);
            gridView1.DataSource = ds.Tables[0];
        }

        private void gridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if the clicked row is valid
            {
                try
                {
                    questionNo = int.Parse(gridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); // Assuming qNo is in the first column
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (questionNo == 0) // Check if a valid question is selected
            {
                MessageBox.Show("Please select a question to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this question?", "Delete Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "DELETE FROM questions WHERE qNo = @qNo"; // Use parameterized queries for safety
                var parameters = new Dictionary<string, object>
        {
            { "@qNo", questionNo }
        };

                fn.setData(query, parameters); // Pass the parameters dictionary
                MessageBox.Show("Question Deleted."); // Notify the user
                ViewAndDelQuestionsForm_Load(this, null); // Refresh the data
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Teacher teacherForm = new Teacher();
            teacherForm.Show();
            this.Close();
        }
    }
}
