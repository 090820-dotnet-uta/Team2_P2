using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    class ContractorHasSkill
    {
        private int contractorHasSkillId;
        private int contractorId;
        private int skillId;
        private Contractor thisContractor;
        private Skill thisSkill;

        public ContractorHasSkill(int contractorId, int skillId)
        {
            ContractorId = contractorId;
            SkillId = skillId;
        }

        public int ContractorHasSkillId { get => contractorHasSkillId; set => contractorHasSkillId = value; }
        public int ContractorId { get => contractorId; set => contractorId = value; }
        public int SkillId { get => skillId; set => skillId = value; }
        internal Contractor ThisContractor { get => thisContractor; set => thisContractor = value; }
        internal Skill ThisSkill { get => thisSkill; set => thisSkill = value; }
    }
}
