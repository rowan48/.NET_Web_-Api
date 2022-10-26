namespace ManageEmployeesVacations.Models
{
    public class Vacation
    {

        public int VacationId { get; set; }

        public string VacationName { get; set; }

        public double Balance { get; set; }
        public virtual List<EmployeeVacation> EmployeeVacations { get; set; }
        public Vacation()
        {
            EmployeeVacations = new List<EmployeeVacation>();
        }

    }
}
