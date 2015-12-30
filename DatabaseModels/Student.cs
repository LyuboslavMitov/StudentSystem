namespace StudentSystem.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string EGN { get; set; }
        public Student()
        {
            this.Marks = new List<Mark>();
        }
        //Relations
        [Key, ForeignKey("StudentClass")]
        public int StudentClassID { get; set; }
        public virtual StudentClass StudentClass { get; set; }
        private ICollection<Mark> marks;

        public ICollection<Mark> Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        
    }
}
