// <copyright file="EasyDataAccessAsyncTTest.cs" company="TCDSB">Copyright © TCDSB 2009</copyright>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDapper;

namespace MyDapper.Tests
{
    /// <summary>This class contains parameterized unit tests for EasyDataAccessAsync`1</summary>
    [PexClass(typeof(EasyDataAccessAsync<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class EasyDataAccessAsyncTTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public EasyDataAccessAsync<T> ConstructorTest<T>()
        {
            EasyDataAccessAsync<T> target = new EasyDataAccessAsync<T>();
            return target;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ConstructorTest()
        }

        /// <summary>Test stub for ListOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<List<T>> ListOfTTest<T>(string sp, object parameter)
        {
            Task<List<T>> result = EasyDataAccessAsync<T>.ListOfT(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ListOfTTest(String, Object)
        }

        /// <summary>Test stub for ListOfT(String, String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<List<T>> ListOfTTest01<T>(
            string db,
            string sp,
            object parameter
        )
        {
            Task<List<T>> result = EasyDataAccessAsync<T>.ListOfT(db, sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ListOfTTest01(String, String, Object)
        }

        /// <summary>Test stub for ListOfT(String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<List<T>> ListOfTTest02<T>(
            string sp,
            object parameter,
            string type
        )
        {
            Task<List<T>> result = EasyDataAccessAsync<T>.ListOfT(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ListOfTTest02(String, Object, String)
        }

        /// <summary>Test stub for ListOfT(String, String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<List<T>> ListOfTTest03<T>(
            string db,
            string sp,
            object parameter,
            string type
        )
        {
            Task<List<T>> result = EasyDataAccessAsync<T>.ListOfT(db, sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ListOfTTest03(String, String, Object, String)
        }

        /// <summary>Test stub for ValueOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<T> ValueOfTTest<T>(string sp, object parameter)
        {
            Task<T> result = EasyDataAccessAsync<T>.ValueOfT(sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ValueOfTTest(String, Object)
        }

        /// <summary>Test stub for ValueOfT(String, String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<T> ValueOfTTest01<T>(
            string db,
            string sp,
            object parameter
        )
        {
            Task<T> result = EasyDataAccessAsync<T>.ValueOfT(db, sp, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ValueOfTTest01(String, String, Object)
        }

        /// <summary>Test stub for ValueOfT(String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<T> ValueOfTTest02<T>(
            string sp,
            object parameter,
            string type
        )
        {
            Task<T> result = EasyDataAccessAsync<T>.ValueOfT(sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ValueOfTTest02(String, Object, String)
        }

        /// <summary>Test stub for ValueOfT(String, String, Object, String)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Task<T> ValueOfTTest03<T>(
            string db,
            string sp,
            object parameter,
            string type
        )
        {
            Task<T> result = EasyDataAccessAsync<T>.ValueOfT(db, sp, parameter, type);
            return result;
            // TODO: add assertions to method EasyDataAccessAsyncTTest.ValueOfTTest03(String, String, Object, String)
        }
    }
}
