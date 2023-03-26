using HS7_BP.Domain.Enums;

namespace HS7_BP.UI.Areas.Admin.ViewModels
{
    public class CategoryCreateVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status => Status.Active;
    }
}
