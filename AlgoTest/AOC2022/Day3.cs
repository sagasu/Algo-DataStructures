﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.AOC2022
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace AlgoTest.AOC2021
    {
        [TestClass]
        public class Day3
        {

            Dictionary<char, int> alphabet = new Dictionary<char, int>()
            {
                {'a',1},
                {'b',2},
                {'c',3},
                {'d',4},
                {'e',5},
                {'f',6},
                {'g',7},
                {'h',8},
                {'i',9},
                {'j',10},
                {'k',11},
                {'l',12},
                {'m',13},
                {'n',14},
                {'o',15},
                {'p',16},
                {'q',17},
                {'r',18},
                {'s',19},
                {'t',20},
                {'u',21},
                {'v',22},
                {'w',23},
                {'x',24},
                {'y',25},
                {'z',26},
                {'A',27},
                {'B',28},
                {'C',29},
                {'D',30},
                {'E',31},
                {'F',32},
                {'G',33},
                {'H',34},
                {'I',35},
                {'J',36},
                {'K',37},
                {'L',38},
                {'M',39},
                {'N',40},
                {'O',41},
                {'P',42},
                {'Q',43},
                {'R',44},
                {'S',45},
                {'T',46},
                {'U',47},
                {'V',48},
                {'W',49},
                {'X',50},
                {'Y',51},
                {'Z',52},
            };

            [TestMethod]
            public void Test1()
            {
                var data = realData;
                var score = 0;


                for (var i = 0; i < data.Length; i++)
                {
                    var dic1 = new Dictionary<char, int>();
                    var dic2 = new Dictionary<char, int>();
                    var mid = data[i].Length / 2;

                    var row = data[i];
                    for (int j = 0; j < mid; j++)
                    {
                        var firstElement = row[j];
                        var secondElement = row[mid + j];
                        dic1.TryAdd(firstElement, 1);

                        dic2.TryAdd(secondElement, 1);
                        if (dic2.ContainsKey(firstElement))
                        {
                            score += alphabet[firstElement];
                            break;
                        }
                        if (dic1.ContainsKey(secondElement))
                        {
                            score += alphabet[secondElement];
                            break;
                        }
                    }
                }

                Assert.AreEqual(7742, score);
            }

            [TestMethod]
            public void Test2()
            {
                var data = realData;
                var score = 0;


                for (var i = 0; i < data.Length; i+=3)
                {
                    var dic1 = new Dictionary<char, int>();

                    var row = data[i];

                    for (int j = 0; j < row.Length; j++)
                    {
                        dic1.TryAdd(row[j], 1);
                    }
                    row = data[i+1];
                    for (int j = 0; j < row.Length; j++)
                    {
                        if (dic1.ContainsKey(row[j]) && dic1[row[j]] == 1) dic1[row[j]] = 2;
                    }

                    row = data[i + 2];
                    for (int j = 0; j < row.Length; j++)
                    {
                        if (dic1.ContainsKey(row[j]) && dic1[row[j]] == 2)
                        {
                            score += alphabet[row[j]];
                            break;
                        }
                    }

                }

                Assert.AreEqual(2276, score);
            }

            private string[] realData = new[]
            {
                "NJvhJcQWTJWTNTFFMTqqGqfTmB",
"VwVzPldRZVLVRmfsvfjvqfmm",
"ZDPDHZHVcvDhbvnv",
"FHHwHBzzVCWWmmCzCPrVmgBwbLTtRFFbbbttRGRLjTcLpbbT",
"vhZZvdsNSdSMdNvjncppCLcLnGnj",
"CDZZsNZMZqdNSdlNZCqrzPHDzgrgzwVVWwmwwm",
"ndlndntsFJntFvccLjjLrjBShcBBfc",
"GpCGHzVwmmzqQWSSSfWHBhQL",
"mpCMGGCZVzVwGGVwmJsZnFtZnTSTJtdsvl",
"nCnPDGmDNmVCsVQDmGSWqvzchWSjjcWGqS",
"gTnBRLpfTRnrTdZgdLfRdrThvqcvWWhFFWvcFSSgjqqzjv",
"pfZfTMwrbLTTfsbmQtlVtHHnbs",
"wNdSdsbTvTZMTvTv",
"rrdRWdWQhFVdHWBGWQmmmnnMvCfmnhvmCmtZ",
"rJrVDRWpGddpbSlNSlspPP",
"chTNrthMMwWMTjfsmRzZszJpwm",
"BLnFFCngbcBnbbldDlpRjGpmsCzGsGsRGmmG",
"dqvnvlgbqtcPPMhH",
"QcLNqZbCzJDQBJJRpwzRpdnRldgnpf",
"GmmmvVGsHrWffrlwdCWd",
"CMsFVVFjCmFStGQbbLZNBbJBcTjc",
"LQVggbQvcLbQLHgvVLhWGGsChssrMWfzGccc",
"qDnRTTRqJttPfWMChJhGslWlzh",
"qRTRwPBTBtRZdnjnqqqnQVbjbNLFbbfLgVmgHLQm",
"cZbzwCwZPlJcMLrNSNfHWNBBNZ",
"vsQsDCqtsDhmtjVrBNWNjBHrhr",
"TtDTGnvTlgbbRCGg",
"BgBlplHlsgNNsJlVpBtPwJhMPRRQSSttRtSP",
"bvhTnmdFTzddStwStQRddt",
"ZnZDLvnvqZzbbhFzzmTbnFsVjVlNgsCCNVsVLpNWVgsB",
"TdptqrrcVGhhzFtw",
"DRnSfwJlDmmDDVGv",
"RCSQNSCQZndwbcMqQrBB",
"wvRlrlwVwwqzgbZRdCJBWfmdzCWfBdhf",
"cFcsQpNtLLsGTtNGpMdPmDdPBmmBvJPWvDtC",
"TpjssTFFvLLLcFFQpwbwwHngjHRrZRqZVH",
"mqqddrPPcPmqPDlrQnjTrbvMvbHzzsjjpTvz",
"gtBWgGgVhLGWHzMDztzstDHj",
"hfWRhBBNBGgLNQDPwdNPcPdw",
"LhQzdhhbTzpMhddhhhTzhnZcBFllHZFtrrHZHMHFjlHr",
"mwwssqDvjptrvplr",
"NCSgVDPDwmDgVJVpLfTznQJdhfLhnhQQ",
"GzjzDhjhhZzcrRgQCBjBPBBjQCgT",
"vHHHmntsbSgLwbsSmNHbwNbvpqPCBVppCpFTpTPTBtqWBCqV",
"NJbwNSwdndvmvwhGhgzcfMcDJfgJ",
"GncgDvvcMGnttjDvrgRRFSZZLZFWdJFJwGQwZBWZ",
"bPqpChPfsshfZZBdZdLTFZ",
"lNqqsClmbsNlPbHqPsmblmsrHdvdMngcVrjggvrvggRDcn",
"bDvtgVVVpMQvjQWmQL",
"rwTflmlfZJBBdQWQWjQqdM",
"HsJJmZZwscHrwTrcRbzpcbPgtCSbgz",
"CsCsRvshMjpbqCqf",
"ncblgDBgtDmmmTlBgwlgbHHqMFHLqPDMHPHHpqWfFM",
"TcBctSmTZTtSTzsZvsvJZRsGVb",
"znznvngttwltzlLwhtThHbqHPvNbNHSSHmmNWHjP",
"FBcLrRMFQpPqpPSpqHHW",
"fRQMJZJfrcMcMVrQJJftnwCzVCltgTnstTVnVL",
"MfLlRfCMrLzRlQgwNqQFcsGd",
"jtTjjBTvbdqcGjqFcj",
"vvShDSBDppzhCmzq",
"plWMptTvfrnncvcRfwqzqLGhzhzThNzNNJqD",
"jSdSHFPQQbdPCQCssjSbBmhJGNZZNGNqqJNBlJqqLh",
"VCCCVCQgjdddjCgljCjbbwgRRttgrpftfWrgvpwpnf",
"MWlbBcPjjvvjPWWMPqgRQZfJZDGGbRZJffQQwh",
"HrHrnncHpzrJQJfVDQVR",
"zzsSTtSTLzsspSdtTmHHmpmtFgqcgPlgFqWBqqqBMdWWvFlg",
"nSqBbJbqlnBBClVZcMgZVgcP",
"FQwrwHrRwWWFBRPNgNgcCGZZZC",
"rWFWFTwpwwWzHrnDbfJDLDbBBbbz",
"BMmNtLMMtFCNFNMvvLmcndpgcdgppPrgrGPPrgJD",
"WVWWhbTtVnGpjrrPhr",
"HWssSTHWfRHRsQQFLvfvFFCLCNMNlt",
"sTmDsQffVrrLCjTFltTFWL",
"BnwwQBJbJndMMRzMwCLlWlLWWCWLLtRlWF",
"cqqBMcMqwnznMGzcvDmQhrvssHmPDVssrP",
"pQGQGJDDrDVJbbfVzvvgPcCZwhZhncscZWWc",
"SqMMlBBljMmRlchhPTqThCZnPs",
"FMjMBmjRNFHQJJpHVhVDhG",
"tHNNdBdNtBBBMgsMpsZm",
"wVPzVvbwqzhrVqvjqzzsZpDsZDsZmsCPCgZgCM",
"bVbvLThvvbrWqHmmnJLdHdJQLn",
"PzTspPZpdLLDZTplPLpPDpvbfhnqNvqzfvNMzQQfNwnQ",
"GWRHmjmFWMMSnhbhHw",
"JWWcmtBrBtWBFWGJpsgTgldhLVLpJl",
"DwLMDzLMhvMcwvgdVqWWlCVgvlqF",
"TTSBBRpbStHZVgjWFldjRVlV",
"SnbTBdJBmnpQzMPDMcMznr",
"nNlMNBPPNtJQnbZhZsgSbh",
"czzCjcwTdvSbgQNcgNQq",
"VTdNdGDTzDTdlFFPtBrtLtDr",
"FMbbfMlzvFsmgVZmmg",
"SrNTHGmdSQDqLhtQhhgggs",
"dRDTSDPPcHRdHGDHlwJBbmwljmMcfjbW",
"sQgWLtqLtWhdqlpNZRpG",
"blTHTjlvTCJnJvRZdGGhHHGZhFGV",
"CCDlJclnCmbrmBMgcwcLWtcBsB",
"vqPWWvqwwCFvFZfZPRFRrcGQrQwsDrNcrwnbDNcQ",
"LVgJLSBBVtzTLzBMmTMJmLnnDNQcrsGbsQbNbrbDjs",
"zggVSmmhVdfqFhvHWG",
"WwdndGGmmmLwwwmRwWSncLRnZqZqhqZthBtqtBqZBgtdtvMH",
"FfHHzlQQDsFzzrNsVTfttZvTvttTqqtbqb",
"lQjFDNQFPjCsVCCDjGCwwSGGnccwcHppGp",
"mrjggcFsFMjdjZRpSZpn",
"NCqfLCFNbQPzPPlPzNfSRTRZdSdWWwndpqRSSd",
"vDvzzbPQFNCFtllLLNMBhMcDHGBGMggMmcBc",
"jhjlBvvnjbtDNPjtSjBDBbDNgHggrQrhghRQrqRrZcRwwqVg",
"pLdTMsWdLLmpMdqZZdPdVqZgHPwH",
"WLTCGmMLfPSlbGjlnnJD",
"gtbwhgHbHgqqbgQthgQLtZZCRjMcjjnRnrRNJmMRJrNhRc",
"bGWVTTvDvfpVFFBpvvVTdRDMJcrccCrJnMRnNnNCcc",
"FVWTBsdvdTzTBFWssVQtLgSQtHqqPzPbqHbw",
"dlzrPTSSjSrllzWhsvVmVtTRTWtf",
"bJMpLGcqGhNbJQttVQmmvRWWsp",
"qLbMwqqbGHFGzrlZrjhPHCrj",
"rNrrffVlqqrfLlPpltcBBTTGRzzZRPRsBTcJ",
"msbsmWSsMmQwjdMbWMhMhQmcRZRzGjTBGTBcBJBjCHJGcC",
"FwWbvdhbmrsFrfrgsN",
"rHjrQHdhdQrvSddcHWLssBSVVpBSWWWWWf",
"JNfTGtqDwVWBMBMpwM",
"qlltZgfJFvcRgcRjvc",
"CqfcwfDqwwmRnnqmRdNRBTRTRrdGdNpTvF",
"WVbzsZszBbrsvpdMpdQM",
"tJhbVZHWLLHDgnSwnSSgHB",
"TZCqqlTsqpZVVsZQJSBSLpLmppnJzmFz",
"brSgNtGjjRjRRjDddDtrRJcJJbJmmwcmBmnPcJFwFB",
"jgdRtMjNNjfqlMvShvSZSZ",
"dJTdqCwMNCgqTQllGBdlGBmmmZ",
"fcVfVcnbVfrwDLWVfncZBQPlBHRGljLZQjHGQl",
"brwnnfSFDvfzCTqFzgMJTh",
"njnsPBjjsrrnGLnbTTjGvcldQPCMllNzMvRQPCdd",
"ggZgfZtmZVpqZqZWDgFmgqfCcQRcRcWhQcccQddMcvRQdQ",
"tfqgggVgHpDwDtfwbGLJRjbLjsrLTj",
"JmrfrmTlDWTfgQCdHCdpqBvQdD",
"jsZtVzNsSNVQQHnBlVQR",
"PljljFjPljSsLPtFLTTgTcFrrfMJmrrmrr",
"hmGcmmndhmGnfmtGnDzFLwrFJQsQFzNFrNJG",
"ZSqPlSWcWlbgqWVTVWRVZPrjQqjzjFNJzLsNJsLJNqNL",
"RHcWTZbSMMMPgZcWgSWPPbVMDnBffmtdpDBddfnnvmCdfC",
"vSJvsbFfJfvqCsTHJswssJnLTZjjhzrrzLrzLMrzhdjM",
"pBNQDPcpmWDcBNgMMnZPVjdddnndhH",
"QWlDgmpmgDBlGRgDDgffSqwSwGCwHfvqwSFJ",
"jvlgvMJclPdGdtdcjMVmMHbFHFVHWHbZHZ",
"CwhLzLhzQpnqfpfqDVHCHbsbDFZDmHmj",
"LnBzfQjSzQrPvJvdSSrr",
"wpcvcsqclDCnVCVvWfnZ",
"BLRMRtbnbbBLNCjNCjVVZhbC",
"rFgMPSRnrRpmqpJwqFDs",
"LZQNQbMrZppLNLQplvlGLNvVmmmfjbwVCfjbwJwCmBCwfj",
"ShTPRFtTHZPCsnwswsFwCF",
"WtHRPdThSqZTRtDqtdRWTdpGDLLzrNczvzMGLlQLGDDM",
"hdcffBvldjhCMljqPwWwWNwWdwqHZr",
"LtQmbQRVsZQZMZPQSN",
"tmMRsJMpDhjJzJhv",
"wNQCMFCDQDBmrHmmRWrrHN",
"SShLnfqpcqpSZSfrzJvRVrvfrrJH",
"cRpqdGclpScltTQQtsFQMQsTCT",
"NCjggZmgfBgnBmgWbcwcTFctcWWfvb",
"HsDGthRGrtppSQpbFFJTVcJdFbTRvd",
"rPDGhDDrSzZLtzBLZMCB",
"RsBBMBsCBlFFCgRsBJzlMjMPNSdPhSrSrzLbmSDrDNmDSd",
"pZHZZJpGHHHpTTHvTncZqVLdqLbhLrDLdhrSLLbLDDdD",
"tGtwnJccvCtCffMBgt",
"wbddvVjfwPhbjjbDbbvbjvTNCNmfHZfpCZRJNzCmJmnJNC",
"BslcLtclZWsZJWNrRRNRpRmR",
"BSLBlScGtFMcssMBBFGLlQZTDZQjPddVwwbTdvvdhTZb",
"NSZHzmLZBnzHmLLzLSntDttDDtddhDtttDWW",
"QgfjsrrvNNJwtMddcvcvtq",
"jrfgfQpQrTTVLSNBClFV",
"GQWcWWPPQRcrJQNDdRcDmmLCFSnqNSmqhCNvFnql",
"zHfwjzpMjwZmCLqvvnlljC",
"ZgtVZBtHHZtgQGgPrbPRJdPv",
"TWdWpJTJTdgLWfWLlLFLrfrgBGsNqhGslBGHqSNqqBNshnws",
"ZpQmjzbZZCjZCCCPZtttRCCwsBnHNssBHbShsshHqsGBqN",
"RDRRPpPCzmZCtRpVVJFrfTfWFLLJggJrDv",
"pDDFlglsvFMgntlTMMqNffmTdfddRM",
"jhGJLVCHQpHGQCCzLjWdTTdZZdNdcRWNccWfNN",
"jQjSGjrjCQLhzVSLSCSHGDpngbrnDFtFBwBglBnBvg",
"wsLzstsgszcpcGLHGpcgcghlDBvQvjQvbFbQCbJBtCCJJv",
"mnSqRSSqSRThWRnmWWRSJDFTFCFCblbBCFQFCjFj",
"rZRRWqSSdZZfMVnZLspPsMgHpzMhHGPg",
"mwHrCLSWWwrsHCHDDsVrsmhfFZFnSSBlFlgZbbgBglbggj",
"GJdpcRtGJvNRdcPtdpJJdbQZfjfQBlnQBjnBtbfFnB",
"qcPpqqzFzJqvPVCCmWrVwhrWrz",
"jjMbvbhDvnRjNRGMmjbMZftSSwwwthJSffStctcwqd",
"lTQrVlpCVvCcfdcSJqLVcw",
"srHFWCHrFlrHlrsBsprljjRmDZZnmbDngNBgbNZv",
"MgTlQJlTQJZWpgLrRssrVqqqpRts",
"bBNbbzSSjMBPjzhMjsPtRVVRVPRqLttGGs",
"SjHBbfjNCDfjZgTlZdMJnDJW",
"lpThgTwtplhghgwhThqnnrdZctSZSjSZcRSRfbdrrc",
"RBVBGvmBmfdrcvrbbr",
"PmVGNGmmGRLLQwwLqTnglQ",
"nHwnBwBTnFHQwRsMhwghmzcm",
"GtprdCpdtqWdbqbrfdnPPszsWmRzRnShPszS",
"dGptbCfCrlnVDBJNLDLLVDLQ",
"CZtCjhTndCzqbCNq",
"dwpGvpsmwGslDszrNNrzqDMzWMgJ",
"vmcGccvpBVPTVTjTdTTTdZ",
"jWZhvZLjZfCZDwrDrSSzJGhVdJccscGsgV",
"blMBlRqqqgSJLBLcsJ",
"blmHLmFMMMnRqLmMMFqHmfPDfjQDnCDDQrZvfCjvDr",
"rnvnHrDLFZmMFLvrHQBMGQggBztzglplRl",
"sbWWhdNzsshsfhcsjJJPPbWdtQGVGllRTRjRRgBgQlpRlppB",
"PPCCwNWhPhNfWCzbqmFnDFFnCDLSrvZS",
"GChNjwWlWJWTJZBggvdgnQgdhdnd",
"HPsHfHHrpHDpFFrcSfsfpCMmQdntLBMgtmtBgDdLLC",
"SqpPscpPzpSWzjlCjjCGjl",
"nvgLvcLgvgvngbLprpJNTDCCRNVJrNPlDDTV",
"WZsMtsffGQtMzWFqFmWmWsVNJNlDwwCDVRTwJlCCDVLz",
"BQfGZGmmsMWFstWFmfMsfBccdncbpbSbvbbvHnLbpc",
"tsmDsvswNZmcZTccfh",
"zCTpGCbWBRWFWHGRFZJbMbJfnrhnhfMnnZ",
"TzFGFBRLdpHHNNQddDQDvwQN",
"fhBBpJgdHddjZQfmVmNzNNLmFN",
"qvMRrvlbwqlbTTMBMvLssFNmVzzwFDmLLzVD",
"TRSRWqRRMcBHhGHcdGgPGp",
"lSjHmtmnpHStblnpSlHSrtmMzLWzqzqCZDDTzTTWqMFqCqVV",
"sLRLLfPPRQfCTqqVVqFT",
"dNJgRPNQNsJJhBRvdJvQvNNsjSrrSmrcctpbpHtBrBjLjmSH",
"nwFwpppjfwSlpLTsqsTgNshhjM",
"ccBRGvtsmgGNPqNNGP",
"BCcJHvssdcWBCVmVHSSrZrwVzblpwbzZnf",
"rcfQRrBPPczjcRBctZDNlnVNHbgZGjVDjN",
"TvMsFJGSFMhJnNZlwVVnDNTZ",
"qhSqqmqLCLhFdJLqSvLhmQRQRWcRPczPtzrCrWGRBp",
"JVhdPhsFPFqLDBHVdHLPvhHDCMwcgJJwbwRgnnCMbwGwcmGC",
"fzjzpTZTQQQLwCbgGgbMmQcR",
"jzNpTzfSZtfNSWZlVVtdFFFDHHqLHVqv",
"TwSNnSnSGVTpNppGlPTlTcVqQrRhVBqdqBRqZqQZqQ",
"DcDCMfDbCMHJdrRBqbdjRBRZ",
"gvftMCJHcHfCDmDLgfMmMmmWlwWnWsTTwlGTlWTwppNlGL",
"pbGMbllDQPhhWWQDpPgVGlMCvRRrQLcCCcfBBQzLBcvQBv",
"wqnJjSmjrstdqwwFBLcRsBRRszzLFC",
"qwdddTJTdHtjndqJqHZHmwVWGpDbGTlbWWpWWrPGhhhM",
"WGllqLjjLCpSffmBmvfpHs",
"dnrQwZzRTdZwnCThdzzFTVmcBHBJBmsHfBPHcfvcSVHs",
"QgQrzCdrTRCZzrZLbjGLqNMWGgNNLt",
"sgPnhPPTTPTTwlJfwNHlqcfs",
"LMCpFbLLbRpMGbMcCFLVlNlNqrHqVfbHHwNDwr",
"GjBcCCtWMtMRZTSvgWQTngvg",
"BCMtJJMpRDlMMvBJBBnfjtcjPhPmZgnhgdcf",
"NrsrsqFNvrVLVGVrsHsqFgfmcPGdcmhfjdPgfjcnZd",
"zFTzsNqHqFssLVLQqNTFbsBDwCCwvWlDwRMRCTRBDMDS",
"zQtLgvggSRtgvVRtLvvnzdnjnGwGdmmrlpnlGz",
"JssBFpqsDqPNnlWWjrrjqrnj",
"DHDFBNDfPbJBsFHNMPvpvStQvMRVTtgVTVtv",
"FvzttFvBTJJzLbvwhCnnVnWwjCnBNC",
"mQdZgZPDPdPPSsMSQPdZgCwVGmnwnWpGnGhqNWjWCG",
"ggdDgfQSdcjtFHjlLJfF",
"ghcgScNNSsCvGSzmpVFlZbrzcFcV",
"MWWRLRqqqdQwTtLjjmqMlFpFlzVnbFVDwplFzlDr",
"LHMHqdHWjdQMdMtLHHLtWjJRsGCGSNghmSvPBJBNhsGfvfGP",
"CbVqqqDbcbMHnnDqcCbrRFCfBvvwGjzrBwQGzrwwBjGwBQ",
"sTPmpNWdWPTJssSSLPfNljjBvflGtjwwBzMG",
"mmWgmgSZLTLMZWpnhqZbhFFCnhqnnn",
"QQmjmZqnmQrfTZlbbcVbBcfbHfzf",
"vpdSNShNppFdSRtdGBqvJBDlDzqbPPHVBH",
"tRNSNRFhNpSRhFRMFtGhRGswLZZsZqWnmrmZwqwsTZmmmQ",
"gGWCllFCGWtGGWdlGlWNZdwpnnSbwpMvpphZpndn",
"RsshDDLcQVMSJQwJwnvw",
"HVPzrPcDNhPFGhPC",
"jtHQGHjGGtdTLjnqTQlmvRPRPBBwRBnFPPWP",
"hZbzNzVrczZzcbNssVspZZVvBwbmPmJPWmvbBRvPlmvRJF",
"fzNVDsZMhzpVhpVhlZcMNfcDDdQTLTjGDTCqGCjtSQHdHL",
"GrbFggGrTrzSrgfwJjdTmwmNJZJd",
"VMPQplPDptchwdsjmlml",
"MqMWtBDPPWDWHQtvqQtWPjbzCGLgSBgGbzgrzFgnnz",
"fcJccCcwcDfcpbRnCfWJnQJqtqtqPQdsGdgPsgTQqg",
"LSjVMhzSFFrljdNbltNGtgdqQq",
"MMhSHFFMLzBWDcHHcfcHwb",
"rwmWtJWMwSNRJMtwNmMrrSsmtTjjlgqnTqZZZPlHnTngTTgn",
"BGqGqqFBFggjjdGHlj",
"QDhhLbDQCDFMNcmhRhqJNW",
"BnRnRvMnLGLSCHvvSnlRfWbbTNQJsJsbNbJTBfQT",
"tzMmmMwjhcpFjDmMcptrcjzFQggfQPTsWsfgNbbgfhJbPhQT",
"FdzcrtDwDMtcwtFGRZdRLvdnHRSZZv",
"HVpsSpvjpNjsBmbGFBnMNnDM",
"WRRWhZtfrVtLJrBZMnDmDbnZBTGF",
"thhPLzWzhzwPtLRLWrQlpPvvClcVcCppSvpl",
"lZPbhnZLRPnnPZZPdlGMBWcBMgMQHBBcvvvzBL",
"jpFjmwwwCDDbsjvjjgcvQgcNBQ",
"rbFmppbwhqhGRGZr",
"ggrLwFgWCBwbMWBbFwLMgNBZdmZHclJPllnJlNRPmSNZRR",
"ppszzDfhDfhsqpnvDVTfGpSPlPmclHcdRcZmmmdPPGSP",
"pvtDDVDVpqDfzDfngBLCwQrgCtCwFwrg",
"pbGjFFGGDjpbsGsmNhNFNRBBBtRhhhHv",
"JnczJVCvwWJvhPgghgNtNtNJ",
"nwVSSzdzzqSpvQSZQG",
"mssLLttQrsMrMzLCRmMmrrSQpvWpDNlBTBDlvNTccDQl",
"HdHJwJqVPwHnqJwbjJbGjnSgSTWPpNgWWpgBBgcvDWWN",
"ZHVwVZGwwdndqJVJqfHbGwnwrRLtLMftMvMMRrhmLMthhLmz",
"RgHGLbTqlZlPRZPHfvvfZttJnvfvjnzr",
"sVcChDVDccwNhhvjTvVzWJjnzFff",
"mpNcCMTCGmLqBLGH",
"wVJwHJHVMtMpBmDDWPQVPWDGDD",
"zCrlZzCblBvnCDWNGLmvGDLPNG",
"dqZglgbzrzbbgZqzTFSBHHFJSSSfjjSMfwhj",
"NMWJSjLMCnHHNMNNHWCHMbVVGBPZTrPVPBVDrBSDGTTr",
"zvttlFpgdtldwwvftPDPTWQdBZrsrWrGBZ",
"hFlFmhRFvfCbmWJWHcnj",
            };

            string[] testdata = new[]
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            };
        }
    }

}
