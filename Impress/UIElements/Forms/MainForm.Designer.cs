namespace Impress.UIElements.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintButton = new System.Windows.Forms.Button();
            this.AutoFormatWizardButton = new System.Windows.Forms.Button();
            this.SourceTextBox = new System.Windows.Forms.RichTextBox();
            this.formatPicker1 = new Impress.UIElements.Components.FormatPicker(this.components);
            this.colorPicker1 = new Impress.UIElements.Components.ColorPicker(this.components);
            this.navigableMinecraftTextLabel1 = new Impress.UIElements.Components.NavigableMinecraftTextLabel();
            this.MenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuStrip.Size = new System.Drawing.Size(676, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItemClicked);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItemClicked);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItemClicked);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.howToUseToolStripMenuItem.Text = "How to use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItemClicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItemClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.formatPicker1);
            this.panel1.Controls.Add(this.colorPicker1);
            this.panel1.Controls.Add(this.navigableMinecraftTextLabel1);
            this.panel1.Controls.Add(this.PrintButton);
            this.panel1.Controls.Add(this.AutoFormatWizardButton);
            this.panel1.Controls.Add(this.SourceTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 556);
            this.panel1.TabIndex = 3;
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(9, 511);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(78, 31);
            this.PrintButton.TabIndex = 10;
            this.PrintButton.Text = "Print Book";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // AutoFormatWizardButton
            // 
            this.AutoFormatWizardButton.Location = new System.Drawing.Point(93, 511);
            this.AutoFormatWizardButton.Name = "AutoFormatWizardButton";
            this.AutoFormatWizardButton.Size = new System.Drawing.Size(136, 31);
            this.AutoFormatWizardButton.TabIndex = 8;
            this.AutoFormatWizardButton.Text = "Autoformat wizard";
            this.AutoFormatWizardButton.UseVisualStyleBackColor = true;
            this.AutoFormatWizardButton.Click += new System.EventHandler(this.AutoFormatWizardButtonClicked);
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.AcceptsTab = true;
            this.SourceTextBox.DetectUrls = false;
            this.SourceTextBox.Location = new System.Drawing.Point(380, 33);
            this.SourceTextBox.MaxLength = 12750;
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Size = new System.Drawing.Size(249, 392);
            this.SourceTextBox.TabIndex = 6;
            this.SourceTextBox.Text = "";
            this.SourceTextBox.TextChanged += new System.EventHandler(this.SourceTextBoxTextChanged);
            // 
            // formatPicker1
            // 
            this.formatPicker1.BackColor = System.Drawing.SystemColors.Control;
            this.formatPicker1.Location = new System.Drawing.Point(370, 3);
            this.formatPicker1.Name = "formatPicker1";
            this.formatPicker1.SelectedChar = '\0';
            this.formatPicker1.Size = new System.Drawing.Size(294, 28);
            this.formatPicker1.TabIndex = 15;
            // 
            // colorPicker1
            // 
            this.colorPicker1.BackColor = System.Drawing.SystemColors.Control;
            this.colorPicker1.Location = new System.Drawing.Point(12, 3);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.SelectedChar = '\0';
            this.colorPicker1.SelectedColor = System.Drawing.Color.Black;
            this.colorPicker1.Size = new System.Drawing.Size(361, 28);
            this.colorPicker1.TabIndex = 14;
            // 
            // navigableMinecraftTextLabel1
            // 
            this.navigableMinecraftTextLabel1.Location = new System.Drawing.Point(12, 34);
            this.navigableMinecraftTextLabel1.Name = "navigableMinecraftTextLabel1";
            this.navigableMinecraftTextLabel1.Size = new System.Drawing.Size(338, 434);
            this.navigableMinecraftTextLabel1.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Impress ";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox SourceTextBox;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button AutoFormatWizardButton;
        private System.Windows.Forms.Button PrintButton;
        private Components.NavigableMinecraftTextLabel navigableMinecraftTextLabel1;
        private Components.FormatPicker formatPicker1;
        private Components.ColorPicker colorPicker1;

    }
}

