using CarRental.Business.Entities;
using System;
using System.Collections.Generic;

namespace CarRental.Data.Repositories
{
    public class AccountRepository : DataRepositoryBase<Account>
    {
        protected override Account AddEntity(CarRentalContext entityContext, Account entity)
        {
            entityContext.AccountSet.Add(entity);
            return entity;

        }

        protected override IEnumerable<Account> GetEntities(CarRentalContext entityContext)
        {
            return entityContext.AccountSet;
        }

        protected override Account GetEntity(CarRentalContext entityContext, int id)
        {
            return entityContext.AccountSet.Find(id);
        }

        protected override Account UpdateEntity(CarRentalContext entityContext, Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
