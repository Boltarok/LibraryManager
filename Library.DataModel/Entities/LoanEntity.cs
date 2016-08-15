using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library.DataModel.Entities
{
    [Table("Loan")]
    public class LoanEntity
    {
        [Key]
        public int Number { get; set; }
        [Required]
        public DateTime LoanDate { get; set; }
        [Required]
        public int MemberNumber { get; set; }
        [Required]
        public int BookCode { get; set; }

        [ForeignKey("BookCode")]
        public virtual BookEntity Book { get; set; }
        [ForeignKey("MemberNumber")]
        public virtual MemberEntity Member { get; set; }
    }
}
