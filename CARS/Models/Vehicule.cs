using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CARS.Models
{
    public class Vehicule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        /*Foreign keys*/

        [ForeignKey("VehiculeTypeId")]
        public VehiculeType VehiculeType { get; set; }
        public int VehiculeTypeId { get; set; }
    }
}
