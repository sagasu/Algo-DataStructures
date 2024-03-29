﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

[TestClass]
public class Day8
{
    [TestMethod]
    public void Test()
    {
        var lines = data.Split("\n", StringSplitOptions.TrimEntries);
        var dic = new Dictionary<string, (string, string)>();
        foreach (var line in lines)
        {
            var network = line.Split("=", StringSplitOptions.TrimEntries);
            var side = network[1].Split(",", StringSplitOptions.TrimEntries);
            dic.Add(network[0], (side[0].Trim('('), side[1].Trim(')')));
        }

        var instr = instructions;
        var n = instr.Length;
        var i = 0;
        var node = dic["AAA"];
        var steps = 0;
        while (i < n)
        {
            steps++;
            var direction = instr[i];
            var key = direction == 'L' ? node.Item1 : node.Item2;
            if (key == "ZZZ") break;
            node = dic[key];
            i++;
            if (i == n) i = 0;
        }

        Console.WriteLine(steps);
    }

    [TestMethod]
    public void Test3()
    {
        var lines = data.Split('\n',StringSplitOptions.TrimEntries);
        var dict = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var splitLine = line.Split('=');
            var key = splitLine[0].Trim();
            var value = splitLine[1].Trim();
            value = value.Trim('(', ')');
            var node = value.Split(',');
            for (var j = 0; j < node.Length; j++)
                node[j] = node[j].Trim();
            
            dict[key] = node;
        }
        
        var curNavPos = 0; var steps = 0; var NodeAAA = "AAA"; long part1 = 0;
        var curNodesA = dict.Keys.Where(key => key.EndsWith("A")).ToList();
        var allSteps = new List<long>();
        do
        {
            for (var i = 0; i < curNodesA.Count; i++)
            {
                if (curNodesA[i] == "") continue;
                curNodesA[i] = dict[curNodesA[i]][instructions[curNavPos] == 'L' ? 0 : 1];
                
                if (!curNodesA[i].EndsWith("Z")) continue;
                allSteps.Add(steps + 1); curNodesA[i] = "";
            }
            if (NodeAAA != "") NodeAAA = dict[NodeAAA][instructions[curNavPos] == 'L' ? 0 : 1];
            if (NodeAAA == "ZZZ") { NodeAAA = ""; part1 = steps + 1; }
            steps++; curNavPos++;
            
            if (curNavPos == instructions.Length) curNavPos = 0;
        } while (allSteps.Count != curNodesA.Count);
        
