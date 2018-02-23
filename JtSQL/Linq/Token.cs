// ====================================================================== //
//
//  Token
//  Chakilo.Linq
// 
//  Created by Chakilo on 12/25/2017 3:00:48 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;

namespace Chakilo.Linq {

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
        public TokenType Type;

        /// <summary>
        /// 起始索引
        /// </summary>
        public long IndexStart;

        /// <summary>
        /// 结束索引
        /// </summary>
        public long IndexEnd;

        /// <summary>
        /// 原始字符串
        /// </summary>
        public string OriginalString;

        /// <summary>
        /// 行数
        /// </summary>
        public long LineNumber;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type"></param>
        /// <param name="indexStart"></param>
        /// <param name="indexEnd"></param>
        /// <param name="originalString"></param>
        internal Token(TokenType type, long indexStart, long indexEnd, long lineNumber, string originalString) {
            Type = type;
            IndexStart = indexStart;
            IndexEnd = indexEnd;
            LineNumber = lineNumber;
            OriginalString = originalString;
        }

    }

}
