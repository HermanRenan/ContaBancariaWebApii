using LayerDataBase.Interface;
using LayerDataBase.Model;
using LayerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LayerService.Services
{
    public class BankAccountService : IBankAccountService
    {
        private IBankAccountRepository _bankRepository;

        public BankAccountService(IBankAccountRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public int Add(BankAccount obj)
        {
            try
            {
                _bankRepository.Add(obj);
                _bankRepository.SaveChanges();

                return obj.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                _bankRepository.DeleteById(id);
                _bankRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BankAccount> Get(Expression<Func<BankAccount, bool>> filter = null, string includeProperties = null)
        {
            try
            {
                return _bankRepository.Get(filter, includeProperties: includeProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BankAccount GetById(int id, string includeProperties = null)
        {
            try
            {
                return _bankRepository.GetFirst(c => c.Id == id, includeProperties: includeProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Update(BankAccount obj, int id)
        {
            try
            {
                var getObject = _bankRepository.GetFirst(x => x.Id == id);
                if(getObject != null)
                {
                    getObject.OpeningDate = obj.OpeningDate == getObject.OpeningDate ? getObject.OpeningDate : obj.OpeningDate;
                    getObject.AccountNumber = obj.AccountNumber == getObject.AccountNumber ? getObject.AccountNumber : obj.AccountNumber;
                    getObject.AgencyNumber = obj.AgencyNumber == getObject.AgencyNumber ? getObject.AgencyNumber : obj.AgencyNumber;
                    getObject.BankCode = obj.BankCode == getObject.BankCode ? getObject.BankCode : obj.BankCode;
                    getObject.ClientName = obj.ClientName == getObject.ClientName ? getObject.ClientName : obj.ClientName;
                    getObject.Cpf_Cnpj = obj.Cpf_Cnpj == getObject.Cpf_Cnpj ? getObject.Cpf_Cnpj : obj.Cpf_Cnpj;
                    getObject.Status = obj.Status == getObject.Status ? getObject.Status : obj.Status;
                }

                _bankRepository.Update(getObject);
                _bankRepository.SaveChanges();

                return "Account changed with success!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
