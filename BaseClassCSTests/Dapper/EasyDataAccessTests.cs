using DomainClass;
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
    public class EasyDataAccessTests
    {
        //*******************************************************************************
        // this work for Dapper ORM 
        // the parameter pass to SP must be an Anonymous object,
        // if pass a domain class object as a parameter,you must include special parameters in SP
        // or the domain class defination must as same as your SP parameters in Name and Order.
        //
        // if include parameters in SP, always using Dapper CommandType=Text
        // using CommandType=Text, works both with parameters and without parameters in SP
        // using CommandType=SP, only works without parameter in SP
        // ********************************************************************************


        private int _ids = 0;
        private Apps _para = new Apps();
        private string sp = "[dbo].[SIC_test_BaseClass_Integation_Apps]";

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            _para.Operate = "Get";
            _para.UserID = "tester";
            _para.IDs = "0";
            _para.AppID = "IEP-2";
            _para.AppName = "Individual Education Plan 2";
            _para.Owners = "IEP Committee";
            _para.Developer = "Frank Mi";
            _para.ActiveFlag = "x";
            _para.StartDate = "2021-09-01";
            _para.Comments = "Base Class Unit Test add new Appstest ";

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDefault_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm", IDs = "0" };

            //Act
             sp = sp + " @Operate,@UserID,@IDs";
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para);

            var result = from s in list
                         where s.AppID == "SIC"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDefaultNoParameter_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm", IDs = "0" };

            //Act
           // sp = sp + " @Operate,@UserID,@IDs";
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para);

            var result = from s in list
                         where s.AppID == "SIC"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_SP_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm" };

            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para, "SP");

            var result = from s in list
                         where s.AppID == "SIC"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_Text_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm" };

            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para, "Text");

            var result = from s in list
                         where s.AppID == "SIC"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_TextandParameter_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
             var para = new { Operate = "List", UserID = "asm", IDs = "0" };
            //Act
            sp = sp + " @Operate,@UserID,@IDs";
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para, "Text");

            var result = from s in list
                         where s.AppID == "SIC"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_SPandParameter_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm", IDs = "0" };
            //Act
            sp = sp + " @Operate,@UserID,@IDs";  
            //*******************************************************************************
            // this work for Dapper ORM 
            // the parameter pass to SP must be an Anonymous object,
            // if pass a domain class object as a parameter,you must include special parameters in SP
            // or the domain class defination must as same as your SP parameters in Name and Order.
            //
            // if include parameters in SP, always using Dapper CommandType=Text
            // using CommandType=Text, works both with parameters and without parameters in SP
            // using CommandType=SP, only works without parameter in SP
            // ********************************************************************************
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para, "SP");

            var result = from s in list
                         where s.AppID == "SIC"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withSQLQueryNoPara_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { };
            string sp = "Select * from SIC_test_BaseClass_IntegrationTest";
            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para);

            var result = from s in list
                         where s.AppID == "TPA"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
        }


        [TestMethod()]
        public void ListOfT_GetAppByID_withDefault_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { Operate = "GetbyID", UserID = "asm", IDs = "6" };

            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para);

            var result = from s in list
                         where s.AppID == "TPA"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
        }
        [TestMethod()]
        public void ListOfT_GetAppByID_withDapperCommandType_SP_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { Operate = "GetbyID", UserID = "asm", IDs = "6" };

            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para, "SP");

            var result = from s in list
                         where s.AppID == "TPA"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
        }
        [TestMethod()]
        public void ListOfT_GetAppByID_withSQLQuery_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { IDs = "6" };
            string sp = "Select * from SIC_test_BaseClass_IntegrationTest where IDs = @IDs";
            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para);

            var result = from s in list
                         where s.AppID == "TPA"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
        }
        [TestMethod()]
        public void ListOfT_GetAppByID_withSQLQueryNoPara_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { };
            string sp = "Select * from SIC_test_BaseClass_IntegrationTest where IDs = 6";
            //Act
            var list = EasyDataAccess<AppsList>.ListOfT(sp, para);

            var result = from s in list
                         where s.AppID == "TPA"
                         select s.AppName;

            //Assert
            Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
        }

        [TestMethod()]
        public void ValueOfT_AddObj_AddNewAppwithDefault_ReturnSuccessuflly_Test()
        {
            //Arrange
            var expect = "Successfully";
            var para = GetAnonymous("Add", _para,"Add Default");

            //Act    
            var result = EasyDataAccess<string>.ValueOfT(sp, para);

            //Assert
            Assert.AreEqual(expect, result.Substring(0, 12), $" Add New App role Permission {result} . ");
            _ids = int.Parse(result.Replace("Successfully", ""));

        }

        [TestMethod()]
        public void ValueOfT_AddObj_AddNewAppwithDapperCommandType_SP_ReturnSuccessuflly_Test()
        {
            //Arrange
            var expect = "Successfully";
            var para = GetAnonymous("Add",_para,"Add with SP");
    
            //Act    
            var result = EasyDataAccess<string>.ValueOfT(sp, para, "SP");

            //Assert
            Assert.AreEqual(expect, result.Substring(0, 12), $" Add New App role Permission {result} . ");
            _ids = int.Parse(result.Replace("Successfully", ""));

        }

        [TestMethod()]
        public void ValueOfT_EditObj_EditAppwithDefault_ReturnSeccessfully_Test()
        {
            //Arrange
            PerpareForTest("Edit"); 
            var expect = "Successfully";
            var para = GetAnonymous("Edit", _para,"Edit");
            //Act 
            var result = EasyDataAccess<string>.ValueOfT(sp, para);

            //Assert
            Assert.AreEqual(expect, result, $" Edit New App role {result} . ");
        }

        [TestMethod()]
        public void ValueOfT_EditObj_EditAppwithDapperCommandType_SP_ReturnSeccessfully_Test()
        {
            //Arrange
            PerpareForTest("Edit");
            var expect = "Successfully";
            var para = GetAnonymous("Edit", _para, "Edit with SP");

            //Act 
            var result = EasyDataAccess<string>.ValueOfT(sp, para, "SP");

            //Assert
            Assert.AreEqual(expect, result, $" Edit New App role {result} . ");
        }


        [TestMethod()]
        public void ValueOfT_DeleteObj_DeleteApps_ReturnSuccessfully_Test()
        {
            //Arrange
            PerpareForTest("Delete");
            var para = new { Operate = "Delete", UserID = "asm", IDs = _ids.ToString() };
            var expect = "Successfully";

            //Act 
            var result = EasyDataAccess<string>.ValueOfT(sp, para);

            //Assert
            Assert.AreEqual(expect, result, $" Update App role  test {result} . ");
        }

        [TestMethod()]
        public void ValueOfT_DeleteObj_DeleteAppsWithDapperCommandType_SP_ReturnSuccessfully_Test()
        {
            //Arrange
            PerpareForTest("Delete"); 
            var para = new { Operate = "Delete", UserID = "asm", IDs = _ids.ToString() };
            var expect = "Successfully";

            //Act 
            var result = EasyDataAccess<string>.ValueOfT(sp, para, "SP");

            //Assert
            Assert.AreEqual(expect, result, $" Update App role  test {result} . ");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                var para = new { Operate = "Delete", UserID = "asm", IDs = _ids.ToString() };
                var result = EasyDataAccess<string>.ValueOfT(sp, para);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void PerpareForTest(string action)
        {
            try
            {
                _ids = 0;
                 var para = GetAnonymous("Add", _para, action);
                var result = EasyDataAccess<string>.ValueOfT(sp, para).Replace("Successfully", "");
                _ids = int.Parse(result);
            }
            catch (Exception)
            {
                _ids = 0;
            }

        }
        private object GetAnonymous(string Operate, Apps paraObj, string perAction)
        {
            var parameter = new
            {
                Operate ,
                paraObj.UserID,
                IDs = _ids,
                paraObj.AppID,
                paraObj.AppName,
                paraObj.Owners,
                paraObj.Developer,
                paraObj.ActiveFlag,
                paraObj.StartDate,
                Comments =  paraObj.Comments  +  " Test action : " + Operate + " Perpare action: " + perAction
            };
            return parameter;

        }
    }
}