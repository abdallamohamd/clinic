using System.ComponentModel.DataAnnotations;

namespace emp_system.view_model
{
    public class logvm
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public bool Remmber { get; set; }
    }
}
