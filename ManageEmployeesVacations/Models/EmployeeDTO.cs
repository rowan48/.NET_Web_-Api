namespace Models
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string? Email { get; set; }

        public string FullName { get; set; }

        public int GenderId { get; set; }
        public string? GenderName { get; set; }

        public DateTime BirthDate { get; set; }

        //public List<EmployeeVacationDTO> EmployeeVacations { get; set; }
        public EmployeeDTO()
        {
            // EmployeeVacations = new List<EmployeeVacationDTO>();
        }
    }
}
