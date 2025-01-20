namespace ScheduleAppView
{
    partial class FormMain
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
            buttonRooms = new Button();
            buttonSubjects = new Button();
            buttonGroups = new Button();
            buttonTeachers = new Button();
            buttonSchedules = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonRooms
            // 
            buttonRooms.Location = new Point(290, 33);
            buttonRooms.Name = "buttonRooms";
            buttonRooms.Size = new Size(101, 23);
            buttonRooms.TabIndex = 0;
            buttonRooms.Text = "Аудитории";
            buttonRooms.UseVisualStyleBackColor = true;
            buttonRooms.Click += buttonRooms_Click;
            // 
            // buttonSubjects
            // 
            buttonSubjects.Location = new Point(290, 91);
            buttonSubjects.Name = "buttonSubjects";
            buttonSubjects.Size = new Size(101, 23);
            buttonSubjects.TabIndex = 1;
            buttonSubjects.Text = "Предметы";
            buttonSubjects.UseVisualStyleBackColor = true;
            buttonSubjects.Click += buttonSubjects_Click;
            // 
            // buttonGroups
            // 
            buttonGroups.Location = new Point(290, 120);
            buttonGroups.Name = "buttonGroups";
            buttonGroups.Size = new Size(100, 23);
            buttonGroups.TabIndex = 2;
            buttonGroups.Text = "Группы";
            buttonGroups.UseVisualStyleBackColor = true;
            buttonGroups.Click += buttonGroups_Click;
            // 
            // buttonTeachers
            // 
            buttonTeachers.Location = new Point(290, 62);
            buttonTeachers.Name = "buttonTeachers";
            buttonTeachers.Size = new Size(101, 23);
            buttonTeachers.TabIndex = 3;
            buttonTeachers.Text = "Преподаватели";
            buttonTeachers.UseVisualStyleBackColor = true;
            buttonTeachers.Click += buttonTeachers_Click;
            // 
            // buttonSchedules
            // 
            buttonSchedules.Location = new Point(290, 149);
            buttonSchedules.Name = "buttonSchedules";
            buttonSchedules.Size = new Size(101, 23);
            buttonSchedules.TabIndex = 4;
            buttonSchedules.Text = "Расписание";
            buttonSchedules.UseVisualStyleBackColor = true;
            buttonSchedules.Click += buttonSchedules_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(152, 15);
            label1.TabIndex = 5;
            label1.Text = "Редактор расписания v3.0 ";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 215);
            Controls.Add(label1);
            Controls.Add(buttonSchedules);
            Controls.Add(buttonTeachers);
            Controls.Add(buttonGroups);
            Controls.Add(buttonSubjects);
            Controls.Add(buttonRooms);
            Name = "FormMain";
            Text = "FormMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonRooms;
        private Button buttonSubjects;
        private Button buttonGroups;
        private Button buttonTeachers;
        private Button buttonSchedules;
        private Label label1;
    }
}