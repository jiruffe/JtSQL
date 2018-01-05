// ====================================================================== //
//
//  JSEngine
//  JtSQL.JavaScriptEngine
// 
//  Created by konar on 12/28/2017 4:07:58 PM.
//  Copyright © 2017 konar. All rights reserved.
//  
// 
// ====================================================================== //

using Jint;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JtSQL.JavaScriptEngine {
    internal class JSEngine {

        #region 成员

        /// <summary>
        /// JS引擎
        /// </summary>
        private Engine _engine;

        #endregion

        #region 构造器

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="assembly">传入引擎的组件</param>
        internal JSEngine(Assembly assembly) {
            // JS引擎
            _engine = new Engine(cfg => cfg.AllowClr(assembly));
        }

        #endregion

    }
}
