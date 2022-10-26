namespace Models
{

    public class EmployeeDataVcationsDTO
    {
        public int EmployeeId { get; set; }
        public int VacationID { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public int? GenderId { get; set; }

        public DateTime? BirthDate { get; set; }
        public double EmployeeBalance { get; set; } = 0;
        //public double EmployeeUsedVacation { get; set; } = 0;

        // public List<EmployeeVacationDTO> EmployeeVacations { get; set; }


        public EmployeeDataVcationsDTO()
        {
            // EmployeeVacations = new List<EmployeeVacationDTO>();
        }

    }
}
