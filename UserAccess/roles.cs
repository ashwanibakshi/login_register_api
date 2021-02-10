using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccess
{
    public class roles
    {
		[Key]
        public int id { get; set; }

        [Required]
		[StringLength(50)]
		[Index("role",IsUnique =true)]
        public string role { get; set; }
        public ICollection<users> users { get; set; }
    }
}
