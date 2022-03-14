﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2021
{
    [TestClass]
    public class Day9
    {
        [TestMethod]
        public void Test()
        {
            var data = realData;
            var n = data[0].Length;
            var grid = new int[data.Length][];
            for (var i = 0; i < data.Length; i++)
            {
                var line = data[i];
                var digit = line.ToCharArray();
                grid[i] = digit.Select(x=>int.Parse(x.ToString())).ToArray();
            }

            var mins = new List<int[]>();

            for (var row = 0; row < grid.Length; row++)
            {
                for (var col = 0; col < grid[row].Length; col++)
                {
                    var cur = grid[row][col];
                    var prevCol = col == 0? int.MaxValue: grid[row][col-1];
                    var nextCor = col == grid[row].Length-1 ? int.MaxValue: grid[row][col + 1];
                    var prevRow = row == 0 ? int.MaxValue : grid[row-1][col];
                    var nextRow = row == grid.Length-1 ? int.MaxValue : grid[row+1][col];

                    if (prevCol > cur && nextCor > cur && prevRow > cur && nextRow > cur) mins.Add(new []{row,col});
                }
            }

            mins.ForEach(x=> Console.WriteLine($"{{{x[0]}, {x[1]}}},"));
            var sum = mins.Sum(x => grid[x[0]][x[1]] + 1);
            Assert.AreEqual(506, sum);
        }

        // much nicer solution is in python available here: https://github.com/sagasu/python-algorithms/blob/master/aoc2021/day9-amazingsolution.py
        [TestMethod]
        public void Test2()
        {
            var data = realData;
            var locMin = localMins;

            var n = data[0].Length;
            var grid = new int[data.Length][];
            for (var i = 0; i < data.Length; i++)
            {
                var line = data[i];
                var digit = line.ToCharArray();
                grid[i] = digit.Select(x => int.Parse(x.ToString())).ToArray();
            }

            var visited = new List<string>();
            var basinSizes = new List<int>();
            
            for (var i = 0; i < locMin.Length/2; i++)
            {
                basinSizes.Add(FindBasinSize(locMin[i, 0], locMin[i, 1]) + 1);
                visited = new List<string>();
            }

            basinSizes.Sort();

            var largestMult = basinSizes[basinSizes.Count - 1] *
                                 basinSizes[basinSizes.Count - 2] *
                                 basinSizes[basinSizes.Count - 3];

            string GetHash(int row, int col) => $"{row},{col}";
            int FindBasinSize(int row, int col)
            {
                var curr = grid[row][col];
                var basinSize = 0;
                if (col != 0 && !visited.Contains(GetHash(row,col-1)) && grid[row][col-1] > curr && grid[row][col-1] != 9)
                {
                    visited.Add(GetHash(row, col - 1));
                    basinSize += FindBasinSize(row, col -1) + 1;
                }
                if (col != grid[row].Length-1 && !visited.Contains(GetHash(row, col + 1)) && grid[row][col + 1] > curr && grid[row][col + 1] != 9)
                {
                    visited.Add(GetHash(row, col + 1));
                    basinSize += FindBasinSize(row, col + 1) + 1;
                }


                if (row != 0 && !visited.Contains(GetHash(row -1, col)) && grid[row - 1][col] > curr && grid[row - 1][col] != 9)
                {
                    visited.Add(GetHash(row-1, col));
                    basinSize += FindBasinSize(row-1, col) + 1;
                }
                if (row != grid.Length - 1 && !visited.Contains(GetHash(row + 1, col)) && grid[row + 1][col] > curr && grid[row + 1][col] != 9)
                {
                    visited.Add(GetHash(row + 1, col));
                    basinSize += FindBasinSize(row +1, col) + 1;
                }
                return basinSize;
            }

            Assert.AreEqual(931200, largestMult);
        }

        string[] testData = new string[] {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678"
        };

        int[,] testLocalMin = new int[,] {
            {0,1},
            {0,9},
            {2,2},
            {4,6},
        };

        private string[] realData = new string[]
        {
            "5456789349886456890123985435578996543213456789656899996467789234989765442345789778999989652349879899",
"4349891298765348789339875323456789665434568996545698874356679959879898321457893569998879931998765668",
"1298910989873234595498764312345678976746899989656987563234567899767987442578954678987968899897654457",
"2987939875432123489999953201234599698657979979997965432023479998959876553689965789876856789789543345",
"9896899984321012668899865313546789569798965469879876553135568987643988767997896898765945697698722256",
"8765789965442143456789996579658895434999876398767987864589679876542099898966789999833123598589810123",
"9954629876553234667899987988767932129899989219755398878678989987943989959355678998921057987678924345",
"6543212989654345788999898999998941098789998998543229989789797999899876543134989997632345698789545456",
"8654543498765476899398759126679953997678987987632101297997656798678965432015699876546559989898756567",
"8767654579879989943297642014567899889567896597543223456789348976578976543126921998758698979999768979",
"9988765678998999765965432123789998765456997498654345789893219865458897654434890139769987867896979989",
"9899876989987899899876843234891249654369889329765567899994325976346789887565789349898765756975395699",
"8767987899876999997987755346910198773235679939876688989875634987497893999679899959999654248954234799",
"9653299999875789986599896467899987652134567899999789879876786798998932398789999898998643135932129978",
"8632102398764578965434987578978698743028979989998998866987899899989510129999987797987659239891098769",
"6543223987643589874323498678965469764167899878987897654398999989876431236789876576898798998789989756",
"7654564597532599993214998789975379894356899865476789762129789879876543345699765455789987684569877546",
"8799796798543489874109899899876123989456989874345678995345698765987876596998954314597998593498766434",
"9989987987654678965929799999993239979569876543234589986797987653298989989897895423456987432987655325",
"9876898998779899899898589998754998768998765432107678999989298942139599879766889435668986543498943212",
"9785799659989956798767467899769878657889877543234789998979109893013498765455679546899598665569954323",
"9654588949893245697654356999898767345678987698645679876767998782129987654343568958912459988798766534",
"7543567998732196899793234789999543236789699798759798765656897643298799973212389979101967999899887646",
"6432457898653989932989345699987684545893568999868979874545989654349698764324567899999899767999998787",
"7421348999769878949878996789999876657932378999979657953435679876598539875634689979876798657789429898",
"3210128799898767956965989899987988867891234989989345942124789998987621986875678967965987545679945929",
"4323235678923456899854567978976799978910349878991249873675678989798710197987989459893296534567896912",
"5454348789636567989765878967965456989321398767890956954578789977679821298998994299794987321457999899",
"7689656896547678979896989549876567895432999656799897967789897855569932459019865987689876432346899768",
"9798798998658999867998996432987678999549899245698689879892996743498643567999989876530998546456796547",
"9899899139769643456999876545698789598998778967789542989954985432129754979789997987421987698578899656",
"3956921019898752147898987676789993497987668989899901299875976593939878998668946799532398799989998997",
"2345892345999864234987698787896432986543445899999892989989987989899999976557899987643469896799997989",
"1016795469899975695995429898999999995432036789987799767898999879789998764345998987654567965678986879",
"2525679579789986989876210989878878986544125679986678956967999765678999855235687899768789654379875668",
"3434567989678999879998329876756569876543234589765459548456898764567899932123456969899997543268994345",
"7566798998989239868965498995435457987764547678955347932345679876689999899015897954966989875346789656",
"9789899867992198957896597954321349999975656889543136793656789997799975768976788963245976996657898769",
"9899997656893987645789986896440497898896787897665945679778997598899854356898899995139895987767899878",
"8989876545679998435699875789559976786797898998779897899899995439998765456999999989298784598998996999",
"7879987934567954324987654668998765345689959689898799910999989323689878767892198778997653239569985321",
"6567899895678965439876523456987643286789244567999667899989878934569989978999987667998732123489876432",
"5434998799789877598965412355698321098992153456796543498868767957878999999398799456789541025678997643",
"3129899678995998997894301234899532136789012568986432987659756899989999893298654345897632125989898856",
"4598797587894359876894213568998754245989193467965421098643237923499989789139885457998784534898759878",
"5999675466789299875689428689549895345678989979876533498754346935999767679099976868959987656789943989",
"9876543245699987654578938795430976467989667899998754579865467899898654568989899979249898767899899993",
"9985432125789998743567899894321987598992556998879867678987568998789843499876788989198779898989798921",
"7898743014569879852456789965939798679321349876765978789998979987679921989795667891098655999876567893",
"6987653123698765920378898979896549789210199765654989899979989875568999876654456789297643498765456989",
"9998754534899994321234567898789329895321987654323499998765698784459679765443234678989931019874359878",
"8979986785678987435345679987679434976433499876212578987644597643274598754320123799767892398765699967",
"7768997896789876587486889898569555986545689974323459954323998932123459866541234598756789469886987856",
"6456798987893987697578998766478976797969789865464567893219876543235579877532346689347898579998986543",
"4347899999932398798678998754367898899898993976789679987623998995468678998546456789456987678979897421",
"5456987891291999899989659765456789989697894987898799876534569989579789979798767897567898989469653210",
"7567896790989899956796539878677899978576989998999893989545698878998996869899878998678999993298964523",
"8879935789876788932986424989789999867485678899987932395987987659497895456989989659799899989987895634",
"9989323498765567891093212399899998754334799789876421034599997545376994345679896543986789876766989745",
"6695214998854458989989923569979876543212345698765432123498898434265679266989689959875698765454878957",
"4594349876543234568979894698667987656101356789876743649987654320124589356789567898764329954343459998",
"2987656987435156679965789987546499797219459899998654997698965434245678967892459929873219543212368999",
"1099878994321067789874689876432345989498968978998789876569876554356789988921378910989398654563567897",
"2178989965442128999943599984321259878987899567889898765459989866457891299543467899898989765687679956",
"4569399879674236789732398743210198767466789335678999654378999878968954397664578998787779876998789632",
"6891239998787645897653987654323987654345679126799198796459998989879765989876789999676567987899996543",
"7920198769898657998764598765459876543234678938894349986567897692999979975987998987543456798998987655",
"8941987654998789729978689876599987532145678956976499987778976543978898943299987976532102679987698786",
"9659998543239897539989798987989976541013799767898989898989987999865767892109876598799993568976539987",
"9998987654357999998599897899879997663123478988999875679297599789754456793298997329987889979765423498",
"7767899765468998897432986798768989893234567899698764799198988678963345989987789419876776898976434579",
"6756789976979767796521095679946679964545678924569953898999876567892259869876678923995665987897545678",
"5345999898989745689432194599834569875657899535679831987894324456891098754324567899874354556789696989",
"3234998789497659996543986987612346989798999947799762986543212367952169765913478998765212345678987891",
"0199879695398798789674987965401656999899587899987653987655423478943459899894589998754303456789698910",
"1987654569219899678995699876213457899945456989999768998766545678986567998789678999865412567896599932",
"2398543458901987567989789984345569989631345678999899469898758789997679989698999989986543456789387893",
"3987654567899895456778999995668979876520234567896952399969969898898798778456789976597654568895456794",
"4598897678998754234567899876779989987431345778995431989459878976789989656345467894398767678998768989",
"7679998789329895345978953987889296796532459889889549879321989345899876543234349943209879789899979978",
"9796999899902976567889992198999345986545669994679698767990993276799989854101247895499989896789898765",
"9895789999893597678999989239998456797676778933468987657789894387989998768212356976989998965899765754",
"3934598998789698789999878956987568998987889012457896545698765498978999978326979899678987654987654323",
"2123567997688999899898767999998678979998993233468993234569976999869899989545998787567899543499843212",
"3234979783467899998789956678999989568989654354569689156789989897456789987659898645456789532398765301",
"4569898672456789987695434599789995479679765457689589235679998756345679998798786534345789643999876412",
"5698765421345698768459996789589954234569879878797678946899987643234568979897654323245689659876986433",
"8789876510124569654347789993467893199979989989998789757998998743123458954999843210156799998765498764",
"9998765421267898542125678975678999987898793296789899867987689854234567893598764321277899899654359875",
"9329878632358987651014567896989998976799532135678999978976534965446789932349875432348998798765667986",
"8912998793479199432123678998999876565987673234567998989986549876767899953456986546556795659976889997",
"7894989895589298753234899769235965434598765345688997899987656998898998764567898657867954345989998998",
"6789976986678999954745678952139876512349998656899876569898967989989689877698949768978985466996567899",
"5689895499899888895677789543025987829467899767998775466789989879976578999789429899989876877895456789",
"4578789357998767797799998765434598998998999878989654345678999967896469989993210967999987998954345678",
"3435689467997655689899899879545679997889997999678921234589997656789359879879921256789798999543257789",
"2324579569889834578965789998976899876679876544567892346899986545992198765767893345997569987654568999",
"1012459698779323569954678967997987764589997432378965467999987956893987654556789457896456999765678967",
"2123468987656313467893212356789996543678986543567899578998898768954998643544579968998345899976899456",
"3654567896543202348932104567899987654569999864568998679997649879869876542123567899765456789987893237",
        };

        private int[,] localMins = new[,]
        {
            {0, 18},
            {0, 38},
            {0, 61},
            {1, 47},
            {1, 72},
            {1, 78},
            {1, 90},
            {2, 0},
            {2, 6},
            {3, 26},
            {3, 55},
            {4, 13},
            {5, 67},
            {5, 91},
            {5, 96},
            {6, 44},
            {6, 85},
            {7, 5},
            {7, 34},
            {8, 50},
            {8, 73},
            {9, 19},
            {9, 25},
            {10, 59},
            {10, 78},
            {11, 44},
            {11, 64},
            {12, 30},
            {13, 88},
            {14, 5},
            {14, 37},
            {14, 69},
            {14, 94},
            {16, 12},
            {16, 55},
            {17, 20},
            {17, 31},
            {17, 80},
            {18, 90},
            {19, 47},
            {19, 98},
            {20, 59},
            {20, 64},
            {21, 8},
            {22, 13},
            {22, 22},
            {22, 34},
            {22, 74},
            {22, 83},
            {23, 18},
            {24, 95},
            {25, 3},
            {25, 55},
            {26, 11},
            {26, 21},
            {26, 39},
            {26, 69},
            {26, 85},
            {26, 98},
            {27, 31},
            {27, 48},
            {27, 79},
            {27, 90},
            {28, 73},
            {29, 27},
            {29, 43},
            {29, 57},
            {29, 84},
            {29, 98},
            {30, 64},
            {31, 7},
            {31, 16},
            {31, 50},
            {31, 77},
            {32, 33},
            {33, 1},
            {33, 40},
            {34, 24},
            {35, 10},
            {35, 63},
            {35, 91},
            {35, 97},
            {36, 54},
            {36, 73},
            {37, 13},
            {37, 49},
            {38, 30},
            {38, 70},
            {38, 82},
            {40, 8},
            {40, 17},
            {40, 54},
            {40, 62},
            {40, 76},
            {40, 99},
            {42, 34},
            {42, 88},
            {43, 1},
            {43, 23},
            {43, 40},
            {43, 79},
            {44, 52},
            {44, 58},
            {44, 62},
            {45, 13},
            {45, 73},
            {45, 96},
            {46, 30},
            {47, 99},
            {48, 7},
            {48, 69},
            {48, 82},
            {49, 0},
            {49, 18},
            {49, 39},
            {50, 32},
            {50, 88},
            {50, 94},
            {51, 47},
            {51, 75},
            {52, 64},
            {53, 56},
            {53, 82},
            {54, 1},
            {54, 28},
            {54, 42},
            {55, 12},
            {55, 99},
            {56, 9},
            {56, 91},
            {58, 19},
            {58, 23},
            {58, 52},
            {58, 81},
            {59, 5},
            {59, 70},
            {60, 38},
            {60, 63},
            {61, 86},
            {61, 92},
            {62, 1},
            {62, 13},
            {62, 75},
            {62, 81},
            {63, 69},
            {64, 21},
            {64, 30},
            {64, 55},
            {64, 99},
            {65, 43},
            {65, 49},
            {66, 3},
            {66, 63},
            {67, 17},
            {67, 86},
            {68, 10},
            {68, 37},
            {68, 74},
            {69, 58},
            {69, 95},
            {70, 55},
            {70, 80},
            {71, 22},
            {71, 44},
            {72, 14},
            {72, 24},
            {72, 51},
            {72, 67},
            {73, 59},
            {73, 74},
            {74, 0},
            {74, 29},
            {74, 86},
            {74, 99},
            {76, 6},
            {76, 11},
            {76, 94},
            {77, 39},
            {78, 16},
            {78, 51},
            {79, 31},
            {79, 83},
            {80, 11},
            {80, 25},
            {80, 57},
            {80, 61},
            {80, 74},
            {82, 43},
            {83, 1},
            {84, 52},
            {84, 90},
            {84, 98},
            {85, 23},
            {85, 49},
            {87, 9},
            {87, 27},
            {87, 34},
            {87, 64},
            {87, 81},
            {88, 94},
            {89, 19},
            {89, 43},
            {89, 59},
            {89, 72},
            {90, 2},
            {90, 13},
            {91, 88},
            {92, 35},
            {93, 28},
            {94, 7},
            {94, 78},
            {95, 51},
            {95, 94},
            {96, 62},
            {96, 67},
            {97, 1},
            {97, 45},
            {98, 36},
            {98, 85},
            {99, 14},
            {99, 23},
            {99, 59},
            {99, 73},
            {99, 97},
        };
    }


}