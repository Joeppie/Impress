using Impress.UIElements.Components;
namespace Impress.UIElements.Forms.FormattingWizard
{
    partial class FormattingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormattingForm));
            this.formattingControl1 = new Impress.UIElements.Components.FormattingControl();
            this.button1 = new System.Windows.Forms.Button();
            this.formattingControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formattingControl1
            // 
            this.formattingControl1.Controls.Add(this.button1);
            this.formattingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formattingControl1.ExampleTemplate = "Example";
            this.formattingControl1.ExampleVisible = false;
            this.formattingControl1.Location = new System.Drawing.Point(0, 0);
            this.formattingControl1.Name = "formattingControl1";
            this.formattingControl1.Size = new System.Drawing.Size(307, 241);
            this.formattingControl1.TabIndex = 0;
            this.formattingControl1.Text = "Choose Formatting";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormattingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(307, 241);
            this.Controls.Add(this.formattingControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormattingForm";
            this.Text = "Pick format";
            this.TopMost = true;
            this.formattingControl1.ResumeLayout(false);
            this.formattingControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FormattingControl formattingControl1;
        private System.Windows.Forms.Button button1;
    }
}