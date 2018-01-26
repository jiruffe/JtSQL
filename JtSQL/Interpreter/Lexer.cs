// ====================================================================== //
//
//  Lexer
//  Chakilo.Interpreter
// 
//  Created by Chakilo on 12/21/2017 5:26:35 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;
using Chakilo.Util;

namespace Chakilo.Interpreter {
    /// <summary>
    /// 词法分析器
    /// </summary>
    internal static class Lexer {

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
            /// 块注释/行注释起始斜杠 /
            /// </summary>
            CommentStartSlash,
            /// <summary>
            /// 行注释第二个斜杠
            /// </summary>
            InlineCommentSecondSlash,
            /// <summary>
            /// 块注释起始星号 *
            /// </summary>
            BlockCommentStartAsterisk,
            /// <summary>
            /// 块注释结束星号 *
            /// </summary>
            BlockCommentEndAsterisk,
            /// <summary>
            /// 块注释结束斜杠 /
            /// </summary>
            BlockCommentEndSlash,
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

        #endregion

        #region 访问器

        #endregion

        #region 构造器

        /// <summary>
        /// 私有的构造器
        /// </summary>
        static Lexer() {
            // 初始化
            Init();
        }

        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        private static void Init() { }

        #endregion

        #region 公开方法

        /// <summary>
        /// 词法分析 得到TOKEN列表
        /// </summary>
        /// <param name="jtsql"></param>
        /// <returns></returns>
        public static List<Token> Tokenize(string jtsql) {

            // 结果
            List<Token> list = new List<Token>();

            // 上一个Token
            Token last = new Token(TokenType.Default, 0, 0, string.Empty);

            // 当前状态
            LexState now = LexState.Default;

            // 字符串转为字符数组
            char[] jtsql_chars = jtsql.ToCharArray();

            // 长度
            long jtsql_chars_length = jtsql_chars.GetLongLength(0);

            // Token起始索引
            long temp_token_start_index = 0;

            // 遍历字符
            for (var i = 0; i < jtsql_chars_length; i++) {

                // 当前字符
                char c = jtsql_chars[i];

                // 根据当前状态找不同的字符
                switch (now) {

                    // 普通状态 可以进入任何Token状态
                    case LexState.Default:
                        if (c.IsSlash()) {
                            // 注释起始 斜杠 /
                            now = LexState.CommentStartSlash;
                        } else if (c.IsDollar()) {
                            // JS内嵌SQL起始 $
                            now = LexState.Dolllar;
                        } else if (c.IsCurlyBracketLeft()) {
                            // SQL内嵌JS起始 {
                            now = LexState.CurlyBracketLeft;
                        }
                        break;

                    default:
                        break;

                }

                // 下次循环
                next_loop:
                continue;

            }

            return list;

        }

        #endregion

        #endregion

    }
}
