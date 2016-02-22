using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
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
        [Key]
        public int MarkID { get; set; }
          [ForeignKey("StudentClass")]
        public int StudentClassID { get; set; }
        [Required]
            public virtual StudentClass StudentClass { get; set; }

       [ ForeignKey("Student")]
        public int StudentID { get; set; }
        [Required]
        public virtual Student Student { get; set; }

       [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }

        
        [Required]
        [Range(2,6)]
        public int Grade { get; set; }

        public DateTime Created { get; set; }

       [Required]
       public virtual ApplicationUser Teacher { get; set; }

        public SubjectType SubjectType { get; set; }
        public Term Term { get; set; }
        public Mark()
        {
            this.Created = DateTime.Now;
        }
    }
}
