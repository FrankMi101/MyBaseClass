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
    public class EasyDataAccessAsyncAsyncTests
    {
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
            Task.Run(async () =>
            {
                sp = sp + " @Operate,@UserID,@IDs";
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para);


                var result = from s in list
                             where s.AppID == "SIC"
                             select s.AppName;
                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

            }).GetAwaiter().GetResult();

        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDefaultNoParameter_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm", IDs = "0" };

            //Act
            Task.Run(async () =>
            {
                // sp = sp + " @Operate,@UserID,@IDs";
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para);

                var result = from s in list
                             where s.AppID == "SIC"
                             select s.AppName;

                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");
            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_SP_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm" };


            Task.Run(async () =>
             {
                 //Act
                 var testAsync = new EasyDataAccessAsync<AppsList>();
                 var list = await testAsync.ListOfT(sp, para, "SP");

                 var result = from s in list
                              where s.AppID == "SIC"
                              select s.AppName;

                 //Assert
                 Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

             }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_Text_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";

            Task.Run(async () =>
            {
              var para = new { Operate = "List", UserID = "asm"};
              //Act
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para,"Text");

                var result = from s in list
                             where s.AppID == "SIC"
                             select s.AppName;

                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_TextandParameter_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm", IDs = "0" };
            Task.Run(async () =>
           {
               //Act
               sp = sp + " @Operate,@UserID,@IDs";
               var testAsync = new EasyDataAccessAsync<AppsList>();
               var list = await testAsync.ListOfT(sp, para, "Text");

               var result = from s in list
                            where s.AppID == "SIC"
                            select s.AppName;

               //Assert
               Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

           }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withDapperCommandType_SPandParameter_ReturnAllAppList_Test()
        {
            //Arrange
            string expect = "School Information Center";
            var para = new { Operate = "List", UserID = "asm", IDs = "0" };
            Task.Run(async () =>
            {
                //Act
                 sp = sp + " @Operate,@UserID,@IDs";
                //*******************************************************************************
                // this work for Dapper ORM 
                // if include parameters in SP, always using Dapper CommandType=Text
                // using CommandType=Text, works both with parameters and without parameters in SP
                // using CommandType=SP, only works without parameter in SP
                // ********************************************************************************
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para, "SP");

                var result = from s in list
                             where s.AppID == "SIC"
                             select s.AppName;

                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ListOfT_GetAppsList_withSQLQueryNoPara_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { };
            string sp = "Select * from SIC_test_BaseClass_IntegrationTest";

            Task.Run(async () =>
            {
                //Act
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para);

                var result = from s in list
                             where s.AppID == "TPA"
                             select s.AppName;

                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

            }).GetAwaiter().GetResult();
        }


        [TestMethod()]
        public void ListOfT_GetAppByID_withDefault_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { Operate = "GetbyID", UserID = "asm", IDs = "6" };

            Task.Run(async () =>
            {
                //Act
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para);

                var result = from s in list
                             where s.AppID == "TPA"
                             select s.AppName;

                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");


            }).GetAwaiter().GetResult();
        }
        [TestMethod()]
        public void ListOfT_GetAppByID_withDapperCommandType_SP_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { Operate = "GetbyID", UserID = "asm", IDs = "6" };

            Task.Run(async () =>
           {
               //Act
               var testAsync = new EasyDataAccessAsync<AppsList>();
               var list = await testAsync.ListOfT(sp, para, "SP");

               var result = from s in list
                            where s.AppID == "TPA"
                            select s.AppName;

               //Assert
               Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

           }).GetAwaiter().GetResult();
        }
        [TestMethod()]
        public void ListOfT_GetAppByID_withSQLQuery_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { IDs = "6" };
            string sp = "Select * from SIC_test_BaseClass_IntegrationTest where IDs = @IDs";
            Task.Run(async () =>
           {
               //Act
               var testAsync = new EasyDataAccessAsync<AppsList>();
               var list = await testAsync.ListOfT(sp, para);

               var result = from s in list
                            where s.AppID == "TPA"
                            select s.AppName;

               //Assert
               Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

           }).GetAwaiter().GetResult();
        }
        [TestMethod()]
        public void ListOfT_GetAppByID_withSQLQueryNoPara_ReturnAppNamebyID_Test()
        {
            //Arrange
            string expect = "Teacher Performance Appraisal";
            var para = new { };
            string sp = "Select * from SIC_test_BaseClass_IntegrationTest where IDs = 6";
            Task.Run(async () =>
            {
                //Act
                var testAsync = new EasyDataAccessAsync<AppsList>();
                var list = await testAsync.ListOfT(sp, para);

                var result = from s in list
                             where s.AppID == "TPA"
                             select s.AppName;

                //Assert
                Assert.AreEqual(expect, result.FirstOrDefault(), $" test {result.FirstOrDefault()} ");

            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ValueOfT_AddObj_AddNewAppwithDefault_ReturnSuccessuflly_Test()
        {
            //Arrange
            var expect = "Successfully";
            var para = GetAnonymous("Add", _para, "Add Default");

            Task.Run(async () =>
           {
               //Act    
               var testAsync = new EasyDataAccessAsync<string>();
               var result = await testAsync.ValueOfT(sp, para);

               //Assert
               Assert.AreEqual(expect, result.Substring(0, 12), $" Add New App role Permission {result} . ");
               _ids = int.Parse(result.Replace("Successfully", ""));

           }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ValueOfT_AddObj_AddNewAppwithDapperCommandType_SP_ReturnSuccessuflly_Test()
        {
            //Arrange
            var expect = "Successfully";
            var para = GetAnonymous("Add", _para, "Add with SP");

            Task.Run(async () =>
           {
               //Act    
               var testAsync = new EasyDataAccessAsync<string>();
               var result = await testAsync.ValueOfT(sp, para, "SP");

               //Assert
               Assert.AreEqual(expect, result.Substring(0, 12), $" Add New App role Permission {result} . ");
               _ids = int.Parse(result.Replace("Successfully", ""));

           }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ValueOfT_EditObj_EditAppwithDefault_ReturnSeccessfully_Test()
        {
            //Arrange
            PerpareForTest("Edit");
            var expect = "Successfully";
            var para = GetAnonymous("Edit", _para, "Edit");
            Task.Run(async () =>
           {
               //Act 
               var testAsync = new EasyDataAccessAsync<string>();
               var result = await testAsync.ValueOfT(sp, para);

               //Assert
               Assert.AreEqual(expect, result, $" Edit New App role {result} . ");

           }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ValueOfT_EditObj_EditAppwithDapperCommandType_SP_ReturnSeccessfully_Test()
        {
            //Arrange
            PerpareForTest("Edit");
            var expect = "Successfully";
            var para = GetAnonymous("Edit", _para, "Edit with SP");

            Task.Run(async () =>
          {
              //Act 
              var testAsync = new EasyDataAccessAsync<string>();
              var result = await testAsync.ValueOfT(sp, para, "SP");

              //Assert
              Assert.AreEqual(expect, result, $" Edit New App role {result} . ");

          }).GetAwaiter().GetResult();
        }


        [TestMethod()]
        public void ValueOfT_DeleteObj_DeleteApps_ReturnSuccessfully_Test()
        {
            //Arrange
            PerpareForTest("Delete");
            var para = new { Operate = "Delete", UserID = "asm", IDs = _ids.ToString() };
            var expect = "Successfully";
            Task.Run(async () =>
            {

                //Act 
                var testAsync = new EasyDataAccessAsync<string>();
                var result = await testAsync.ValueOfT(sp, para);

                //Assert
                Assert.AreEqual(expect, result, $" Update App role  test {result} . ");

            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void ValueOfT_DeleteObj_DeleteAppsWithDapperCommandType_SP_ReturnSuccessfully_Test()
        {
            //Arrange
            PerpareForTest("Delete");
            var para = new { Operate = "Delete", UserID = "asm", IDs = _ids.ToString() };
            var expect = "Successfully";

            Task.Run(async () =>
           {
               //Act 
               var testAsync = new EasyDataAccessAsync<string>();
               var result = await testAsync.ValueOfT(sp, para, "SP");

               //Assert
               Assert.AreEqual(expect, result, $" Update App role  test {result} . ");

           }).GetAwaiter().GetResult();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                var para = new { Operate = "Delete", UserID = "asm", IDs = _ids.ToString() };
                var testAsync = new EasyDataAccessAsync<string>();
                var result = testAsync.ValueOfT(sp, para);
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
                Task.Run(async () =>
                {
                    _ids = 0;
                    var para = GetAnonymous("Add", _para, action);
                    var testAsync = new EasyDataAccessAsync<string>();
                    var result = await testAsync.ValueOfT(sp, para);

                    _ids = int.Parse(result.Replace("Successfully", ""));
                }).GetAwaiter().GetResult();

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
                Operate,
                paraObj.UserID,
                IDs = _ids,
                paraObj.AppID,
                paraObj.AppName,
                paraObj.Owners,
                paraObj.Developer,
                paraObj.ActiveFlag,
                paraObj.StartDate,
                Comments = paraObj.Comments + " Test action : " + Operate + " Perpare action: " + perAction
            };
            return parameter;

        }
    }
}