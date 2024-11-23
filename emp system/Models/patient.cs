using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace emp_system.Models
{
    public class patient
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public int age  { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public DateTime ex_date { get; set; }
        public string diagnosis {  get; set; }
       
    }
}
