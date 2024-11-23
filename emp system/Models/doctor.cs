
using System.ComponentModel.DataAnnotations.Schema;

namespace emp_system.Models
{
    public class doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }

        [ForeignKey("specialty")]
        public int sepcialtyid { get; set; }
        public specialty? specialty { get; set; }
    }
}
