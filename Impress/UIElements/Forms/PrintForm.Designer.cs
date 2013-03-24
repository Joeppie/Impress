namespace Impress.UIElements.Forms
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.MonitorPasteCheckBox = new System.Windows.Forms.CheckBox();
            this.CopyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowPreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.NavigableMinecraftTextLabel = new Impress.UIElements.Components.NavigableMinecraftTextLabel();
            this.SuspendLayout();
            // 
            // MonitorPasteCheckBox
            // 
            this.MonitorPasteCheckBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MonitorPasteCheckBox.AutoSize = true;
            this.MonitorPasteCheckBox.Enabled = false;
            this.MonitorPasteCheckBox.Location = new System.Drawing.Point(12, 6);
            this.MonitorPasteCheckBox.Name = "MonitorPasteCheckBox";
            this.MonitorPasteCheckBox.Size = new System.Drawing.Size(192, 30);
            this.MonitorPasteCheckBox.TabIndex = 1;
            this.MonitorPasteCheckBox.Text = "Monitor clipboard and automatically\r\n copy new page upon pasting,";
            this.MonitorPasteCheckBox.UseVisualStyleBackColor = true;
            this.MonitorPasteCheckBox.CheckedChanged += new System.EventHandler(this.MonitorPasteCheckBoxClicked);
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(12, 55);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(192, 33);
            this.CopyButton.TabIndex = 2;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manually copy page";
            // 
            // OnTopCheckBox
            // 
            this.OnTopCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.OnTopCheckBox.AutoSize = true;
            this.OnTopCheckBox.Checked = true;
            this.OnTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnTopCheckBox.Location = new System.Drawing.Point(12, 94);
            this.OnTopCheckBox.Name = "OnTopCheckBox";
            this.OnTopCheckBox.Size = new System.Drawing.Size(71, 23);
            this.OnTopCheckBox.TabIndex = 4;
            this.OnTopCheckBox.Text = "Stay on top";
            this.OnTopCheckBox.UseVisualStyleBackColor = true;
            this.OnTopCheckBox.CheckedChanged += new System.EventHandler(this.OnTopCheckBoxCheckedChanged);
            // 
            // ShowPreviewCheckBox
            // 
            this.ShowPreviewCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ShowPreviewCheckBox.AutoSize = true;
            this.ShowPreviewCheckBox.Location = new System.Drawing.Point(122, 94);
            this.ShowPreviewCheckBox.Name = "ShowPreviewCheckBox";
            this.ShowPreviewCheckBox.Size = new System.Drawing.Size(82, 23);
            this.ShowPreviewCheckBox.TabIndex = 5;
            this.ShowPreviewCheckBox.Text = "show preview";
            this.ShowPreviewCheckBox.UseVisualStyleBackColor = true;
            this.ShowPreviewCheckBox.CheckedChanged += new System.EventHandler(this.ShowPreviewCheckBoxCheckedChanged);
            // 
            // NavigableMinecraftTextLabel
            // 
            this.NavigableMinecraftTextLabel.Location = new System.Drawing.Point(210, 6);
            this.NavigableMinecraftTextLabel.Name = "NavigableMinecraftTextLabel";
            this.NavigableMinecraftTextLabel.Size = new System.Drawing.Size(338, 434);
            this.NavigableMinecraftTextLabel.TabIndex = 0;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 443);
            this.Controls.Add(this.ShowPreviewCheckBox);
            this.Controls.Add(this.OnTopCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.MonitorPasteCheckBox);
            this.Controls.Add(this.NavigableMinecraftTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.NavigableMinecraftTextLabel NavigableMinecraftTextLabel;
        private System.Windows.Forms.CheckBox MonitorPasteCheckBox;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox OnTopCheckBox;
        private System.Windows.Forms.CheckBox ShowPreviewCheckBox;
    }
}