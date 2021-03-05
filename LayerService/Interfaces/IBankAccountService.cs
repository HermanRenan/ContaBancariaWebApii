using LayerDataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LayerService.Interfaces
{
    public interface IBankAccountService
    {
        int Add(BankAccount obj);
        string Update(BankAccount obj, int id);
        void DeleteById(int id);
        IEnumerable<BankAccount> Get(Expression<Func<BankAccount, bool>> filter = null, string includeProperties = null);
        BankAccount GetById(int id, string includeProperties = null);
    }
}
