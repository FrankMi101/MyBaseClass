// <copyright file="EasyDataAccessExecuteTTest.cs" company="TCDSB">Copyright © TCDSB 2009</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDapper;

namespace MyDapper.Tests
{
    /// <summary>This class contains parameterized unit tests for EasyDataAccessExecute`1</summary>
    [PexClass(typeof(EasyDataAccessExecute<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class EasyDataAccessExecuteTTest
    {
        /// <summary>Test stub for AnyListOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public List<T> AnyListOfTTest<T>(string SP, object parameter)
        {
            List<T> result = EasyDataAccessExecute<T>.AnyListOfT(SP, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessExecuteTTest.AnyListOfTTest(String, Object)
        }

        /// <summary>Test stub for AnyValueOfT(String, Object)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T AnyValueOfTTest<T>(string SP, object parameter)
        {
            T result = EasyDataAccessExecute<T>.AnyValueOfT(SP, parameter);
            return result;
            // TODO: add assertions to method EasyDataAccessExecuteTTest.AnyValueOfTTest(String, Object)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public EasyDataAccessExecute<T> ConstructorTest<T>()
        {
            EasyDataAccessExecute<T> target = new EasyDataAccessExecute<T>();
            return target;
            // TODO: add assertions to method EasyDataAccessExecuteTTest.ConstructorTest()
        }
    }
}
