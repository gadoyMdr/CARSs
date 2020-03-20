using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CARS.Models
{
    public class StepVehiculeType
    {
        [Key]
        public int Id { get; set; }




        /*Foreign keys*/

        [ForeignKey("VehiculeTypeId")]
        public VehiculeType VehiculeType { get; set; }
        [ForeignKey("VehiculeType")]
        public int VehiculeTypeId { get; set; }


        [ForeignKey("StepId")]
        public Step Step { get; set; }
        [ForeignKey("Step")]
        public int StepId { get; set; }


    }
}
