namespace Models
{
    public class EmployeeVacation
    {
        public int EmployeeID { get; set; }
        public int VacationID { get; set; }
        // public virtual Employee Employee { get; set; }
        public virtual Vacation Vacation { get; set; }
        public double EmployeeBalance { get; set; } = 0;
        public double EmployeeUsedVacation { get; set; } = 0;
    }
}
