// ====================================================================== //
//
//  Token
//  JtSQL.Interpreter
// 
//  Created by Chakilo on 12/25/2017 3:00:48 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;

namespace JtSQL.Interpreter {

    /// <summary>
    /// TOKEN类型
    /// </summary>
    internal enum TokenType {
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// 注释
        /// </summary>
        Comment,
        /// <summary>
        /// JS内嵌SQL起始 $&lt;
        /// </summary>
        SqlInJsStart,
        /// <summary>
        /// JS内嵌SQL结束 &gt;
        /// </summary>
        SqlInJsEnd,
        /// <summary>
        /// SQL内嵌JS开始 {{
        /// </summary>
        JsInSqlStart,
        /// <summary>
        /// SQL内嵌JS结束 }}
        /// </summary>
        JsInSqlEnd
    }

    /// <summary>
    /// TOKEN
    /// </summary>
    internal class Token {

        /// <summary>
        /// TOKEN类型
        /// </summary>
        internal TokenType Type;

        /// <summary>
        /// 起始索引
        /// </summary>
        internal int IndexStart;

        /// <summary>
        /// 结束索引
        /// </summary>
        internal int IndexEnd;

        /// <summary>
        /// 原始字符串
        /// </summary>
        internal string OriginalString;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type"></param>
        /// <param name="indexStart"></param>
        /// <param name="indexEnd"></param>
        /// <param name="originalString"></param>
        internal Token(TokenType type, int indexStart, int indexEnd, string originalString) {
            Type = type;
            IndexStart = indexStart;
            IndexEnd = indexEnd;
            OriginalString = originalString;
        }

    }

}
