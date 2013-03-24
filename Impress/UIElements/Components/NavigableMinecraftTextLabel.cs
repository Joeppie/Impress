using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Impress.UIElements.Components
{
    internal partial class NavigableMinecraftTextLabel : UserControl
    {
        public NavigableMinecraftTextLabel()
        {
            InitializeComponent();

            MinecraftTextLabel.PageChanged += (s, e) => { SetPageXofYText(); SetEnabledForPagesButtons(); };
            SetEnabledForPagesButtons();
            SetPageXofYText();

            MinecraftTextLabel.Text = "aaaaaaaaaaa".Replace("a","This is a remarkably long text for testing purposes.\n");

            this.NavigateFirstButton.Click += new System.EventHandler(this.NavigateFirstButtonClicked); 
            this.NavigateLastButton.Click += new System.EventHandler(this.NavigateLastButtonClicked); 
            this.NavigatePreviousButton.Click += new System.EventHandler(this.NavigatePreviousButtonClicked);
            this.NavigateNextButton.Click += new System.EventHandler(this.NavigateNextButtonClicked);

            Label = MinecraftTextLabel;
        }

        public MinecraftTextLabel Label { get; private set; }


        private void SetPageXofYText()
        {
            PageLabel.Text = String.Format("Page {0} of {1}.", MinecraftTextLabel.Page + 1, MinecraftTextLabel.MaxPageNumber + 1);
        }

        #region Navigation Buttons

        private void NavigatePreviousButtonClicked(object sender, EventArgs e)
        {
            if (MinecraftTextLabel.Page > 0)
            {
                MinecraftTextLabel.Page--;
            }
        }

        private void NavigateNextButtonClicked(object sender, EventArgs e)
        {
            if (MinecraftTextLabel.Page < MinecraftTextLabel.MaxPageNumber)
            {
                MinecraftTextLabel.Page++;
            }
        }

        private void NavigateLastButtonClicked(object sender, EventArgs e)
        {
            MinecraftTextLabel.Page = MinecraftTextLabel.MaxPageNumber;
        }

        private void NavigateFirstButtonClicked(object sender, EventArgs e)
        {
            MinecraftTextLabel.Page = 0;
        }

        private void SetEnabledForPagesButtons()
        {
            bool hasNextPage = (MinecraftTextLabel.Page < MinecraftTextLabel.MaxPageNumber);
            bool hasPreviousPage = (MinecraftTextLabel.Page > 0);

            NavigateNextButton.Enabled = hasNextPage;
            NavigateLastButton.Enabled = hasNextPage;

            NavigatePreviousButton.Enabled = hasPreviousPage;
            NavigateFirstButton.Enabled = hasPreviousPage;
        }

        #endregion

    }
}
