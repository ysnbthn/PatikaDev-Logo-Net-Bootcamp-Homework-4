using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First.App.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
          this.repository = repository;
          this.unitOfWork = unitOfWork;
        }

        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }

        public void DeleteCompany(Company company)
        {
            
            repository.Delete(company);
            unitOfWork.Commit();
        }

        public void UpdateCompany(CompanyUpdateDto company)
        {
            // find company
            var comp = unitOfWork.Context.Find<Company>(company.Id);

            // check each value if it is not default
            if(comp != null)
            {
                // this is why we need automapper
                comp.Name = company.Name != "string" ? company.Name : comp.Name;
                comp.Description = company.Description != "string" ? company.Description : comp.Description;
                comp.Address = company.Address != "string" ? company.Address : comp.Address;
                comp.City = company.City != "string" ? company.City : comp.City;
                comp.Country = company.Country != "string" ? company.Country : comp.Country;
                comp.Location = company.Location != "string" ? company.Location : comp.Location;
                comp.Phone = company.Phone != "string" ? company.Phone : comp.Phone;
                comp.LastUpdatedBy = DateTime.Now.ToString();
                comp.LastUpdatedBy = "Batuhan";
            }

            repository.Update(comp);
            unitOfWork.Commit();
        }

        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList();
        }
    }
}
