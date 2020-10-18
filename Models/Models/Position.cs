using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models.Models
{
    public class Position
    {
        private int positionId;
        private int projectId;
        private string contractorId;
        private string positionTitle;
        private string description;
        private Project thisProject;
        private Contractor thisContractor;

        public Position(string positionTitle, string description)
        {
         
            PositionTitle = positionTitle;
            Description = description;
        }

        public int PositionId { get => positionId; set => positionId = value; }
 
        public string PositionTitle { get => positionTitle; set => positionTitle = value; }
        public string Description { get => description; set => description = value; }

    }
}
