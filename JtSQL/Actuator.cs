// ====================================================================== //
//
//  Actuator
//  Chakilo
// 
//  Created by Chakilo on 12/21/2017 5:50:20 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using Chakilo.Delegate;
using Chakilo.Exception;
using Chakilo.Interpreter;
using Chakilo.Linq;
using Chakilo.SqlExecutor;

namespace Chakilo {
    /// <summary>
    /// JtSQL致动器
    /// </summary>
    internal class Actuator {

        #region 成员

        /// <summary>
        /// 保存单例
        /// </summary>
        private static readonly Lazy<Actuator> _instance = new Lazy<Actuator>(() => new Actuator());

        /// <summary>
        /// 工作对应的线程
        /// </summary>
        private ConcurrentDictionary<Work, Thread> _work_lk_thread;

        #endregion

        #region 事件

        #endregion

        #region 访问器

        /// <summary>
        /// 获取单例
        /// </summary>
        internal static Actuator Instance { get { return _instance.Value; } }

        #endregion

        #region 构造器

        /// <summary>
        /// 私有的构造器
        /// </summary>
        private Actuator() {
            // 初始化
            Init();
        }

        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            // 工作对应的线程
            _work_lk_thread = new ConcurrentDictionary<Work, Thread>();
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="jtsql">The JtSQL code</param>
        /// <returns>The js code or null if error</returns>
        internal string TryParse(string jtsql) {

            // 词法分析
            List<Token> token_list = Lexer.Tokenize(jtsql);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(token_list));

            // 语法分析

            // 翻译


            return null;
        }

        /// <summary>
        /// 执行作业
        /// </summary>
        /// <param name="work"></param>
        internal void Run(Work work) {

            // null
            if (null == work) {
                throw new ArgumentNullException();
            }

            // 已经在运行
            if (work.IsRunning || null != _work_lk_thread.GetValueOrDefault(work)) {
                if (!work.IsRunning) {
                    work.IsRunning = true;
                }
                throw new JtSQLWorkAlreadyRunningException();
            }

            // 翻译
            if (!work.IsCompiled) {
                work.JsCode = TryParse(work.JtsqlCode);
            }

            // 运行


            // 加入到字典
            
        }

        /// <summary>
        /// 中止作业
        /// </summary>
        /// <param name="work"></param>
        internal void Abort(Work work) {

            // null
            if (null == work) {
                throw new ArgumentNullException();
            }

            // 还未运行
            if (!work.IsRunning || null == _work_lk_thread.GetValueOrDefault(work)) {
                if (work.IsRunning) {
                    work.IsRunning = false;
                }
                throw new JtSQLWorkNotRunningException();
            }

        }

        #endregion

        #endregion

    }
}
