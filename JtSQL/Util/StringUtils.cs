// ====================================================================== //
//
//  StringUtils
//  Chakilo.Util
// 
//  Created by Chakilo on 1/9/2018 4:47:05 PM.
//  Copyright © 2018 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;

namespace Chakilo.Util {
    /// <summary>
    /// 字符、字符串处理
    /// </summary>
    internal static class StringUtils {

        #region 常量

        /// <summary>
        /// 空白字符
        /// </summary>
        private static char[] BlankChars = new char[] { (char)0x00, (char)0x01, (char)0x02, (char)0x03, (char)0x04, (char)0x05,
                (char)0x06, (char)0x07, (char)0x08, (char)0x09, (char)0x0a, (char)0x0b, (char)0x0c, (char)0x0d, (char)0x0e, (char)0x0f,
                (char)0x10, (char)0x11, (char)0x12, (char)0x13, (char)0x14, (char)0x15, (char)0x16, (char)0x17, (char)0x18, (char)0x19, (char)0x20,
                (char)0x1a, (char)0x1b, (char)0x1c, (char)0x1d, (char)0x1e, (char)0x1f, (char)0x7f, (char)0x85, (char)0x2028, (char)0x2029 };

        #endregion

        #region 方法

        #region 私有方法

        #endregion

        #region 公开方法

        /// <summary>
        /// /
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsSlash(this char c) {
            return ('/'.Equals(c));
        }

        /// <summary>
        /// *
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsAsterisk(this char c) {
            return ('*'.Equals(c));
        }

        /// <summary>
        /// \n
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsNewLine(this char c) {
            return ('\n'.Equals(c));
        }

        /// <summary>
        /// $
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsDollar(this char c) {
            return ('$'.Equals(c));
        }

        /// <summary>
        /// &lt;
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsLessThan(this char c) {
            return ('<'.Equals(c));
        }

        /// <summary>
        /// &gt;
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsGreaterThan(this char c) {
            return ('>'.Equals(c));
        }
        
        /// <summary>
        /// ;
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsSemicolon(this char c) {
            return (';'.Equals(c));
        }

        /// <summary>
        /// {
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsCurlyBracketLeft(this char c) {
            return ('{'.Equals(c));
        }

        /// <summary>
        /// }
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsCurlyBracketRight(this char c) {
            return ('}'.Equals(c));
        }

        /// <summary>
        /// White space
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsBlank(this char c) {

            foreach (var w in BlankChars)
                if (w.Equals(c))
                    return true;

            return false;

        }

        #endregion

        #endregion

    }
}
