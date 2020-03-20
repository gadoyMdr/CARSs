using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CARS.Models
{
    [Table("Steps")]
    public class Step
    {
        [Key]
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public string Name { get; set; }

        public string Observations { get; set; }

        public List<StepVehiculeType> StepVehiculeTypes { get; set; }


        /*Foreign Keys*/
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
