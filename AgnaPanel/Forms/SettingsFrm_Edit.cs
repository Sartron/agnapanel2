using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AgnaPanel.Forms
{
    public partial class SettingsFrm_Edit : Form
    {
        public bool Saved;
        public Settings.AgnaImage selectedImage;
        public Settings.AgnaImageCategory selectedCategory;

        public SettingsFrm_Edit(int imageIndex, Settings.AgnaImageCategory parentCategory)
        {
            InitializeComponent();
            selectedCategory = parentCategory.Clone();
            selectedImage = parentCategory.Images[imageIndex].Clone();

            if (!String.IsNullOrWhiteSpace(parentCategory.Path) && selectedImage.Path.StartsWith("..") ||
                selectedImage.Path.StartsWith("<root>"))
                optionRelative.Checked = true;
            else
                optionAbsolute.Checked = true;

            txtName.Text = selectedImage.Name;
            txtPath.Text = selectedImage.Path;
        }

        public SettingsFrm_Edit(Settings.AgnaImageCategory agnaImageCategory)
        {
            InitializeComponent();
            selectedCategory = agnaImageCategory.Clone();

            txtName.Text = agnaImageCategory.Name;
            txtPath.Text = agnaImageCategory.Path;

            if (String.IsNullOrWhiteSpace(agnaImageCategory.Path))
                optionAbsolute.Checked = true;
            else
                optionRelative.Checked = true;

            optionAbsolute.Enabled = false;
            optionRelative.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saved = true;

            if (selectedCategory != null && selectedImage == null)
            {
                //Editing an AgnaImageCategory
                selectedCategory.Name = txtName.Text;
                selectedCategory.Path = txtPath.Text;
            }
            else
            {
                //Editing an AgnaImage
                selectedImage.Name = txtName.Text;
                selectedImage.Path = txtPath.Text;
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (selectedCategory != null && txtName.Text == String.Empty)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (selectedImage == null && selectedCategory != null)
            {
                if (String.IsNullOrWhiteSpace(txtPath.Text))
                    optionAbsolute.Checked = true;
                else
                    optionRelative.Checked = true;

                return;
            }

            if (!String.IsNullOrWhiteSpace(selectedCategory.Path) && txtPath.Text.StartsWith("..") || txtPath.Text.StartsWith("<root>"))
                optionRelative.Checked = true;
            else
                optionAbsolute.Checked = true;
        }
    }
}
