
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentSystem.DatabaseModels
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectID{ get; set; }
        [Required]
        public string SubjectName { get; set; }

        public Subject()
        {
            this.Marks = new List<Mark>();
        }
        private ICollection<Mark> marks;

        public virtual ICollection<Mark> Marks
        {
            get { return marks; }
            set { marks = value; }
        }
    }
}
