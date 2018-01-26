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
    public abstract class JtSQLException : System.Exception { }

    /// <summary>
    /// jtsql异常 在jtsql运行时修改代码
    /// </summary>
    public class JtSQLChangingCodeDuringWorkRunningException : JtSQLException { }

    /// <summary>
    /// jtsql异常 jtsql已经在运行
    /// </summary>
    public class JtSQLWorkAlreadyRunningException : JtSQLException { }

    /// <summary>
    /// jtsql异常 jtsql还未运行
    /// </summary>
    public class JtSQLWorkNotRunningException : JtSQLException { }

}