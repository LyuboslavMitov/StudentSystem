using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentSystem.DatabaseModels
{
    [Table("StudentClasses")]
   public class StudentClass
    {
        //Primerno
       
       public StudentClass()
       {
           this.Students = new List<Student>();
           this.Marks = new List<Mark>();
       }
        [Key]
       public int StudentClassID { get; set; }
        [Required]
       public string ClassName { get; set; }
       private ICollection<Student> students;
       public virtual ICollection<Student> Students { get { return this.students; } set { this.students = value; } }

        //Relation with Marks
       private ICollection<Mark> marks;

       public virtual ICollection<Mark> Marks
       {
           get { return this.marks; }
           set { this.marks = value; }
       }
    }
}
