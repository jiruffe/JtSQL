// ====================================================================== //
//
//  Lexer
//  JtSQL.Interpreter
// 
//  Created by Chakilo on 12/21/2017 5:26:35 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;

namespace JtSQL.Interpreter {
    /// <summary>
    /// 词法分析器
    /// </summary>
    internal class Lexer {

        #region 状态机

        /// <summary>
        /// 词法分析状态
        /// </summary>
        private enum LexState {
            /// <summary>
            /// 默认状态
            /// </summary>
            Default,
            /// <summary>
            /// 斜杠 /
            /// </summary>
            Slash,
            /// <summary>
            /// 星号 *
            /// </summary>
            Asterisk,
            /// <summary>
            /// 换行 \n
            /// </summary>
            NewLine,
            /// <summary>
            /// 美元符 $
            /// </summary>
            Dolllar,
            /// <summary>
            /// 小于号 $lt;
            /// </summary>
            LessThan,
            /// <summary>
            /// 大于号 &gt;
            /// </summary>
            GreaterThan,
            /// <summary>
            /// 左花括号 {
            /// </summary>
            CurlyBracketLeft,
            /// <summary>
            /// 右花括号
            /// </summary>
            CurlyBracketRight
        }

        #endregion

        #region 成员

        /// <summary>
        /// 保存单例
        /// </summary>
        private static readonly Lazy<Lexer> _instance = new Lazy<Lexer>(() => new Lexer());

        #endregion

        #region 访问器

        /// <summary>
        /// 获取单例
        /// </summary>
        public static Lexer Instance { get { return _instance.Value; } }

        #endregion

        #region 构造器

        /// <summary>
        /// 私有的构造器
        /// </summary>
        private Lexer() {
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

        /// <summary>
        /// 找出TOKEN
        /// </summary>
        /// <param name="jtsql"></param>
        /// <returns></returns>
        public static List<Token> GetTokens(string jtsql) {

            // 结果
            List<Token> list = new List<Token>();

            // 上一个Token
            Token last = new Token(TokenType.Default, 0, 0, "");

            // 字符串转为字符数组
            char[] jtsql_chars = jtsql.ToCharArray();

            // TODO:

            return list;

        }

        #endregion

        #endregion

    }
}
