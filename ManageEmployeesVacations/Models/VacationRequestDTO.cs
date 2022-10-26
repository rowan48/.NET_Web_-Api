namespace Models
{
    public class VacationRequestDTO
    {
        public int VacationRequestId { get; set; }

        public int EmployeeID { get; set; }
        public int VacationID { get; set; }
        public double VacationDuration { get; set; }


        public DateTime StartVacationDate { get; set; }


        public DateTime EndVacationDate { get; set; }
    }
}
