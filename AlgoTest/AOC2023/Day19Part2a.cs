﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

[TestClass]
public class Day19_Part2a
{
    [TestMethod]
    public void Test()
    {
        var lines = data.Split('\n', StringSplitOptions.TrimEntries);
        var result = SolvePart2(lines);
        Console.WriteLine(result);
    }

        public static long SolvePart1(IEnumerable<string> input)
    {
        var startParsingRatings = false;
        List<Part> parts = new();
        Dictionary<string, IEnumerable<Func<Part, string>>> workflows = new();

        foreach (var line in input)
        {
            if (startParsingRatings)
            {
                parts.Add(ParseRatings(line));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    startParsingRatings = true;
                    continue;
                }

                var (name, funcs) = ParseWorkflow(line);
                workflows[name] = funcs;
            }
        }

        var sum = 0;
        foreach (var part in parts)
        {
            var output = SimulateWorflows(part, workflows);
            if (output is 'A')
            {
                sum += part.X + part.M + part.S + part.A;
            }
        }

        return sum;
    }

    public static long SolvePart2(IEnumerable<string> input)
    {
        Dictionary<string, IEnumerable<string>> workflows = new();

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var (name, rules) = ParseRules(line);
            workflows[name] = rules;
        }

        long sum = 0;

        var q = new Queue<State>();

        q.Enqueue(new State("in", (1, 4000), (1, 4000), (1, 4000), (1, 4000)));
        List<State> items = new();

        while (q.Any())
        {
            var s = q.Dequeue();
            var (curr, xRange, mRange, aRange, sRange) = s;
            if (curr == "R")
            {
                continue;
            }

            var (xLow, xHigh) = xRange;
            var (mLow, mHigh) = mRange;
            var (aLow, aHigh) = aRange;
            var (sLow, sHigh) = sRange;

            if (curr == "A")
            {
                sum +=
                    (long)(xHigh - xLow + 1)
                    * (mHigh - mLow + 1)
                    * (aHigh - aLow + 1)
                    * (sHigh - sLow + 1);
                continue;
            }

            if (xLow > xHigh || mLow > mHigh || aLow > aHigh || sLow > sHigh)
            {
                continue;
            }

            var workflow = workflows[curr];
            // Console.WriteLine(string.Join(',', workflow));
            foreach (var rule in workflow)
            {
                (xLow, xHigh) = xRange;
                (mLow, mHigh) = mRange;
                (aLow, aHigh) = aRange;
                (sLow, sHigh) = sRange;
                var ruleArr = rule.Split(':');
                if (ruleArr.Length == 1)
                {
                    q.Enqueue(new State(ruleArr[0], xRange, mRange, aRange, sRange));
                    continue;
                }

                var comparison = ruleArr[0];
                var compared = comparison[0];
                var op = comparison[1];
                var comparedTo = int.Parse(string.Join("", comparison.Skip(2)));
                var outcome = ruleArr[1];

                State state;
                if (op == '>')
                {
                    switch (compared)
                    {
                        case 'x':
                            state = new State(
                                outcome,
                                (comparedTo + 1, xHigh),
                                mRange,
                                aRange,
                                sRange
                            );
                            xRange = (xLow, comparedTo);
                            break;
                        case 'm':
                            state = new State(
                                outcome,
                                xRange,
                                (comparedTo + 1, mHigh),
                                aRange,
                                sRange
                            );
                            mRange = (mLow, comparedTo);
                            break;
                        case 'a':
                            state = new State(
                                outcome,
                                xRange,
                                mRange,
                                (comparedTo + 1, aHigh),
                                sRange
                            );
                            aRange = (aLow, comparedTo);
                            break;
                        case 's':
                            state = new State(
                                outcome,
                                xRange,
                                mRange,
                                aRange,
                                (comparedTo + 1, sHigh)
                            );
                            sRange = (sLow, comparedTo);
                            break;
                        default:
                            throw new Exception("OOPS");
                    }
                }
                else
                {
                    switch (compared)
                    {
                        case 'x':
                            state = new State(
                                outcome,
                                (xLow, comparedTo - 1),
                                mRange,
                                aRange,
                                sRange
                            );
                            xRange = (comparedTo, xHigh);
                            break;
                        case 'm':
                            state = new State(
                                outcome,
                                xRange,
                                (mLow, comparedTo - 1),
                                aRange,
                                sRange
                            );
                            mRange = (comparedTo, mHigh);
                            break;
                        case 'a':
                            state = new State(
                                outcome,
                                xRange,
                                mRange,
                                (aLow, comparedTo - 1),
                                sRange
                            );
                            aRange = (comparedTo, aHigh);
                            break;
                        case 's':
                            state = new State(
                                outcome,
                                xRange,
                                mRange,
                                aRange,
                                (sLow, comparedTo - 1)
                            );
                            sRange = (comparedTo, sHigh);
                            break;
                        default:
                            throw new Exception("OOPS");
                    }
                }
                q.Enqueue(state);
            }
        }

        return sum;
    }

    public readonly record struct State(
        string Current,
        (int, int) XRange,
        (int, int) MRange,
        (int, int) ARange,
        (int, int) SRange
    );

    public static char SimulateWorflows(
        Part part,
        Dictionary<string, IEnumerable<Func<Part, string>>> workflows
    )
    {
        var currentWorkflow = "in";
        while (true)
        {
            var flow = workflows[currentWorkflow];
            foreach (var step in flow)
            {
                var res = step(part);
                if (res == "A")
                {
                    return 'A';
                }

                if (res == "R")
                {
                    return 'R';
                }

                if (res == currentWorkflow)
                {
                    continue;
                }

                currentWorkflow = res;
                break;
            }
        }
    }

    public static (string, IEnumerable<Func<Part, string>>) ParseWorkflow(string line)
    {
        var (name, rules) = ParseRules(line);

        List<Func<Part, string>> funcs = new();
        foreach (var rule in rules)
        {
            var ruleArr = rule.Split(':');
            if (ruleArr.Length == 1)
            {
                funcs.Add((Part p) => ruleArr[0]);
                continue;
            }

            var comparison = ruleArr[0];
            var target = int.Parse(string.Join("", comparison.Skip(2)));
            var outcome = ruleArr[1];

            funcs.Add(
                (Func<Part, string>)(
                    (Part p) =>
                    {
                        var partRating = comparison[0] switch
                        {
                            'x' => p.X,
                            'm' => p.M,
                            'a' => p.A,
                            's' => p.S,
                            _ => throw new Exception($"Hi {comparison[0]}")
                        };

                        if (Compare(partRating, target, comparison[1]))
                        {
                            return outcome;
                        }

                        return name;
                    }
                )
            );
        }

        return (name, funcs);
    }

    public static (string, IEnumerable<string>) ParseRules(string line)
    {
        var lineArr = line.Split('{');
        var name = lineArr[0];
        var rules = lineArr[1].Replace("}", "").Split(',');

        return (name, rules);
    }

    public static Part ParseRatings(string line)
    {
        var arr = line.Split(',');
        var x = int.Parse(arr[0].Split('=')[1]);
        var m = int.Parse(arr[1].Split('=')[1]);
        var a = int.Parse(arr[2].Split('=')[1]);
        var s = int.Parse(arr[3].Split('=')[1].Replace("}", ""));

        return new Part(x, m, a, s);
    }

    public static bool Compare(int a, int b, char comp)
    {
        if (comp == '>')
        {
            return a > b;
        }
        if (comp == '<')
        {
            return a < b;
        }

        return a == b;
    }

    public readonly record struct Part(int X, int M, int A, int S);

    private string data = """
                            vvd{a<3062:hrj,x>1762:zgl,s<881:dlf,A}
                            ckk{s>862:R,a>3127:A,A}
                            th{a<3804:jjp,a>3923:mfp,a<3866:ck,fgv}
                            sm{m>453:A,s<2996:R,A}
                            gj{x>1334:R,R}
                            szs{m>3306:A,a<2977:A,A}
                            hk{m<2759:tbr,s>3402:A,cn}
                            hrj{s>993:R,R}
                            gd{m<1654:pb,zk}
                            zb{x>2892:R,R}
                            qd{x>926:R,s>1347:A,s<1075:R,R}
                            gb{a<3731:tt,x<2259:tdk,qxg}
                            nh{a>1660:A,a<1559:A,A}
                            qb{x<952:A,a<824:R,A}
                            hb{x>958:R,R}
                            tl{s>3339:glg,m>3104:R,bx}
                            dv{a<3358:A,A}
                            kgt{a<2746:R,s<590:A,x<961:R,A}
                            fgv{m>1968:R,pcs}
                            kzc{x>1543:R,x<1255:lrn,lb}
                            pz{m>3096:R,A}
                            fbq{m<3544:fq,sdh}
                            vp{m>1213:qgj,a>2889:dn,m>629:A,tk}
                            cpv{s<1222:R,a<3006:A,m>485:R,R}
                            cm{s>1201:vbl,x>1442:lv,ff}
                            ms{x>1035:R,A}
                            nqf{a>3776:A,x<2712:R,A}
                            tns{m<512:A,R}
                            ddj{x<982:A,R}
                            lkm{s>1761:A,x<3406:R,A}
                            rgv{x<1838:R,A}
                            kk{a<3285:A,m>3883:A,a>3614:A,R}
                            sb{a<2998:A,x>1425:R,m>399:A,A}
                            psn{s<2782:R,a<2995:R,A}
                            xn{s>2939:slq,m>2356:fgs,rj}
                            flx{m>502:A,x<3413:A,s>1324:A,A}
                            hqb{a>2426:tx,s<3349:A,R}
                            tq{m>1617:dvq,x<2295:jsh,a<3368:rzc,qms}
                            cn{s>3099:R,A}
                            lft{m>726:R,m>598:A,R}
                            kt{a<2349:tdv,x>1126:hnz,bps}
                            qms{m<1499:lvq,a>3479:R,R}
                            ns{s>1283:R,A}
                            cj{m>3441:ql,m<3391:A,R}
                            rcm{x<1000:R,lrz}
                            tqd{x>1200:A,A}
                            lkc{m<1761:A,A}
                            gzf{x<3613:A,a>2771:R,A}
                            nzt{a>306:A,s<973:R,A}
                            fth{m>355:R,s<3285:R,A}
                            cmg{a>3790:R,m>1001:R,A}
                            vhf{s>1126:A,a<3520:tsb,R}
                            mpm{m>869:qh,a>3099:zq,dff}
                            lq{x<2632:zpc,tct}
                            dlf{m>1614:R,m<1126:A,A}
                            bkk{s<3105:mqs,sg}
                            tct{s<984:gnm,m>1073:jfz,s>1514:dc,xj}
                            lv{a<239:A,A}
                            fb{m>2007:R,A}
                            fpj{s<1828:xz,zt}
                            kl{s>2400:A,x>1193:A,x<671:A,A}
                            jb{s>796:qt,zn}
                            qs{x>2260:A,a<3886:jxg,a<3903:pt,A}
                            tc{a>2840:rqp,m>1035:vl,hq}
                            fss{s>1221:fld,m>1250:hvc,rg}
                            qkd{x<3277:A,R}
                            scm{a>3604:A,x>2828:gtl,s<3136:nn,R}
                            lxd{x>1459:R,s<2218:R,m<1488:A,R}
                            qvl{a>2241:zsv,a>2125:R,R}
                            ttb{x<1466:bfr,R}
                            zbk{m<464:A,s<3379:R,R}
                            xv{s>494:A,R}
                            pld{m<2671:R,a>3092:R,A}
                            zjm{a<3448:A,A}
                            pd{s<2953:rm,szc}
                            tfn{s<719:dh,m>343:bgz,bn}
                            ktl{s<2776:dp,s>3093:mfv,a>2897:fm,pd}
                            pnh{a<239:A,x<3185:R,R}
                            rrc{m>1995:A,s<1027:A,A}
                            nzp{s<2226:A,a>2676:A,A}
                            tzf{a<3801:A,m>841:cgp,R}
                            zp{m>158:A,A}
                            pr{x>2833:txv,x<2596:jf,a<3047:fj,np}
                            rjl{a<2122:R,m<1656:R,m>1865:R,A}
                            zx{x<1497:A,A}
                            vtf{m<1214:R,R}
                            tzk{x<3013:R,s<3078:ss,s>3545:tb,tpm}
                            ffj{x>1221:R,A}
                            tkx{a<2272:R,x>915:R,A}
                            dg{a<3554:A,m<929:vsm,hqx}
                            lf{s<1049:R,R}
                            kpz{a<2829:dsg,m<3108:R,m<3701:bp,kk}
                            qf{s<635:jd,a>1648:qmt,fd}
                            gsn{s<3722:A,s>3839:km,vqb}
                            txv{m<3809:A,R}
                            jrm{a<292:R,m<840:R,x<3311:A,R}
                            zbg{a>538:A,m>1824:pnh,jrm}
                            lmk{s<809:A,a<3296:R,A}
                            rv{s<2680:A,s>2808:sr,x<1735:hhm,R}
                            xc{m<2865:xn,bd}
                            dzj{s>1477:R,x<2248:A,a<3592:R,flx}
                            zpc{a>608:pv,x<934:sx,m<1037:cl,dj}
                            pvz{a>2770:A,A}
                            gr{a>462:R,m<2929:A,A}
                            zq{x<1166:tfn,m<571:fjm,s<1013:jss,qx}
                            kp{s>355:md,m<2930:cc,nj}
                            jz{x<987:gzx,rl}
                            pp{x<3704:A,s>3206:R,m<3115:A,A}
                            bcn{s>2021:A,m<1423:A,R}
                            qtk{x<1430:R,x<2500:A,A}
                            vsm{x<2477:R,R}
                            vmb{m<1207:tns,jrn}
                            lvq{s<810:A,s<1122:A,s<1245:A,A}
                            khs{x>2121:xvq,A}
                            ngj{s<399:R,A}
                            ss{s>2610:A,x>3640:R,s>2396:R,A}
                            kbz{x<1704:A,a>3333:R,a<3253:A,A}
                            mks{x<3622:A,x<3764:R,a>3793:A,A}
                            mx{a>1771:A,R}
                            nf{a<1730:R,x<3361:R,s>1633:A,A}
                            sx{s<1067:R,x<583:bm,x<742:mcm,A}
                            gjk{a>2935:A,x>3630:A,s>1501:R,R}
                            gk{x>1901:pcd,s>1977:fpf,lqr}
                            hz{s>2381:R,s<2154:A,R}
                            nht{s>1162:A,m>558:R,x>2991:A,R}
                            pll{m>1200:sgn,x>395:phg,a>2429:xd,A}
                            bj{x<1510:ks,s<729:jlm,gfx}
                            xr{m>488:R,A}
                            tfh{m>864:R,m<433:R,m>662:A,A}
                            hfd{x<3738:R,R}
                            cjt{a<2997:A,s<1260:tvq,m>1403:xm,R}
                            kb{s<1000:A,s>1542:A,A}
                            lsf{x>1237:fqk,A}
                            mmv{x>3617:R,s<1009:mq,ns}
                            bfr{x>951:A,s>1265:A,R}
                            pb{a<1607:zgf,kg}
                            jts{a>2338:vsj,x>1160:A,a>2097:zp,A}
                            zmz{x<1333:R,a>2919:R,a<2898:R,A}
                            ql{s<2765:A,s>3539:R,a>2246:R,R}
                            fqz{m>313:dl,R}
                            bdt{m<2707:pld,lrr}
                            vrj{a>3214:scm,zv}
                            hkq{s>2374:sz,A}
                            lp{s<1125:thr,sfr}
                            kbh{s>3110:jcg,s>2776:R,m<1890:A,R}
                            tk{x>916:A,x<350:A,R}
                            xkq{a>3056:R,psn}
                            sgz{a>579:A,x>2261:pc,m>3185:kzq,A}
                            vd{x<3081:fsx,s>2036:dth,gkg}
                            sr{s>2908:A,x>2436:A,x>1169:R,A}
                            zm{m<3770:gzf,m>3888:R,nvh}
                            kcs{x<3636:pkt,a<2781:hlg,x>3835:xsj,xr}
                            tg{s>2776:R,R}
                            dp{a>2961:R,A}
                            gh{a<2396:R,m>972:R,x>3211:gpb,xp}
                            sk{m<1280:A,A}
                            bc{x<2841:A,a>1557:A,s<385:R,R}
                            thf{a>3106:A,x>3631:A,s>1037:A,A}
                            nn{m<2491:A,R}
                            vhc{a<3571:nmk,rjb}
                            pcz{s<275:R,a>2784:R,A}
                            jgv{x<1067:vhf,lp}
                            vvf{a>2403:R,R}
                            jsh{a>3401:A,A}
                            vbp{x<2776:R,s>3492:R,m<2655:R,A}
                            ctl{m>1709:R,x>1436:R,a>3348:R,R}
                            xrb{a<2649:R,x<934:A,A}
                            gs{m>2043:A,x<3011:R,x>3230:R,R}
                            rg{s<670:A,s<957:R,A}
                            bl{s<1524:vx,s>1654:A,s<1601:A,nf}
                            gfx{a<3594:A,s<974:R,A}
                            kxl{s<1519:R,s>1562:R,A}
                            ds{a<3168:A,A}
                            fcp{s<2341:R,m>297:R,A}
                            glb{s<2066:R,a<3736:A,a<3870:R,R}
                            fvx{x>263:A,A}
                            mt{s>625:R,a<1776:A,s<217:R,A}
                            qzv{m>1080:R,A}
                            thr{a<3487:A,s>505:R,a>3759:A,R}
                            tsb{a<3152:A,m<2461:A,a<3391:R,R}
                            fsm{m<561:R,a<2786:A,R}
                            jzs{a<3752:A,x<1950:xf,m<1782:R,fs}
                            kxk{m<570:A,R}
                            zv{a>2688:R,s>3118:vbp,R}
                            xcp{m>644:R,s<2394:A,m<338:A,R}
                            lt{a>3140:ds,thf}
                            cxt{a<3625:scz,tzf}
                            qp{a>2830:zz,m>1424:zbp,sk}
                            vb{s<3582:A,s>3789:R,A}
                            rh{x>799:R,s>3176:A,R}
                            hzq{x<2680:R,A}
                            jmm{s<1119:bj,m<680:pq,x>1590:dkd,bgc}
                            vtg{s>3299:gj,s>2431:zx,A}
                            dfq{s>1634:lkm,a>3475:mks,kxl}
                            dcr{s>1739:A,A}
                            bnn{a<207:R,x>446:A,m>3421:xdp,gr}
                            hqx{a>3731:A,R}
                            xd{s<3275:A,a<2588:R,m>437:R,R}
                            dth{m<702:fqz,xtr}
                            vnj{a>3383:A,m<1784:A,s>1539:R,R}
                            dl{a>2976:A,s<3191:R,A}
                            fv{x<3335:vrj,qkm}
                            pg{x<1444:R,m>2004:R,A}
                            ck{m>1984:kcq,m>1942:qtk,R}
                            zz{m<1305:R,A}
                            pbc{m>226:A,s<1134:R,A}
                            kx{m>1355:vhc,gn}
                            grr{m>2230:lzz,x<3328:A,s<1205:hc,cr}
                            nj{x>1430:R,s>185:A,A}
                            ltb{a>597:tj,x>970:cm,bnn}
                            qnn{x>3342:R,x>2644:R,R}
                            mfp{s>1123:R,m>1993:ft,R}
                            zgf{s>2601:A,m<973:A,tzx}
                            nvh{a>2945:A,R}
                            qxg{x>2968:xcp,A}
                            bn{m<149:R,x>731:R,A}
                            dqk{s>1560:R,s>534:A,A}
                            mg{s>2297:rv,pgf}
                            qt{s>1334:A,s<1018:R,R}
                            hc{s>459:R,m<812:R,a>1440:R,A}
                            fld{x>3004:R,A}
                            jd{x>2634:bc,s>234:R,a>1560:A,A}
                            ndr{m<1486:R,s>1539:dcr,R}
                            jvl{a<3475:A,s>2038:A,A}
                            dkd{x<3070:dg,s>1405:dfq,lfp}
                            sg{m>1909:A,x<914:R,m<1778:R,R}
                            khh{x<1396:R,a>3708:A,s>383:R,R}
                            mb{s>1878:ftc,kpz}
                            in{a<1965:fpj,m>2060:vh,a<3206:pdl,kx}
                            gn{s>1904:qkj,jmm}
                            gnm{x<3102:A,m<1222:kjn,gp}
                            ps{m>1681:hg,s>2179:qp,m<1433:fss,sd}
                            zn{a<975:A,a>1069:A,x<3304:R,R}
                            hhm{m>1630:A,m>617:A,m>333:A,A}
                            gz{x<1706:A,s<2485:R,R}
                            zpx{m>725:zss,xkq}
                            fsx{s>2295:skb,bkr}
                            scz{s<3285:dv,A}
                            jsj{x<3085:A,x<3686:R,A}
                            xsj{a<2827:R,x>3904:A,A}
                            gzq{m>810:A,a>827:R,s<3297:R,A}
                            bb{x<2959:A,dz}
                            vbl{m>2965:R,A}
                            dmt{m>1732:hd,s>2127:R,jvl}
                            lrn{x>1164:R,R}
                            smp{x>3224:R,s>1268:A,m<2046:A,A}
                            pc{s>693:A,A}
                            kpx{m>1878:A,m>1807:R,x>928:R,R}
                            glj{a>1711:R,a>1631:A,A}
                            qk{m>1185:R,xrb}
                            bdp{a<2516:lsf,a<2625:xk,a<2678:qk,tfh}
                            czn{a<2241:fxp,x>3789:R,s<3133:rsm,A}
                            ks{x<999:xv,x>1311:khh,R}
                            bkr{x<2429:mc,m<484:A,m<850:lft,R}
                            brl{s>1349:xg,gh}
                            bx{x>1197:A,a>1427:R,s<3095:A,A}
                            fhz{a>2435:A,m>3386:A,A}
                            rl{a<3051:nsq,R}
                            tr{s>1784:A,s>1693:A,m>190:A,A}
                            mkj{x<1486:A,m>3363:A,a>1667:R,A}
                            nb{a>1464:R,a>1365:jth,R}
                            kzq{m>3512:R,A}
                            kz{x>553:R,m>1531:A,m>1423:A,A}
                            gl{a<2776:kgt,R}
                            xpt{m<249:R,m>335:A,a>3718:A,R}
                            zbp{a>2789:A,m<1574:A,s>3020:R,A}
                            mfv{a>3208:A,x<1280:fhz,rf}
                            qpn{x>3117:A,s<1302:A,a>2683:fjl,xnt}
                            qm{a<2927:ps,tn}
                            pt{a<3892:R,a<3898:R,R}
                            hks{x>2521:A,s<483:R,A}
                            md{x<1323:R,R}
                            jct{x>1059:gpl,a<2740:qv,mj}
                            bt{m<1666:R,s>1464:A,m>1696:R,R}
                            dsg{x<3064:A,A}
                            nsk{x>3173:R,spq}
                            qr{m>521:R,s>377:R,R}
                            qqq{x<378:fg,m>2497:R,A}
                            tj{a<935:jj,m>3383:A,a>1076:R,R}
                            glg{a<1551:A,m>3175:R,R}
                            cc{x<939:R,s<224:A,R}
                            rk{s<1079:A,x<2703:A,A}
                            dc{x<3243:R,a>568:R,jc}
                            bcp{x>686:hqb,pll}
                            pft{m<912:vnn,dm}
                            kfr{s>3103:nsk,x>3254:zm,pr}
                            xvq{a>3436:A,m<1515:A,m<1586:R,R}
                            bd{s<3314:ktl,jz}
                            km{s<3941:A,m<418:R,A}
                            sj{s>3320:R,m<735:A,R}
                            jrn{m>1587:R,A}
                            tx{a<2594:R,m<987:R,R}
                            dj{m>1535:rrc,x<1518:xh,R}
                            zgl{s>843:R,a>3152:R,m>1357:A,A}
                            mfq{m>378:R,R}
                            szc{s<3003:A,m<3402:R,m>3709:A,R}
                            vnn{x<979:fdn,a<2498:A,a>2632:A,A}
                            xkc{m>3553:kfr,pk}
                            rzk{m>386:R,A}
                            tbl{a<3119:A,m<1094:A,a>3172:A,A}
                            sgn{s>3270:R,s<3159:R,x>306:R,A}
                            kdh{x>1392:A,s<2174:gsg,m>2235:R,nzp}
                            fg{x>157:A,x>87:R,A}
                            dn{x>1120:R,A}
                            zss{a<3072:A,s>3213:A,vtf}
                            gsg{m>2239:A,x<588:R,a>2666:R,A}
                            jfz{m<1831:R,x>3533:jh,s>1453:gs,smp}
                            phg{s>3312:R,m<723:R,m>941:R,A}
                            cb{a>2536:A,s>812:pm,ngj}
                            mf{m<1593:A,x<529:R,R}
                            fhr{x>1106:R,x<386:A,x<798:kz,pcz}
                            ml{s<1370:R,R}
                            zd{s>1589:A,a>1448:R,a>1311:A,lrh}
                            xm{s<1627:R,a<3035:A,s<1799:R,A}
                            sgs{x<3304:mt,x<3393:A,glj}
                            ttv{x>3479:nb,a<1580:grr,s<1026:sgs,bl}
                            xp{x>3128:R,a>2555:R,R}
                            jx{s<2054:A,A}
                            bjd{s<818:A,R}
                            tzx{a<1332:R,m<1279:A,a<1434:R,A}
                            mj{s<2372:A,s>2416:R,A}
                            dh{s<467:A,m<418:A,m>634:A,R}
                            fj{x<2703:A,x<2772:R,m<3838:R,A}
                            jxg{x>909:A,s>2752:A,s<2236:R,A}
                            bfs{m<1689:R,m>1872:A,A}
                            dz{m>3210:A,x>3525:R,A}
                            mcm{a>283:R,a>116:R,a>49:A,A}
                            dqr{m<1356:ckk,s>1025:nmm,a<3125:ffj,A}
                            tbr{m<2367:R,x<2937:R,A}
                            rsm{x<3615:R,x>3713:R,m>909:A,R}
                            rm{m<3439:R,A}
                            fmb{s>2014:nr,a<2950:hm,mpm}
                            pq{m<400:knp,dzj}
                            lsk{m<322:R,s>2264:R,R}
                            zsv{m>713:R,R}
                            mk{a<2676:R,R}
                            knp{s>1623:tr,s<1355:xpt,ssk}
                            bmv{a<3815:qnx,m<1902:vtg,a<3932:qs,dmk}
                            hlg{a>2740:R,m>464:A,R}
                            pn{s>759:A,m>1519:R,A}
                            qnx{x<1888:R,A}
                            nmm{x<1288:R,s<1542:A,A}
                            ff{a<305:A,R}
                            rt{m<1666:khs,x>1599:kbh,bkk}
                            bgz{x<430:A,x<824:A,A}
                            hm{a>2828:ksr,m>1357:mhl,rnt}
                            fdn{x<359:R,A}
                            hq{a<2800:fth,x>1082:A,s<2977:R,zbk}
                            xh{a<267:R,m>1348:R,a<492:R,A}
                            rf{a<2730:R,a<3039:R,R}
                            pl{m>2474:mkj,a<1456:A,nh}
                            hrg{m<3582:A,x<1494:R,x>2002:R,A}
                            kn{x<2826:sgz,a>638:jb,x<3390:ccz,mmv}
                            cgp{m<1166:R,a>3899:R,x<1426:R,R}
                            nvp{s>1649:A,s<765:mzn,zkb}
                            skb{s>3129:R,s>2585:R,x>2580:zb,R}
                            fs{s<971:A,s<1381:R,s<1589:A,A}
                            fm{s<2965:A,s>3026:zjm,A}
                            zvz{s>2991:bv,mg}
                            fxp{m<759:A,R}
                            mzn{s<436:R,x<2333:A,a>2292:A,A}
                            hg{x>2695:rn,s>2386:R,x<2329:R,A}
                            xf{a<3868:A,A}
                            gx{a<2954:nnv,m>2815:fbq,jgv}
                            np{a>3593:A,m>3821:R,R}
                            nct{m<1503:A,glb}
                            mpl{s<1048:R,gjk}
                            gpl{x>1584:R,s<2360:R,a<2875:R,A}
                            dmk{a<3973:czg,s<3272:pg,A}
                            lqr{a<2295:mnt,s>823:bdp,s>373:vmb,pft}
                            sdh{s<743:R,a<3416:R,m<3797:fhq,tp}
                            xg{m<1238:R,x>3346:A,m<1761:A,R}
                            nss{s<3633:rh,A}
                            jth{x>3707:R,A}
                            bv{x<2477:ljl,s>3516:zbg,gsq}
                            ct{a>3210:R,A}
                            mh{m<3086:A,A}
                            gnt{m>1076:R,R}
                            mhl{m>1815:rcm,s>751:pvz,s>442:gl,fhr}
                            fz{m>447:A,s>2628:A,m>293:A,R}
                            gp{a>573:R,a<367:A,m<1733:A,R}
                            qq{s>1754:czn,a<2335:qn,cb}
                            ksr{s<1161:vp,s<1671:kr,a<2871:rjj,lj}
                            jhs{a>3568:A,a>3361:R,R}
                            pgf{x<2090:R,m<1854:rqz,m<3102:R,qnn}
                            drk{m>2799:R,x>844:A,m<2423:R,A}
                            lr{a<3110:A,x>3689:lxp,tg}
                            tsf{x<906:A,s<3626:R,A}
                            slq{x>1074:kzc,x<635:qqq,a<2692:nss,kj}
                            xtr{m>851:R,m>780:sn,sj}
                            sd{x>3112:lf,m<1593:pn,a>2806:mtv,A}
                            mqs{s<2800:A,a<3429:A,a>3486:A,R}
                            dm{a<2520:R,s>247:ms,x>887:fpz,A}
                            tdk{s<2421:R,a<3901:R,A}
                            qx{s>1541:R,nv}
                            hd{a>3498:R,a>3424:A,R}
                            fq{x<1299:jl,a<3628:A,A}
                            qv{x<689:R,x>933:R,s<2373:R,A}
                            nnv{a<2442:ttb,a>2628:kb,s<712:kp,zh}
                            xdp{m<3623:R,m<3797:A,x>156:A,A}
                            shr{m>595:bqs,m<393:R,qr}
                            pkt{s<1087:R,a<2786:R,x<3363:A,R}
                            xz{a>1176:kdx,m>2309:fl,lq}
                            tpm{m>3107:A,R}
                            sh{s>2775:R,A}
                            pk{a>2798:bb,m>3345:cj,tzk}
                            gkg{a>3040:lt,a<2878:kcs,m<499:bjd,mpl}
                            cjc{s<623:A,s<1014:A,a>3256:A,R}
                            kc{s>697:A,R}
                            xnt{a>2374:R,x>2862:R,A}
                            mtv{s<1181:R,A}
                            ftc{s>1991:A,mh}
                            qgj{a<2874:A,A}
                            pcs{a>3897:A,s>903:R,R}
                            spq{a>2688:A,s>3621:R,m<3800:R,R}
                            cfh{a<2335:xrc,fql}
                            lj{s<1815:zmz,R}
                            dvq{m>1770:A,s>678:kbz,ctl}
                            tn{m<1611:kjv,a>3081:ml,zxd}
                            rxz{s>802:sb,R}
                            nmk{s>2328:rt,s<1387:tq,hr}
                            kjn{a<773:A,a<910:A,s<582:R,A}
                            fh{m<317:jts,m<594:gsn,x<661:qvl,bq}
                            tdv{m<1383:A,rjl}
                            jhr{a<2523:A,a<2728:R,A}
                            bqs{s<416:R,s>574:R,a>2772:R,A}
                            qnv{x>702:R,s<1521:kxk,R}
                            fhq{s<1199:R,a>3693:R,R}
                            drc{s<3614:R,m<1189:R,a>2578:R,R}
                            bs{x<2494:gx,njd}
                            fjl{s>1410:A,R}
                            qn{a>2138:R,m>1309:lkc,x>3708:A,R}
                            jj{x>921:R,s>1153:R,R}
                            pdl{a<2720:gk,x<2022:fmb,tm}
                            gsq{a<574:qkd,x<3457:dbp,m>1541:pp,gzq}
                            tp{x>1394:R,x>699:A,a>3692:R,A}
                            qmt{a>1858:rk,s>1346:mx,s>1021:R,A}
                            lnx{m>1720:kpx,s>2143:lxd,R}
                            mnt{s<1107:hb,m>1084:ndr,qnv}
                            jlm{a>3607:nqf,s<268:mtx,hks}
                            bq{x>1150:stt,m>747:A,tkx}
                            tt{m>724:gz,a<3383:lsk,s<2421:A,fz}
                            jcl{a>3378:A,s<1567:R,A}
                            pm{m<977:R,A}
                            ft{a<3968:R,A}
                            ktp{m<1837:jzs,dxl}
                            vsj{m>207:R,A}
                            pjg{a<3083:A,s<3749:R,x<491:R,R}
                            rn{x>3266:A,x<3028:A,s>2454:R,A}
                            rjj{x<694:lck,R}
                            cpc{a>3153:R,A}
                            df{x>2484:nct,zhf}
                            fpz{s<129:R,m>1620:A,a<2635:A,A}
                            qxb{a<1692:mxv,A}
                            rjb{m<1740:df,s>1900:bmv,m<1912:ktp,th}
                            fql{a<2531:kl,m<1336:R,m<1729:R,ddj}
                            mtx{m<574:A,a>3385:R,x>2832:A,A}
                            bjp{m<302:hzq,x<2687:dqk,vvf}
                            kjv{a>3075:jsj,a<3004:R,a<3042:A,A}
                            cr{a>1387:A,s>1535:R,A}
                            fjm{x<1530:A,x>1775:pbc,x>1626:mfq,A}
                            jcg{x>2441:R,R}
                            nsq{m>3370:R,m>3177:R,R}
                            zt{a>1008:gd,zvz}
                            xs{x>3300:kc,s>754:cg,a<2947:jhr,pz}
                            fpf{s<3090:cfh,s<3519:bcp,m<934:fh,kt}
                            gtl{m>2494:A,s<2767:R,s>3241:A,A}
                            cl{m<658:nzt,R}
                            bm{s<1419:A,A}
                            qkm{s<3147:lr,px}
                            jc{a>292:A,R}
                            lrr{s<2464:R,s>2665:A,R}
                            sfr{s>1594:A,s<1406:A,A}
                            jss{s<385:cpc,A}
                            cks{a<3347:A,m>1497:A,m>1438:R,A}
                            vqb{s<3794:A,A}
                            tm{m<1090:vd,qm}
                            xk{m<842:A,m<1321:sp,qd}
                            zf{a<2394:fcp,a<2554:A,s<2158:A,R}
                            lrh{s<1419:R,x<652:R,s<1477:A,A}
                            kcq{a<3825:R,R}
                            sc{a<2768:R,s>2918:R,s>2526:A,R}
                            lpk{m>1742:R,R}
                            lzz{x<3346:A,s>660:R,x<3417:R,R}
                            fqk{s>1274:R,R}
                            bgc{a<3564:jcl,kqc}
                            vh{s<2107:bs,x<2417:xc,lm}
                            lb{x<1423:A,m<2424:A,m<2603:A,R}
                            dbp{x<2990:A,R}
                            jf{x<2529:A,m>3833:R,A}
                            zk{s<2758:hkq,x<2198:tl,hk}
                            kg{s>3042:R,s<2430:R,R}
                            zh{a<2554:drk,m<3186:A,hrg}
                            rj{s>2451:sh,s>2299:jct,kdh}
                            mxv{m>2171:A,m>1286:R,s<1567:R,R}
                            nv{x<1693:A,A}
                            ssk{s<1524:A,A}
                            fgs{m>2627:bdt,ct}
                            xrc{m<1236:hz,a<2134:jp,s>2439:tqd,R}
                            kqc{x>611:cmg,s<1534:fvx,gnt}
                            px{m>2369:A,a>3103:A,hfd}
                            pcd{x<3064:sf,x>3489:qq,brl}
                            hvc{m<1363:R,m>1409:R,R}
                            rzc{a>3309:cks,a>3269:lmk,a<3243:A,cjc}
                            njd{s<1006:vc,s<1480:mfl,mb}
                            vc{s>404:xs,mk}
                            mdp{a<2842:A,x<200:A,x<431:R,A}
                            nr{a<2936:tc,zpx}
                            stt{s<3742:A,a<2429:A,A}
                            bp{s>1625:A,R}
                            jh{x>3726:R,x>3640:A,a>637:R,A}
                            czg{m>1984:A,A}
                            gpb{m<443:R,m>754:A,A}
                            kj{x<843:R,x<942:tsf,A}
                            rnt{s<858:shr,fsm}
                            pv{m<1137:qb,s<792:nsg,x<1386:A,lpk}
                            ljl{m<2075:vb,R}
                            vkf{x>836:pl,s<1216:mf,x>426:zd,qxb}
                            kdx{x<2015:vkf,x<3140:qf,ttv}
                            hr{s<1980:zr,x>2467:smb,a>3368:dmt,lnx}
                            sn{m>817:A,x<3461:A,A}
                            vx{a>1758:A,s<1203:R,s<1355:A,R}
                            kr{a<2895:A,s<1391:R,A}
                            ccz{s>920:R,R}
                            tvq{s>734:A,x<1240:R,x<1314:A,A}
                            qh{x<1010:qsc,x>1431:vvd,a>3080:dqr,cjt}
                            mc{a<3014:A,R}
                            mbh{x>3007:A,s<1172:A,s<1552:A,A}
                            rqp{x>1114:A,m<946:sm,hf}
                            sz{a<1451:A,A}
                            gzx{s>3618:pjg,x<579:mdp,szs}
                            bps{m>1506:R,a>2520:R,A}
                            fl{x>1717:kn,ltb}
                            tb{x>3663:R,x>3384:R,R}
                            zhf{m<1536:bcn,bt}
                            sf{m>776:nvp,x<2370:zf,bjp}
                            lfp{s>1251:qzv,jhs}
                            dxl{m>1885:A,s>771:A,A}
                            qsc{m>1428:A,m<1232:tbl,x>399:R,A}
                            jjp{a<3653:A,fb}
                            ffg{x<3318:A,s>2102:A,m<1905:R,A}
                            lrz{x>1539:A,R}
                            jp{s>2644:R,R}
                            zr{s<1776:vnj,s>1888:R,rgv}
                            lxp{m>2494:R,m>2241:A,a>3647:A,A}
                            rqz{a>338:A,A}
                            fd{x<2753:R,mbh}
                            hp{a>3707:R,a>3524:A,m>3277:R,R}
                            vl{m>1659:sc,A}
                            hnz{m>1381:bfs,s<3698:drc,a>2479:A,A}
                            nsg{a>843:A,a>744:A,s<406:A,A}
                            lm{m<2985:fv,xkc}
                            dff{a>3044:rzk,x<1040:cpv,rxz}
                            mfl{a>3319:hp,qpn}
                            zkb{x<2485:R,m>1493:A,R}
                            jl{a>3338:A,m<3078:A,A}
                            cg{s<841:A,m<3221:A,s>923:R,A}
                            mq{a>414:A,s<617:R,a>253:R,A}
                            hf{a>2898:A,R}
                            xj{x>3177:A,s<1294:nht,m<651:R,R}
                            zxd{a<2981:A,m>1800:A,x>2930:jx,A}
                            smb{m<1780:R,ffg}
                            qkj{s>2787:cxt,gb}
                            sp{a<2561:R,m>1156:A,A}
                            lck{s<1850:R,A}
                          
                            {x=302,m=140,a=650,s=1288}
                            {x=93,m=1448,a=1836,s=292}
                            {x=3311,m=758,a=62,s=1463}
                            {x=576,m=1505,a=314,s=1038}
                            {x=7,m=685,a=4,s=1132}
                            {x=472,m=57,a=3605,s=9}
                            {x=2369,m=83,a=412,s=382}
                            {x=2834,m=573,a=875,s=1127}
                            {x=97,m=539,a=90,s=1568}
                            {x=100,m=836,a=263,s=179}
                            {x=846,m=227,a=396,s=261}
                            {x=492,m=1517,a=150,s=935}
                            {x=291,m=3188,a=1419,s=942}
                            {x=1384,m=1726,a=74,s=1873}
                            {x=690,m=369,a=115,s=3123}
                            {x=1399,m=589,a=58,s=135}
                            {x=512,m=85,a=1572,s=313}
                            {x=253,m=2433,a=480,s=2736}
                            {x=2148,m=2367,a=1531,s=96}
                            {x=1008,m=1373,a=685,s=250}
                            {x=706,m=815,a=57,s=3476}
                            {x=236,m=1404,a=652,s=587}
                            {x=1093,m=2589,a=229,s=329}
                            {x=656,m=892,a=1729,s=438}
                            {x=2046,m=2759,a=1544,s=568}
                            {x=985,m=229,a=2228,s=56}
                            {x=248,m=1893,a=112,s=609}
                            {x=2837,m=73,a=1216,s=338}
                            {x=290,m=44,a=9,s=153}
                            {x=1499,m=1634,a=2499,s=1240}
                            {x=2266,m=227,a=1560,s=1034}
                            {x=32,m=3306,a=744,s=403}
                            {x=1187,m=171,a=17,s=33}
                            {x=330,m=259,a=710,s=655}
                            {x=294,m=325,a=383,s=2483}
                            {x=2434,m=168,a=1967,s=785}
                            {x=11,m=586,a=916,s=743}
                            {x=1773,m=362,a=1553,s=70}
                            {x=1130,m=1599,a=31,s=622}
                            {x=1595,m=23,a=1268,s=1578}
                            {x=3912,m=283,a=1407,s=842}
                            {x=1081,m=2942,a=807,s=375}
                            {x=1257,m=1551,a=1523,s=12}
                            {x=69,m=3109,a=1305,s=2094}
                            {x=2625,m=1929,a=16,s=759}
                            {x=926,m=1384,a=629,s=291}
                            {x=917,m=373,a=740,s=2138}
                            {x=59,m=1757,a=1283,s=323}
                            {x=2434,m=510,a=9,s=56}
                            {x=210,m=395,a=54,s=1646}
                            {x=3555,m=2225,a=1096,s=120}
                            {x=462,m=932,a=316,s=13}
                            {x=177,m=2607,a=570,s=1945}
                            {x=10,m=3261,a=2065,s=2260}
                            {x=1017,m=250,a=1022,s=1572}
                            {x=682,m=169,a=782,s=3}
                            {x=718,m=483,a=1875,s=1986}
                            {x=208,m=1563,a=1441,s=1752}
                            {x=1509,m=1408,a=852,s=1057}
                            {x=64,m=310,a=1589,s=897}
                            {x=2427,m=757,a=2034,s=1266}
                            {x=526,m=45,a=841,s=429}
                            {x=320,m=778,a=797,s=1253}
                            {x=65,m=2044,a=354,s=191}
                            {x=2245,m=163,a=892,s=856}
                            {x=850,m=321,a=42,s=522}
                            {x=626,m=410,a=201,s=844}
                            {x=1130,m=1745,a=1196,s=1984}
                            {x=89,m=513,a=225,s=1482}
                            {x=180,m=35,a=198,s=1999}
                            {x=367,m=1679,a=609,s=127}
                            {x=32,m=28,a=2507,s=736}
                            {x=2219,m=1881,a=255,s=199}
                            {x=635,m=2381,a=2243,s=2395}
                            {x=1442,m=495,a=2242,s=1557}
                            {x=863,m=63,a=3459,s=522}
                            {x=1353,m=493,a=312,s=2}
                            {x=445,m=401,a=587,s=114}
                            {x=356,m=2289,a=1520,s=1686}
                            {x=425,m=568,a=191,s=527}
                            {x=2595,m=758,a=3569,s=708}
                            {x=1311,m=2144,a=945,s=771}
                            {x=167,m=666,a=1899,s=454}
                            {x=1623,m=281,a=1474,s=579}
                            {x=102,m=56,a=1720,s=722}
                            {x=356,m=16,a=602,s=334}
                            {x=1149,m=212,a=791,s=245}
                            {x=2357,m=622,a=527,s=220}
                            {x=1965,m=5,a=1133,s=1332}
                            {x=1652,m=169,a=21,s=977}
                            {x=372,m=100,a=674,s=1224}
                            {x=1774,m=873,a=10,s=221}
                            {x=8,m=604,a=15,s=201}
                            {x=779,m=304,a=1486,s=52}
                            {x=44,m=1797,a=532,s=59}
                            {x=102,m=1013,a=1916,s=101}
                            {x=1007,m=621,a=80,s=2917}
                            {x=825,m=1444,a=845,s=1813}
                            {x=396,m=55,a=1851,s=570}
                            {x=2119,m=872,a=1209,s=2087}
                            {x=1896,m=59,a=2709,s=1492}
                            {x=680,m=216,a=45,s=1607}
                            {x=2180,m=2415,a=149,s=793}
                            {x=955,m=1397,a=616,s=441}
                            {x=1337,m=746,a=97,s=33}
                            {x=1291,m=703,a=1680,s=344}
                            {x=1890,m=50,a=414,s=1292}
                            {x=207,m=303,a=1959,s=514}
                            {x=2020,m=1104,a=653,s=3283}
                            {x=274,m=2059,a=835,s=604}
                            {x=1945,m=22,a=86,s=711}
                            {x=1225,m=390,a=1795,s=1384}
                            {x=1837,m=238,a=638,s=295}
                            {x=966,m=568,a=2067,s=755}
                            {x=1942,m=340,a=1419,s=818}
                            {x=53,m=2013,a=1221,s=1871}
                            {x=86,m=2633,a=196,s=202}
                            {x=102,m=2322,a=711,s=3427}
                            {x=1967,m=477,a=67,s=1255}
                            {x=2742,m=493,a=1673,s=411}
                            {x=546,m=252,a=43,s=429}
                            {x=821,m=422,a=2094,s=1533}
                            {x=78,m=116,a=184,s=947}
                            {x=502,m=258,a=1337,s=82}
                            {x=186,m=372,a=313,s=271}
                            {x=2717,m=586,a=502,s=342}
                            {x=490,m=2086,a=45,s=1424}
                            {x=546,m=1048,a=411,s=663}
                            {x=1387,m=2721,a=534,s=1500}
                            {x=22,m=1,a=1231,s=2927}
                            {x=584,m=1382,a=752,s=1516}
                            {x=2467,m=1090,a=89,s=2937}
                            {x=2783,m=126,a=1324,s=801}
                            {x=1343,m=87,a=2232,s=2066}
                            {x=846,m=980,a=2807,s=3698}
                            {x=1260,m=20,a=128,s=199}
                            {x=26,m=1734,a=53,s=1459}
                            {x=713,m=1371,a=762,s=827}
                            {x=1563,m=946,a=539,s=643}
                            {x=1898,m=3022,a=3464,s=66}
                            {x=508,m=113,a=2159,s=186}
                            {x=818,m=1473,a=232,s=11}
                            {x=140,m=1337,a=2485,s=577}
                            {x=1196,m=1725,a=857,s=989}
                            {x=374,m=291,a=276,s=120}
                            {x=162,m=665,a=660,s=84}
                            {x=1829,m=590,a=1732,s=551}
                            {x=55,m=421,a=178,s=349}
                            {x=51,m=2387,a=235,s=1420}
                            {x=1795,m=3341,a=624,s=692}
                            {x=923,m=641,a=3147,s=1686}
                            {x=62,m=2162,a=953,s=520}
                            {x=133,m=218,a=3130,s=346}
                            {x=436,m=291,a=1366,s=1710}
                            {x=341,m=2054,a=420,s=593}
                            {x=1451,m=85,a=1296,s=355}
                            {x=1128,m=372,a=411,s=264}
                            {x=960,m=477,a=1139,s=444}
                            {x=2073,m=1841,a=1447,s=734}
                            {x=1808,m=3556,a=2231,s=80}
                            {x=1004,m=2097,a=417,s=925}
                            {x=1593,m=1820,a=1450,s=3391}
                            {x=576,m=932,a=90,s=742}
                            {x=295,m=2888,a=2296,s=338}
                            {x=2693,m=190,a=630,s=1186}
                            {x=1086,m=66,a=85,s=893}
                            {x=1181,m=32,a=814,s=88}
                            {x=1671,m=650,a=933,s=1900}
                            {x=110,m=682,a=852,s=1431}
                            {x=141,m=89,a=563,s=2260}
                            {x=771,m=2014,a=216,s=753}
                            {x=1485,m=3065,a=2418,s=26}
                            {x=2175,m=828,a=1241,s=2374}
                            {x=601,m=785,a=2903,s=707}
                            {x=2635,m=865,a=1163,s=971}
                            {x=560,m=2287,a=1469,s=2081}
                            {x=246,m=4,a=26,s=2596}
                            {x=1104,m=109,a=788,s=165}
                            {x=1142,m=2257,a=1125,s=155}
                            {x=3292,m=2635,a=511,s=744}
                            {x=2205,m=395,a=197,s=553}
                            {x=1168,m=1348,a=510,s=238}
                            {x=1827,m=289,a=359,s=293}
                            {x=513,m=352,a=1181,s=330}
                            {x=164,m=2153,a=263,s=408}
                            {x=363,m=158,a=275,s=2266}
                            {x=544,m=404,a=2695,s=692}
                            {x=7,m=730,a=2276,s=32}
                            {x=988,m=340,a=1480,s=191}
                            {x=690,m=85,a=1289,s=57}
                            {x=368,m=813,a=762,s=1787}
                            {x=2088,m=2053,a=1917,s=2756}
                            {x=3331,m=712,a=1735,s=309}
                            {x=334,m=490,a=268,s=1451}
                            {x=631,m=70,a=371,s=577}
                            {x=662,m=893,a=541,s=2204}
                            {x=1147,m=354,a=1121,s=1455}
                            {x=2517,m=2025,a=2242,s=674}
                            {x=418,m=1394,a=1326,s=405}
                            {x=1630,m=354,a=226,s=1078}
                          """;
}