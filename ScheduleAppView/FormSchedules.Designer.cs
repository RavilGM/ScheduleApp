namespace ScheduleAppView
{
    partial class FormSchedules
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
            buttonUpdateTheListOfSchedules = new Button();
            buttonDeleteSchedule = new Button();
            buttonCreateSchedule = new Button();
            dataGridViewSchedules = new DataGridView();
            buttonExportToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdateTheListOfSchedules
            // 
            buttonUpdateTheListOfSchedules.Location = new Point(390, 102);
            buttonUpdateTheListOfSchedules.Name = "buttonUpdateTheListOfSchedules";
            buttonUpdateTheListOfSchedules.Size = new Size(77, 42);
            buttonUpdateTheListOfSchedules.TabIndex = 15;
            buttonUpdateTheListOfSchedules.Text = "Обновить Список";
            buttonUpdateTheListOfSchedules.UseVisualStyleBackColor = true;
            buttonUpdateTheListOfSchedules.Click += buttonUpdateTheListOfSchedules_Click;
            // 
            // buttonDeleteSchedule
            // 
            buttonDeleteSchedule.Location = new Point(378, 57);
            buttonDeleteSchedule.Name = "buttonDeleteSchedule";
            buttonDeleteSchedule.Size = new Size(100, 39);
            buttonDeleteSchedule.TabIndex = 14;
            buttonDeleteSchedule.Text = "Удалить расписание";
            buttonDeleteSchedule.UseVisualStyleBackColor = true;
            buttonDeleteSchedule.Click += buttonDeleteSchedule_Click;
            // 
            // buttonCreateSchedule
            // 
            buttonCreateSchedule.Location = new Point(378, 12);
            buttonCreateSchedule.Name = "buttonCreateSchedule";
            buttonCreateSchedule.Size = new Size(100, 39);
            buttonCreateSchedule.TabIndex = 13;
            buttonCreateSchedule.Text = "Создать расписание";
            buttonCreateSchedule.UseVisualStyleBackColor = true;
            buttonCreateSchedule.Click += buttonCreateSchedule_Click;
            // 
            // dataGridViewSchedules
            // 
            dataGridViewSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSchedules.Dock = DockStyle.Left;
            dataGridViewSchedules.Location = new Point(0, 0);
            dataGridViewSchedules.MultiSelect = false;
            dataGridViewSchedules.Name = "dataGridViewSchedules";
            dataGridViewSchedules.ReadOnly = true;
            dataGridViewSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSchedules.Size = new Size(372, 450);
            dataGridViewSchedules.TabIndex = 12;
            // 
            // buttonExportToExcel
            // 
            buttonExportToExcel.Location = new Point(378, 399);
            buttonExportToExcel.Name = "buttonExportToExcel";
            buttonExportToExcel.Size = new Size(100, 39);
            buttonExportToExcel.TabIndex = 16;
            buttonExportToExcel.Text = "Экспорт в Excel";
            buttonExportToExcel.UseVisualStyleBackColor = true;
            buttonExportToExcel.Click += buttonExportToExcel_Click;
            // 
            // FormSchedules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 450);
            Controls.Add(buttonExportToExcel);
            Controls.Add(buttonUpdateTheListOfSchedules);
            Controls.Add(buttonDeleteSchedule);
            Controls.Add(buttonCreateSchedule);
            Controls.Add(dataGridViewSchedules);
            Name = "FormSchedules";
            Text = "Расписание";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonUpdateTheListOfSchedules;
        private Button buttonDeleteSchedule;
        private Button buttonCreateSchedule;
        private DataGridView dataGridViewSchedules;
        private Button buttonExportToExcel;
    }
}