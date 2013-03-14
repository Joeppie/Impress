namespace Impress.UIElements
{
    partial class AutoFormatForm
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
            this.colorPicker1 = new Impress.UIElements.Components.ColorPicker(this.components);
            this.SuspendLayout();
            // 
            // colorPicker1
            // 
            this.colorPicker1.Location = new System.Drawing.Point(27, 12);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.Size = new System.Drawing.Size(200, 100);
            this.colorPicker1.TabIndex = 0;
            // 
            // AutoFormatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.colorPicker1);
            this.Name = "AutoFormatForm";
            this.Text = "AutoFormatForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UIElements.Components.ColorPicker colorPicker1;
    }
}