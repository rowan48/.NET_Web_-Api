namespace Models
{
    public class VacationDTO
    {
        public int VacationId { get; set; }

        public string VacationName { get; set; }

        public double Balance { get; set; }
        //public virtual List<EmployeeVacation> EmployeeVacations { get; set; }
        public VacationDTO()
        {
            // EmployeeVacations = new List<EmployeeVacation>();
        }
    }
}
