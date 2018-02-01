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
    internal static class StringUtils {
		
        /// <summary>
        /// /
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsSlash(this char c) {
            return ('/' == c);
        }

        /// <summary>
        /// *
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsAsterisk(this char c) {
            return ('*' == c);
        }

        /// <summary>
        /// \n
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsNewLine(this char c) {
            return ('\n' == c);
        }

        /// <summary>
        /// $
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsDollar(this char c) {
            return ('$' == c);
        }

        /// <summary>
        /// &lt;
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsLessThan(this char c) {
            return ('<' == c);
        }

        /// <summary>
        /// &gt;
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsGreaterThan(this char c) {
            return ('>' == c);
        }

        /// <summary>
        /// {
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsCurlyBracketLeft(this char c) {
            return ('{' == c);
        }

        /// <summary>
        /// }
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static bool IsCurlyBracketRight(this char c) {
            return ('}' == c);
        }

    }
}
