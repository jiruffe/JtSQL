// ====================================================================== //
//
//  Parser
//  Chakilo.Interpreter
// 
//  Created by Chakilo on 12/21/2017 5:27:31 PM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;
using Chakilo.Util;
using Chakilo.Exception;

namespace Chakilo.Interpreter {
    /// <summary>
    /// 语法分析器 syntactic analyser
    /// </summary>
    internal static class Parser {

        #region 状态机

        /// <summary>
        /// 
        /// </summary>
        private enum SynState {
            /// <summary>
            /// 默认状态
            /// </summary>
            Default,
            /// <summary>
            /// JS内嵌SQL $< >
            /// </summary>
            SqlInJs,
            /// <summary>
            /// SQL内嵌JS {{ }}
            /// </summary>
            JsInSql
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
        static Parser() {
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

        internal static string Parse(List<Token> tokens) {

            // 结果
            string rst = string.Empty;

            // 上一个Token
            Token last_token = new Token(TokenType.Default, -1, -1, 1, string.Empty);

            // 当前状态
            SynState now = SynState.Default;

            // JS内嵌SQL的变量
            List<string> vars = new List<string>();

            // 遍历token 根据token内容拼接字符串
            foreach (var token in tokens) {

                // 忽略注释
                if (TokenType.Comment == token.Type) {
                    continue;
                }

                // 根据当前状态
                switch (now) {

                    // 默认状态
                    case SynState.Default:
                        break;

                    // JS内嵌SQL $< >
                    case SynState.SqlInJs:
                        break;

                    // SQL内嵌JS {{ }}
                    case SynState.JsInSql:
                        break;

                    default:
                        break;

                }

                // 根据token类型
                switch (token.Type) {

                    case TokenType.Default:
                        if (SynState.JsInSql == now) {
                            // 占位符
                            rst += Constant.SqlVarPlaceholder;
                            // 变量加入
                            vars.Add(token.OriginalString);
                        } else {
                            // 直接加入结果
                            rst += token.OriginalString;
                        }
                        break;

                    case TokenType.SqlInJsStart:
                        if (SynState.Default != now) {
                            // $<>不能直接内嵌
                            throw new JtSQLCompileTimeException(string.Format("Invalid expression term '$<' at line {0}.", token.LineNumber));
                        } else {
                            // 替换内容加入结果
                            rst += Constant.SqlInJsStartReplacement;
                            // 状态变换
                            now = SynState.SqlInJs;
                        }
                        break;

                    case TokenType.SqlInJsEnd:
                        if (SynState.SqlInJs == now) {
                            // 结束
                            // 要加入的字符串
                            string sta = "\"";
                            foreach (var v in vars) {
                                sta += ", " + v;
                            }
                            sta += ")";

                            // 清空变量
                            vars.Clear();

                            // 加入
                            rst += sta;

                            // 状态变换
                            now = SynState.Default;

                        } else {
                            // 其它情况 应该视作大于符号 直接加入结果
                            rst += token.OriginalString;
                        }
                        break;

                    case TokenType.JsInSqlStart:

                        // 状态变换
                        now = SynState.JsInSql;

                        break;

                    case TokenType.JsInSqlEnd:

                        if (SynState.JsInSql == now) {

                            // 状态变换
                            now = SynState.SqlInJs;

                        } else {

                            // 其它情况 应该视作普通token 直接加入结果
                            rst += token.OriginalString;

                        }

                        break;

                    default:
                        break;

                }

            }

            return rst;

        }

        #endregion

        #endregion

    }
}
