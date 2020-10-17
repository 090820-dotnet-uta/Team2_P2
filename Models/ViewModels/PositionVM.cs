using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models.Models
{
   public class PositionVM
    {
        
       
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        public string ContractorId { get; set; }
        public string PositionTitle { get; set; }
        public string Description { get; set; }
        public Project ThisProject { get; set; }
        public Contractor ThisContractor { get; set; }
        public List<Skill> SkillsNeeded { get; set; }
    }
}
