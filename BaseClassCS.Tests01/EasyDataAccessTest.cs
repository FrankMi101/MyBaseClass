// <copyright file="EasyDataAccessTest.cs" company="TCDSB">Copyright © TCDSB 2009</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDapper;

namespace MyDapper.Tests
{
    /// <summary>This class contains parameterized unit tests for EasyDataAccess</summary>
    [PexClass(typeof(EasyDataAccess))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class EasyDataAccessTest
    {
        /// <summary>Test stub for ListOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public List<T> ListOfTTest<T>(string sp, object parameter)
        {
            List<T> result = EasyDataAccess.ListOfT<T>(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ListOfTTest(String, Object)
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
            List<T> result = EasyDataAccess.ListOfT<T>(db, sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ListOfTTest01(String, String, Object)
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
            List<T> result = EasyDataAccess.ListOfT<T>(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ListOfTTest02(String, Object, String)
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
            List<T> result = EasyDataAccess.ListOfT<T>(db, sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ListOfTTest03(String, String, Object, String)
        }

        /// <summary>Test stub for ValueOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T ValueOfTTest<T>(string sp, object parameter)
        {
            T result = EasyDataAccess.ValueOfT<T>(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ValueOfTTest(String, Object)
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
            T result = EasyDataAccess.ValueOfT<T>(db, sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ValueOfTTest01(String, String, Object)
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
            T result = EasyDataAccess.ValueOfT<T>(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ValueOfTTest02(String, Object, String)
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
            T result = EasyDataAccess.ValueOfT<T>(db, sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessTest.ValueOfTTest03(String, String, Object, String)
        }
    }
}
