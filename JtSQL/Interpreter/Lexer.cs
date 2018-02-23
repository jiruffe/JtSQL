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

using Chakilo.Linq;
using Chakilo.Util;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Chakilo.Interpreter {
    /// <summary>
    /// 词法分析器 lexical analyser
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
        private static Token ProduceNewToken(string jtsql, List<Token> token_list, Token last_token, long start_index, long end_index, long line_number, TokenType token_type) {
            // 与上个token之间有普通js代码
            if (last_token.IndexEnd + 1 != start_index) {
                // 先产生前面的普通token
                Token dft_token = new Token(TokenType.Default, last_token.IndexEnd + 1, start_index - 1, line_number, jtsql.Substring(Convert.ToInt32(last_token.IndexEnd + 1), Convert.ToInt32(start_index - last_token.IndexEnd - 1)));
                token_list.Add(dft_token);
                last_token = dft_token;
            }
            // 新token
            Token new_token = new Token(token_type, start_index, end_index, line_number, jtsql.Substring(Convert.ToInt32(start_index), Convert.ToInt32(end_index - start_index + 1)));
            token_list.Add(new_token);

            return new_token;
        }

        /// <summary>
        /// 产生新TOKEN
        /// </summary>
        /// <param name="new_state"></param>
        /// <param name="new_token"></param>
        /// <param name="jtsql"></param>
        /// <param name="token_list"></param>
        /// <param name="last_token"></param>
        /// <param name="start_index"></param>
        /// <param name="end_index"></param>
        /// <param name="line_number"></param>
        /// <param name="tokenType"></param>
        private static void ProduceNewToken(ref LexState new_state, ref Token new_token, bool is_producing_new_token, string jtsql, List<Token> token_list, Token last_token, long start_index, long end_index, long line_number, TokenType token_type) {

            if (is_producing_new_token) {

                // 产生新token
                new_token = ProduceNewToken(jtsql, token_list, last_token, start_index, end_index, line_number, token_type);

                // 返回至普通状态
                new_state = LexState.Default;

            }

        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 词法分析 得到TOKEN列表
        /// </summary>
        /// <param name="jtsql"></param>
        /// <returns></returns>
        internal static List<Token> Tokenize(string jtsql) {

            // 空
            if (null == jtsql)
                throw new ArgumentNullException();

            // 结果
            List<Token> token_list = new List<Token>();

            // 上一个Token
            Token last_token = new Token(TokenType.Default, -1, -1, 1, string.Empty);
            
            // 当前状态
            LexState now = LexState.Default;

            // 字符串转为字符数组
            char[] jtsql_chars = jtsql.ToCharArray();

            // 长度
            long jtsql_chars_length = jtsql_chars.GetLongLength(0);

            // Token起始索引
            long temp_token_start_index = 0;

            // 当前行数
            long line = 1;

            // 遍历字符
            for (var i = 0; i < jtsql_chars_length; i++) {

                // 当前字符
                char c = jtsql_chars[i];
                
                // 进入新状态标记
                bool is_entering_new_state = false;

                // 产生新token标志
                bool is_producing_new_token = false;

                // 新token类型
                TokenType new_token_type = TokenType.Default;

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
                        } else if (c.IsGreaterThan()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // JS内嵌SQL结束 >
                            now = LexState.GreaterThan;
                        } else if (c.IsCurlyBracketLeft()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // SQL内嵌JS起始 {
                            now = LexState.CurlyBracketLeft;
                        } else if (c.IsCurlyBracketRight()) {
                            // 进入状态标记
                            is_entering_new_state = true;
                            // SQL内嵌JS结束 }
                            now = LexState.CurlyBracketRight;
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
                            new_token_type = TokenType.Comment;
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
                            new_token_type = TokenType.Comment;
                        } else if (c.IsAsterisk()) {
                            // 还是星号 什么也不做 接着找
                        } else {
                            // 重新寻找星号 *
                            now = LexState.BlockCommentStartAsterisk;
                        }

                        break;

                    #endregion

                    #region 内嵌状态 $< >

                    case LexState.Dolllar:
                        if (c.IsLessThan()) {
                            // 产生新token标志
                            is_producing_new_token = true;
                            new_token_type = TokenType.SqlInJsStart;
                        } else {
                            // 返回普通状态
                            now = LexState.Default;
                        }

                        break;

                    case LexState.GreaterThan:
                        if (c.IsBlank() && !c.IsNewLine()) {
                            // 空白符 什么也不做
                        } else if (c.IsSemicolon() || c.IsNewLine() || c.IsCurlyBracketRight()) {
                            // 右花括号、分号和换行 产生新token
                            is_producing_new_token = true;
                            new_token_type = TokenType.SqlInJsEnd;

                            // 这个字符实际上是提前读取 因此须重新判断
                            goto prdc_new_token_then_re_loop;

                        } else {
                            // 返回普通状态
                            now = LexState.Default;
                            // 需要重新判断当前字符
                            goto re_loop;
                        }

                        break;

                    #endregion

                    #region 内嵌状态 {{ }}

                    case LexState.CurlyBracketLeft:
                        if (c.IsCurlyBracketLeft()) {
                            // 产生新token标志
                            is_producing_new_token = true;
                            new_token_type = TokenType.JsInSqlStart;
                        } else {
                            // 返回普通状态
                            now = LexState.Default;
                        }
                        break;

                    case LexState.CurlyBracketRight:
                        if (c.IsCurlyBracketRight()) {
                            // 产生新token标志
                            is_producing_new_token = true;
                            new_token_type = TokenType.JsInSqlEnd;
                        } else {
                            // 返回普通状态
                            now = LexState.Default;
                        }
                        break;

                    #endregion

                    default:
                        break;

                }

                // 产生新token
                ProduceNewToken(ref now, ref last_token, is_producing_new_token, jtsql, token_list, last_token, temp_token_start_index, i, line, new_token_type);

                // 行数
                if (c.IsNewLine())
                    line++;

                // 下次循环
                next_loop:
                continue;

                // 重进本次循环
                re_loop:
                // 回退索引
                i--;
                continue;

                // 产生新token 然后重进本次循环
                prdc_new_token_then_re_loop:
                // 回退索引
                i--;
                // 产生新token
                ProduceNewToken(ref now, ref last_token, is_producing_new_token, jtsql, token_list, last_token, temp_token_start_index, i, line, new_token_type);
                continue;

            }

            return token_list;

        }

        #endregion

        #endregion

    }
}
