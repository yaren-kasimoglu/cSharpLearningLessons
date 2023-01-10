namespace TagHelperWithHttpsConf.Models
{
    public class PersonalVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public DepartmentVM Department { get; set; }
        public int DepartmentId { get; set; }
    }
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
