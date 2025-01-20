namespace ScheduleAppView
{
    partial class FormGroups
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
            dataGridViewGroups = new DataGridView();
            buttonCreateGroup = new Button();
            buttonDeleteGroup = new Button();
            buttonUpdateTheListOfGroups = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGroups).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewGroups
            // 
            dataGridViewGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGroups.Dock = DockStyle.Left;
            dataGridViewGroups.Location = new Point(0, 0);
            dataGridViewGroups.MultiSelect = false;
            dataGridViewGroups.Name = "dataGridViewGroups";
            dataGridViewGroups.ReadOnly = true;
            dataGridViewGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGroups.Size = new Size(372, 353);
            dataGridViewGroups.TabIndex = 0;
            dataGridViewGroups.CellContentClick += dataGridViewGroups_CellContentClick;
            // 
            // buttonCreateGroup
            // 
            buttonCreateGroup.Location = new Point(395, 12);
            buttonCreateGroup.Name = "buttonCreateGroup";
            buttonCreateGroup.Size = new Size(75, 40);
            buttonCreateGroup.TabIndex = 1;
            buttonCreateGroup.Text = "Создать Группу";
            buttonCreateGroup.UseVisualStyleBackColor = true;
            buttonCreateGroup.Click += buttonCreateGroup_Click;
            // 
            // buttonDeleteGroup
            // 
            buttonDeleteGroup.Location = new Point(395, 58);
            buttonDeleteGroup.Name = "buttonDeleteGroup";
            buttonDeleteGroup.Size = new Size(75, 39);
            buttonDeleteGroup.TabIndex = 2;
            buttonDeleteGroup.Text = "Удалить Группу";
            buttonDeleteGroup.UseVisualStyleBackColor = true;
            buttonDeleteGroup.Click += buttonDeleteGroup_Click;
            // 
            // buttonUpdateTheListOfGroups
            // 
            buttonUpdateTheListOfGroups.Location = new Point(395, 103);
            buttonUpdateTheListOfGroups.Name = "buttonUpdateTheListOfGroups";
            buttonUpdateTheListOfGroups.Size = new Size(75, 42);
            buttonUpdateTheListOfGroups.TabIndex = 3;
            buttonUpdateTheListOfGroups.Text = "Обновить Список";
            buttonUpdateTheListOfGroups.UseVisualStyleBackColor = true;
            buttonUpdateTheListOfGroups.Click += buttonUpdateTheListOfGroups_Click;
            // 
            // FormGroups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 353);
            Controls.Add(buttonUpdateTheListOfGroups);
            Controls.Add(buttonDeleteGroup);
            Controls.Add(buttonCreateGroup);
            Controls.Add(dataGridViewGroups);
            Name = "FormGroups";
            Text = "Группы";

            ((System.ComponentModel.ISupportInitialize)dataGridViewGroups).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewGroups;
        private Button buttonCreateGroup;
        private Button buttonDeleteGroup;
        private Button buttonUpdateTheListOfGroups;
    }
}