using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Application.Services.Interface
{
    public interface ITalukService
    {
        IEnumerable<Taluk> GetAllTaluks();
        Taluk GetTalukById(int id);
        void CreateTaluk(Taluk taluk);
        void UpdateTaluk(Taluk taluk);
        bool DeleteTaluk(int id);
    }
}
