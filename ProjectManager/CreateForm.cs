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
    public partial class CreateForm : Form
    {
        
        public enum createType
        {
            EMPLOYEE = 1,
            PROJECT = 2
        }

        public createType userDefinedCreate { get; set; }

        public object newCreation { get; set; }

        public CreateForm(createType createType)
        {
            InitializeComponent();
            this.userDefinedCreate = createType;
            loadPropGrid();
        }

        public CreateForm(createType createType, object objToEdit)
        {
            InitializeComponent();
            this.newCreation = objToEdit;
            this.userDefinedCreate = createType;
            loadPropGrid(objToEdit);
        }

        private void loadPropGrid(object objToCreate = null)
        {
            switch (userDefinedCreate)
            {
                case createType.EMPLOYEE:
                    pg_Create.SelectedObject = new XMLDataToObj.Employee()
                    {
                        Admin = "false",
                        AssignedProjects = new List<XMLDataToObj.AssignedProjects>(),
                        Password = "default",
                        UserName = "default"
                    };
                    if (objToCreate != null)
                    {
                        pg_Create.SelectedObject = (XMLDataToObj.Employee)objToCreate;
                    }
                    break;
                case createType.PROJECT:
                    XMLDataToObj.Project proj = new XMLDataToObj.Project();
                    proj.ProjectDescription = new XMLDataToObj.ProjectDescription();
                    proj.ProjectDescription.Requirements = new List<XMLDataToObj.Requirement>();
                    proj.ProjectDescription.Risks = new List<XMLDataToObj.Risk>();
                    pg_Create.SelectedObject = proj;
                    if (objToCreate != null)
                    {
                        pg_Create.SelectedObject = (XMLDataToObj.Project)objToCreate;
                    }
                    break;
                default:
                    MessageBox.Show("Unkown type encountered. Currently only creation of new " + Environment.NewLine +
                        "Employees or Projects is currently supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            switch (userDefinedCreate)
            {
                case createType.EMPLOYEE:
                    newCreation = (XMLDataToObj.Employee)pg_Create.SelectedObject;
                    break;
                case createType.PROJECT:
                    newCreation = (XMLDataToObj.Project)pg_Create.SelectedObject;
                    break;
                default:
                    newCreation = null;
                    MessageBox.Show("Unkown type encountered. Currently only creation of new " + Environment.NewLine +
                        "Employees or Projects is currently supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
