namespace ManageEmployeesVacations.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<EmployeeVacation> EmployeeVacations { get; set; }
        public virtual List<VacationRequest> VacationRequests { get; set; }
        public Employee()
        {

            EmployeeVacations = new List<EmployeeVacation>();
            VacationRequests = new List<VacationRequest>();

        }




    }
}
