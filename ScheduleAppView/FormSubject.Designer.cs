namespace ScheduleAppView
{
    partial class FormSubject
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
            buttonCanelSaveSubject = new Button();
            buttonSaveSubject = new Button();
            label1 = new Label();
            textBoxSubjectName = new TextBox();
            SuspendLayout();
            // 
            // buttonCanelSaveSubject
            // 
            buttonCanelSaveSubject.Location = new Point(277, 52);
            buttonCanelSaveSubject.Name = "buttonCanelSaveSubject";
            buttonCanelSaveSubject.Size = new Size(76, 23);
            buttonCanelSaveSubject.TabIndex = 15;
            buttonCanelSaveSubject.Text = "Отмена";
            buttonCanelSaveSubject.UseVisualStyleBackColor = true;
            buttonCanelSaveSubject.Click += buttonCanelSaveSubject_Click;
            // 
            // buttonSaveSubject
            // 
            buttonSaveSubject.Location = new Point(135, 52);
            buttonSaveSubject.Name = "buttonSaveSubject";
            buttonSaveSubject.Size = new Size(75, 23);
            buttonSaveSubject.TabIndex = 14;
            buttonSaveSubject.Text = "Сохранить";
            buttonSaveSubject.UseVisualStyleBackColor = true;
            buttonSaveSubject.Click += buttonSaveSubject_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 13;
            label1.Text = "Название предмета";
            // 
            // textBoxSubjectName
            // 
            textBoxSubjectName.Location = new Point(135, 12);
            textBoxSubjectName.Name = "textBoxSubjectName";
            textBoxSubjectName.Size = new Size(218, 23);
            textBoxSubjectName.TabIndex = 12;
            // 
            // FormSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 90);
            Controls.Add(buttonCanelSaveSubject);
            Controls.Add(buttonSaveSubject);
            Controls.Add(label1);
            Controls.Add(textBoxSubjectName);
            Name = "FormSubject";
            Text = "Создание Предмета";
            this.Load += new System.EventHandler(this.FormSubject_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCanelSaveSubject;
        private Button buttonSaveSubject;
        private Label label1;
        private TextBox textBoxSubjectName;
    }
}