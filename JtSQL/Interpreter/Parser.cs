// ====================================================================== //
//
//  Parser
//  JtSQL.Interpreter
// 
//  Created by Chakilo on 12/21/2017 5:27:31 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;

namespace JtSQL.Interpreter {
    /// <summary>
    /// 语法分析器
    /// </summary>
    internal class Parser {

        #region 成员

        /// <summary>
        /// 保存单例
        /// </summary>
        private static readonly Lazy<Parser> _instance = new Lazy<Parser>(() => new Parser());

        #endregion

        #region 访问器

        /// <summary>
        /// 获取单例
        /// </summary>
        public static Parser Instance { get { return _instance.Value; } }

        #endregion

        #region 构造器

        /// <summary>
        /// 私有的构造器
        /// </summary>
        private Parser() {
            // 初始化
            Init();
        }

        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() { }

        #endregion

        #region 公开方法

        #endregion

        #endregion

    }
}
