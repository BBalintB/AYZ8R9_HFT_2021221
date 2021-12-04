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
    [Table("Players")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        [Required]
        public string PlayerName { get; set; }
        public int PlayerJerseyNumber { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        [NotMapped]
        public virtual Statistic Stat { get; set; }
        [ForeignKey(nameof(Stat))]
        public int StatID { get; set; }
        [NotMapped]
        public virtual Team Teams { get; set; }
        [ForeignKey(nameof(Teams))]
        public int TeamID { get; set; }

        public override string ToString()
        {
            return $"Player ID: {PlayerId} Name: {PlayerName}, Jersey number: {PlayerJerseyNumber},Position: {Position},Age: {Age},StatID: {StatID}, TeamID: {TeamID}";
        }
    }
}
