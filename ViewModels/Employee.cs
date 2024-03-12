namespace Employee_Skill_Management.ViewModels
{
    public class Employee
    {
        public int id { get; set; }
        public string emp_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public DateTime doj { get; set; }
        public string gender { get; set; }
        public string reporting_manager { get; set; }
        public string phone { get; set; }
        public string personal_email { get; set; }
        public string employee_email { get; set; }
        public string address { get; set; }
        public string blood_group { get; set; }
        public string job_title { get; set; }
        public string about_me { get; set; }
        public int role_id { get; set; }
    }
    public class LoggedInEmployeeData 
    {
        public Employee loggedUserData { get; set; }
        public List<EmployeeDataTableRecord> allEmployees { get; set; }
    }

}