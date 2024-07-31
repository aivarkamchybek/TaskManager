using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuoteID { get; set; }
        public string QuoteType { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Premium {  get; set; }
        public decimal Sales { get; set; }
    }
}
