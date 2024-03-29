// <copyright file="EasyDataAccessTTest.cs" company="TCDSB">Copyright © TCDSB 2009</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDapper;

namespace MyDapper.Tests
{
    /// <summary>This class contains parameterized unit tests for EasyDataAccess`1</summary>
    [PexClass(typeof(EasyDataAccess<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class EasyDataAccessTTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public EasyDataAccess<T> ConstructorTest<T>()
        {
            //Arrange
            string expect = "";
            //Action
            EasyDataAccess<T> target = new EasyDataAccess<T>();
            return target;
            // TODO: add assertions to method EasyDataAccessTTest.ConstructorTest()
        }

        /// <summary>Test stub for ListOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public List<T> ListOfTTest<T>(string sp, object parameter)
        {
            List<T> result = EasyDataAccess<T>.ListOfT(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ListOfTTest(String, Object)
        }

        /// <summary>Test stub for ListOfT(String, String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public List<T> ListOfTTest01<T>(
            string db,
            string sp,
            object parameter
        )
        {
            List<T> result = EasyDataAccess<T>.ListOfT(db, sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ListOfTTest01(String, String, Object)
        }

        /// <summary>Test stub for ListOfT(String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public List<T> ListOfTTest02<T>(
            string sp,
            object parameter,
            string type
        )
        {
            List<T> result = EasyDataAccess<T>.ListOfT(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ListOfTTest02(String, Object, String)
        }

        /// <summary>Test stub for ListOfT(String, String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public List<T> ListOfTTest03<T>(
            string db,
            string sp,
            object parameter,
            string type
        )
        {
            List<T> result = EasyDataAccess<T>.ListOfT(db, sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ListOfTTest03(String, String, Object, String)
        }

        /// <summary>Test stub for ValueOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T ValueOfTTest<T>(string sp, object parameter)
        {
            T result = EasyDataAccess<T>.ValueOfT(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ValueOfTTest(String, Object)
        }

        /// <summary>Test stub for ValueOfT(String, String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T ValueOfTTest01<T>(
            string db,
            string sp,
            object parameter
        )
        {
            T result = EasyDataAccess<T>.ValueOfT(db, sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ValueOfTTest01(String, String, Object)
        }

        /// <summary>Test stub for ValueOfT(String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T ValueOfTTest02<T>(
            string sp,
            object parameter,
            string type
        )
        {
            T result = EasyDataAccess<T>.ValueOfT(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ValueOfTTest02(String, Object, String)
        }

        /// <summary>Test stub for ValueOfT(String, String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T ValueOfTTest03<T>(
            string db,
            string sp,
            object parameter,
            string type
        )
        {
            T result = EasyDataAccess<T>.ValueOfT(db, sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.ValueOfTTest03(String, String, Object, String)
        }

        /// <summary>Test stub for GetDapperType(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public string GetDapperTypeTest<T>(string sp, object parameter)
        {
            string result = EasyDataAccess<T>.GetDapperType(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.GetDapperTypeTest(String, Object)
        }

        /// <summary>Test stub for GetDapperType(String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public string GetDapperTypeTest<T>(
            string sp,
            object parameter,
            string type
        )
        {
            string result = EasyDataAccess<T>.GetDapperType(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTTest.GetDapperTypeTest(String, Object, String)
        }
    }
}
