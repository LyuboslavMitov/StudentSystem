using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentSystem.DatabaseModels
{
    public enum SubjectType
    {
        Standart=0,
        Mendatory=1,
        Optional=2
    }
    public enum Term
    {
        First=0,
        Second=1
    }
        
    [Table ("Marks")]
        public class Mark
    {
            [Key, ForeignKey("StudentClass")]
        public int StudentClassID { get; set; }
            public virtual StudentClass StudentClass { get; set; }

        [Key, ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [Key, ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        
        [Required]
        [Range(2,6)]
        public int Grade { get; set; }

        [Key]
        public int TeacherID { get; set; }
        public virtual ApplicationUser Teacher { get; set; }

        public SubjectType SubjectType { get; set; }
        public Term Term { get; set; }
    }
}
