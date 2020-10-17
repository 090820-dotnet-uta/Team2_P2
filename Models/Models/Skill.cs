using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
   public class Skill
    {
       
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set; }
    }
}
