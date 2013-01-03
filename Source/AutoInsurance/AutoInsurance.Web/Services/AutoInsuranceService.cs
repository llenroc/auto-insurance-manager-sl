
namespace AutoInsurance.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using AutoInsurance.Web;


    // Implements application logic using the AutoInsuaranceEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class AutoInsuranceService : LinqToEntitiesDomainService<AutoInsuaranceEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Agencies' query.
        public IQueryable<Agency> GetAgencies()
        {
            return this.ObjectContext.Agencies;
        }

        public void InsertAgency(Agency agency)
        {
            if ((agency.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agency, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Agencies.AddObject(agency);
            }
        }

        public void UpdateAgency(Agency currentAgency)
        {
            this.ObjectContext.Agencies.AttachAsModified(currentAgency, this.ChangeSet.GetOriginal(currentAgency));
        }

        public void DeleteAgency(Agency agency)
        {
            if ((agency.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agency, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Agencies.Attach(agency);
                this.ObjectContext.Agencies.DeleteObject(agency);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Autos' query.
        public IQueryable<Auto> GetAutos()
        {
            return this.ObjectContext.Autos;
        }

        public void InsertAuto(Auto auto)
        {
            if ((auto.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(auto, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Autos.AddObject(auto);
            }
        }

        public void UpdateAuto(Auto currentAuto)
        {
            this.ObjectContext.Autos.AttachAsModified(currentAuto, this.ChangeSet.GetOriginal(currentAuto));
        }

        public void DeleteAuto(Auto auto)
        {
            if ((auto.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(auto, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Autos.Attach(auto);
                this.ObjectContext.Autos.DeleteObject(auto);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AutoTypes' query.
        public IQueryable<AutoType> GetAutoTypes()
        {
            return this.ObjectContext.AutoTypes;
        }

        public void InsertAutoType(AutoType autoType)
        {
            if ((autoType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(autoType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AutoTypes.AddObject(autoType);
            }
        }

        public void UpdateAutoType(AutoType currentAutoType)
        {
            this.ObjectContext.AutoTypes.AttachAsModified(currentAutoType, this.ChangeSet.GetOriginal(currentAutoType));
        }

        public void DeleteAutoType(AutoType autoType)
        {
            if ((autoType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(autoType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AutoTypes.Attach(autoType);
                this.ObjectContext.AutoTypes.DeleteObject(autoType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Companies' query.
        public IQueryable<Company> GetCompanies()
        {
            return this.ObjectContext.Companies;
        }

        public void InsertCompany(Company company)
        {
            if ((company.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(company, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Companies.AddObject(company);
            }
        }

        public void UpdateCompany(Company currentCompany)
        {
            this.ObjectContext.Companies.AttachAsModified(currentCompany, this.ChangeSet.GetOriginal(currentCompany));
        }

        public void DeleteCompany(Company company)
        {
            if ((company.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(company, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Companies.Attach(company);
                this.ObjectContext.Companies.DeleteObject(company);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'FuelTypes' query.
        public IQueryable<FuelType> GetFuelTypes()
        {
            return this.ObjectContext.FuelTypes;
        }

        public void InsertFuelType(FuelType fuelType)
        {
            if ((fuelType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(fuelType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.FuelTypes.AddObject(fuelType);
            }
        }

        public void UpdateFuelType(FuelType currentFuelType)
        {
            this.ObjectContext.FuelTypes.AttachAsModified(currentFuelType, this.ChangeSet.GetOriginal(currentFuelType));
        }

        public void DeleteFuelType(FuelType fuelType)
        {
            if ((fuelType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(fuelType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.FuelTypes.Attach(fuelType);
                this.ObjectContext.FuelTypes.DeleteObject(fuelType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'InsurancePolicies' query.
        public IQueryable<InsurancePolicy> GetInsurancePolicies()
        {
            return this.ObjectContext.InsurancePolicies;
        }

        public void InsertInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            if ((insurancePolicy.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(insurancePolicy, EntityState.Added);
            }
            else
            {
                this.ObjectContext.InsurancePolicies.AddObject(insurancePolicy);
            }
        }

        public void UpdateInsurancePolicy(InsurancePolicy currentInsurancePolicy)
        {
            this.ObjectContext.InsurancePolicies.AttachAsModified(currentInsurancePolicy, this.ChangeSet.GetOriginal(currentInsurancePolicy));
        }

        public void DeleteInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            if ((insurancePolicy.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(insurancePolicy, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.InsurancePolicies.Attach(insurancePolicy);
                this.ObjectContext.InsurancePolicies.DeleteObject(insurancePolicy);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Persons' query.
        public IQueryable<Person> GetPersons()
        {
            return this.ObjectContext.Persons;
        }

        public void InsertPerson(Person person)
        {
            if ((person.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(person, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Persons.AddObject(person);
            }
        }

        public void UpdatePerson(Person currentPerson)
        {
            this.ObjectContext.Persons.AttachAsModified(currentPerson, this.ChangeSet.GetOriginal(currentPerson));
        }

        public void DeletePerson(Person person)
        {
            if ((person.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(person, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Persons.Attach(person);
                this.ObjectContext.Persons.DeleteObject(person);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Purposes' query.
        public IQueryable<Purpose> GetPurposes()
        {
            return this.ObjectContext.Purposes;
        }

        public void InsertPurpose(Purpose purpose)
        {
            if ((purpose.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(purpose, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Purposes.AddObject(purpose);
            }
        }

        public void UpdatePurpose(Purpose currentPurpose)
        {
            this.ObjectContext.Purposes.AttachAsModified(currentPurpose, this.ChangeSet.GetOriginal(currentPurpose));
        }

        public void DeletePurpose(Purpose purpose)
        {
            if ((purpose.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(purpose, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Purposes.Attach(purpose);
                this.ObjectContext.Purposes.DeleteObject(purpose);
            }
        }
    }
}


