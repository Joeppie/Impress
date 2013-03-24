using Impress.UIElements.Components;
namespace Impress.UIElements.Components
{
    partial class FormattingControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new Impress.UIElements.Components.MinecraftTextLabel();
            this.colorPicker1 = new Impress.UIElements.Components.ColorPicker(this.components);
            this.formatPicker1 = new Impress.UIElements.Components.FormatPicker(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Example:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Example";
            // 
            // colorPicker1
            // 
            this.colorPicker1.Location = new System.Drawing.Point(12, 12);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.SelectedChar = '\0';
            this.colorPicker1.SelectedColor = System.Drawing.Color.Black;
            this.colorPicker1.Size = new System.Drawing.Size(216, 52);
            this.colorPicker1.TabIndex = 0;
            // 
            // formatPicker1
            // 
            this.formatPicker1.Location = new System.Drawing.Point(12, 70);
            this.formatPicker1.Name = "formatPicker1";
            this.formatPicker1.SelectedChar = '\0';
            this.formatPicker1.Size = new System.Drawing.Size(187, 63);
            this.formatPicker1.TabIndex = 2;
            // 
            // FormattingForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 223);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorPicker1);
            this.Controls.Add(this.formatPicker1);
            this.Name = "FormattingForm";
            this.Text = "Choose Formatting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UIElements.Components.ColorPicker colorPicker1;
        private Components.FormatPicker formatPicker1;
        private System.Windows.Forms.Label label1;
        private MinecraftTextLabel label2;
    }
}