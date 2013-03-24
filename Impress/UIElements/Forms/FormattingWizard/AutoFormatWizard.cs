using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Impress.UIElements.Forms.FormattingWizard
{
    public partial class AutoFormatWizard : Form
    {
        private AutoFormatWizard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the autoformatwizard
        /// </summary>
        /// <param name="inputString">The text to be formatted using the wizard.</param>
        public AutoFormatWizard(string inputText) : this()
        {
            OriginalText = inputText;

            navigableMinecraftTextLabel1.Label.Text = OriginalText;
        }

        private string _defaultFormatting;
        private string _fallbackDefault = "&r";

        public string OriginalText { get; private set; }
        public string FormattedText { get; private set; }

        /// <summary>
        /// The formatting to use as the default text color, null or empty when using the default; black.
        /// </summary>
        public string DefaultFormatting
        {
            get { return (string.IsNullOrEmpty(_defaultFormatting) ? _fallbackDefault : _defaultFormatting); }
            set { _defaultFormatting = value; }
        }

        /// <summary>
        /// The formatting to use for capitals that mark the start of sentences or paragraphs
        /// </summary>
        public string CapitalizationFormatting { get; private set; }

        /// <summary>
        /// The formatting to use on quotes.
        /// </summary>
        public string QuoteFormatting { get; private set; }

        /// <summary>
        /// The formatting to use on the body of quotes.
        /// </summary>
        public string QuoteBodyFormatting { get; private set; } 



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("You clicked the label, try clicking the checkboxes.","Almost!");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void UpdatePreview()
        {
            FormattedText = OriginalText; //falback scenario.

            if (RemoveFormattingCheckBox.Checked)
            {
                FormattedText = Regex.Replace(FormattedText, "[&§][a-fl-pk]", string.Empty);
            }

            if (!string.IsNullOrEmpty(CapitalizationFormatting))
            {
                FormatCapitals();
            }
            if (!string.IsNullOrEmpty(QuoteFormatting) &&
                !string.IsNullOrEmpty(QuoteBodyFormatting) )
            {
                FormatQuotes();
            }
            if (SpacePagesCheckBox.Checked)
            {
                FormatPageSpacing();
            }

            navigableMinecraftTextLabel1.Label.Text = FormattedText;
        }

        public void FormatCapitals()
        {

            string replace =
                "${start}"
                + CapitalizationFormatting
                + "${capital}"
                + DefaultFormatting;

            string regex = @"(?<start>^\s*|(\.|\?|\!)\s*)(?<capital>[A-Z])";

            FormattedText = Regex.Replace(OriginalText, regex, replace);
        }


        public void FormatQuotes()
        {

        }

        /// <summary>
        /// This is the most complex formatting, since it will need to evaluate the output rendered by a
        /// <see cref="MinecraftTextRenderHelper"/>
        /// </summary>
        public void FormatPageSpacing()
        {
            new FormattingForm().ShowDialog();

            string capitalizationColor = "&4";
            string restorationColor = "&0";

            string replace =
                "${start}"
                + capitalizationColor
                + "${capital}"
                + restorationColor;

            string regex = @"(?<start>^\s*|(\.|\?|\!)\s*)(?<capital>[A-Z])";

            FormattedText = Regex.Replace(OriginalText, regex, replace);
        }

        private void ChangeColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                var form = new FormattingForm();
                form.ExampleTemplate = "{0}normal text";
                form.ShowDialog();

                if (form.DialogResult != DialogResult.OK)
                {
                    return;
                }

                DefaultFormatting = form.Formatting;
            }
            else
            {
                DefaultFormatting = string.Empty;
            }
            UpdatePreview();
        }

        private void FormatCapitalsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                var form = new FormattingForm();
                form.ExampleTemplate = "{0}M&rinecraft!";
                form.ShowDialog("Pick Capital format");

                if (form.DialogResult != DialogResult.OK)
                {
                    return;
                }

                CapitalizationFormatting = form.Formatting;
            }
            else
            {
                CapitalizationFormatting = string.Empty;
            }
            UpdatePreview();
        }

        private void FormatQuotesTextBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                var form = new FormattingForm();
                form.ExampleTemplate = "{0}\"&rNo{0}\"&r he said.";
                form.ShowDialog("Pick Quote format");

                if (form.DialogResult != DialogResult.OK)
                {
                    return;
                }

                QuoteFormatting = form.Formatting;

                form.ExampleTemplate = form.Formatting + '"' + "{0}No" + form.Formatting + '"' + "&r he said";
                form.ShowDialog("Pick Quote body format");

                if (form.DialogResult != DialogResult.OK)
                {
                    return;
                }

                
                QuoteBodyFormatting = form.Formatting;
            }
            else
            {
                QuoteFormatting = string.Empty;
                QuoteBodyFormatting = string.Empty;
            }
            UpdatePreview();
        }

        private void SpacePagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.","Unimplemented.");
            UpdatePreview();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            navigableMinecraftTextLabel1.Label.Text = (sender as TextBox).Text;
            navigableMinecraftTextLabel1.Label.Invalidate();
        }

        private void RemoveAllExistingFormattingCheckboxChecked(object sender, EventArgs e)
        {
            UpdatePreview();
        }



    }
}
