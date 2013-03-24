namespace Impress.UIElements.Forms.FormattingWizard
{
    partial class AutoFormatWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoFormatWizard));
            this.AutoFormatButton = new System.Windows.Forms.Button();
            this.FormatCapitalsCheckBox = new System.Windows.Forms.CheckBox();
            this.FormatQuotesTextBox = new System.Windows.Forms.CheckBox();
            this.SpacePagesCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CancelButton = new System.Windows.Forms.Button();
            this.ChangeColorCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RemoveFormattingCheckBox = new System.Windows.Forms.CheckBox();
            this.navigableMinecraftTextLabel1 = new Impress.UIElements.Components.NavigableMinecraftTextLabel();
            this.SuspendLayout();
            // 
            // AutoFormatButton
            // 
            this.AutoFormatButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AutoFormatButton.Location = new System.Drawing.Point(12, 488);
            this.AutoFormatButton.Name = "AutoFormatButton";
            this.AutoFormatButton.Size = new System.Drawing.Size(75, 23);
            this.AutoFormatButton.TabIndex = 0;
            this.AutoFormatButton.Text = "Apply";
            this.AutoFormatButton.UseVisualStyleBackColor = true;
            this.AutoFormatButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormatCapitalsCheckBox
            // 
            this.FormatCapitalsCheckBox.AutoSize = true;
            this.FormatCapitalsCheckBox.Location = new System.Drawing.Point(12, 158);
            this.FormatCapitalsCheckBox.Name = "FormatCapitalsCheckBox";
            this.FormatCapitalsCheckBox.Size = new System.Drawing.Size(97, 17);
            this.FormatCapitalsCheckBox.TabIndex = 1;
            this.FormatCapitalsCheckBox.Text = "Format capitals";
            this.FormatCapitalsCheckBox.UseVisualStyleBackColor = true;
            this.FormatCapitalsCheckBox.CheckedChanged += new System.EventHandler(this.FormatCapitalsCheckBox_CheckedChanged);
            // 
            // FormatQuotesTextBox
            // 
            this.FormatQuotesTextBox.AutoSize = true;
            this.FormatQuotesTextBox.Enabled = false;
            this.FormatQuotesTextBox.Location = new System.Drawing.Point(12, 204);
            this.FormatQuotesTextBox.Name = "FormatQuotesTextBox";
            this.FormatQuotesTextBox.Size = new System.Drawing.Size(93, 17);
            this.FormatQuotesTextBox.TabIndex = 2;
            this.FormatQuotesTextBox.Text = "Format quotes";
            this.FormatQuotesTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FormatQuotesTextBox.UseVisualStyleBackColor = true;
            this.FormatQuotesTextBox.CheckedChanged += new System.EventHandler(this.FormatQuotesTextBox_CheckedChanged);
            // 
            // SpacePagesCheckBox
            // 
            this.SpacePagesCheckBox.AutoSize = true;
            this.SpacePagesCheckBox.Cursor = System.Windows.Forms.Cursors.No;
            this.SpacePagesCheckBox.Enabled = false;
            this.SpacePagesCheckBox.Location = new System.Drawing.Point(12, 227);
            this.SpacePagesCheckBox.Name = "SpacePagesCheckBox";
            this.SpacePagesCheckBox.Size = new System.Drawing.Size(152, 17);
            this.SpacePagesCheckBox.TabIndex = 3;
            this.SpacePagesCheckBox.Text = "Automatically space pages";
            this.SpacePagesCheckBox.UseVisualStyleBackColor = true;
            this.SpacePagesCheckBox.CheckedChanged += new System.EventHandler(this.SpacePagesCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 78);
            this.label1.TabIndex = 4;
            this.label1.Text = "Use the checkboxes below to automatically format\r\nthe book.\r\nTicking a checkbox w" +
    "ill open a form where you can customize the settings.\r\n\r\nTo the right side, ther" +
    "e is a preview available.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(93, 488);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ChangeColorCheckBox
            // 
            this.ChangeColorCheckBox.AutoSize = true;
            this.ChangeColorCheckBox.Enabled = false;
            this.ChangeColorCheckBox.Location = new System.Drawing.Point(12, 181);
            this.ChangeColorCheckBox.Name = "ChangeColorCheckBox";
            this.ChangeColorCheckBox.Size = new System.Drawing.Size(175, 17);
            this.ChangeColorCheckBox.TabIndex = 6;
            this.ChangeColorCheckBox.Text = "Change default formatting/color";
            this.ChangeColorCheckBox.UseVisualStyleBackColor = true;
            this.ChangeColorCheckBox.CheckedChanged += new System.EventHandler(this.ChangeColorCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Preview of selected formatting: options:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // RemoveFormattingCheckBox
            // 
            this.RemoveFormattingCheckBox.AutoSize = true;
            this.RemoveFormattingCheckBox.Location = new System.Drawing.Point(12, 135);
            this.RemoveFormattingCheckBox.Name = "RemoveFormattingCheckBox";
            this.RemoveFormattingCheckBox.Size = new System.Drawing.Size(166, 17);
            this.RemoveFormattingCheckBox.TabIndex = 15;
            this.RemoveFormattingCheckBox.Text = "Remove all existing formatting";
            this.RemoveFormattingCheckBox.UseVisualStyleBackColor = true;
            this.RemoveFormattingCheckBox.CheckedChanged += new System.EventHandler(this.RemoveAllExistingFormattingCheckboxChecked);
            // 
            // navigableMinecraftTextLabel1
            // 
            this.navigableMinecraftTextLabel1.Location = new System.Drawing.Point(337, 68);
            this.navigableMinecraftTextLabel1.Name = "navigableMinecraftTextLabel1";
            this.navigableMinecraftTextLabel1.Size = new System.Drawing.Size(338, 434);
            this.navigableMinecraftTextLabel1.TabIndex = 14;
            // 
            // AutoFormatWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 523);
            this.Controls.Add(this.RemoveFormattingCheckBox);
            this.Controls.Add(this.navigableMinecraftTextLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChangeColorCheckBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpacePagesCheckBox);
            this.Controls.Add(this.FormatQuotesTextBox);
            this.Controls.Add(this.FormatCapitalsCheckBox);
            this.Controls.Add(this.AutoFormatButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoFormatWizard";
            this.Text = "AutoFormatWizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AutoFormatButton;
        private System.Windows.Forms.CheckBox FormatCapitalsCheckBox;
        private System.Windows.Forms.CheckBox FormatQuotesTextBox;
        private System.Windows.Forms.CheckBox SpacePagesCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox ChangeColorCheckBox;
        private System.Windows.Forms.Label label3;
        private Components.NavigableMinecraftTextLabel navigableMinecraftTextLabel1;
        private System.Windows.Forms.CheckBox RemoveFormattingCheckBox;
    }
}