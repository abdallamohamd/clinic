using Microsoft.AspNetCore.Mvc;

namespace emp_system.Models
{
    public class specialty
    {
        public int specialtyid { get; set; }
        [Remote(action:"uniqe",controller:"speecialty",ErrorMessage ="this name is used")]
        public string Name { get; set; }
        public ICollection<doctor>? doctors { get; set; }
        public ICollection<appointment>? appointments { get; set; }
    }
}
