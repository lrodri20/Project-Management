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
    public partial class ManagementForm : Form
    {
        private ProjectManager.XMLDataToObj.ProjectDatabase projectData { get; set; }
        private ProjectManager.XMLDataToObj.Employee currEmployee { get; set; }
        private bool isAdmin {get; set;}
        public EventHandler formSavedClick;


        //default constructor, dont use
        public ManagementForm()
        {
            InitializeComponent();
        }

        //constructor that takes in all the project data along with the employee that just
        //logged in. 
        public ManagementForm(ProjectManager.XMLDataToObj.ProjectDatabase projData, 
            ProjectManager.XMLDataToObj.Employee currEmployee)
        {
            this.projectData = projData;
            this.currEmployee = currEmployee;

            InitializeComponent();
            isAdmin = currEmployee.Admin.ToLower() == "true" ? true : false;
            
            if (isAdmin)
            {
                projectToolStripMenuItem.Visible = true;
            }
            else
            {
                projectToolStripMenuItem.Visible = false;
            }

            loadDGV();
            
        }

        //populate the data grid view with all the project information
        //as of right now, it's just project ID, Name, and Description
        private void loadDGV()
        {
            foreach (XMLDataToObj.AssignedProjects assignedProj in currEmployee.AssignedProjects)
            {
                List<string> assignedProjects = assignedProj.ProjectIDs.Select(x => x.ID).ToList();
                List<string> projectHours = assignedProj.ProjectIDs.Select(x => x.TotalHours).ToList();

                foreach (XMLDataToObj.Project project in projectData.Projects.ProjectList)
                {
                    if (project.ProjectDescription.Description == null ||
                        project.ProjectDescription.Description == "")
                    {
                        project.ProjectDescription.Description = " ";
                    }
                    if (isAdmin)
                    {
                        string[] row = { project.ID, project.Name, project.ProjectDescription.Description };
                        dgv_ProjectView.Rows.Add(row);
                    }
                    else if (assignedProjects.Contains(project.ID))
                    {
                        string[] row = {project.ID, project.Name, project.ProjectDescription.Description };
                        dgv_ProjectView.Rows.Add(row);
                    }
                }
            }
        }

        //this is used so that an employee can edit their hours for a specific project
        private void dgv_ProjectView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (!isAdmin)
            {
                if (rowIndex == dgv_ProjectView.Rows.Count - 1)
                {
                    return;
                }
                string[] row;

                if (dgv_ProjectView.Rows[e.RowIndex].Cells[2].Value == null)
                {
                    row = new string[] { dgv_ProjectView.Rows[e.RowIndex].Cells[0].Value.ToString(),
                                              dgv_ProjectView.Rows[e.RowIndex].Cells[1].Value.ToString(),
                                              ""};
                }
                else
                {
                     row = new string[] { dgv_ProjectView.Rows[e.RowIndex].Cells[0].Value.ToString(),
                                              dgv_ProjectView.Rows[e.RowIndex].Cells[1].Value.ToString(),
                                              dgv_ProjectView.Rows[e.RowIndex].Cells[2].Value.ToString()};
                }
                
                for (int i = 0; i < projectData.Projects.ProjectList.Count(); i++)
                {
                    XMLDataToObj.Project selectedProject = projectData.Projects.ProjectList[i];
                    if (selectedProject.ID == row[0])
                    {
                        EmployeeForm newEmpForm = new EmployeeForm(selectedProject);
                        newEmpForm.ShowDialog();
                        if (newEmpForm.DialogResult == DialogResult.OK)
                        {
                            projectData.Projects.ProjectList[i] = newEmpForm.Project;
                        }
                        break;
                    }
                }
            }
            else
            {
                int projectId = -1;
                Int32.TryParse(dgv_ProjectView.Rows[rowIndex].Cells[0].Value.ToString(), out projectId);
                if (projectId < 0)
                {
                    MessageBox.Show("Error parsing this project ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < projectData.Projects.ProjectList.Count; i++)
                {
                    if (projectData.Projects.ProjectList[i].ID == projectId + "")
                    {
                        
                        XMLDataToObj.Project oldProj = projectData.Projects.ProjectList[i];
                        XMLDataToObj.Project projToEdit = new XMLDataToObj.Project()
                        {
                            AnalysisHours = oldProj.AnalysisHours,
                            CodeHours = oldProj.CodeHours,
                            DesignHours = oldProj.DesignHours,
                            ID = oldProj.ID,
                            ManHours = oldProj.ManHours,
                            Name = oldProj.Name,
                            ProjectDescription = oldProj.ProjectDescription,
                            ProjectOwner = oldProj.ProjectOwner,
                            TestHours = oldProj.TestHours
                        };
                        CreateForm editForm = new CreateForm(CreateForm.createType.PROJECT, projToEdit);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            projectData.Projects.ProjectList[i] = (XMLDataToObj.Project)editForm.newCreation;
                        }
                        break;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            XMLDataToObj save = new XMLDataToObj();
            save.SaveXML(projectData);
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateForm create = new CreateForm(CreateForm.createType.PROJECT);
            if (create.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XMLDataToObj.Project newProj = (XMLDataToObj.Project)create.newCreation;
                foreach (XMLDataToObj.Project proj in projectData.Projects.ProjectList)
                {
                    if (proj.ID == newProj.ID)
                    {
                        MessageBox.Show("Project with ID: " + proj.ID + " already exists." + Environment.NewLine +
                            "Please use a unique ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        projectData.Projects.ProjectList.Add(newProj);
                        loadDGV();
                        break;
                    }
                }
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm create = new CreateForm(CreateForm.createType.EMPLOYEE);
            if (create.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XMLDataToObj.Employee newEmploy = (XMLDataToObj.Employee)create.newCreation;
                foreach(XMLDataToObj.Employee employee in projectData.Employees.EmployeeList)
                {
                    if (newEmploy.UserName == employee.UserName)
                    {
                        MessageBox.Show("Employee with user name: " + employee.UserName + Environment.NewLine
                            + "already exixst. Employee user names must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        projectData.Employees.EmployeeList.Add(newEmploy);
                        break;
                    }
                }
                
            }
        }

    }
}
