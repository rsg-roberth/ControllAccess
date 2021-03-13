using System;
using Domain.Command.Access;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Commands
{
    [TestClass]
    public class AccessCommandTests
    {
        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_createAccessCommand_com_dados_invalidos()
        {
            var createAccessCommand = new CreateAccessCommand("1","1",Guid.NewGuid());            
            createAccessCommand.Validate();            
            Assert.AreEqual(false, createAccessCommand.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_createAccessCommand_idCustomer_invalido()
        {
            var createAccessCommand = new CreateAccessCommand("Acesso teste","Descrição do acesso teste",Guid.Empty);            
            createAccessCommand.Validate();            
            Assert.AreEqual(false, createAccessCommand.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_updateAccessCommand_com_dados_invalidos()
        {
            var updateAccessCommand = new UpdateAccessCommand(Guid.NewGuid(),"1","1",Guid.NewGuid());            
            updateAccessCommand.Validate();            
            Assert.AreEqual(false, updateAccessCommand.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_updateAccessCommand_idCustomer_invalido()
        {
            var updateAccessCommand = new UpdateAccessCommand(Guid.NewGuid(),"Acesso teste","Descrição do acesso teste",Guid.Empty);            
            updateAccessCommand.Validate();            
            Assert.AreEqual(false, updateAccessCommand.IsValid);
        }

        [TestMethod]
        public void Deve_retornar_falso_ao_criar_um_updateAccessCommand_id_invalido()
        {
            var updateAccessCommand = new UpdateAccessCommand(Guid.Empty,"Acesso teste","Descrição do acesso teste",Guid.Empty);            
            updateAccessCommand.Validate();            
            Assert.AreEqual(false, updateAccessCommand.IsValid);
        }
    }
}