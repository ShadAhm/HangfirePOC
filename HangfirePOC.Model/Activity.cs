using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Model
{
    public class Activity
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
