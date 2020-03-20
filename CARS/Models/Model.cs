using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CARS.Models
{
    [Table("CarModel")]
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        /*Foreign Keys*/

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}
