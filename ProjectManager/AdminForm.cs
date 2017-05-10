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
    public partial class AdminForm : Form
    {
        public XMLDataToObj.Project Project { get; set; }

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(ProjectManager.XMLDataToObj.Project project)
        {
            this.Project = project;
        }


    }
}
