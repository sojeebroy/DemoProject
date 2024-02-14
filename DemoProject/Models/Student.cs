using System.ComponentModel.DataAnnotations;

namespace DempProect.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Gender  { get; set; }
        public DateTime DOB { get; set; }
        public int ClassId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModificationDate { get; set; }
        public Class Class { get; set; }

    }
}
