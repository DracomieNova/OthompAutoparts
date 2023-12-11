using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityFramWork.Models
{
    public class MainPointVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int EmployeeId { get; set; }
        public string licencePlate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

       

    }
}
