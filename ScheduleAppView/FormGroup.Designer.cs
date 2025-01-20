namespace ScheduleAppView
{
    partial class FormGroup
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
            textBoxGroupName = new TextBox();
            label1 = new Label();
            buttonSaveGroup = new Button();
            buttonCanelSaveGroup = new Button();
            SuspendLayout();
            // 
            // textBoxGroupName
            // 
            textBoxGroupName.Location = new Point(112, 12);
            textBoxGroupName.Name = "textBoxGroupName";
            textBoxGroupName.Size = new Size(234, 23);
            textBoxGroupName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 15);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 1;
            label1.Text = "Название группы";
            // 
            // buttonSaveGroup
            // 
            buttonSaveGroup.Location = new Point(112, 52);
            buttonSaveGroup.Name = "buttonSaveGroup";
            buttonSaveGroup.Size = new Size(75, 23);
            buttonSaveGroup.TabIndex = 2;
            buttonSaveGroup.Text = "Сохранить";
            buttonSaveGroup.UseVisualStyleBackColor = true;
            buttonSaveGroup.Click += buttonSaveGroup_Click;
            // 
            // buttonCanelSaveGroup
            // 
            buttonCanelSaveGroup.Location = new Point(270, 52);
            buttonCanelSaveGroup.Name = "buttonCanelSaveGroup";
            buttonCanelSaveGroup.Size = new Size(76, 23);
            buttonCanelSaveGroup.TabIndex = 3;
            buttonCanelSaveGroup.Text = "Отмена";
            buttonCanelSaveGroup.UseVisualStyleBackColor = true;
            buttonCanelSaveGroup.Click += buttonCanelSaveGroup_Click;
            // 
            // FormGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 103);
            Controls.Add(buttonCanelSaveGroup);
            Controls.Add(buttonSaveGroup);
            Controls.Add(label1);
            Controls.Add(textBoxGroupName);
            Name = "FormGroup";
            Text = "Создание Группы";
            this.Load += new System.EventHandler(this.FormGroup_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxGroupName;
        private Label label1;
        private Button buttonSaveGroup;
        private Button buttonCanelSaveGroup;
    }
}