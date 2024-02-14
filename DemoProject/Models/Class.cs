using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DempProect.Models
{
    public class Class
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModificationDate { get; set; }


        public ICollection<Student> Students { get; set; }
    }
}
