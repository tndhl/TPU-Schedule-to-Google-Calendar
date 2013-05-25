namespace TPU_Schedule_to_Google_Calendar.Google_Calendar
{
    partial class AuthenticationForm
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
            this.authToken = new System.Windows.Forms.TextBox();
            this.authTokenLabel = new System.Windows.Forms.Label();
            this.authButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authToken
            // 
            this.authToken.Location = new System.Drawing.Point(11, 42);
            this.authToken.Name = "authToken";
            this.authToken.Size = new System.Drawing.Size(260, 20);
            this.authToken.TabIndex = 0;
            // 
            // authTokenLabel
            // 
            this.authTokenLabel.AutoSize = true;
            this.authTokenLabel.Location = new System.Drawing.Point(12, 23);
            this.authTokenLabel.Name = "authTokenLabel";
            this.authTokenLabel.Size = new System.Drawing.Size(197, 13);
            this.authTokenLabel.TabIndex = 1;
            this.authTokenLabel.Text = "Please, enter authentication code below";
            // 
            // authButton
            // 
            this.authButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.authButton.Location = new System.Drawing.Point(196, 82);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(75, 23);
            this.authButton.TabIndex = 2;
            this.authButton.Text = "Continue";
            this.authButton.UseVisualStyleBackColor = true;
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.authButton);
            this.Controls.Add(this.authTokenLabel);
            this.Controls.Add(this.authToken);
            this.Name = "AuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthenticationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox authToken;
        private System.Windows.Forms.Label authTokenLabel;
        private System.Windows.Forms.Button authButton;

    }
}