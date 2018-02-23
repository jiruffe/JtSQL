// ====================================================================== //
//
//  Exceptions
//  Chakilo.Exception
// 
//  Created by Chakilo on 12/22/2017 5:48:04 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;

namespace Chakilo.Exception {

    /// <summary>
    /// jtsql异常基类
    /// </summary>
    public abstract class JtSQLException : SystemException {
        public JtSQLException() : base() { }
        public JtSQLException(string message) : base(message) { }
    }

    /// <summary>
    /// jtsql异常 在jtsql运行时修改代码
    /// </summary>
    public class JtSQLChangingCodeDuringWorkRunningException : JtSQLException {
        public JtSQLChangingCodeDuringWorkRunningException() : base() { }
        public JtSQLChangingCodeDuringWorkRunningException(string message) : base(message) { }
    }

    /// <summary>
    /// jtsql异常 jtsql已经在运行
    /// </summary>
    public class JtSQLWorkAlreadyRunningException : JtSQLException {
        public JtSQLWorkAlreadyRunningException() : base() { }
        public JtSQLWorkAlreadyRunningException(string message) : base(message) { }
    }

    /// <summary>
    /// jtsql异常 jtsql还未运行
    /// </summary>
    public class JtSQLWorkNotRunningException : JtSQLException {
        public JtSQLWorkNotRunningException() : base() { }
        public JtSQLWorkNotRunningException(string message) : base(message) { }
    }

    /// <summary>
    /// jtsql编译时错误
    /// </summary>
    public class JtSQLCompileTimeException : JtSQLException {
        public JtSQLCompileTimeException() : base() { }
        public JtSQLCompileTimeException(string message) : base(message) { }
    }

}