using System;
using Domain.Command.CAT;
using Domain.Command.Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Commands
{
    [TestClass]
    public class PersonCommandTests
    {
        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_createCATCommand_com_dados_invalidos()
        {
            var createCATCommand = new CreateCATCommand("1","222","11");            
            createCATCommand.Validate();            
            Assert.AreEqual(false, createCATCommand.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_createCutomerCAT_com_dados_invalidos()
        {
            var createCustomerCommand = new CreateCustomerCommand("1","222","11",Guid.NewGuid());  
            createCustomerCommand.Validate();
            Assert.AreEqual(false, createCustomerCommand.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_createCutomerCAT_com_id_CAT_invalido()
        {
            var createCustomerCommand = new CreateCustomerCommand("Empresa Teste", "Empresa Teste","30560346000105", Guid.Empty);
            createCustomerCommand.Validate();
            Assert.AreEqual(false, createCustomerCommand.IsValid);
        }
    }
}