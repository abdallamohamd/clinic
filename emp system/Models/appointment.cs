//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emp_system.Models
{
    public class appointment
    {
        public int Id {  get; set; }
        [Required]
        public string Patientname { get; set; }
        [Required]
        public string address {  get; set; }
        [Required]
       
        [Range(10,11)]
        public string phone { get; set; }
        [Required]
        public int age {  get; set; }
        [Required]
        public DateTime appointmentdate { get; set; }

        [ForeignKey("specialtyid")]
        public int specialtyid { get; set; }
        public specialty? specialtys { get; set; }

       

    }
}
