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
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FamilyMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateFamilyMember(FamilyMember FamilyMember)
        {
            _unitOfWork.FamilyMember.Add(FamilyMember);
            _unitOfWork.Save();
        }

        public bool DeleteFamilyMember(int id)
        {
            try
            {
                FamilyMember? objFromDb = _unitOfWork.FamilyMember.Get(u => u.FamilyMemberId == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.FamilyMember.Remove(objFromDb);
                    _unitOfWork.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<FamilyMember> GetAllFamilyMembers()
        {
            return _unitOfWork.FamilyMember.GetAll();
        }

        public FamilyMember GetFamilyMemberById(int id)
        {
            return _unitOfWork.FamilyMember.Get(u => u.FamilyMemberId == id);
        }

        public void UpdateFamilyMember(FamilyMember FamilyMember)
        {
            _unitOfWork.FamilyMember.Update(FamilyMember);
            _unitOfWork.Save();
        }
    }
}
