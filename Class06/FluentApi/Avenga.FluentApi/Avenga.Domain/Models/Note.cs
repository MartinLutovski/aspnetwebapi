using Avenga.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.Domain.Models
{
    public class Note
    {
        
        public int Id { get; set; }
        
        public string Text { get; set; }
        
        public Priority Priority { get; set; }
        
        public Tag Tag { get; set; }
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}
