using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectManager
{
    public class XMLDataToObj
    {
        public XMLDataToObj()
        {
        }

        public ProjectDatabase LoadXML(string xmlLoc)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProjectDatabase));
            ProjectDatabase projectData;

            using (XmlReader reader = XmlReader.Create(@"Resources/ProjectDatabase.xml"))
            {
                projectData = (ProjectDatabase)ser.Deserialize(reader);
            }

            return projectData;
        }

        public void SaveXML(ProjectDatabase projectData)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProjectDatabase));
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = " ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };

            using (XmlWriter writer = XmlWriter.Create(@"Resources/ProjectDatabase.xml", settings))
            {
                ser.Serialize(writer, projectData);
            }
        }

        [Serializable()]
        [XmlRoot("ProjectDatabase")]
        public class ProjectDatabase
        {
            [XmlElement("Employees")]
            public Employees Employees { get; set; }

            [XmlElement("Projects")]
            public Projects Projects { get; set; }
        }

        #region EMPLOYEE HANDLING
        public class Employees
        {
            [XmlElement("Employee")]
            public List<Employee> EmployeeList { get; set; }
        }

        public class Employee
        {
            [XmlAttribute("UserName")]
            public string UserName { get; set; }

            [XmlAttribute("Password")]
            public string Password { get; set; }

            [XmlAttribute("Admin")]
            public string Admin { get; set; }

            [XmlElement("AssignedProjects")]
            public List<AssignedProjects> AssignedProjects { get; set; }
        }

        public class AssignedProjects
        {
            [XmlElement("ProjectID")]
            public List<ProjectID> ProjectIDs { get; set; }
        }

        public class ProjectID
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }

            [XmlAttribute("TotalHours")]
            public string TotalHours { get; set; }
        }
        #endregion

        #region PROJECT HANDLING

        public class Projects
        {
            [XmlElement("Project")]
            public List<Project> ProjectList { get; set; }
        }

        public class Project
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }

            [XmlAttribute("Name")]
            public string Name { get; set; }

            [XmlAttribute("ProjOwner")]
            public string ProjectOwner { get; set; }

            [XmlAttribute("ManHours")]
            public string ManHours { get; set; }

            [XmlAttribute("TestHours")]
            public string TestHours { get; set; }

            [XmlAttribute("CodeHours")]
            public string CodeHours { get; set; }

            [XmlAttribute("DesignHours")]
            public string DesignHours { get; set; }

            [XmlAttribute("AnalysisHours")]
            public string AnalysisHours { get; set; }

            [XmlElement("ProjectDescription")]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public ProjectDescription ProjectDescription { get; set; }
        }

        public class ProjectDescription
        {
            [XmlElement("Requirements")]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public List<Requirement> Requirements { get; set; }

            [XmlElement("Risks")]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public List<Risk> Risks { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }
        }

        public class Requirements
        {
            [XmlElement("Requirement")]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public List<Requirement> Requirement { get; set; }
        }

        public class Requirement
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }

            [XmlAttribute("Type")]
            public string Type { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }
        }

        public class Risks
        {
            [XmlElement("Risk")]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public List<Risks> Risk { get; set; }

        }

        public class Risk
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }

            [XmlAttribute("Severity")]
            public string Type { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }
        }

        #endregion
    }
}
