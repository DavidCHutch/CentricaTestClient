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
        Task<IEnumerable<Salesman>> GetAllSalesmenInDistrict(string id);
        Task<IEnumerable<Store>> GetAllStoresInDistrict(string id);
        Task<IEnumerable<Salesman>> GetAllSalesmenOutsideDistrict(string id);
        Task<bool> AddSalesmanToDistrict(string id, Salesman salesman);
        Task<bool> RemoveSalesmanFromDistrict(string id, Salesman salesman);
        Task<bool> PromotePrimarySalesmanInDistrict(string id, Salesman salesmanPromote);
    }
}
