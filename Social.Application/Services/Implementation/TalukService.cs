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
    public class TalukService : ITalukService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalukService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateTaluk(Taluk Taluk)
        {
            _unitOfWork.Taluk.Add(Taluk);
            _unitOfWork.Save();
        }

        public bool DeleteTaluk(int id)
        {
            try
            {
                Taluk? objFromDb = _unitOfWork.Taluk.Get(u => u.TalukId == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.Taluk.Remove(objFromDb);
                    _unitOfWork.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Taluk> GetAllTaluks()
        {
            return _unitOfWork.Taluk.GetAll();
        }

        public Taluk GetTalukById(int id)
        {
            return _unitOfWork.Taluk.Get(u => u.TalukId == id);
        }

        public void UpdateTaluk(Taluk taluk)
        {
            _unitOfWork.Taluk.Update(taluk);
            _unitOfWork.Save();
        }
    }
}
