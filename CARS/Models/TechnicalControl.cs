using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CARS.Models
{
    public class TechnicalControl
    {
        [Key]
        public int Id { get; set; }
        public List<Step> Steps{ get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        /*Foreign Keys*/

        [ForeignKey("IdVehicule")]
        public Vehicule Vehicule { get; set; }
        public int IdVehicule { get; set; }
    }
}
