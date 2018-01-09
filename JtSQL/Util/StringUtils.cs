// ====================================================================== //
//
//  StringUtils
//  JtSQL.Util
// 
//  Created by Chakilo on 1/9/2018 4:47:05 PM.
//  Copyright © 2018 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;

namespace JtSQL.Util {
    internal static class StringUtils {
		
        internal static bool IsSlash(this char c) {
            return ('/' == c);
        }

        internal static bool IsAsterisk(this char c) {
            return ('*' == c);
        }

        internal static bool IsNewLine(this char c) {
            return ('\n' == c);
        }

    }
}
