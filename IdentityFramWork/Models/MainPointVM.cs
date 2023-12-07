using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityFramWork.Models
{
    public class MainPointVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string licencePlate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public int PartsId { get; set; }
        public int ServiceId { get; set; }


    
        public virtual Parts? Parts { get; set; }

     
        public virtual Service? Service { get; set; }

    }
}
