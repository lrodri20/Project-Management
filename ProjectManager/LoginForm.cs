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
    public partial class LoginForm : Form
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        private ProjectManager.XMLDataToObj.ProjectDatabase projectData { get; set; }
        private ProjectManager.XMLDataToObj.Employee currEmployee { get; set; }

        public LoginForm()
        {
            InitializeComponent();

            XMLDataToObj xmlReader = new XMLDataToObj();
            projectData = xmlReader.LoadXML(@"C:\Users\William_2\Documents\visual studio 2012\Projects\ProjectManager\ProjectDatabase.xml");
        }

        private void b_Login_Click(object sender, EventArgs e)
        {
            if (tb_Password.Text != "" && tb_UserName.Text != "")
            {
                UserName = tb_UserName.Text;
                Password = tb_Password.Text;
                if (validateLogin(UserName, Password))
                {
                    ManagementForm mForm = new ManagementForm(projectData, currEmployee);
                    this.Hide();
                    mForm.Show();
                    mForm.FormClosing += mForm_FormClosing;
                }
            }
        }

        private void mForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private bool validateLogin(string UserName, string Password)
        {
            foreach (ProjectManager.XMLDataToObj.Employee employ in projectData.Employees.EmployeeList)
            {
                if (employ.UserName == UserName && employ.Password == Password)
                {
                    currEmployee = employ;
                    return true;
                }
            }
            return false;
        }
    }
}
