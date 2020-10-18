using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
  public class ProjectPositions
    {


        public int ProjectPositionsId { get; set; }
        public Project Project { get; set; }
        
        public Position Position { get; set; }

        public Contractor Contractor { get; set; }



    }
}
