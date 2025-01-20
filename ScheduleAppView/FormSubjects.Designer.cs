namespace ScheduleAppView
{
    partial class FormSubjects
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
            buttonUpdateTheListOfSubjects = new Button();
            buttonDeleteSubject = new Button();
            buttonCreateSubject = new Button();
            dataGridViewSubjects = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjects).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdateTheListOfSubjects
            // 
            buttonUpdateTheListOfSubjects.Location = new Point(401, 95);
            buttonUpdateTheListOfSubjects.Name = "buttonUpdateTheListOfSubjects";
            buttonUpdateTheListOfSubjects.Size = new Size(77, 42);
            buttonUpdateTheListOfSubjects.TabIndex = 15;
            buttonUpdateTheListOfSubjects.Text = "Обновить Список";
            buttonUpdateTheListOfSubjects.UseVisualStyleBackColor = true;
            buttonUpdateTheListOfSubjects.Click += buttonUpdateTheListOfSubjects_Click;
            // 
            // buttonDeleteSubject
            // 
            buttonDeleteSubject.Location = new Point(390, 50);
            buttonDeleteSubject.Name = "buttonDeleteSubject";
            buttonDeleteSubject.Size = new Size(100, 39);
            buttonDeleteSubject.TabIndex = 14;
            buttonDeleteSubject.Text = "Удалить предмет";
            buttonDeleteSubject.UseVisualStyleBackColor = true;
            buttonDeleteSubject.Click += buttonDeleteSubject_Click;
            // 
            // buttonCreateSubject
            // 
            buttonCreateSubject.Location = new Point(390, 5);
            buttonCreateSubject.Name = "buttonCreateSubject";
            buttonCreateSubject.Size = new Size(100, 39);
            buttonCreateSubject.TabIndex = 13;
            buttonCreateSubject.Text = "Создать предмет";
            buttonCreateSubject.UseVisualStyleBackColor = true;
            buttonCreateSubject.Click += buttonCreateSubject_Click;
            // 
            // dataGridViewSubjects
            // 
            dataGridViewSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubjects.Dock = DockStyle.Left;
            dataGridViewSubjects.Location = new Point(0, 0);
            dataGridViewSubjects.MultiSelect = false;
            dataGridViewSubjects.Name = "dataGridViewSubjects";
            dataGridViewSubjects.ReadOnly = true;
            dataGridViewSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSubjects.Size = new Size(372, 288);
            dataGridViewSubjects.TabIndex = 12;
            // 
            // FormSubjects
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 288);
            Controls.Add(buttonUpdateTheListOfSubjects);
            Controls.Add(buttonDeleteSubject);
            Controls.Add(buttonCreateSubject);
            Controls.Add(dataGridViewSubjects);
            Name = "FormSubjects";
            Text = "Предметы";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjects).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonUpdateTheListOfSubjects;
        private Button buttonDeleteSubject;
        private Button buttonCreateSubject;
        private DataGridView dataGridViewSubjects;
    }
}