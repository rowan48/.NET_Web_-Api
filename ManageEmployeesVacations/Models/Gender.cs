namespace Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderType { get; set; }


        public virtual List<Employee> Employees { get; set; }
        public Gender()
        {
            Employees = new List<Employee>();
        }
    }
}
