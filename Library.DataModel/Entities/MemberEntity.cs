using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel.Entities
{
    [Table("Member")]
    public class MemberEntity
    {
        [Key]
        public int Number { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(40)]
        public string Adress { get; set; }
        [MaxLength(25)]
        public string  Status { get; set; }

        public virtual ICollection<LoanEntity> Loans { get; set; }
    }
}
