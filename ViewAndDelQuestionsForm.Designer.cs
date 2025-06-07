namespace QuizManagementSystem_1
{
    partial class ViewAndDelQuestionsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAndDelQuestionsForm));
            this.label10 = new System.Windows.Forms.Label();
            this.viewDel_setCombo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.gridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(303, 29);
            this.label10.TabIndex = 61;
            this.label10.Text = "View && Delete Questions";
            // 
            // viewDel_setCombo
            // 
            this.viewDel_setCombo.BackColor = System.Drawing.Color.Transparent;
            this.viewDel_setCombo.BorderColor = System.Drawing.Color.Black;
            this.viewDel_setCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.viewDel_setCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewDel_setCombo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.viewDel_setCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.viewDel_setCombo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDel_setCombo.ForeColor = System.Drawing.Color.Black;
            this.viewDel_setCombo.HoverState.ForeColor = System.Drawing.Color.Black;
            this.viewDel_setCombo.ItemHeight = 30;
            this.viewDel_setCombo.Location = new System.Drawing.Point(516, 122);
            this.viewDel_setCombo.Name = "viewDel_setCombo";
            this.viewDel_setCombo.Size = new System.Drawing.Size(351, 36);
            this.viewDel_setCombo.TabIndex = 63;
            this.viewDel_setCombo.SelectedIndexChanged += new System.EventHandler(this.viewDel_setCombo_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(521, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 24);
            this.label12.TabIndex = 62;
            this.label12.Text = "Set";
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Red;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(963, 649);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(131, 37);
            this.btn_delete.TabIndex = 65;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // gridView1
            // 
            this.gridView1.BackgroundColor = System.Drawing.Color.White;
            this.gridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridView1.ColumnHeadersHeight = 25;
            this.gridView1.GridColor = System.Drawing.Color.White;
            this.gridView1.Location = new System.Drawing.Point(43, 236);
            this.gridView1.Name = "gridView1";
            this.gridView1.Size = new System.Drawing.Size(1051, 397);
            this.gridView1.TabIndex = 64;
            this.gridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView1_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(753, 649);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 37);
            this.button1.TabIndex = 66;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewAndDelQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1153, 735);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.gridView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.viewDel_setCombo);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewAndDelQuestionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewAndDelQuestionsForm";
            this.Load += new System.EventHandler(this.ViewAndDelQuestionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox viewDel_setCombo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_delete;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.DataGridView gridView1;
        private System.Windows.Forms.Button button1;
    }
}