// ====================================================================== //
//
//  JavaScriptTemplatedStructuredQueryLanguage
//  JtSQL
// 
//  Created by Chakilo on 12/25/2017 2:07:17 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using JtSQL.Delegate;
using JtSQL.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JtSQL {
    public static class JavaScriptTemplatedStructuredQueryLanguage {

        #region 成员

        /// <summary>
        /// JtSQL制动器
        /// </summary>
        private static readonly Actuator _actuator;

        #endregion

        #region 事件

        #endregion

        #region 访问器

        #endregion

        #region 构造器

        /// <summary>
        /// 静态构造器
        /// </summary>
        static JavaScriptTemplatedStructuredQueryLanguage() {
            _actuator = Actuator.Instance;
        }

        #endregion

        #region 方法

        #region 私有方法

        #endregion

        #region 公开方法

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="work">The JtSQL.Linq.Work to be excuted.</param>
        public static void Run(Work work) {
            _actuator.Run(work);
        }

        #endregion

        #endregion

    }
}
