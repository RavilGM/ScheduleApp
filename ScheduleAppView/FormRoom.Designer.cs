namespace ScheduleAppView
{
    partial class FormRoom
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
            buttonCanelSaveRoom = new Button();
            buttonSaveRoom = new Button();
            label1 = new Label();
            textBoxRoomName = new TextBox();
            SuspendLayout();
            // 
            // buttonCanelSaveRoom
            // 
            buttonCanelSaveRoom.Location = new Point(276, 52);
            buttonCanelSaveRoom.Name = "buttonCanelSaveRoom";
            buttonCanelSaveRoom.Size = new Size(76, 23);
            buttonCanelSaveRoom.TabIndex = 7;
            buttonCanelSaveRoom.Text = "Отмена";
            buttonCanelSaveRoom.UseVisualStyleBackColor = true;
            buttonCanelSaveRoom.Click += buttonCanelSaveRoom_Click;
            // 
            // buttonSaveRoom
            // 
            buttonSaveRoom.Location = new Point(118, 52);
            buttonSaveRoom.Name = "buttonSaveRoom";
            buttonSaveRoom.Size = new Size(75, 23);
            buttonSaveRoom.TabIndex = 6;
            buttonSaveRoom.Text = "Сохранить";
            buttonSaveRoom.UseVisualStyleBackColor = true;
            buttonSaveRoom.Click += buttonSaveRoom_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 15);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 5;
            label1.Text = "Номер Аудитории";
            // 
            // textBoxRoomName
            // 
            textBoxRoomName.Location = new Point(118, 12);
            textBoxRoomName.Name = "textBoxRoomName";
            textBoxRoomName.Size = new Size(234, 23);
            textBoxRoomName.TabIndex = 4;
            // 
            // FormRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 84);
            Controls.Add(buttonCanelSaveRoom);
            Controls.Add(buttonSaveRoom);
            Controls.Add(label1);
            Controls.Add(textBoxRoomName);
            Name = "FormRoom";
            Text = "Создание Аудитории";
            this.Load += new System.EventHandler(this.FormRoom_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCanelSaveRoom;
        private Button buttonSaveRoom;
        private Label label1;
        private TextBox textBoxRoomName;
    }
}