![][neverbuilt]
[![][dnc2]](https://dotnet.github.io/)
[![][vs2017]](https://www.visualstudio.com/)

# JtSQL

An interpreter implemented with .Net Core for JtSQL

[About JtSQL](https://github.com/noear/JtSQL)

## To-do

- [x] Hello World
- [x] Lexer
- [x] Parser
- [ ] SQL Executor

## How-to

```csharp
Chakilo.JtSQL.Run(new Chakilo.Linq.Work("Your JtSQL code here"));
```

## Differences from JtSQL-for-Java

* Using placeholder in sql.

    ```js
    $<SELECT * FROM `user` WHERE user_id > {{0}} AND user_id < {{Math.abs(5)}};>
    ```
    will be compile into
    ```js
    sql("SELECT * FROM `user` WHERE user_id > ? AND user_id < ?;", 0, Math.abs(5))
    ```

* Semicolons may be omitted.

    Both
    ```js
    for (;;) {
        if (condition) {
            var result = $<SELECT * FROM {{table}};>;
        };
    };
    ```
    and
    ```js
    for (;;) {if (condition) {var result = $<SELECT * FROM {{table}}>}}
    ```
    are avaliable.
	
* Inline comments supported.

    ```js
    // get id by username
    var user_id = $<SELECT user_id FROM `user` WHERE username = {{username}} LIMIT 1;>
    ```

## Examples

See also [noear/JtSQL](https://github.com/noear/JtSQL/tree/master/demo)

## Dependencies

* [noear/JtSQL](https://github.com/noear/JtSQL)

* [sebastienros/jint](https://github.com/sebastienros/jint)

[neverbuilt]: https://img.shields.io/badge/build-never%20built-lightgrey.svg
[build]: https://img.shields.io/badge/build-passing-brightgreen.svg
[dnc2]: https://img.shields.io/badge/.Net%20Core-2.0-68217a.svg
[vs2017]: https://img.shields.io/badge/Visual%20Studio-2017-68217a.svg
