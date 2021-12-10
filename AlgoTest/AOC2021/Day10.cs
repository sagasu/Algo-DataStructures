﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2021
{
    [TestClass]
    public class Day10
    {
        [TestMethod]
        public void Test2()
        {
            var data = realData;
            var stack = new Stack<char>();
            var dic = new Dictionary<char,char>()
            {
                {'{', '}'},
                {'[',']'},
                {'<','>'},
                {'(',')'}
            };

            var points = new Dictionary<char, int>()
            {
                { '}',1197},
                {']',57},
                {'>',25137},
                {')',3}
            };
            var sum = 0;
            for (var line = 0; line < data.Length; line++)
            {
                for (var i = 0; i < data[line].Length; i++)
                {
                    var element = data[line][i];
                    if (dic.Keys.Contains(element))
                        stack.Push(element);
                    else
                    {
                        var close = stack.Pop();
                        if (dic[close] != element)
                        {
                            sum += points[element];
                            break;
                        }

                        
                    }
                }
                stack = new Stack<char>();
            }

            Assert.AreEqual(344193, sum);
        }

        [TestMethod]
        public void Test3()
        {
            var data = realData;
            var stack = new Stack<char>();
            var dic = new Dictionary<char, char>()
            {
                {'{', '}'},
                {'[',']'},
                {'<','>'},
                {'(',')'}
            };

            var points = new Dictionary<char, int>()
            {
                { '{',3},
                {'[',2},
                {'<',4},
                {'(',1}
            };
            var scores = new List<long>();            
            for (var line = 0; line < data.Length; line++)
            {
                long sum = 0;
                for (var i = 0; i < data[line].Length; i++)
                {
                    var element = data[line][i];
                    if (dic.Keys.Contains(element))
                        stack.Push(element);
                    else
                    {
                        var close = stack.Pop();
                        if (dic[close] != element)
                        {
                            stack = new Stack<char>();
                            break;
                        }
                    }
                }

                while(stack.Count != 0)
                {
                    var open = stack.Pop();
                    sum *= 5;
                    sum += points[open];
                }
                if(sum != 0) scores.Add(sum);

                stack = new Stack<char>();
            }

            var middle = scores.Count / 2;
            scores.Sort();
            
            Assert.AreEqual(3241238967, scores[middle]);
        }

        string[] testData = new string[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };
        string[] realData = new string[]
        {
            "[[<[<{[<{{<[{(()[])[[]()]}[((){})<[]{}>]}<<{[]{}}<(){}>><([]<>)>>>[[[<<>>[<><>]][<<>>(<><>)]][{",
"((<[(<<(<{<((<()<>>{()()}){<<>><()[]>})([{<>{}}(()[])]{(<><>>})>(<((()())<[][]>)>([(<>{})({}())][<",
"<<<(<<[[((({<([]<>)[[]]>{<{}>{(){}}}}{[<[][]><<>[]>]({<><>}{()<>})})[<<({}())(()<>)>[([]{})<[]()>]>({[[]",
"<(<<<[((([{({((){})<<>{}>}[<(){}>[<>()]])[[<{}[]>({}{}]](<<>[]><[]<>>)]}](<[({[][]}<()<>>)<[",
"{<<<{[({{(<<(<<>[]><[]()>){<[][]>{<>{}}}>((({}())([]<>))[<{}{}>({}())])>(<<<()[]>><<<>{}>(()<",
"{<{<<[[(<<[{<<{}[]>>([<>()]{{}{}})}]<(<{<>()}{{}()}>{({}[])<<>()>})>>>){[{[{<[[]{}][<><>]>}{(<{}(",
"(((([(({((<[<(<>{})[{}{}]>](<[()<>]{<><>}>)><<[<[]{}>((){})]<[()[]]>>{[{<>()}((){})]({()[]}(()[]))}>))}(",
"<<[(({({(<{{((<>[])[[]<>])([<>]{()()})}<<{<>[]}><<{}()>>>}>)(<(<{<()[]><(){}>}{{(){}}[{}<>]}>{",
"(([[{<[<<{[<{<()[]>{<>[]}}{<{}{}>{[]<>}}>[{<{}{}>(<>[])}]]{<<({}[])>(<[]<>>[{}])>({{<>()}(<",
"(<{{(<<{[([<<{()[]}>{({}<>){<>[]}]>((<[]{}><{}{}>))]([{(()<>)(<>[])}]<<((){})<<>{}>>[(()[])",
"{{[[<<{<{{{([{()[]}[{}()]]{(<>{}){<><>}}){<[[][]][()[]]>}}<{{<[][]>[{}[]]>(<<>{}><{}{}>)}>}}<<{[{([](",
"{[<({{{[<{<{[([][])]{({}())<[][]>}}((<(){}>{()<>})<<<>{}>>)>}(((<{<>{}}<{}()>>)[((()()))[<<>{}>(",
"{{{[{{[(([{{[[{}<>]([]<>)]([(){}][[]()])}[{{[]<>}[{}()]}(<<><>>]]}][[([[[]<>]<<>{}>][{[]{}",
"<<{{{[{{[<({<<[]<>><{}<>>>}[[{()<>}{[]<>}]({(){}}{{}()})])[[(<<>[]>[[]])[{{}{}}[[]()]]]<((",
"({{[{{{{<[[({[{}{}]{[]<>}}<<()<>>(()<>)>)<{{(){}]<()()>}{{(){}}[<><>]}>]<<({{}{}}<(){}>)([{}",
"{([[[<<([[{{[<()<>>(()<>))({<>[]}(<>{}))}{(<{}()>{()[]})}}([[{{}[]}<[]>]<([]<>){<>}>])]<{[[([]{})]{(<><>)[[]<",
"([<<([<[[({((({}[]){[]{}}){({}[])({}<>)})>)[(<{{{}{}}[(){}]}(([][])<{}<>>)><[[<><>]{<>{}}]{{{}[]}{[][]}}>)<[[",
"{[<<{[<{[<{[[({}[])({}<>)]<<{}{}>{{}()}}]{[[<>{}]<[]{}>]}}(([(<><>){[][]}]([<>()]<()[]>))<[<()<>>(<><>)",
"(<[<[(({{<{<<[{}()]>(([]())<<>[]>)>}[{<[[]{}]([]<>)><{<><>}[()<>]>}{{{(){}}{[]{}}}}]>}}){{<{([<([]())({}())",
"<<{({{<[<[{([{{}<>}{<><>}]([(){}](()[]))){[{()[]}<<>()>]({()()}({}()))}}]<[<<(())(()[])>>{(<{}<>>{",
"{{{(<<[(<[([[[()<>]<()[]>]]{[[[]{}]{<>{}}]((<><>)({}{}))})]([(<{<>()}{[]{}}><<{}{}><<>[]>>)[<<()[]>((){",
"[{(<<{[<<([{[<[][]>][{()()}({}())]}]([{([]{})<{}<>>}(<()>[{}])]{<([]<>)<{}{}>>(({}<>)<<><>>)}))>([[((<<>{}",
"[[(<({{(({{(<[{}<>]([]{})>{[<>[]]([][])})[(<[]<>><{}()>)[<{}()>(())]]}<[<[[]{}]<{}{}>>{<()()>({}<>)}]<",
"([(<({(<{{(((<[]<>>{<>()})<{[]{}>([]{})>)[<[()<>]({}[])>[(<>{})(<>[])]]){<((<>{}){()[]})><{<[]<>><<><>>",
"({{<({(<<({[[{<><>}]<<<><>>({}[])>]([<[]<>>[{}()]]{{<>{}}({}[])}}}<{({[]<>}({}{}))[(<>())(<>())]}((([]{}){[][",
"(((({[(<([<[(<<>>[[][]])<{<><>}[{}<>]>]{({<>()}(<><>))(({}<>))}>])<([[<<()<>>{[][]}>]<[[[][",
"[<<(([({((<<{({}())}[(()()){[]<>}]>>){({<[{}{}]<<>()>>{<{}()>}})})})])[[<((<[{([<>()][{}[]])((()[])",
"{{{<{[[(<[{{<<{}()>[{}<>]>{({}{})<()>}}(<[(){}]>(<(){}>[[]]))}(<<[[]{}}({})><[<>[]]{<><>}>><[<[]<>>{<><>}](((",
"{<[[<[{{<((<[<<>()><[]{}>][<{}()><{}{}>]>)[[[[[][]]<()[]}][([]{})(()())]]])>[[((<{[]<>}<()>><[{}[]](<><>)>",
"<{([{[{[{([({<{}[]>([]<>)}[[[][]]<()()>])[<[{}()]>{<<><>>(()<>)}]]){({(<[]<>>([]<>))[(<>){",
"[{{<(({<{[{<{({})(<>[])}({<><>}{[]()})>(({[]<>}(<>{}))[{()()}{{}<>}])}{<{{<>()}<[]{})}(<()><(",
"{(<[{[[{{<(([{{}{}}<()[]>]<[<><>]>)([(<><>)])){<<{[]{}}[[][]]>{[[]<>]{<>{}}}>[<<[][]><<>()>><<{}<>>[<>()>>]}>",
"<[{{(<<{{{[[{<[]<>>(()<>)}<{()<>}{<>[]}>]<[<()()>]{<<>>([]())}>]{([<<>{}>({}<>)])[({{}}{[]<>})[",
"<<[[<<[(<{{{[{()[]}([]())][[[]]((){})]}}(([{[][]}[()()]]<<()>[{}[]]>))}>)<{({{<[[][]]{()()}><<{}{}",
"{[<(([([{({([({}()){<><>}][((){})([]())])[<<()<>>(<>())>{[[]()}(()[])}]}<{{<(){}>{()[]}}((<><>){{}<>})}((",
"{(({([[{{((([<()()>([][])]<<{}[]>[<>]>)(<{<><>}[{}{}]>[[<>{}]]))[{<<[][]>[()]><[{}{}]>}{<([]<>)([]<>)>}]",
"(({[[<<<{[{([(<>[])<()[]>])(<([])({}{})>)}[{(<<>{}>({}<>))}<<[<>[]>[(){}]>(<{}{}>)>]]{([[<<>()>",
"[{[[{([({[{(({()[]}[[]<>])<[[]<>]([])>)([{{}{}}[{}[]]]<{{}<>}>)][<(<<>[]>{<><>})<(()<>){[][]}>>[[{[]{}}([]())",
"([[{({([({<<(<[]<>>)[{()[]}<<>()>]><<{<>()}<<>[]>>[[<>{}]<<><>>]>)<<<<<>[]><<><>>>[[[]]]>[{",
"[{{([(<[[<{((([]{})[()()])[<[]{}>[<>()]])<[{()()}(<>{})]({[]}[<>{}])>}((<{[]()}>)({<{}{}>[",
"[[[{{[[[<<(<(({}())[<>{}])<{{}<>}(()())>>[[((){})][[[]{}]{()}]])>>{[(<([{}{}]({}<>))([{}()]<<>[]])>({<",
"{<{({(({{{[{<(<>{})>{<{}<>>(<><>)}}<(<[]()>[[][]])<[{}()]>>]<{{<()[]>{{}()}}{<{}[]>{{}{}}}}{{<()<>><<>",
"[{[<{[<<({(<{{<>()}({}<>)}<(<>[])[()()]>>{{{<>()}{()[]}}})<{<({}()){<>{}}>({<>[]}({}())]}>}(",
"[[{<([((({([{{()[]}<[]{}>}({<>[]}[<><>])]{{<[]<>>[<><>]}[{()()}[<>[]]]})}[{[<{()()}(<>))<({}){()<>}>]([",
"(<(<{[{<({[{{{[]()}({}{})}{<{}[]><<>{}>}}]})>}<{[[(<[<[]{}>([]())](<{}>[()()])>)][(([{[]<>",
"<<<<{<{<<[<({<[]>({}<>)})<[{[][]}[[]()]][[{}<>]<{}[]>])>([(([][])[[]()])<[{}[]]{[]{}}>](<[{}()]{{}()}",
"({[[([([<{[[({()[]}[<>[]])[<[][]><<>{}>>][(({}{})(<>[])){(<>[])}]]<{{{{}()}[<>[]]}<[[]<>]([]())>}>}{<{({",
"((<{<{{[((<<<(()<>)<[]{}>>[<[][]>[(){}]]>>)){([[[[<>]({}<>)]{{{}<>}([]{})}]<[<<>()>(()())][{[]{}}{[]<>}]>]",
"{<<{{[({[<{{(<{}[]><<>[]>)([[]()])}<[{{}{}}{<><>}]<({})<{}()>>>}<[([{}<>][<>{}])](<<{}[]><<",
"{[{[[<<[(({[(((){}){<>[]})]([[<>[]]][<<>{}>[<><>]])})({<[({}[])<{}[]>]>}<(<(()<>)[[]{}]][[()()][<><",
"((<<[({<{[[({<[]()>([]())}[<[]{}>(()<>)])]<<{[{}[]][<>()]}><<{<>[]}[()<>]>[<[]{}>{[]()}]>>][(({[<>",
"{{<[{<([({{([<<><>>{{}()}][<[][]>{[]()}])[<[[]]{[]<>}>]}(({<()[]>[{}()]}<[[]<>]{<>()}>))})])<{[{<[<[{}{}]",
"[(({({[[<{(<{{<>[]}[()<>]}((<>{})<<>[]>)>{[<(){}>{{}<>}]])[<{(<>[]){{}[]}}([()()][<>[]])>((({}())",
"{(([<{([[{([<<{}()><[][]>>[(<>()){()[]}]]<[<()()>[{}]]([{}<>][{}[]])>){<{[[]<>]<<>{}>}{([]{})}>[([",
"<{[{({([(<<{<[()<>]<(){}>>(<()>{[][]})})>{[([<{}{}>[<>()]])[{([]()){<>{}}}<<{}<>>>]]})])([<(([{<(){}>[{",
"<<<(([<[{[[<{({}()>{[]()}}>]]([<[[()][{}[]]]<[()()]{(){}}>><<({}[])(()<>)>{(()[])}>]{[(<[]()>)[{[]{}}",
"(({(([[<{(<{[(<>[]]]}<(({}{}))([[][]]([][]))>><[{(()())[()<>]}<{(){}}>]>)((<{{()[]}{<>()}}<([",
"[[[{<[{<[<[[{(<>{})<[]()>}{(()[])[<>()]}][<({}()>[<><>]>{<[]{}><[][]>}]]><<{[{(){}}{{}{}}][<<><",
"((([<<((<[{(([<>[]]([]{}))([<>]{<>()})}([[(){}][[]()]][(<><>){{}()}])}{[<[()<>]({}<>)>[<{}{}>]][<(<>())<[]",
"{<<{([(((([{<[()]{(){}}>{{{}[]}}}[{(()[]){()<>}}{<<>>[<>{}]}]]<[{(<>())(()[])}]>){[[<({}{})[()[]]>{[{}(",
"([{(({([([(<<{<>[]}<{}<>>>[[[]{}]<[]{}>]>((([]<>)<<>[]>)[[(){}]]))[<{{<>{}}}[(<>}{()()}]><{<<>{}><",
"{(<[<{({([{{([[][]]>({()()}[[][]])}[<(()())([]())><(<><>)([]{})>]}[(({{}{}}{{}<>})([<><>]<()[]>))]",
"((<(<<{{{{<{{(()<>)({}{})}{{<>[]}<()[]>}}<<<[][]>(()[])>[[()[]][[]()]]>>[[{{[]{}}[[][]]}][<[()[]]{[]<>}>",
"(((<(<<<{{<{<{{}{}}(()<>)>[((){})[()[]]]}{[[<>[]]{{}()}][{()[]}({}{})]}>}}>{[{<<{[{}()]}<[[]()]",
"({(([[<{[{<(([[]()](<><>))[<{}[]){{}()}])(<[()[]]<[]()>>[<{}<>>[()<>]])>[<[[()()]<<>[]>][([]())([]{})]>{{<<>(",
"[[(([((([<[[<{{}<>}({}[])>[([]<>)[()[]]]]<[(()())({}<>)](([]<>)<[]()>)>]>[{{{(()<>)}<{[]()}",
"(<(({[<<{((<[[[]()]{{}<>}]<<{}()>({}[])>>)<{{({}){()()}}<{[][]}>}>){[(<<[]<>>[{}{}]>{{(){}}{[",
"{<(<(<<{<(<{{[{}[]]([]{})}([{}[]](<>))}[([<>()]{[]{}})<({}<>){<><>}>]>[{<[[][]]>}[<[<><>](()())>(([",
"{(<(<{<(<<{{{<(){}>}({[][]}{{}{}})}}<(<<<>()>[(){}]>(<{}()>{{}}))>>[{{[{[]{}}(()[])]}[((<>())<<",
"([((([[{([{<<((){})>{{<>}{[]()}}>{[((){})<()[]>]<{[]{}}[(){}]>}}{((<{}()><{}>)){{<{}[]>[[]",
"{{{(<<{((([[{(<>{})({}())}[<[]()>({}{})]]<<[{}]>{[[]()]{()[]}}>]{({<()[]>((){})})<{<[]<>>{{}{}",
"(<<[[([{{(<<({{}}[{}{}])<([]{}){<>()}>>>(({<()()>({}[])}<<{}()>[(){}]>)))[{([{<>[]}([]())]([()()][<>{}])){",
"<(<(<<<([[[(<{{}[]}{{}[]}>[[<>()]{()[]}])]<{({{}()}{{}<>})<({}[])([]<>)>}{(({}[])(<>{}))((()<>)<[]()>)}>](<",
"<<{(([<([[[[<{<>()}({}[])>{((){})[{}()]}]}[<{<<>[]><[]<>>}<[{}<>]{{}()}>>{{(()())[()[]]}{<()<>",
"(({<<[{([{<(([{}[]][(){}])[<[]()>(()<>)]}>}<[(<{{}()}{{}<>}><[[]()][[]()]>)]<(<(<>())>({<>[]})){[{(){}}<{}{}>",
"({[[{[{{<(([[[{}{}]<(){}>]((()[])(()[]))]({([]<>)({}{})}{<<>{}>{<>}}))<{(<[]{}>(()()))[[()[]](<><>)",
"([{[{{<{{(<[((<>){[]()})(({}())[<><>])]>({[(<><>}{{}[]}]{(()[])[()]}}{([[]{}](<><>))<<{}[]>(<>())>}))",
"<[(([[[<{[[(({()[]}<<>[]>){{<><>}<(){}>})<([()]{<>[]}){{<>{}}}>]]<[{{([]())({}{}>}<{[][]}<<>{}>",
"({(<{<([[<{[<{[]()}[{}<>>>[[(){}][[]{}]]][{[()<>][<><>]}{<()()>}]}<({{(){}}<()()>}{[<><>](<>())})[(",
"([({<[<[{({<<[<>{})[<><>]>{{[]{}}}>[[{()<>}([]{})](({}<>)<<>>)]}<{<<<>>{()[]}>}<{<[]()>}>>)(<<<{",
"({<{[[({[([{[{[]{}}{[]<>}](((){})({}()))}]([<{<>{}}{()<>}>{({}{})(()())}])}]<{({{<()[]>{()}}",
"({[[{[((<[[[{<<>[]>(<>[])}]]{<({{}[]}){[{}{}]<<>()>}>[([<>()]{{}()})(<()()><<>[]>)]}]>(<([{<[]{}>(()())}<{[",
"[<<<{<({({{<{[<><>]{{}<>}}{<(){}>}>}})})[<<[{[{({}{})<<>>}[{[]}(()())]]{{([]())([]())}{({}[])[<>",
"<<<[[((<{{<(((<>[])(()))<<<>()><<>{}>>)<[{<>[]}{(){}}]{[{}]({}())}>>}}[[((({()}{[][]}){<{}[]>}",
"(<[<({[[{[<<[(<>[])]([[]<>]<[]{}>)>({(<>[])([]())}<[{}<>)<<>{}>>)>[{<[[][]]><[{}<>]<[]()>>}<<[",
"{[({<<<<(<([{{[][]}}]{<{<>()}<<>()>>[({}())<[]{}>]})>)>>><<<{{((([{}[]]<<><>>)[[[][]]({}[])])<{<{}{}>(",
"[[[({((({<([({[][]}{[]})<({}[]}[{}{}]>][([[]()]([]()))<<()<>>>])<[<<()[]><()[]>>]>>([<<{[]()}{[][]}><",
"[{{<<<({<({(<<<><>>>{(<>[])[<><>]})<(<<>{}>(()()))[{{}()}{(){}}]}}[(<{[]()}<[]<>>>({<>{}}[{}",
"([<<{<[{([<[<{<>{}}<[]{}>><([][]>>][{([][])[()()]}<<[]<>>>]>][{<({<>()}<[][]>)[[[]<>]{()<>}",
"({<<[<(<<<(<((()<>)<{}<>>)>)<<([<>{}][<>[]])<<()()>({}[])>>([(()())(()<>)]{{{}<>}<[]{}>})>>>>[",
"<{[{<[[<[(<{({<><>}{[]<>}){<[]{}><()>}}({({})[[]{}]})>{(<{[]<>}{<><>}>([{}[]]{<><>}))(<<{}()>[",
"<{{<[[({{{<({<[]()>[{}[]]}<{<><>}{()<>}>)[<<[]{}>{{}<>}>[<<>[]>((){})]]>}}(<[[(([][])[{}<>]){(()<>)[()[]]}]((",
"[{[{<[(({{({<{{}{}}<()()>>(<[]<>>{<>[]})}(<<()[]>{()<>}>))<<<[{}{}]<<>[]>>>[[{[]{}}]((()<>){<>",
"{[[<{({[<(<((<{}[]>){[{}[]]})[{[{}{}]({}())}]>(<{{()<>}(<><>)}[(<><>)<[]{}]]><{<()[]>([][])",
        };
    }
}
