// ====================================================================== //
//
//  JtSQL
//  Chakilo
// 
//  Created by Chakilo on 12/25/2017 2:07:17 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using Chakilo.Linq;

namespace Chakilo {
    public static class JtSQL {

        #region 成员

        /// <summary>
        /// JtSQL致动器
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
        static JtSQL() {
            _actuator = Actuator.Instance;
        }

        #endregion

        #region 方法

        #region 私有方法

        #endregion

        #region 公开方法

        /// <summary>
        /// 执行作业
        /// </summary>
        /// <param name="work">The work to be excuted.</param>
        public static void Run(Work work) {
            _actuator.Run(work);
        }

        /// <summary>
        /// 中止作业
        /// </summary>
        /// <param name="work">The work to be aborted.</param>
        public static void Abort(Work work) {
            _actuator.Abort(work);
        }

        #endregion

        #endregion

    }
}
