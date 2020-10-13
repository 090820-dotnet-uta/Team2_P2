using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models.Models
{
    class Position
    {
        private int positionId;
        private int projectId;
        private string contractorId;
        private string positionTitle;
        private string description;
        private Project thisProject;

        public Position(int projectId, string contractorId, string positionTitle, string description)
        {
            ProjectId = projectId;
            ContractorId = contractorId;
            PositionTitle = positionTitle;
            Description = description;
        }

        public int PositionId { get => positionId; set => positionId = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public string ContractorId { get => contractorId; set => contractorId = value; }
        public string PositionTitle { get => positionTitle; set => positionTitle = value; }
        public string Description { get => description; set => description = value; }
        internal Project ThisProject { get => thisProject; set => thisProject = value; }
    }
}
