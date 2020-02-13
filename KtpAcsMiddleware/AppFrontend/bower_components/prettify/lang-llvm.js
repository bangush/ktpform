PR.registerLangHandler(PR.createSimpleLexer(
        [
            ["pln", /^[\t\n\r \xa0]+/, null, "\t\n\r \u00a0"], ["str", /^!?"(?:[^"\\]|\\[\S\s])*(?:"|$)/, null, '"'],
            ["com", /^;[^\n\r]*/, null, ";"]
        ],
        [
            ["pln", /^[!%@](?:[$\-.A-Z_a-z][\w$\-.]*|\d+)/], ["kwd", /^[^\W\d]\w*/, null], ["lit", /^\d+\.\d+/],
            ["lit", /^(?:\d+|0[Xx][\dA-Fa-f]+)/], ["pun", /^[(-*,:<->[\]{}]|\.\.\.$/]
        ]),
    ["llvm", "ll"]);