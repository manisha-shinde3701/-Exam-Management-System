namespace QuizManagementSystem_1
{
    partial class StudentResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentResultForm));
            this.gridView2 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.combo_studentName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBarResult = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.BackgroundColor = System.Drawing.Color.White;
            this.gridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridView2.ColumnHeadersHeight = 25;
            this.gridView2.GridColor = System.Drawing.Color.White;
            this.gridView2.Location = new System.Drawing.Point(42, 208);
            this.gridView2.Name = "gridView2";
            this.gridView2.Size = new System.Drawing.Size(1051, 397);
            this.gridView2.TabIndex = 68;
            this.gridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView2_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(35, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 31);
            this.label10.TabIndex = 65;
            this.label10.Text = "Student Result";
            // 
            // combo_studentName
            // 
            this.combo_studentName.BackColor = System.Drawing.Color.Transparent;
            this.combo_studentName.BorderColor = System.Drawing.Color.Black;
            this.combo_studentName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_studentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_studentName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combo_studentName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combo_studentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_studentName.ForeColor = System.Drawing.Color.Black;
            this.combo_studentName.HoverState.ForeColor = System.Drawing.Color.Black;
            this.combo_studentName.ItemHeight = 30;
            this.combo_studentName.Location = new System.Drawing.Point(424, 118);
            this.combo_studentName.Name = "combo_studentName";
            this.combo_studentName.Size = new System.Drawing.Size(351, 36);
            this.combo_studentName.TabIndex = 67;
            this.combo_studentName.SelectedIndexChanged += new System.EventHandler(this.combo_studentName_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(420, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 20);
            this.label12.TabIndex = 66;
            this.label12.Text = "Student Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(955, 641);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 58);
            this.button1.TabIndex = 69;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBarResult
            // 
            this.progressBarResult.Location = new System.Drawing.Point(990, 105);
            this.progressBarResult.Maximum = 10;
            this.progressBarResult.Name = "progressBarResult";
            this.progressBarResult.Size = new System.Drawing.Size(139, 68);
            this.progressBarResult.TabIndex = 70;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(887, 133);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(72, 20);
            this.lblProgress.TabIndex = 71;
            this.lblProgress.Text = "Progress";
            // 
            // StudentResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1153, 735);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBarResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridView2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.combo_studentName);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "studentResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridView2;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox combo_studentName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBarResult;
        private System.Windows.Forms.Label lblProgress;
    }
}