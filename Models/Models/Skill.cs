using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    class Skill
    {
        private int skillId;
        private string skillName;
        private string description;

        public Skill(string skillName, string description)
        {
            SkillName = skillName;
            Description = description;
        }

        public int SkillId { get => skillId; set => skillId = value; }
        public string SkillName { get => skillName; set => skillName = value; }
        public string Description { get => description; set => description = value; }
    }
}
