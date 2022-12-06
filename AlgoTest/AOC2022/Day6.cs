using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{
    [TestClass]
    public class Day6
    {
        [TestMethod]
        public void Test1()
        {
            var queue = new Queue<char>();
            var data = realData;
            int i = 0;
            for (; i < data.Length; i++)
            {
                var element = data[i];
                if (queue.Count < 3) queue.Enqueue(element);
                else
                {
                    if (!Contains(queue, element)) break;
                    queue.Dequeue();
                    queue.Enqueue(element);
                }
            }

            Assert.AreEqual(7, i + 1);
        }

        private bool Contains(Queue<char> queue, char element)
        {
            var dic = new Dictionary<char, int> { { element, 1 } };
            foreach (var c in queue)
                if (!dic.TryAdd(c, 1)) return true;

            return false;
        }

        [TestMethod]
        public void Test2()
        {
            var queue = new Queue<char>();
            var data = realData;
            int i = 0;
            for (; i < data.Length; i++)
            {
                var element = data[i];
                if (queue.Count < 13) queue.Enqueue(element);
                else
                {
                    if (!Contains(queue, element)) break;
                    queue.Dequeue();
                    queue.Enqueue(element);
                }
            }


            Assert.AreEqual(19, i + 1);
        }

        private string testData = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
        private string realData = "zcncrcnrrlccmhchssgqsqrsstfffnqfnfsswgwjjcmcnnvjvwjvwvfvnvwwhvvwmwhmwwwhbhhldhdmhhdfdbdfbdblllnfllgslllqhlhfhlhqllncnfnsffwmwzzlglzlwlhwwmvmddpvvbrvrdvrdvdhhzdhdpdzzbgbsssrpsrshrshhbqbgbmmtwwcbcrbbvnvhnncscwcwlcwlwnwswbbnwntthzzdlzdzffvqvdqvvtptdptphpddzzvhzvzwwqgqjjjvsspvspsbsffvpvcvjcvjvrvjjgmjjhrrdhhdvhvttjttzptpssnlnjjlnnhmnndjnjwwtjjtbbfflwfwgwvvpjpwpcwcgglmgmdmnmbbqtqctcwcmwwvmvlmvmdvdvhvlhlzhzttghttnvnjntnqqtmtwwhvhrhfhchqchhdrdllnwnfwfjjmsmmnhhshnhpptstjjpnpzzhmmpssgrsrzsrrffzjjhvjhjcjcpcvpccfnfjnfjfllssrdsdnnmffldldppcctcmtctffprpsrrrfhfmflldccnpppvsswppdgpgjpgpqgpqpjppclcjczcnzzzqvzzwlzzqfzffsqqphqhvqqbcccstsdttwcwcvvmjjhqqmllpglgtgwgnnbnrbnnjdndhhbrbvrvwwwblwwwppmdmttztqzqrqjjpggpmgpmpqqmssvnsvnndnvddtztddrrsnsbbshhqmhqmmdnnrsrllqvvfjfpfqpqfqflqlmqmrrqgrqrrhvvfddfhhfnhnlncnzzwwjwswpsscpchcssrzssjqsqrsswbbzggnqnwqqsrqqzbqbddtffcjjdggwlwnwtnnpddcqddsppcwpcwpphvphhhrprqrqttwgwqwppvdpvvrgggmpmddzvvwwthwtttbqtbbftfrffbdfbbspshphpwhppnhnmhhbbshbsbmbdmmtrmrbrprbprphhnmhmvhmhhqqbvqvqcvcwcbwcchbbgwwqffrcffsvvcczrztrzzdhdmhdmmzbbvlvqqtptpvvfsfppdzppmddfvdfdwdfdmdwwlvvqdvqdqmdqqmnmdndsswsfwfvwfwzzhrzhhwfhhpvhppmssnhsnsnwswvwlwdwzwnwswwmqmjmbbdjdbbtllcpllltqlttnvvppznpnttlrrwlwvllphpbblccgjcggbtbwtwdwrrbnndpddbqqnpnrnnqqshspsggtptztpzzclcggtqtgqttcmmbgbfbdfdfsddlrlvrlvvmqqgbqgbqbcbbnpplqqblqbqmbbbdqbbhjjcgcdgdwdjwjqqlsqqnnwffglfglgnlggjgjtgjtgjtgjjclcwcqqvpvwwvgvhgvhvjjzpzbznnvrrrpbpdbdhhmshsnnnwppcbcvvlldccdggqnqgnqqzbzzcfflnnmppcgcmgmrgmrgmgngwwptpzzpfzpfzpzdppgcgtcgtgccvtctzzdmzmlmzlzwllbplblltgtctrrghgvhgvvfvssngsschshrhvrvddghgwwwwzgwgvgccjdjzjwwvdvvqsqshsvvddmddbllvppmlpmlmwlwppjmppwrrdzrrpmrmrdmrmbmzzwttvwwsfswwlflnlrlvvdllzbztbtpbtppnjpnpdnnjrjsshtssvvsjvjfjwffsszvsvjssqzsslpslppjpspqptbncvzrlwtjvsrwtnzzhwdfsmlthvgqgjrpshpbsrrvnsdbqslbcplnpcjqwmwqsnwdcjsdmccbdglwbrcdcqsfhjqhstvhqqdwltqwhhqcrnpvnzjhhbjvqbqhclwggjqfvnfsvcnjjhbmrvbpjqrbljbtltvnsgdfhddlmsdhcrfwvlvbsdrjwjvtnqzhrlqgjmzsmjlpdjsrjmdhmvgwjmfwtqffnzfrtswrlgvvhhqgpzcjwscfqgjmdhtvbgzdlvzfhgqlqbfwsjrmmhrlcwhrcnwwvngcmsrfgczsfqvvmdtmtprfvjrwrwcqwvgmzcjncrzvcswlzsdszvdtwmptnrhgzqwrhjjtbchhpwsdjnqmnsgzwqzvlzlsznpqgvtqnldjqpvndtsjlzhpzsgthbwvwnlbwjlmndqpcdvjdgdzhctpghlfwrtqtvfwdpgrjbmwzqgthjpmlrsqmzsznddhrbjnggqrdntpbngvldnnltfnmdwfhftjvpqbrzqvdzbzzctshzldtcdgfnczglrrjtwswzdvjrfgwztwznbpplmbgwpcmstcsjtqhmzmzsjwsfbjlbnbdtdsmlpdmrrbhdhpzrjdpzhcwsrgfrhmqzqtjfhpvltnthwjrrrpnsbmmwrhsfqbmnvwhpntltsgwgnqhcvlndfrtrfrnlmbhltmtgzhlzqgtsbbnggdjvbslfbczhpghqqcqlrbtpnbqbflfjrmpmwwvjqgvcqtmfggmptqlqstcmdtqlslnnzwbgnstftfsvsjdrmgbzfnzltwbjmqhsvshnmwhftjdndltdpngzwbrjpgpwmqgfsflnhmtzcmdjmzwrsrrrmpvwgggwrhrwtfwdbgbpmwpcdspdtbqvdwwsnwdtrtdtgnfzzsmlbcqdzbsqnrgtvvnlfcdlcgcnfpqbddqcjfqtmpndmnwvfqgjzrltqvlprmbbhmtwbzjjgfhhhfjswpffmjnsdmrcjrwlwpmfrmhljpphlwwwwmgsjcsrcvmfrdjdhshddshpplzsnsphcmdhvllgmdgrvbvjmtpltdthffsvwwhvgqrhmfjfpdswcqldrhpmznffjsntwrnmnpmsshljszbchctptsdlnbcvpfvtlfnzcrljpdwrsjnlpqcpnwvnqhzhqmjbvlbtgslzthlbbjzsgdglbrltzjdshpfbndjtssvsjqlstnrjdzzjvlpqhmwvrsvndcqrqjjcsqvmvrbhngtcfdprlbnqmhqllddgjpdzbjlphntrtgjrdgtbslrtzczbnnlddzzsvqvqvvzjpjqfhztgtsfggdppfdhzsbjzqjmpnmgqzlsdhjjbfpbsbnzpmhwrzjqhczrgcsflfwtrgwbnbrshjpwltntsnsdhmhqlmzdprcrcpcpjnphsmjwhzdqtncdbwgspmnfzsgmpbdhmslqchhhbbwfrghhnfjplsvrtbvplgrwdnbnfsgpwrqczvzlnfsngnsnbwvpmfdcmjztdnrllslnwcfwwnwsvztqmgqtfvmdqrrrmwfmphbcvwwttpmwjjbvqrmlwtwfsjdpcbmdlnlzcqntfzzmslshwprjfhwwpbbdfcdjwllfwcznwpjpwrlsfnnbgzjllrgtzcdcvhdhbtlrcvfdvsdjlzsmwwqvpzfhzjlqpfbqstvfrpcchmtwgbrhqqbglrvzmctdlpnvmglgdtzpbdngtfdnmsmwbgjstzbqwqcdlhfrtqqnhqvpfhdrjqvsvstftdgwwnwpfbfbdcfqnqlwpdnfhhfctwrgdqpbpbmgnfsnbpjfctvdtjnsfqlrtctrnjgltndngcmrdphhsqpjhprbngjzqqhnhhrdwlwwpmhzwshvrtzfgzlrhwghvpvfprbbvflltplpptvrmwcrdqndfqbfqtlqqwvphsmcvnbzghvsptrphhfcgdsslhfbcwhtjcmnpbvqrfgpsjgqpnnwwhjjwqrhhqgznwdzjqbtmmjljjwctqtfgwqbdrjwqwbbcftvjwfdfrgvsrlcrccpvfzdrcjvqfbhddpvrrhjrmhdgchrghbzsqpmgnmslfctblwlvphdfpvtdtwpdfsjwssmgnsvsqpdbqngccsplhmjbwjwtzwsbjhwpwcslqjdchmbvzrbgnwvjrrrdtvhtlzlrbwthzlhhqzzpvpwbzrrbrbtpwnhldhqqltqrqdddfwdmjzgctnlrjrjwvddfmjpnptdmrvnqjvsjfrmlvlqsthhsbvnjlsdzrjngfnqdjfssmvgrchbwmwbbvfqfhvrtwghmrpddnwbrbvbmqvfzbjdsnbzgrtmsfhmsmjtrqsgmpnwwbfwtp";

    }


}
