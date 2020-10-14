using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models.Models
{
    class PositionNeedsSkill
    {
        private int positionNeedsSkillId;
        private int positionId;
        private int skillId;
        private Position thisPosition;
        private Skill thisSkill;

        public PositionNeedsSkill(int positionId, int skillId)
        {
            PositionId = positionId;
            SkillId = skillId;
        }

        public int PositionNeedsSkillId { get => positionNeedsSkillId; set => positionNeedsSkillId = value; }
        public int PositionId { get => positionId; set => positionId = value; }
        public int SkillId { get => skillId; set => skillId = value; }
        internal Position ThisPosition { get => thisPosition; set => thisPosition = value; }
        internal Skill ThisSkill { get => thisSkill; set => thisSkill = value; }
    }
}
