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

        /// <summary>
        /// 产生新TOKEN
        /// </summary>
        /// <param name="token_list"></param>
        /// <param name="last_token"></param>
        /// <param name="start_index"></param>
        /// <param name="jtsql"></param>
        /// <param name="end_index"></param>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        private static Token ProduceNewToken(string jtsql, List<Token> token_list, Token last_token, long start_index, long end_index, TokenType tokenType) {
            // 与上个token之间有普通js代码
            if (last_token.IndexEnd + 1 != start_index) {
                // 先产生前面的普通token
                Token dft_token = new Token(TokenType.Default, last_token.IndexEnd + 1, start_index - 1, jtsql.Substring(Convert.ToInt32(last_token.IndexEnd + 1), Convert.ToInt32(start_index - last_token.IndexEnd - 1)));
                token_list.Add(dft_token);
                last_token = dft_token;
            }
            // 新token
            Token new_token = new Token(tokenType, start_index, end_index, jtsql.Substring(Convert.ToInt32(start_index), Convert.ToInt32(end_index - start_index + 1)));
            token_list.Add(new_token);

            return new_token;
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 词法分析 得到TOKEN列表
        /// </summary>
        /// <param name="jtsql"></param>
        /// <returns></returns>
        public static List<Token> Tokenize(string jtsql) {

            // 结果
            List<Token> token_list = new List<Token>();

            // 上一个Token
            Token last_token = new Token(TokenType.Default, -1, -1, string.Empty);
             
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
                
                // 进入新状态标记
                bool is_entering_new_state = false;

                // 产生新token标志
                bool is_producing_new_token = false;

                // 根据当前状态找不同的字符
                switch (now) {

                    #region 普通状态

                    // 普通状态 可以进入任何Token状态
                    case LexState.Default:
                        if (c.IsSlash()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // 注释起始 斜杠 /
                            now = LexState.CommentStartSlash;
                        } else if (c.IsDollar()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // JS内嵌SQL起始 $
                            now = LexState.Dolllar;
                        } else if (c.IsCurlyBracketLeft()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // SQL内嵌JS起始 {
                            now = LexState.CurlyBracketLeft;
                        } else if (c.IsGreaterThan()) {

                        }

                        // 进入了新状态
                        if (is_entering_new_state) {

                            // 记录进入状态时的索引
                            temp_token_start_index = i;
                        }

                        break;

                    #endregion

                    #region 注释状态

                    case LexState.CommentStartSlash:
                        if (c.IsSlash()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // 行注释 第二个斜杠 /
                            now = LexState.InlineCommentSecondSlash;
                        } else if (c.IsAsterisk()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // 块注释起始 星号 *
                            now = LexState.BlockCommentStartAsterisk;
                        } else {
                            // 进入注释状态失败 返回到普通状态
                            now = LexState.Default;
                        }
                        break;

                    case LexState.InlineCommentSecondSlash:
                        if (c.IsNewLine()) {
                            // 产生新token标志
                            is_producing_new_token = true;
                        }

                        // 产生新token
                        if (is_producing_new_token) {

                            last_token = ProduceNewToken(jtsql, token_list, last_token, temp_token_start_index, i, TokenType.Comment);

                            // 返回至普通状态
                            now = LexState.Default;
                        }

                        break;

                    case LexState.BlockCommentStartAsterisk:
                        if (c.IsAsterisk()) {
                            // 块注释结束 星号 *
                            now = LexState.BlockCommentEndAsterisk;
                        }

                        break;

                    case LexState.BlockCommentEndAsterisk:
                        if (c.IsSlash()) {
                            // 产生新token标志
                            is_producing_new_token = true;
                        } else if (c.IsAsterisk()) {

                        } else {
                            // 重新寻找星号 *
                            now = LexState.BlockCommentStartAsterisk;
                        }

                        // 产生新token
                        if (is_producing_new_token) {
                            
                            last_token = ProduceNewToken(jtsql, token_list, last_token, temp_token_start_index, i, TokenType.Comment);

                            // 返回至普通状态
                            now = LexState.Default;
                        }

                        break;

                    #endregion

                    #region 内嵌状态

                    case LexState.Dolllar:
                        if (c.IsLessThan()) {
                            // 产生新token标志
                            is_producing_new_token = true;
                        } else {
                            // 返回普通状态
                            now = LexState.Default;
                        }

                        // 产生新token
                        if (is_producing_new_token) {
                            last_token = ProduceNewToken(jtsql, token_list, last_token, temp_token_start_index, i, TokenType.SqlInJsStart);

                            // 返回至普通状态
                            now = LexState.Default;
                        }

                        break;

                    #endregion

                    default:
                        break;

                }

                // 下次循环
                next_loop:
                continue;

            }

            return token_list;

        }

        #endregion

        #endregion

    }
}
