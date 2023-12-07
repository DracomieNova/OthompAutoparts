using System.ComponentModel.DataAnnotations;

namespace backendAPI.Model
{
    public class Parts
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string? Casinumber { get; set; }
        public string? VechiclePart { get; set; }

        public string VechiclePartName { get; set; }
    }
}

