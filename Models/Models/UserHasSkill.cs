using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class UserHasSkill
    {
   
        private int skillId;

        private string loginInfoId;
        private LoginInfo thisLoginInfo;
        private Skill thisSkill;

        public UserHasSkill(string loginInfoId, int skillId)
        {
            LoginInfoId = loginInfoId;
            SkillId = skillId;
        }

        public int UserHasSkillId { get => UserHasSkillId; set => UserHasSkillId = value; }
        public string LoginInfoId { get => loginInfoId; set => loginInfoId = value; }
        public int SkillId { get => skillId; set => skillId = value; }
        internal LoginInfo ThisLoginInfo { get => thisLoginInfo; set => thisLoginInfo = value; } 
        internal Skill ThisSkill { get => thisSkill; set => thisSkill = value; }
    }
}
