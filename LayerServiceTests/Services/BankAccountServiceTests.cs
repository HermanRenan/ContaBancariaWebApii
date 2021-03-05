using Microsoft.VisualStudio.TestTools.UnitTesting;
using LayerService.Services;
using System;
using System.Collections.Generic;
using System.Text;
using LayerDataBase.Interface;
using LayerDataBase.Model;
using LayerDataBase.Repository;

namespace LayerService.Services.Tests
{
    [TestClass()]
    public class BankAccountServiceTests
    {
        //private IBankAccountRepository _bankRepository;

        //public BankAccountServiceTests(IBankAccountRepository bankRepository)
        //{
        //    _bankRepository = bankRepository;
        //}

        [TestMethod()]
        public void AddTest()
        {
            IBankAccountRepository repo = new BankAccountRepository();

            BankAccountService newServi = new BankAccountService(repo);

            var getNewData = new BankAccount()
            {
                AccountNumber = "1233-22",
                BankCode = 237,
                ClientName = "Jão Teste",
                Cpf_Cnpj = "105.369.147-10",
                AgencyNumber = "1458-8",
                OpeningDate = Convert.ToDateTime("02-02-2020"),
                Status = "ativo"
            };

            newServi.Add(getNewData);
            //_bankRepository.SaveChanges();

            if (getNewData.Id == 0)
                Assert.Fail("Não foi possivel inserir no banco de dados");
            else
                Assert.IsTrue(getNewData.Id != 0, "Inserido no banco!");
        }
    }
}