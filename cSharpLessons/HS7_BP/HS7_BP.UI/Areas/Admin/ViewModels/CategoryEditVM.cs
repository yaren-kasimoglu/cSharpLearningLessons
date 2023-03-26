using HS7_BP.Domain.Enums;

namespace HS7_BP.UI.Areas.Admin.ViewModels
{
    public class CategoryEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
