using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper.Tests
{
    [TestClass()]
    public class DBConnectionHelperTests
    {
        private string sp = "[dbo].[SIC_test_BaseClass_Integation_Apps]";

        [TestMethod()]
        public void GetDefault_CurrentDB_ConnectionSTR_Return_currentDBValue_Test()
        {
            // Arrange
            string expect = "Data Source=TRLM_Companion;Initial Catalog=trilliumcompanion;User ID=transport;PWD=transport;Application Name=SIC";
            //Action
            var result = DBConnectionHelper.ConnectionSTR();

            //Assert
              Assert.AreEqual(expect, result, $" test {result }") ;
 
        }

        [TestMethod()]
        public void Get_ProductionofCurrentDBValue_ConnectionSTR_Return_currentDBValue_Test()
        {
            // Arrange
            string expect = "Data Source=TRLM_Companion;Initial Catalog=trilliumcompanion;User ID=transport;PWD=transport;Application Name=SIC";
            //Action
            var result = DBConnectionHelper.ConnectionSTR("Production");

            //Assert
            Assert.AreEqual(expect, result, $" test {result }");

        }

        [TestMethod()]
        public void Get_TestofCurrentDBValue_ConnectionSTR_Return_currentDBValue_Test()
        {
            // Arrange
            string expect = "Data Source=tcDevDB01\\TRLM;Initial Catalog=trilliumcompanion;User ID=transport;PWD=transport;Application Name=SIC";
            //Action
            var result = DBConnectionHelper.ConnectionSTR("Test");

            //Assert
            Assert.AreEqual(expect, result, $" test {result }");

        }

        [TestMethod()]
        public void GetDefault_CurrentDB_EncryptedConnectionSTR_Return_currentDBValue_Test()
        {
            // Arrange
            string expect = "Data Source=TRLM_Companion;Initial Catalog=trilliumcompanion;User ID=transport;PWD=transport;Application Name=SIC";
            //Action
            var result = DBConnectionHelper.ConnectionSTR();

            //Assert
            Assert.AreEqual(expect, result, $" test {result }");

        }

        [TestMethod()]
        public void Get_ProductionofCurrentDBValue_EncryptedConnectionSTR_Return_currentDBValue_Test()
        {
            // Arrange
            string expect = "Data Source=TRLM_Companion;Initial Catalog=trilliumcompanion;User ID=transport;PWD=transport;Application Name=SIC";
            //Action
            var result = DBConnectionHelper.ConnectionSTR("Production");

            //Assert
            Assert.AreEqual(expect, result, $" test {result }");

        }

        [TestMethod()]
        public void Get_TestofCurrentDBValue_EncryptedConnectionSTR_Return_currentDBValue_Test()
        {
            // Arrange
            string expect = "Data Source=tcDevDB01\\TRLM;Initial Catalog=trilliumcompanion;User ID=transport;PWD=transport;Application Name=SIC";
            //Action
            var result = DBConnectionHelper.ConnectionSTR("Test");

            //Assert
            Assert.AreEqual(expect, result, $" test {result }");

        }

        [TestMethod()]
        public void CheckSPandParametersbyCommandType_SP_ReturnSPonly_Test()
        {
            //Arrange
            var para = new { Operate = "List", UserID = "asm", IDs = "0", AppID = "IEP", AppName = "Individual Education Plan" };
            string expect = sp;
            //Act
            var result = EasyDataAccess<string>.CheckSPandParametersbyCommandType(sp, para, "SP");

            //Assert
            Assert.AreEqual(expect, result, $" test {result} ");

        }

        [TestMethod()]
        public void CheckSPandParametersbyCommandType_Text_ReturnSPPlusParameters_Test()
        {
            //Arrange
            var para = new { Operate = "List", UserID = "asm", IDs = "0", AppID = "IEP", AppName = "Individual Education Plan" };
            string expect = sp + " @Operate,@UserID,@IDs,@AppID,@AppName";
            //Act
            var result = EasyDataAccess<string>.CheckSPandParametersbyCommandType(sp, para, "Text");

            //Assert
            Assert.AreEqual(expect, result, $" test {result} ");

        }


        [TestMethod()]
        public void CheckSPandParametersbyCommandType_Text_ReturnOrginalSP_Test()
        {
            //Arrange
            var _sp = sp + " @Operate,@UserID,@IDs";
            var para = new { Operate = "List", UserID = "asm", IDs = "0", AppID = "IEP", AppName = "Individual Education Plan" };
            string expect = _sp;
            //Act
            var result = EasyDataAccess<string>.CheckSPandParametersbyCommandType(_sp, para, "Text");

            //Assert
            Assert.AreEqual(expect, result, $" test {result} ");

        }


    }
}