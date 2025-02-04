using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Application.Common.Interfaces;
using Social.Application.Services.Interface;
using Social.Domain.Entities;

namespace Social.Application.Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateSkill(Skill Skill)
        {
            _unitOfWork.Skill.Add(Skill);
            _unitOfWork.Save();
        }

        public bool DeleteSkill(int id)
        {
            try
            {
                Skill? objFromDb = _unitOfWork.Skill.Get(u => u.SkillId == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.Skill.Remove(objFromDb);
                    _unitOfWork.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _unitOfWork.Skill.GetAll();
        }

        public Skill GetSkillById(int id)
        {
            return _unitOfWork.Skill.Get(u => u.SkillId == id);
        }

        public void UpdateSkill(Skill Skill)
        {
            _unitOfWork.Skill.Update(Skill);
            _unitOfWork.Save();
        }
    }
}
