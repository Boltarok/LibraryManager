using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel.Entities
{
    [Table("Book")]
    public class BookEntity
    {
        [Key]
        public int Code { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public int AmmountAvailable { get; set; }
        public string Status { get; set; }

        public virtual ICollection<LoanEntity> Loans { get; set; }
    }
}
