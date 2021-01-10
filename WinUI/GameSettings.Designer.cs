namespace Ex05.WinUI
{
    public partial class GameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.PlayAgainstCompButton = new System.Windows.Forms.Button();
            this.PlayAgainstFriendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSizeButton
            // 
            resources.ApplyResources(this.BoardSizeButton, "BoardSizeButton");
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.UseVisualStyleBackColor = true;
            this.BoardSizeButton.Click += new System.EventHandler(this.BoardSizeButton_Click);
            // 
            // PlayAgainstCompButton
            // 
            resources.ApplyResources(this.PlayAgainstCompButton, "PlayAgainstCompButton");
            this.PlayAgainstCompButton.Name = "PlayAgainstCompButton";
            this.PlayAgainstCompButton.UseVisualStyleBackColor = true;
            this.PlayAgainstCompButton.Click += new System.EventHandler(this.PlayAgainstCompButton_Click);
            // 
            // PlayAgainstFriendButton
            // 
            resources.ApplyResources(this.PlayAgainstFriendButton, "PlayAgainstFriendButton");
            this.PlayAgainstFriendButton.Name = "PlayAgainstFriendButton";
            this.PlayAgainstFriendButton.UseVisualStyleBackColor = true;
            this.PlayAgainstFriendButton.Click += new System.EventHandler(this.PlayAgainstFriendButton_Click);
            // 
            // GameSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayAgainstFriendButton);
            this.Controls.Add(this.PlayAgainstCompButton);
            this.Controls.Add(this.BoardSizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BoardSizeButton;
        private System.Windows.Forms.Button PlayAgainstCompButton;
        private System.Windows.Forms.Button PlayAgainstFriendButton;
    }
}