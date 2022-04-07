using First.App.Business.DTOs;
using First.App.Domain.Entities;
using System.Collections.Generic;

namespace First.App.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAllCompany();
        void AddCompany(Company company);
        void UpdateCompany(CompanyUpdateDto company);
        void DeleteCompany(Company company);
    }
}
