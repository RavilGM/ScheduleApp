namespace ScheduleAppView
{
    partial class FormTeachers
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
            buttonUpdateTheListOfTeachers = new Button();
            buttonDeleteTeacher = new Button();
            buttonCreateTeacher = new Button();
            dataGridViewTeachers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeachers).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdateTheListOfTeachers
            // 
            buttonUpdateTheListOfTeachers.Location = new Point(389, 96);
            buttonUpdateTheListOfTeachers.Name = "buttonUpdateTheListOfTeachers";
            buttonUpdateTheListOfTeachers.Size = new Size(77, 42);
            buttonUpdateTheListOfTeachers.TabIndex = 11;
            buttonUpdateTheListOfTeachers.Text = "Обновить Список";
            buttonUpdateTheListOfTeachers.UseVisualStyleBackColor = true;
            buttonUpdateTheListOfTeachers.Click += buttonUpdateTheListOfTeachers_Click;
            // 
            // buttonDeleteTeacher
            // 
            buttonDeleteTeacher.Location = new Point(378, 51);
            buttonDeleteTeacher.Name = "buttonDeleteTeacher";
            buttonDeleteTeacher.Size = new Size(100, 39);
            buttonDeleteTeacher.TabIndex = 10;
            buttonDeleteTeacher.Text = "Удалить преподавателя";
            buttonDeleteTeacher.UseVisualStyleBackColor = true;
            buttonDeleteTeacher.Click += buttonDeleteTeacher_Click;
            // 
            // buttonCreateTeacher
            // 
            buttonCreateTeacher.Location = new Point(378, 6);
            buttonCreateTeacher.Name = "buttonCreateTeacher";
            buttonCreateTeacher.Size = new Size(100, 39);
            buttonCreateTeacher.TabIndex = 9;
            buttonCreateTeacher.Text = "Создать преподавателя";
            buttonCreateTeacher.UseVisualStyleBackColor = true;
            buttonCreateTeacher.Click += buttonCreateTeacher_Click;
            // 
            // dataGridViewTeachers
            // 
            dataGridViewTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTeachers.Dock = DockStyle.Left;
            dataGridViewTeachers.Location = new Point(0, 0);
            dataGridViewTeachers.MultiSelect = false;
            dataGridViewTeachers.Name = "dataGridViewTeachers";
            dataGridViewTeachers.ReadOnly = true;
            dataGridViewTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTeachers.Size = new Size(372, 276);
            dataGridViewTeachers.TabIndex = 8;
            // 
            // FormTeachers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 276);
            Controls.Add(buttonUpdateTheListOfTeachers);
            Controls.Add(buttonDeleteTeacher);
            Controls.Add(buttonCreateTeacher);
            Controls.Add(dataGridViewTeachers);
            Name = "FormTeachers";
            Text = "Преподаватели";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeachers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonUpdateTheListOfTeachers;
        private Button buttonDeleteTeacher;
        private Button buttonCreateTeacher;
        private DataGridView dataGridViewTeachers;
    }
}