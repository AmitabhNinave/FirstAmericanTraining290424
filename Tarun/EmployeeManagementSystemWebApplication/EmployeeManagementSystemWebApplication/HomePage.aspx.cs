using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EmployeeManagementSystemWebApplication
{
    public partial class EmployeeManagementPage : System.Web.UI.Page
    {
        protected static List<Employee> employees = new List<Employee>();
        protected static List<Employee> searchEmployees = new List<Employee>();
        protected static bool isListAll = false;
        protected static bool isSearch = false;
        protected static bool isUpdate = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DeserializationDAL();
                GetDepartment();
                GetDesignations();
                GetSearchByList();
            }
        }

        protected void GetDesignations()
        {
            ddlDesig.Items.Add("--- Select Designation ---");
            ddlDesig.Items.Add("Jr. Programmer");
            ddlDesig.Items.Add("Sr. Programmer");
            ddlDesig.Items.Add("Team Lead");
            ddlDesig.Items.Add("Project Lead");
        }

        protected void GetDepartment()
        {
            ddlDepart.Items.Add("--- Select Department ---");
            ddlDepart.Items.Add("IT");
            ddlDepart.Items.Add("Finance");
            ddlDepart.Items.Add("HR");
            ddlDepart.Items.Add("Software");
        }

        protected int getDepartmentIndex(string department)
        {
            if(department == "IT")
                return 1;
            if(department == "Finance")
                return 2;
            if(department == "HR")
                return 3;
            if (department == "Software")
                return 4;
            else
                return -1;
        }

        protected int getDesignationIndex(string designation)
        {
            if (designation == "Jr. Programmer")
                return 1;
            if (designation == "Sr. Programmer")
                return 2;
            if (designation == "Team Lead")
                return 3;
            if (designation == "Project Lead")
                return 4;
            else
                return -1;
        }

        protected void GetSearchByList()
        {
            ddlSearchBy.Items.Add("ID");
            ddlSearchBy.Items.Add("Name");
            ddlSearchBy.Items.Add("Gender");
            ddlSearchBy.Items.Add("Department");
            ddlSearchBy.Items.Add("Designation");
            ddlSearchBy.Items.Add("Education");
        }

        protected void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            AddEmployee();
            SerializationDAL();
            ClearDetails();
        }

        protected void clrBtn_Click(object sender, EventArgs e)
        {
            ClearDetails();
        }

        protected void listAllBtn_Click(object sender, EventArgs e)
        {
            isListAll = true;
            isSearch = false;
            EmployeeListGridView.DataSource = employees;
            EmployeeListGridView.DataBind();
        }

        protected void updateEmployeeBtn_Click(Object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Employee updateEmployee = employees.Find(employee => employee.id == id);

            updateEmployee.name = txtName.Text;
            if(rdFemale.Checked)
            {
                updateEmployee.gender = rdFemale.Text;
            }
            else
            {
                updateEmployee.gender = rdMale.Text;
            }
            updateEmployee.department = ddlDepart.SelectedItem.Text;
            updateEmployee.designation = ddlDesig.SelectedItem.Text;
            string employeeEducation = string.Empty;
            if (cbGraduation.Checked)
            {
                employeeEducation += cbGraduation.Text;
            }
            if (cbPostGraduation.Checked)
            {
                if (employeeEducation == "")
                {
                    employeeEducation += cbPostGraduation.Text;
                }
                else
                {
                    employeeEducation += ",";
                    employeeEducation += cbPostGraduation.Text;
                }
            }
            if (cbPhd.Checked)
            {
                if (employeeEducation == "")
                {
                    employeeEducation += cbPhd.Text;
                }
                else
                {
                    employeeEducation += ",";
                    employeeEducation += cbPhd.Text;
                }
            }
            updateEmployee.education = employeeEducation;
            isUpdate = false;
            EmployeeListGridView.DataSource = employees;
            EmployeeListGridView.DataBind();
            SerializationDAL();
            ClearDetails();
        }

        protected void AddEmployee()
        {
            int id;
            string name;
            string designation;
            string department;
            string gender;

            string employeeEducation = string.Empty;

            id = Convert.ToInt32(txtId.Text);
            name = txtName.Text;
            if(ddlDesig.SelectedItem.ToString() == "--- Select Designation ---")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select designation');", true);
                return;
            }
            else
            {
                designation = ddlDesig.SelectedItem.ToString();
            }
            if (ddlDepart.SelectedItem.ToString() == "--- Select Department ---")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select department');", true);
                return;
            }
            else
            {
                department = ddlDepart.SelectedItem.ToString();
            }
            if (rdMale.Checked)
            {
                gender = rdMale.Text;
            }
            else
            {
                gender = rdFemale.Text;
            }
            if (cbGraduation.Checked)
            {
                employeeEducation += cbGraduation.Text;
            }
            if (cbPostGraduation.Checked)
            {
                if (employeeEducation == "")
                {
                    employeeEducation += cbPostGraduation.Text;
                }
                else
                {
                    employeeEducation += ",";
                    employeeEducation += cbPostGraduation.Text;
                }
            }
            if (cbPhd.Checked)
            {
                if (employeeEducation == "")
                {
                    employeeEducation += cbPhd.Text;
                }
                else
                {
                    employeeEducation += ",";
                    employeeEducation += cbPhd.Text;
                }
            }

            Employee objEmployee = new Employee
            {
                id = id,
                name = name,
                designation = designation,
                department = department,
                gender = gender,
                education = employeeEducation
            };
            employees.Add(objEmployee);
        }

        protected void ClearDetails()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            ddlDesig.SelectedIndex = 0;
            ddlDepart.SelectedIndex = 0;
            cbGraduation.Checked = false;
            cbPostGraduation.Checked = false;
            cbPhd.Checked = false;
            rdMale.Checked = false;
            rdFemale.Checked = false;
            isUpdate = false;
        }

        protected void DeleteEmployee(int id)
        {
            Employee deleteEmployee = employees.Find(employee => employee.id == id);
            employees.Remove(deleteEmployee);
            SerializationDAL();
            EmployeeListGridView.DataSource = employees;
            EmployeeListGridView.DataBind();
        }

        protected void EditEmployee(int id)
        {
            Employee updateEmployee = employees.Find(employee => employee.id == id);
            txtId.Text = updateEmployee.id.ToString();
            txtName.Text = updateEmployee.name;
            if(updateEmployee.gender == "Male")
            {
                rdMale.Checked = true;
                rdFemale.Checked = false;
            }
            else
            {
                rdMale.Checked = false;
                rdFemale.Checked = true;
            }
            ddlDepart.SelectedIndex = getDepartmentIndex(updateEmployee.department);
            ddlDesig.SelectedIndex = getDesignationIndex(updateEmployee.designation);
            string[] educations = updateEmployee.education.Split(',');
            foreach(string education in educations)
            {
                switch(education)
                {
                    case "Graduation":
                        cbGraduation.Checked = true;
                            break;
                    case "PostGraduation":
                        cbPostGraduation.Checked = true;
                        break;
                    case "Phd":
                        cbPhd.Checked = true;
                        break;
                }
            }
        }

        protected void SerializationDAL()
        {
            FileStream objFS = null;
            
            if (File.Exists("C:\\src\\EmployeeManagementSystemWebApplication\\Data\\EmployeeData.dat"))
            {
                objFS = new FileStream(@"C:\src\EmployeeManagementSystemWebApplication\Data\EmployeeData.dat",
                FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            }
            else
            {
                objFS = new FileStream(@"C:\src\EmployeeManagementSystemWebApplication\Data\EmployeeData.dat",
                FileMode.Create, FileAccess.Write, FileShare.Read);
            }
            BinaryFormatter objBF = new BinaryFormatter();
            objBF.Serialize(objFS, employees);
            objFS.Close();
        }

        protected void DeserializationDAL()
        {
            FileStream objFS = null;
            if (File.Exists("C:\\src\\EmployeeManagementSystemWebApplication\\Data\\EmployeeData.dat"))
            {
                objFS = new FileStream(@"C:\src\EmployeeManagementSystemWebApplication\Data\EmployeeData.dat",
                FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter objBF = new BinaryFormatter();
                employees = objBF.Deserialize(objFS) as List<Employee>;
                objFS.Close();
            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            isSearch = true;
            isListAll = false;
            string searchBy = ddlSearchBy.Text;

            switch(searchBy)
            {
                case "ID":
                    int id = Convert.ToInt32(txtSearch.Text);
                    searchEmployees = employees.FindAll(employee => employee.id == id);
                    EmployeeListGridView.DataSource = searchEmployees;
                    EmployeeListGridView.DataBind();
                    break;
                case "Name":
                    string name = txtSearch.Text;
                    searchEmployees = employees.FindAll(employee => employee.name.ToLower() == name.ToLower());
                    EmployeeListGridView.DataSource = searchEmployees;
                    EmployeeListGridView.DataBind();
                    break;
                case "Gender":
                    string gender = txtSearch.Text;
                    searchEmployees = employees.FindAll(employee => employee.gender.ToLower() == gender.ToLower());
                    EmployeeListGridView.DataSource = searchEmployees;
                    EmployeeListGridView.DataBind();
                    break;
                case "Department":
                    string department = txtSearch.Text;
                    searchEmployees = employees.FindAll(employee => employee.department.ToLower() == department.ToLower());
                    EmployeeListGridView.DataSource = searchEmployees;
                    EmployeeListGridView.DataBind();
                    break;
                case "Designation":
                    string designation = txtSearch.Text;
                    searchEmployees = employees.FindAll(employee => employee.designation.ToLower() == designation.ToLower());
                    EmployeeListGridView.DataSource = searchEmployees;
                    EmployeeListGridView.DataBind();
                    break;
                case "Education":
                    string education = txtSearch.Text;
                    searchEmployees = employees.FindAll(employee => employee.education.ToLower().Contains(education.ToLower()));
                    EmployeeListGridView.DataSource = searchEmployees;
                    EmployeeListGridView.DataBind();
                    break;
            }
        }

        protected void EmployeeListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "EditRow")
            {
                isUpdate = true;
                int id = Convert.ToInt32(e.CommandArgument);
                EditEmployee(id);
            }
            else
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteEmployee(id);
            }
        }
    }
}