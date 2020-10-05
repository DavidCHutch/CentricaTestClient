using CentricaTestClient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestClient.Domain.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> GetAllDistricts();
    }
}
