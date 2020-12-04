namespace Client
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            this.MessageWindow = new System.Windows.Forms.RichTextBox();
            this.InputField = new System.Windows.Forms.RichTextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NameInput = new System.Windows.Forms.RichTextBox();
            this.NameButton = new System.Windows.Forms.Button();
            this.PeopleButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.PeopleList = new System.Windows.Forms.RichTextBox();
            this.GameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageWindow
            // 
            this.MessageWindow.Location = new System.Drawing.Point(14, 55);
            this.MessageWindow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MessageWindow.Name = "MessageWindow";
            this.MessageWindow.Size = new System.Drawing.Size(789, 381);
            this.MessageWindow.TabIndex = 0;
            this.MessageWindow.Text = "";
            // 
            // InputField
            // 
            this.InputField.Location = new System.Drawing.Point(14, 444);
            this.InputField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(789, 61);
            this.InputField.TabIndex = 1;
            this.InputField.Text = "";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(812, 445);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(107, 60);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(14, 15);
            this.NameInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(230, 33);
            this.NameInput.TabIndex = 4;
            this.NameInput.Text = "Name";
            // 
            // NameButton
            // 
            this.NameButton.Location = new System.Drawing.Point(252, 14);
            this.NameButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NameButton.Name = "NameButton";
            this.NameButton.Size = new System.Drawing.Size(88, 35);
            this.NameButton.TabIndex = 6;
            this.NameButton.Text = "Connect";
            this.NameButton.UseVisualStyleBackColor = true;
            this.NameButton.Click += new System.EventHandler(this.NameButton_Click);
            // 
            // PeopleButton
            // 
            this.PeopleButton.Location = new System.Drawing.Point(812, 14);
            this.PeopleButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PeopleButton.Name = "PeopleButton";
            this.PeopleButton.Size = new System.Drawing.Size(107, 35);
            this.PeopleButton.TabIndex = 7;
            this.PeopleButton.Text = "People";
            this.PeopleButton.UseVisualStyleBackColor = true;
            this.PeopleButton.Click += new System.EventHandler(this.PeopleButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(346, 14);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(88, 35);
            this.DisconnectButton.TabIndex = 8;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // PeopleList
            // 
            this.PeopleList.Location = new System.Drawing.Point(812, 55);
            this.PeopleList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PeopleList.Name = "PeopleList";
            this.PeopleList.Size = new System.Drawing.Size(107, 382);
            this.PeopleList.TabIndex = 9;
            this.PeopleList.Text = "";
            // 
            // GameButton
            // 
            this.GameButton.Location = new System.Drawing.Point(728, 15);
            this.GameButton.Name = "GameButton";
            this.GameButton.Size = new System.Drawing.Size(75, 35);
            this.GameButton.TabIndex = 10;
            this.GameButton.Text = "Play Game";
            this.GameButton.UseVisualStyleBackColor = true;
            this.GameButton.Click += new System.EventHandler(this.GameButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.GameButton);
            this.Controls.Add(this.PeopleList);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.PeopleButton);
            this.Controls.Add(this.NameButton);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.InputField);
            this.Controls.Add(this.MessageWindow);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox MessageWindow;
        private System.Windows.Forms.RichTextBox InputField;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox NameInput;
        private System.Windows.Forms.Button NameButton;
        private System.Windows.Forms.Button PeopleButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.RichTextBox PeopleList;
        private System.Windows.Forms.Button GameButton;
    }
}