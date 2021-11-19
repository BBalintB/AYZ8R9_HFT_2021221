using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Models
{
    [Table("Statistics")]
    public class Statistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatId { get; set; }
        public int Touchdowns { get; set; }
        public int PassingYards { get; set; }
        public int ReceivingYards { get; set; }
        public int RushingYards { get; set; }
        [NotMapped]
        public virtual Player Player { get; set; }

        public override string ToString()
        {
            return $"{StatId}-{Touchdowns}-{PassingYards}-{ReceivingYards}-{RushingYards}";
        }
    }
}
