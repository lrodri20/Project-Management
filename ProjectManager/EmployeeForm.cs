using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager
{
    public partial class EmployeeForm : Form
    {
        public XMLDataToObj.Project Project { get; set; }
        private XMLDataToObj.Project ProjectToEdit { get; set; }
        private int currentlySelectedIndex;

        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(XMLDataToObj.Project Project)
        {
            this.Project = Project;
            this.ProjectToEdit = new XMLDataToObj.Project()
            {
                AnalysisHours = Project.AnalysisHours,
                CodeHours = Project.CodeHours,
                DesignHours = Project.DesignHours,
                ID = Project.ID,
                ManHours = Project.ManHours,
                Name = Project.Name,
                ProjectDescription = Project.ProjectDescription,
                ProjectOwner = Project.ProjectOwner,
                TestHours = Project.TestHours
            };

            this.currentlySelectedIndex = 0;

            InitializeComponent();
        }

        private void cb_SelectHours_DropDownClosed(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)(sender)).SelectedIndex;
            string selectedText = ((ComboBox)(sender)).SelectedText;
            switch (selectedIndex)
            {
                case 0:
                    tb_CurrProjHours.Text = ProjectToEdit.ManHours;
                    break;                  
                case 1:                     
                    tb_CurrProjHours.Text = ProjectToEdit.TestHours;
                    break;                  
                case 2:                     
                    tb_CurrProjHours.Text = ProjectToEdit.CodeHours;
                    break;                  
                case 3:                     
                    tb_CurrProjHours.Text = ProjectToEdit.DesignHours;
                    break;                  
                case 4:                     
                    tb_CurrProjHours.Text = ProjectToEdit.AnalysisHours;
                    break;
            }
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            Project = ProjectToEdit;
            this.DialogResult = DialogResult.OK;
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tb_CurrProjHours_Leave(object sender, EventArgs e)
        {
            int getHoursFromString = 0;
            Int32.TryParse(tb_CurrProjHours.Text, out getHoursFromString);
            if (getHoursFromString <= -1)
            {
                MessageBox.Show("Can only enter in a whole, postive integer quantity");
            }
            else
            {
                switch (currentlySelectedIndex)
                {
                    case 0:
                        ProjectToEdit.ManHours = getHoursFromString + "";
                        break;
                    case 1:
                        ProjectToEdit.TestHours = getHoursFromString + "";
                        break;
                    case 2:
                        ProjectToEdit.CodeHours = getHoursFromString + "";
                        break;
                    case 3:
                        ProjectToEdit.DesignHours = getHoursFromString + "";
                        break;
                    case 4:
                        ProjectToEdit.AnalysisHours = getHoursFromString + "";
                        break;
                }
            }
        }

    }
}
