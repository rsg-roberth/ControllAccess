using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Entities
{
    [TestClass]
    public class PersonTests
    {
        private CAT _catWithLinkedCustomer;
        private CAT _catWithoutLinkedCustomer;
        private Customer _customerWithLinkedAccess;
        private Customer _customerWithoutLinkedAccess;
        private Access _access;

        public PersonTests()
        {            
            _catWithLinkedCustomer = new CAT("CAT teste com clientes vinculados LTDA", "CAT teste com clientes vinculados", "31933945000190");            
            _customerWithLinkedAccess = new Customer("Cliente teste com acessos vinculados LTDA", "Cliente teste com acessos vinculados", "26529560000121", _catWithLinkedCustomer.Id);
            _access = new Access("Acesso teste", "Descrição do acesso", _customerWithLinkedAccess.Id);            
            _customerWithLinkedAccess.AddAccess(_access);
            _catWithLinkedCustomer.AddCustomer(_customerWithLinkedAccess);            

            _catWithoutLinkedCustomer = new CAT("CAT teste sem clientes vinculados LTDA", "CAT teste sem clientes vinculados", "89017222000120");              
            _customerWithoutLinkedAccess = new Customer("Cliente teste sem acessos vinculados LTDA", "Cliente teste sem acessos vinculados", "26529560000121", Guid.NewGuid());
        }    


        [TestMethod]
        public void CAT_deve_ser_ativo_ao_ser_incluido()
        {            
            Assert.AreEqual(true, _catWithLinkedCustomer.Active);            
        }

        [TestMethod]
        public void Cliente_deve_ser_ativo_ao_ser_includdo()
        {            
            Assert.AreEqual(true, _customerWithLinkedAccess.Active);   
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_desativar_um_CAT_com_clientes_vinculados()
        {
            _catWithLinkedCustomer.MarkInactive();
            Assert.AreEqual(false, _catWithLinkedCustomer.IsValid); 
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_desativar_um_cliente_com_acessos_vinculados()
        {            
            _customerWithLinkedAccess.MarkInactive();
            Assert.AreEqual(false, _customerWithLinkedAccess.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_verdadeiro_ao_desativar_um_CAT_sem_clientes_vinculados()
        {
            _catWithoutLinkedCustomer.MarkInactive();
            Assert.AreEqual(true, _catWithLinkedCustomer.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_verdadeiro_ao_desativar_um_cliente_sem_acessos_vinculados()
        {
            _catWithoutLinkedCustomer.MarkInactive();
            Assert.AreEqual(true, _catWithoutLinkedCustomer.IsValid);
        }
    }
}
