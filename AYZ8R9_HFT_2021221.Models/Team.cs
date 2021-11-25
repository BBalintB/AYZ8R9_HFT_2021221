using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string HeadCoach { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string Division { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }

        public Team()
        {
            Players = new HashSet<Player>();
        }

        public override string ToString()
        {
            return $"{TeamId}-{TeamName}-{HeadCoach}-{Stadium}-{City}-{Division}";
        }
    }
}