        Console.WriteLine($"Part1: {part1}\nPart2: {LCM(allSteps)}"); ;
    }

    private static long LCM(List<long> numbers) { return numbers.Aggregate((a, b) => a * b / GCD(a, b)); }
    private static long GCD(long a, long b) { return b == 0 ? a : GCD(b, a % b); }
    
    [TestMethod]
    public void Test2()
    {
        var lines = data.Split("\n", StringSplitOptions.TrimEntries);
        var dic = new Dictionary<string, (string, string)>();
        var nodes = new List<(string, string)>();
        foreach (var line in lines)
        {
            var network = line.Split("=", StringSplitOptions.TrimEntries);
            var side = network[1].Split(",", StringSplitOptions.TrimEntries);
            dic.Add(network[0], (side[0].Trim('('), side[1].Trim(')')));
            if (network[0][2] == 'A')
            {
                nodes.Add(dic[network[0]]);
            }
        }

        var instr = instructions;
        var n = instr.Length;
        var i = 0;
        var steps = 0;

        while (i < n)
        {
            steps++;
            var direction = instr[i];
            var isFound = true;
            for (var j = 0; j < nodes.Count; j++)
            {
                var key = direction == 'L' ? nodes[j].Item1 : nodes[j].Item2;
                if (key[2] != 'Z') isFound = false;
                nodes[j] = dic[key];
            }

            if (isFound) break;
            i++;
            if (i == n) i = 0;
        }

        Console.WriteLine(steps);
    }

    private string testInstructions = "RL";
    private string testInstructions3 = "LR";
    private string testInstructions2 = "LLR";
    private string instructions = "LRLRLLRRLRRRLRLRRLRLLRRLRRRLRLRLRLRRLRLLRRRLRRRLLRRLRRLRLRRRLLLRRLRLRLRLRLRLLRRRLRLRRRLRRRLRRRLRRRLRRRLRRRLRRRLRRLRRRLLRLLRRLRRLRRLRRRLLRLRRLRLRLRRLLRLRRRLRRLLRLRLRRRLRRLRRLRRLRLLRLRRRLLLRRRLLLLRRLRRRLLLRRLLRLRLRLLLRRRLLRRRLLLRLRRLLRRRLRRRLRLLRRRLRLRLRLLRRLLRRLRRRLRLRRRLRRLRLRRLRRRR";
    
    string testData = """
                            AAA = (BBB, CCC)
                            BBB = (DDD, EEE)
                            CCC = (ZZZ, GGG)
                            DDD = (DDD, DDD)
                            EEE = (EEE, EEE)
                            GGG = (GGG, GGG)
                            ZZZ = (ZZZ, ZZZ)
                           """;
    string testData2 = """
                        AAA = (BBB, BBB)
                        BBB = (AAA, ZZZ)
                        ZZZ = (ZZZ, ZZZ)
                       """;
    string testData3 = """
                        11A = (11B, XXX)
                        11B = (XXX, 11Z)
                        11Z = (11B, XXX)
                        22A = (22B, XXX)
                        22B = (22C, 22C)
                        22C = (22Z, 22Z)
                        22Z = (22B, 22B)
                        XXX = (XXX, XXX)
                       """;
    string data = """
                    SGR = (JLL, VRV)
                    XDC = (TBG, KNF)
                    QRS = (BVR, VGS)
                    BHD = (SFQ, LFL)
                    KJN = (BVB, SNM)
                    MVR = (XNS, GXN)
                    KTX = (GHQ, QRL)
                    GLH = (GPF, PLR)
                    XKH = (BTC, CKN)
                    MXM = (HDB, BVC)
                    MRG = (KFG, SFF)
                    SBM = (PVH, CJK)
                    DPH = (TBV, QCV)
                    NKL = (TRR, GRQ)
                    BNL = (RBS, DMT)
                    KHB = (RQQ, HPL)
                    KSB = (HQM, NXH)
                    CKX = (XQT, KJK)
                    LFC = (RMT, LCM)
                    BFN = (FVH, DNL)
                    TNT = (HCH, CKX)
                    RQK = (BQB, JQS)
                    MKH = (MPH, VMJ)
                    CCJ = (HMF, DXJ)
                    XFT = (GNC, RQT)
                    DPD = (JJG, RSN)
                    LLH = (TMP, XVH)
                    GFT = (XJV, PVG)
                    QFL = (RBH, VLM)
                    QFF = (JVR, NJN)
                    SVT = (LSH, TSV)
                    FQG = (QTJ, JNM)
                    JVR = (CGX, BML)
                    SGL = (KLN, RFH)
                    HFX = (GJD, LMK)
                    MRD = (JLV, JLV)
                    TRF = (KXR, LNS)
                    VRH = (XJV, PVG)
                    PQX = (VDS, QXZ)
                    RMF = (HTT, TCG)
                    JJG = (VKL, FLQ)
                    TKQ = (HCH, CKX)
                    SKD = (XPX, BTV)
                    XGB = (GXT, TBL)
                    HDB = (DQC, GRK)
                    LNS = (HXJ, HLB)
                    XNC = (LXP, LPD)
                    HNL = (DPD, HBN)
                    KVJ = (JGP, LFC)
                    FNK = (SDF, SDF)
                    FPM = (DNG, PGL)
                    LLJ = (VKC, SGR)
                    KJX = (NKH, HKD)
                    HQM = (JFL, RFM)
                    NXV = (DHL, SMB)
                    KHM = (NSK, NRL)
                    KDG = (RTN, JFN)
                    HTT = (PTL, GQQ)
                    CKT = (KQT, RQS)
                    QQB = (TBX, CXG)
                    HHV = (NBD, KDG)
                    TSR = (JKF, QST)
                    PFS = (TJV, NDR)
                    DXJ = (HNL, SHS)
                    GRK = (XSH, CGM)
                    KPT = (LKJ, KVJ)
                    FBG = (CTQ, GGP)
                    SBD = (QKN, JKM)
                    JTB = (JRR, RCX)
                    CFF = (RNF, FGG)
                    TQH = (PJP, RVH)
                    RBH = (JKS, VXD)
                    LKJ = (JGP, LFC)
                    RVS = (QSC, NMX)
                    DCG = (SVV, KMP)
                    MBP = (NDP, BJS)
                    FVH = (KDB, GXQ)
                    PGL = (QCX, PPL)
                    MTZ = (TDF, DCG)
                    HKM = (VMJ, MPH)
                    MCL = (XPR, PGN)
                    LBV = (FFD, VVD)
                    QCV = (GPG, KFR)
                    QSC = (JPL, NNG)
                    FBH = (MRD, DGL)
                    MNG = (KLM, LFG)
                    XKR = (VNT, BFB)
                    RNG = (KFL, NQX)
                    RCK = (TDD, PQX)
                    KSN = (FFD, VVD)
                    NQX = (TNS, KCM)
                    KFG = (QLH, QSR)
                    LMK = (XDM, CJS)
                    JJC = (TSR, FQP)
                    KMR = (NBD, KDG)
                    XPM = (LXT, JCH)
                    VTP = (RNG, JLB)
                    KFL = (TNS, KCM)
                    JSB = (NDR, TJV)
                    QKA = (QQD, SSM)
                    NFP = (JPT, DPM)
                    DKP = (RTD, PCV)
                    BJT = (KJM, KJM)
                    BVC = (DQC, GRK)
                    QQD = (JRH, TCB)
                    KMP = (SLM, GDX)
                    GMJ = (DMV, CMS)
                    RTX = (SKV, LCK)
                    SFQ = (TMM, MGX)
                    NML = (XRT, GRM)
                    BGT = (GDB, VDT)
                    RGG = (NLQ, JNT)
                    XQV = (DKX, LGQ)
                    SGF = (LHD, NJL)
                    RKL = (JKK, NDZ)
                    HPL = (GNQ, FTF)
                    JLP = (RBV, TLD)
                    XSN = (HQM, NXH)
                    HRD = (DXJ, HMF)
                    GMV = (PQF, STD)
                    JCC = (CTK, XQD)
                    RXM = (LSM, BPH)
                    KRF = (XGB, CJN)
                    FFS = (NNK, DLC)
                    XJV = (LPM, QFL)
                    JHV = (CXG, TBX)
                    LJP = (BJQ, JTB)
                    TBX = (SRF, VNC)
                    LKM = (XBB, GJT)
                    NSV = (VBV, GBV)
                    VDT = (RBT, LLJ)
                    MGF = (MQB, LRM)
                    QQK = (BFC, MBP)
                    TLD = (RGG, HSX)
                    QFC = (QBB, VPV)
                    PJF = (NGG, MRG)
                    DLT = (TLM, JBR)
                    SRP = (QQK, FRH)
                    GNQ = (PCP, CFM)
                    VHR = (PBK, PBK)
                    RCX = (SDD, QXM)
                    JSJ = (LGJ, TJG)
                    JJP = (TCQ, NJQ)
                    HJL = (FNQ, JSD)
                    DLG = (XQJ, PFH)
                    QHK = (XKP, RTR)
                    GBV = (FKC, LSR)
                    QVX = (TFD, KFB)
                    GDX = (GHJ, LNX)
                    LSR = (SQD, VMT)
                    PPN = (KHB, FRV)
                    CKN = (CSD, QRD)
                    BVX = (RKM, LXN)
                    FPR = (KJM, RCK)
                    NLX = (XKR, PNK)
                    XSH = (PHB, NRD)
                    TXH = (KTD, BPD)
                    SSM = (JRH, TCB)
                    VTD = (MXM, JCV)
                    HND = (NKH, HKD)
                    CJN = (TBL, GXT)
                    VJJ = (PCM, QLC)
                    PGD = (BJM, NBR)
                    VVD = (GRR, FVM)
                    GNC = (PRJ, LJP)
                    DLP = (VXJ, TSB)
                    LJD = (BLF, BHD)
                    XQD = (DRT, VTP)
                    BFB = (CBK, CHB)
                    QBB = (FFS, PFR)
                    KDH = (TTK, MNG)
                    STD = (MQP, MJB)
                    RVH = (DLP, HVQ)
                    LRL = (JQP, DLT)
                    PFH = (GMJ, LVN)
                    JLV = (CHD, CHD)
                    QRL = (HVB, DKP)
                    SRR = (FQV, TQD)
                    VPV = (PFR, FFS)
                    JFN = (XQP, FGF)
                    MJP = (LRT, XKS)
                    SMB = (QHK, TSS)
                    GPZ = (PFH, XQJ)
                    MTB = (LCK, SKV)
                    XKP = (HMN, FGJ)
                    BQK = (MBG, JCQ)
                    BLR = (FMH, VJJ)
                    VMA = (DCG, TDF)
                    SDD = (VRK, NTJ)
                    JRN = (SRC, LKV)
                    BPM = (MXM, JCV)
                    PBR = (VBB, SRK)
                    FGH = (CMP, TFP)
                    BCD = (PBR, GBB)
                    TCG = (PTL, GQQ)
                    GKT = (RBF, SVS)
                    SLS = (CCT, MDM)
                    FHL = (NDG, LSS)
                    RPD = (SRQ, RDQ)
                    VDR = (SJR, CKP)
                    CTQ = (JHK, QFS)
                    MXD = (CJK, PVH)
                    NDR = (RMF, SCG)
                    NBD = (RTN, JFN)
                    RQS = (CQN, GMV)
                    BTV = (NQT, SXK)
                    PNK = (VNT, BFB)
                    LFL = (TMM, MGX)
                    KDV = (KTD, BPD)
                    HLS = (RRC, PNL)
                    TQD = (QFF, PFQ)
                    SQD = (XHT, MXH)
                    PGN = (GLH, GCQ)
                    NMX = (NNG, JPL)
                    BLF = (LFL, SFQ)
                    XBB = (BGQ, FCL)
                    QSR = (GNB, RPH)
                    KSG = (FHL, KKJ)
                    HFG = (KVL, KDH)
                    TQS = (CKN, BTC)
                    FRF = (DDX, DGP)
                    DVC = (MGF, CLJ)
                    BTC = (CSD, QRD)
                    QXZ = (SSM, QQD)
                    QCX = (KDV, TXH)
                    DHL = (TSS, QHK)
                    CGM = (PHB, NRD)
                    DQQ = (DDX, DGP)
                    VNL = (LPX, HTQ)
                    BPD = (KKP, PNH)
                    LHQ = (PFS, JSB)
                    RKQ = (LDR, KTV)
                    GSK = (DMT, RBS)
                    FKC = (SQD, VMT)
                    BFC = (BJS, NDP)
                    JBX = (XPR, PGN)
                    FGG = (MBR, FCR)
                    TXN = (TVL, XRX)
                    HMN = (BPQ, XSP)
                    CCT = (FGH, MPS)
                    KQT = (CQN, GMV)
                    CVG = (FRV, KHB)
                    LPM = (VLM, RBH)
                    PLR = (FVB, GSR)
                    KXR = (HLB, HXJ)
                    NSK = (JQK, DXL)
                    QGL = (TQD, FQV)
                    VBB = (BPM, VTD)
                    FQV = (PFQ, QFF)
                    BJS = (JRL, KMX)
                    DSL = (RVS, MST)
                    PCM = (RLL, LKK)
                    RPQ = (HND, KJX)
                    JPT = (QGJ, RDM)
                    BSR = (BPH, LSM)
                    AAA = (KPT, QLD)
                    RPH = (LBV, KSN)
                    CTJ = (TPQ, KTL)
                    KDB = (BGT, LRJ)
                    TNG = (VPF, FQG)
                    CQN = (PQF, STD)
                    KJM = (TDD, TDD)
                    HKV = (LPD, LXP)
                    FDQ = (KBM, NFP)
                    FLQ = (RNC, CTJ)
                    HKD = (CKT, DTR)
                    VXD = (SKK, BHJ)
                    SLH = (KHM, RJJ)
                    GHL = (NBR, BJM)
                    TCB = (NVB, CTH)
                    PRJ = (JTB, BJQ)
                    CMP = (HFG, BLT)
                    VKM = (PGL, DNG)
                    MBG = (KRS, PCL)
                    PPC = (HJL, GSP)
                    FTT = (FDQ, KVR)
                    GDT = (NML, HDD)
                    PXC = (XBB, GJT)
                    VRV = (DHS, FKR)
                    GDN = (KPT, QLD)
                    DXL = (FTT, LNK)
                    LPD = (RTX, MTB)
                    FCD = (FLK, JCC)
                    HSX = (JNT, NLQ)
                    ZZZ = (QLD, KPT)
                    CNV = (CHC, SHX)
                    TRP = (VJJ, FMH)
                    CKD = (JKK, JKK)
                    BVR = (DKQ, JHM)
                    TBG = (LVG, SHF)
                    GQQ = (MKH, HKM)
                    QRG = (TCQ, NJQ)
                    SBH = (DSL, LVD)
                    BTM = (LRL, NDV)
                    FRH = (MBP, BFC)
                    PCP = (XVB, LHQ)
                    RKA = (BGX, BCX)
                    VNP = (LXN, RKM)
                    KLM = (JXT, GMQ)
                    BJM = (XNC, HKV)
                    NRS = (KPP, KVM)
                    DJT = (DVC, FGT)
                    GPG = (BBK, XDC)
                    MLD = (NJL, LHD)
                    LSS = (SFX, RRT)
                    VMT = (XHT, MXH)
                    FCQ = (PPN, CVG)
                    LRT = (XMS, BRN)
                    QKN = (MVR, HSR)
                    XDR = (NQM, LQT)
                    LHD = (QRG, JJP)
                    VHZ = (HFX, CVR)
                    DRT = (JLB, RNG)
                    VMF = (KSP, SGX)
                    PTL = (MKH, HKM)
                    FGT = (CLJ, MGF)
                    TJV = (SCG, RMF)
                    JKK = (BGX, BCX)
                    TFP = (HFG, BLT)
                    DDX = (PTH, RCS)
                    MPS = (CMP, TFP)
                    QTJ = (TVK, TVK)
                    TVL = (XKH, TQS)
                    BRN = (KSQ, KRP)
                    FCR = (MXD, SBM)
                    TJG = (CFF, CSS)
                    XVH = (LHP, TBT)
                    KBL = (SHX, CHC)
                    GPF = (GSR, FVB)
                    XRX = (TQS, XKH)
                    FMT = (QGL, SRR)
                    JQK = (FTT, LNK)
                    XNS = (LLH, RNH)
                    FTF = (CFM, PCP)
                    NLH = (SGF, MLD)
                    CTK = (VTP, DRT)
                    XJX = (DCG, TDF)
                    NDZ = (BCX, BGX)
                    GPK = (RKX, RMP)
                    FGF = (RXM, BSR)
                    HVQ = (VXJ, TSB)
                    KDF = (TLF, DPH)
                    TFD = (HSN, SBH)
                    LXN = (JDK, LBM)
                    RJJ = (NRL, NSK)
                    DLC = (GKT, KCC)
                    JSR = (NQM, LQT)
                    DKX = (PXC, LKM)
                    NNK = (KCC, GKT)
                    CSD = (QQB, JHV)
                    LKV = (JFQ, VMM)
                    KVL = (TTK, MNG)
                    PTH = (GPK, SPN)
                    JHK = (VKM, FPM)
                    GXN = (LLH, RNH)
                    FVB = (XRL, JSJ)
                    RBS = (KMM, PPC)
                    BGQ = (SLH, HPV)
                    QQQ = (GDN, ZZZ)
                    KFR = (BBK, XDC)
                    TDF = (SVV, KMP)
                    RSN = (FLQ, VKL)
                    TMH = (HQG, KDF)
                    QRD = (JHV, QQB)
                    MGX = (MVB, SGL)
                    JBR = (PJF, QRB)
                    GCQ = (GPF, PLR)
                    VKL = (RNC, CTJ)
                    RFM = (FCD, VFT)
                    QSD = (KHP, VSF)
                    BQB = (NRS, NXG)
                    GMQ = (TLP, TXN)
                    XMS = (KSQ, KRP)
                    LQT = (PRL, VGG)
                    HDG = (MRD, DGL)
                    QND = (TKQ, TNT)
                    JKF = (CNV, KBL)
                    TRR = (XXS, SXL)
                    XRT = (RPQ, DKC)
                    LQQ = (RQK, BSB)
                    VDS = (QQD, SSM)
                    MQP = (BVX, VNP)
                    PHB = (PGD, GHL)
                    NNG = (CBC, XFT)
                    KJD = (PBM, HQK)
                    FFD = (GRR, FVM)
                    NNT = (BHD, BLF)
                    CDP = (TNG, MBH)
                    FQP = (JKF, QST)
                    PRL = (XML, XML)
                    DPM = (QGJ, RDM)
                    NHT = (PBK, JGV)
                    PVG = (LPM, QFL)
                    NJQ = (TFJ, KTX)
                    SLM = (LNX, GHJ)
                    XML = (XJX, XJX)
                    XDM = (BCC, NLX)
                    LRF = (TLC, BDQ)
                    TLF = (QCV, TBV)
                    SGX = (NKL, DPG)
                    TMM = (MVB, SGL)
                    SHS = (DPD, HBN)
                    CHD = (GDN, GDN)
                    HTQ = (NCV, MJP)
                    SHX = (NDF, VKQ)
                    GXT = (LRF, BMG)
                    RKM = (JDK, LBM)
                    XHB = (BNL, GSK)
                    VKQ = (VMF, MDF)
                    KCC = (SVS, RBF)
                    PPX = (NFL, QVP)
                    CBC = (GNC, RQT)
                    PRV = (DDB, SNX)
                    SVF = (GGP, CTQ)
                    NFL = (VSG, QRS)
                    LHN = (BJT, FPR)
                    MLC = (HTQ, LPX)
                    DNR = (GGR, LQQ)
                    DPG = (TRR, GRQ)
                    BVB = (GFT, VRH)
                    DTR = (RQS, KQT)
                    SRK = (VTD, BPM)
                    KLN = (PQC, FPF)
                    JFT = (JKM, QKN)
                    HKL = (DVC, FGT)
                    BQD = (BVB, SNM)
                    RLL = (FNK, PBQ)
                    PNH = (XSN, KSB)
                    DKQ = (SLS, QMV)
                    BSB = (BQB, JQS)
                    VGG = (XML, CPF)
                    FNC = (VFC, PRV)
                    BDQ = (NLH, BGC)
                    NVB = (DQQ, FRF)
                    NDF = (MDF, VMF)
                    NQM = (PRL, PRL)
                    JVL = (SRP, GSB)
                    NXG = (KPP, KVM)
                    MPH = (LXH, SXV)
                    JNM = (TVK, CSR)
                    VFT = (FLK, JCC)
                    RFH = (FPF, PQC)
                    XQT = (KSG, LFP)
                    KPP = (CJJ, SNK)
                    XXS = (TRB, SBR)
                    PCL = (JVL, NPD)
                    HBN = (RSN, JJG)
                    TLC = (NLH, BGC)
                    JGP = (RMT, LCM)
                    DRG = (TFD, KFB)
                    FNQ = (HVJ, BCD)
                    DMT = (PPC, KMM)
                    SVS = (MCL, JBX)
                    GSV = (SRC, LKV)
                    BHJ = (BFN, KLB)
                    VPF = (QTJ, QTJ)
                    LRJ = (VDT, GDB)
                    TBL = (LRF, BMG)
                    SVV = (GDX, SLM)
                    NXH = (RFM, JFL)
                    FLK = (XQD, CTK)
                    PFQ = (JVR, NJN)
                    MVB = (KLN, RFH)
                    RBF = (MCL, JBX)
                    NRD = (GHL, PGD)
                    PPL = (KDV, TXH)
                    SXV = (QQM, NGC)
                    LNK = (FDQ, KVR)
                    SFX = (FNC, GKD)
                    FMH = (PCM, QLC)
                    HVJ = (GBB, PBR)
                    CSR = (DLG, GPZ)
                    QVP = (VSG, QRS)
                    QST = (CNV, KBL)
                    NTJ = (SVT, FKX)
                    GRQ = (XXS, SXL)
                    HSR = (GXN, XNS)
                    XRL = (LGJ, TJG)
                    SDV = (PNL, RRC)
                    MXH = (SMD, GDT)
                    KRS = (JVL, NPD)
                    TVK = (DLG, DLG)
                    FPF = (BQD, KJN)
                    SGB = (BQK, SVR)
                    KNF = (SHF, LVG)
                    TPQ = (NXV, LRD)
                    HDD = (GRM, XRT)
                    BGX = (HCX, TMH)
                    TTK = (LFG, KLM)
                    RTD = (KPM, XHB)
                    XSD = (QBB, VPV)
                    SNM = (GFT, VRH)
                    LPX = (NCV, MJP)
                    DDB = (RMX, NJJ)
                    MJB = (BVX, VNP)
                    JKS = (SKK, BHJ)
                    MDF = (SGX, KSP)
                    KHP = (FTJ, RKQ)
                    FGJ = (XSP, BPQ)
                    LKK = (FNK, PBQ)
                    CFM = (LHQ, XVB)
                    KKP = (KSB, XSN)
                    LVG = (NSV, MCF)
                    RKX = (FCQ, SNH)
                    NLD = (GGR, LQQ)
                    QMV = (MDM, CCT)
                    TCQ = (KTX, TFJ)
                    LXT = (JSR, XDR)
                    TFJ = (GHQ, QRL)
                    TMP = (LHP, TBT)
                    MDM = (FGH, MPS)
                    KVM = (CJJ, SNK)
                    LXP = (RTX, MTB)
                    DHB = (CVR, HFX)
                    SCG = (HTT, TCG)
                    TLM = (PJF, QRB)
                    CJJ = (JLP, JQJ)
                    CHB = (QNV, RPD)
                    JGV = (DHB, VHZ)
                    VSG = (VGS, BVR)
                    SKV = (FHB, BDD)
                    TSS = (RTR, XKP)
                    VNT = (CBK, CHB)
                    TDD = (VDS, VDS)
                    NDV = (DLT, JQP)
                    MBH = (VPF, FQG)
                    KJK = (KSG, LFP)
                    LRD = (SMB, DHL)
                    SRF = (PNP, KJD)
                    JDK = (DRG, QVX)
                    CCP = (SKD, BVG)
                    BML = (QSD, NLB)
                    SJR = (DJT, HKL)
                    SRC = (JFQ, VMM)
                    CTH = (FRF, DQQ)
                    BCC = (XKR, PNK)
                    MBR = (MXD, SBM)
                    JPL = (CBC, XFT)
                    JCH = (JSR, XDR)
                    JDS = (SJR, CKP)
                    PBK = (DHB, DHB)
                    QRB = (NGG, MRG)
                    LVN = (DMV, CMS)
                    QLH = (GNB, RPH)
                    NQT = (QND, HKQ)
                    FHB = (LJD, NNT)
                    QXM = (VRK, NTJ)
                    RDQ = (HLS, SDV)
                    KTD = (PNH, KKP)
                    KRP = (TRP, BLR)
                    VNC = (PNP, KJD)
                    DHS = (BXD, XPM)
                    XPX = (NQT, SXK)
                    KCG = (RVH, PJP)
                    HCX = (KDF, HQG)
                    NBR = (HKV, XNC)
                    TSV = (QFC, XSD)
                    SRQ = (SDV, HLS)
                    LBM = (DRG, QVX)
                    SHF = (NSV, MCF)
                    RRC = (PFN, JJC)
                    HKQ = (TKQ, TNT)
                    KKJ = (LSS, NDG)
                    LSM = (HDG, FBH)
                    VFC = (DDB, SNX)
                    CGX = (NLB, QSD)
                    RQT = (LJP, PRJ)
                    CJS = (BCC, NLX)
                    NKH = (CKT, DTR)
                    TSB = (CDP, RRG)
                    HSN = (DSL, LVD)
                    LNX = (KRF, KJV)
                    LHP = (CCJ, HRD)
                    RQQ = (FTF, GNQ)
                    GNB = (LBV, KSN)
                    PMR = (CHD, QQQ)
                    DGQ = (KXR, LNS)
                    RRG = (TNG, MBH)
                    FRV = (HPL, RQQ)
                    RNC = (TPQ, KTL)
                    HQG = (TLF, DPH)
                    JRH = (CTH, NVB)
                    DMV = (DHN, BTM)
                    RBT = (SGR, VKC)
                    JRL = (GSV, JRN)
                    FVM = (NLD, DNR)
                    KTV = (TQH, KCG)
                    SDF = (CKD, CKD)
                    LRM = (SVF, FBG)
                    RRT = (FNC, GKD)
                    LGQ = (LKM, PXC)
                    BDD = (LJD, NNT)
                    BGC = (MLD, SGF)
                    MQB = (SVF, FBG)
                    DQC = (XSH, CGM)
                    QFS = (VKM, FPM)
                    QQM = (XQV, BKB)
                    CBK = (RPD, QNV)
                    VRK = (SVT, FKX)
                    PQF = (MQP, MJB)
                    VSF = (RKQ, FTJ)
                    DKC = (HND, KJX)
                    HQK = (HHV, KMR)
                    SVR = (MBG, JCQ)
                    JCV = (BVC, HDB)
                    RMX = (VHR, VHR)
                    QLC = (RLL, LKK)
                    NJL = (QRG, JJP)
                    NDP = (JRL, KMX)
                    DNG = (PPL, QCX)
                    MCF = (GBV, VBV)
                    NJJ = (VHR, NHT)
                    SBR = (VDR, JDS)
                    NJN = (BML, CGX)
                    TBT = (HRD, CCJ)
                    PVF = (CKD, RKL)
                    KPM = (GSK, BNL)
                    PFR = (DLC, NNK)
                    BMG = (BDQ, TLC)
                    DHN = (NDV, LRL)
                    LXH = (QQM, NGC)
                    CSS = (RNF, FGG)
                    PQC = (KJN, BQD)
                    BJQ = (RCX, JRR)
                    VMM = (MTC, PPX)
                    XKS = (XMS, BRN)
                    XQP = (RXM, BSR)
                    SFF = (QSR, QLH)
                    BXD = (LXT, JCH)
                    SKK = (KLB, BFN)
                    FKR = (XPM, BXD)
                    VBV = (LSR, FKC)
                    PNL = (PFN, JJC)
                    KMM = (GSP, HJL)
                    JRR = (SDD, QXM)
                    XHT = (GDT, SMD)
                    NCV = (XKS, LRT)
                    HXJ = (VNL, MLC)
                    CVR = (LMK, GJD)
                    BKB = (DKX, LGQ)
                    JCQ = (KRS, PCL)
                    LVD = (MST, RVS)
                    LBA = (XQJ, PFH)
                    GXQ = (LRJ, BGT)
                    PFN = (FQP, TSR)
                    PSK = (FMT, HVX)
                    GSP = (JSD, FNQ)
                    JLB = (NQX, KFL)
                    SNH = (CVG, PPN)
                    BPH = (HDG, FBH)
                    NRL = (JQK, DXL)
                    NLB = (VSF, KHP)
                    RNH = (TMP, XVH)
                    GSB = (QQK, FRH)
                    HLB = (MLC, VNL)
                    BCX = (HCX, TMH)
                    RMT = (SBD, JFT)
                    SNX = (RMX, NJJ)
                    HMF = (SHS, HNL)
                    HPV = (RJJ, KHM)
                    LCK = (BDD, FHB)
                    BLT = (KVL, KDH)
                    CKP = (DJT, HKL)
                    NGG = (KFG, SFF)
                    CPF = (XJX, MTZ)
                    PJP = (HVQ, DLP)
                    XSP = (XHD, SGB)
                    JQP = (JBR, TLM)
                    HVX = (SRR, QGL)
                    PNP = (HQK, PBM)
                    RTN = (FGF, XQP)
                    JQS = (NXG, NRS)
                    PVH = (DGQ, TRF)
                    XHD = (BQK, SVR)
                    CXG = (VNC, SRF)
                    MTC = (NFL, QVP)
                    QLD = (KVJ, LKJ)
                    RNF = (MBR, FCR)
                    JXT = (TXN, TLP)
                    LSH = (QFC, XSD)
                    XPR = (GCQ, GLH)
                    KSP = (NKL, DPG)
                    DGP = (PTH, RCS)
                    RDM = (LHN, QBH)
                    MST = (NMX, QSC)
                    GRR = (DNR, NLD)
                    BBK = (KNF, TBG)
                    PBM = (HHV, KMR)
                    SPN = (RKX, RMP)
                    KJV = (XGB, CJN)
                    QGJ = (LHN, QBH)
                    CLJ = (LRM, MQB)
                    LGJ = (CSS, CFF)
                    PBQ = (SDF, PVF)
                    VLM = (JKS, VXD)
                    TLP = (XRX, TVL)
                    LFG = (GMQ, JXT)
                    VKC = (VRV, JLL)
                    XQJ = (LVN, GMJ)
                    CHC = (NDF, VKQ)
                    VGS = (JHM, DKQ)
                    FCL = (SLH, HPV)
                    LMB = (FMT, HVX)
                    GJD = (XDM, CJS)
                    PCV = (XHB, KPM)
                    JNT = (PSK, LMB)
                    SXK = (QND, HKQ)
                    HCH = (XQT, KJK)
                    DGL = (JLV, PMR)
                    RCS = (GPK, SPN)
                    JHM = (SLS, QMV)
                    JFQ = (PPX, MTC)
                    KSQ = (TRP, BLR)
                    BVG = (BTV, XPX)
                    NDG = (RRT, SFX)
                    GKD = (PRV, VFC)
                    GJT = (BGQ, FCL)
                    GRM = (DKC, RPQ)
                    KBM = (JPT, DPM)
                    VMJ = (LXH, SXV)
                    GDB = (RBT, LLJ)
                    KTL = (LRD, NXV)
                    JMA = (CVR, HFX)
                    NTS = (BVG, SKD)
                    TBV = (GPG, KFR)
                    KFB = (HSN, SBH)
                    JLL = (FKR, DHS)
                    LDR = (TQH, KCG)
                    QBH = (BJT, FPR)
                    KLB = (DNL, FVH)
                    JQJ = (RBV, TLD)
                    GGP = (QFS, JHK)
                    GSR = (JSJ, XRL)
                    RTR = (HMN, FGJ)
                    SMD = (HDD, NML)
                    CJK = (TRF, DGQ)
                    LCM = (SBD, JFT)
                    FTJ = (KTV, LDR)
                    SNK = (JQJ, JLP)
                    TNS = (CCP, NTS)
                    FKX = (LSH, TSV)
                    JKM = (MVR, HSR)
                    RMP = (FCQ, SNH)
                    RBV = (RGG, HSX)
                    NGC = (XQV, BKB)
                    LFP = (KKJ, FHL)
                    SXL = (TRB, SBR)
                    NLQ = (PSK, LMB)
                    BPQ = (XHD, SGB)
                    QNV = (RDQ, SRQ)
                    HVB = (PCV, RTD)
                    GHJ = (KJV, KRF)
                    JFL = (VFT, FCD)
                    KMX = (JRN, GSV)
                    VXJ = (CDP, RRG)
                    DNL = (KDB, GXQ)
                    JSD = (BCD, HVJ)
                    TRB = (JDS, VDR)
                    KVR = (KBM, NFP)
                    NPD = (GSB, SRP)
                    XVB = (PFS, JSB)
                    GGR = (BSB, RQK)
                    CMS = (BTM, DHN)
                    GHQ = (HVB, DKP)
                    KCM = (CCP, NTS)
                    GBB = (SRK, VBB)
                  """;
}