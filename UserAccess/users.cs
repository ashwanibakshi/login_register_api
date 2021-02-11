using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccess
{
   public class users
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Index("uname", IsUnique = true)]
        public string uname { get; set; }

        [Required]
        [StringLength(15)]
        public string password { get; set; }  

        public int roleid { get; set; }

        [ForeignKey("roleid")] 
        public roles roles { get; set; } 
    }
}
