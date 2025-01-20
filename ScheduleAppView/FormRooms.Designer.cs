namespace ScheduleAppView
{
    partial class FormRooms
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
            buttonUpdateTheListOfRooms = new Button();
            buttonDeleteRoom = new Button();
            buttonCreateRoom = new Button();
            dataGridViewRooms = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdateTheListOfRooms
            // 
            buttonUpdateTheListOfRooms.Location = new Point(394, 96);
            buttonUpdateTheListOfRooms.Name = "buttonUpdateTheListOfRooms";
            buttonUpdateTheListOfRooms.Size = new Size(77, 42);
            buttonUpdateTheListOfRooms.TabIndex = 7;
            buttonUpdateTheListOfRooms.Text = "Обновить Список";
            buttonUpdateTheListOfRooms.UseVisualStyleBackColor = true;
            buttonUpdateTheListOfRooms.Click += buttonUpdateTheListOfRooms_Click;
            // 
            // buttonDeleteRoom
            // 
            buttonDeleteRoom.Location = new Point(394, 51);
            buttonDeleteRoom.Name = "buttonDeleteRoom";
            buttonDeleteRoom.Size = new Size(77, 39);
            buttonDeleteRoom.TabIndex = 6;
            buttonDeleteRoom.Text = "Удалить аудиторию";
            buttonDeleteRoom.UseVisualStyleBackColor = true;
            buttonDeleteRoom.Click += buttonDeleteRoom_Click;
            // 
            // buttonCreateRoom
            // 
            buttonCreateRoom.Location = new Point(394, 5);
            buttonCreateRoom.Name = "buttonCreateRoom";
            buttonCreateRoom.Size = new Size(77, 40);
            buttonCreateRoom.TabIndex = 5;
            buttonCreateRoom.Text = "Создать аудиторию";
            buttonCreateRoom.UseVisualStyleBackColor = true;
            buttonCreateRoom.Click += buttonCreateRoom_Click;
            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRooms.Dock = DockStyle.Left;
            dataGridViewRooms.Location = new Point(0, 0);
            dataGridViewRooms.MultiSelect = false;
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.ReadOnly = true;
            dataGridViewRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRooms.Size = new Size(372, 310);
            dataGridViewRooms.TabIndex = 4;
            // 
            // FormRooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 310);
            Controls.Add(buttonUpdateTheListOfRooms);
            Controls.Add(buttonDeleteRoom);
            Controls.Add(buttonCreateRoom);
            Controls.Add(dataGridViewRooms);
            Name = "FormRooms";
            Text = "Аудитории";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonUpdateTheListOfRooms;
        private Button buttonDeleteRoom;
        private Button buttonCreateRoom;
        private DataGridView dataGridViewRooms;
    }
}