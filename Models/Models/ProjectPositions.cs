using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
  public class ProjectPositions
    {


        public int ProjectPositionsId { get; set; }
        public int ProjectId { get; set; }
        
        public int PositionId { get; set; }

        public string ContractorId { get; set; }



    }
}
