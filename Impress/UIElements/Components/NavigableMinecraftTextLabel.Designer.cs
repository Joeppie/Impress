namespace Impress.UIElements.Components
{
    partial class NavigableMinecraftTextLabel
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
            this.NavigateFirstButton = new System.Windows.Forms.Button();
            this.NavigateLastButton = new System.Windows.Forms.Button();
            this.PageLabel = new System.Windows.Forms.Label();
            this.MinecraftTextLabel = new Impress.UIElements.Components.MinecraftTextLabel();
            this.NavigateNextButton = new System.Windows.Forms.Button();
            this.NavigatePreviousButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NavigateFirstButton
            // 
            this.NavigateFirstButton.Location = new System.Drawing.Point(0, 410);
            this.NavigateFirstButton.Name = "NavigateFirstButton";
            this.NavigateFirstButton.Size = new System.Drawing.Size(75, 23);
            this.NavigateFirstButton.TabIndex = 19;
            this.NavigateFirstButton.Text = "<<";
            this.NavigateFirstButton.UseVisualStyleBackColor = true;
            // 
            // NavigateLastButton
            // 
            this.NavigateLastButton.Location = new System.Drawing.Point(263, 410);
            this.NavigateLastButton.Name = "NavigateLastButton";
            this.NavigateLastButton.Size = new System.Drawing.Size(75, 23);
            this.NavigateLastButton.TabIndex = 18;
            this.NavigateLastButton.Text = ">>";
            this.NavigateLastButton.UseVisualStyleBackColor = true;
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Location = new System.Drawing.Point(0, 390);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(35, 13);
            this.PageLabel.TabIndex = 17;
            this.PageLabel.Text = "label2";
            // 
            // MinecraftTextLabel
            // 
            this.MinecraftTextLabel.BackColor = System.Drawing.Color.White;
            this.MinecraftTextLabel.Location = new System.Drawing.Point(0, 0);
            this.MinecraftTextLabel.Name = "MinecraftTextLabel";
            this.MinecraftTextLabel.Size = new System.Drawing.Size(338, 390);
            this.MinecraftTextLabel.TabIndex = 16;
            // 
            // NavigateNextButton
            // 
            this.NavigateNextButton.Location = new System.Drawing.Point(182, 410);
            this.NavigateNextButton.Name = "NavigateNextButton";
            this.NavigateNextButton.Size = new System.Drawing.Size(75, 23);
            this.NavigateNextButton.TabIndex = 15;
            this.NavigateNextButton.Text = ">";
            this.NavigateNextButton.UseVisualStyleBackColor = true;
            // 
            // NavigatePreviousButton
            // 
            this.NavigatePreviousButton.Location = new System.Drawing.Point(81, 410);
            this.NavigatePreviousButton.Name = "NavigatePreviousButton";
            this.NavigatePreviousButton.Size = new System.Drawing.Size(75, 23);
            this.NavigatePreviousButton.TabIndex = 14;
            this.NavigatePreviousButton.Text = "<";
            this.NavigatePreviousButton.UseVisualStyleBackColor = true;
            // 
            // NavigableMinecraftTextLabel
            // 
            this.Controls.Add(this.NavigateFirstButton);
            this.Controls.Add(this.NavigateLastButton);
            this.Controls.Add(this.PageLabel);
            this.Controls.Add(this.MinecraftTextLabel);
            this.Controls.Add(this.NavigateNextButton);
            this.Controls.Add(this.NavigatePreviousButton);
            this.Name = "NavigableMinecraftTextLabel";
            this.Size = new System.Drawing.Size(338, 434);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NavigateFirstButton;
        private System.Windows.Forms.Button NavigateLastButton;
        private System.Windows.Forms.Label PageLabel;
        private MinecraftTextLabel MinecraftTextLabel;
        private System.Windows.Forms.Button NavigateNextButton;
        private System.Windows.Forms.Button NavigatePreviousButton;
    }
}