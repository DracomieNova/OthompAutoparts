using System.ComponentModel.DataAnnotations;

namespace backendAPI.Model
{
    public class Serivce
    {
        [Key]
        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public string? EmployeeOn { get; set; }


        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }
    }
}

