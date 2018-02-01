// ====================================================================== //
//
//  Delegates
//  Chakilo.Delegate
// 
//  Created by Chakilo on 12/22/2017 5:33:11 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

namespace Chakilo.Delegate {

    /// <summary>
    /// 翻译完成后
    /// </summary>
    /// <param name="js">翻译后的JavaScript代码</param>
    public delegate void AfterCompilingDelegate(string js);

    /// <summary>
    /// SQL执行前
    /// </summary>
    /// <param name="sql">即将执行的SQL语句</param>
    /// <returns>true: SQL继续执行
    /// <para>false: 取消SQL执行</para>
    /// </returns>
    public delegate bool BeforeSQLExecutingDelegate(string sql);

    /// <summary>
    /// SQL执行后
    /// </summary>
    /// <param name="sql">执行的SQL语句</param>
    public delegate void AfterSQLExecutedDelegate(string sql);

}