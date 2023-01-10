using BlogProject.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Entities.Entities
{
    public class Comment : CoreEntity
    {
        public string CommendText { get; set; }

        [ForeignKey("Kullanici")]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Gonderi")]
        public Guid PostID { get; set; }
        public virtual Post Gonderi { get; set; }
    }
}
