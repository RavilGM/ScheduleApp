namespace ScheduleAppView
{
    partial class FormTeacher
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
            buttonCanelSaveTeacher = new Button();
            buttonSaveTeacher = new Button();
            label1 = new Label();
            textBoxTeacherName = new TextBox();
            SuspendLayout();
            // 
            // buttonCanelSaveTeacher
            // 
            buttonCanelSaveTeacher.Location = new Point(270, 52);
            buttonCanelSaveTeacher.Name = "buttonCanelSaveTeacher";
            buttonCanelSaveTeacher.Size = new Size(76, 23);
            buttonCanelSaveTeacher.TabIndex = 11;
            buttonCanelSaveTeacher.Text = "Отмена";
            buttonCanelSaveTeacher.UseVisualStyleBackColor = true;
            buttonCanelSaveTeacher.Click += buttonCanelSaveTeacher_Click;
            // 
            // buttonSaveTeacher
            // 
            buttonSaveTeacher.Location = new Point(128, 52);
            buttonSaveTeacher.Name = "buttonSaveTeacher";
            buttonSaveTeacher.Size = new Size(75, 23);
            buttonSaveTeacher.TabIndex = 10;
            buttonSaveTeacher.Text = "Сохранить";
            buttonSaveTeacher.UseVisualStyleBackColor = true;
            buttonSaveTeacher.Click += buttonSaveTeacher_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 15);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 9;
            label1.Text = "ФИО преподавателя";
            // 
            // textBoxTeacherName
            // 
            textBoxTeacherName.Location = new Point(128, 12);
            textBoxTeacherName.Name = "textBoxTeacherName";
            textBoxTeacherName.Size = new Size(218, 23);
            textBoxTeacherName.TabIndex = 8;
            // 
            // FormTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 92);
            Controls.Add(buttonCanelSaveTeacher);
            Controls.Add(buttonSaveTeacher);
            Controls.Add(label1);
            Controls.Add(textBoxTeacherName);
            Name = "FormTeacher";
            Text = "Создание Преподавателя";
            this.Load += new System.EventHandler(this.FormTeacher_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCanelSaveTeacher;
        private Button buttonSaveTeacher;
        private Label label1;
        private TextBox textBoxTeacherName;
    }
}