namespace ScheduleAppView
{
    partial class FormSchedule
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
            buttonCanelSaveSchedule = new Button();
            buttonSaveSchedule = new Button();
            label1 = new Label();
            dateTimePickerDate = new DateTimePicker();
            comboBoxRoom = new ComboBox();
            comboBoxTeacher = new ComboBox();
            comboBoxSubject = new ComboBox();
            comboBoxGroup = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // buttonCanelSaveSchedule
            // 
            buttonCanelSaveSchedule.Location = new Point(340, 327);
            buttonCanelSaveSchedule.Name = "buttonCanelSaveSchedule";
            buttonCanelSaveSchedule.Size = new Size(76, 23);
            buttonCanelSaveSchedule.TabIndex = 14;
            buttonCanelSaveSchedule.Text = "Отмена";
            buttonCanelSaveSchedule.UseVisualStyleBackColor = true;
            buttonCanelSaveSchedule.Click += buttonCanelSaveSchedule_Click;
            // 
            // buttonSaveSchedule
            // 
            buttonSaveSchedule.Location = new Point(216, 327);
            buttonSaveSchedule.Name = "buttonSaveSchedule";
            buttonSaveSchedule.Size = new Size(75, 23);
            buttonSaveSchedule.TabIndex = 13;
            buttonSaveSchedule.Text = "Сохранить";
            buttonSaveSchedule.UseVisualStyleBackColor = true;
            buttonSaveSchedule.Click += buttonSaveSchedule_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 29);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 12;
            label1.Text = "Дата";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(216, 21);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(200, 23);
            dateTimePickerDate.TabIndex = 15;
            // 
            // comboBoxRoom
            // 
            comboBoxRoom.FormattingEnabled = true;
            comboBoxRoom.Location = new Point(216, 50);
            comboBoxRoom.Name = "comboBoxRoom";
            comboBoxRoom.Size = new Size(200, 23);
            comboBoxRoom.TabIndex = 16;
            comboBoxRoom.SelectedIndexChanged += comboBoxRoom_SelectedIndexChanged;
            // 
            // comboBoxTeacher
            // 
            comboBoxTeacher.FormattingEnabled = true;
            comboBoxTeacher.Location = new Point(216, 79);
            comboBoxTeacher.Name = "comboBoxTeacher";
            comboBoxTeacher.Size = new Size(200, 23);
            comboBoxTeacher.TabIndex = 17;
            comboBoxTeacher.SelectedIndexChanged += comboBoxTeacher_SelectedIndexChanged;
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(216, 108);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(200, 23);
            comboBoxSubject.TabIndex = 18;
            comboBoxSubject.SelectedIndexChanged += comboBoxSubject_SelectedIndexChanged;
            // 
            // comboBoxGroup
            // 
            comboBoxGroup.FormattingEnabled = true;
            comboBoxGroup.Location = new Point(216, 137);
            comboBoxGroup.Name = "comboBoxGroup";
            comboBoxGroup.Size = new Size(200, 23);
            comboBoxGroup.TabIndex = 19;
            comboBoxGroup.SelectedIndexChanged += comboBoxGroup_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 58);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 20;
            label2.Text = "Аудитория";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 116);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 21;
            label3.Text = "Предмет";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 145);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 22;
            label4.Text = "Группа";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 87);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 23;
            label5.Text = "Преподаватель";
            // 
            // FormSchedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 362);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxGroup);
            Controls.Add(comboBoxSubject);
            Controls.Add(comboBoxTeacher);
            Controls.Add(comboBoxRoom);
            Controls.Add(dateTimePickerDate);
            Controls.Add(buttonCanelSaveSchedule);
            Controls.Add(buttonSaveSchedule);
            Controls.Add(label1);
            Name = "FormSchedule";
            Text = "FormSchedule";
            this.Load += new System.EventHandler(this.FormSchedule_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCanelSaveSchedule;
        private Button buttonSaveSchedule;
        private Label label1;
        private DateTimePicker dateTimePickerDate;
        private ComboBox comboBoxRoom;
        private ComboBox comboBoxTeacher;
        private ComboBox comboBoxSubject;
        private ComboBox comboBoxGroup;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}