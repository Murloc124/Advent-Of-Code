using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2___Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string>
            {
                "kbqwtcvzgumhpwelrnaxydpfuj",
                "kbqwtcvzgsmhpoelryaxydiqij",
                "kbqwpcvzssmhpoelgnaxydifuj",
                "kbqgtcvxgsmhpoalrnaxydifuj",
                "kbqwtcvygsmhpoelrnaxydiaut",
                "kbqwtcvjgsmhpoelrnawydzfuj",
                "kbqftcvzgsmhpoeprnaxydifus",
                "rbqwtcgzgsxhpoelrnaxydifuj",
                "kbqwtlvzgvmhpoelrnaxkdifuj",
                "kbqwtcvzgsmhpolqrnaxydifub",
                "kbqbtcqzgsmhposlrnaxydifuj",
                "kbqwmcvzgswhpoelxnaxydifuj",
                "kbqwtyvzgsmhkoelrnsxydifuj",
                "khqwtcvzgsmhqoelinaxydifuj",
                "koqwtcvzcsmhpoelrnaxydizuj",
                "kbqwtcvzlsmhpoezrnaxydmfuj",
                "kbqwtcvzdsmhpoelrjaxydifij",
                "kbqwtcvzgsmhpoelrncxyjifuk",
                "kbtwtcvzgsmhpoelonaxydiwuj",
                "kbqwfcrzgsmhpoelrnaeydifuj",
                "kbqutcvkgsmhpoelrnfxydifuj",
                "kbqwtcvzgsmvvoelrnaxydihuj",
                "kbqwtcvzhymhpoelrnaxydifyb",
                "kbqctcvzgumhpoalrnaxydifuj",
                "kuqktcvzgsmhpoelrnaxydieuj",
                "kbqwtcvzgsmvpozlrnaxydifmj",
                "kbqwtcvzgsmhpojlraaxydiouj",
                "kbqwtcvzgmmhpoelknaxydizuj",
                "kbwwtcvzgsmhpoefrnaxydifij",
                "kbqwucvzgsmhpoelvnahydifuj",
                "kbqwtcvzpsmhpgelrqaxydifuj",
                "kblqtcvzgsmhpoeirnaxydifuj",
                "kbqwtcvzgsmhpovlrnabydifum",
                "kbqwwcvzgsmhpoelrnaoydnfuj",
                "kyqwdcvzgsmhpoelrnaxfdifuj",
                "kbqftcvzgsmxpoelknaxydifuj",
                "kbqwtsvzksmhpoelqnaxydifuj",
                "kbqwtcvzgsmhplelrnauydifux",
                "kbqytcvzgsmhpkelrnaxydefuj",
                "kbqwtcvzgsmjjoelrlaxydifuj",
                "kbqvtcvzgsmhpoelnnaxydafuj",
                "kbqwtcvzgsjhioelrnaxpdifuj",
                "kbqptcvpgsmhpoelrnaxydiful",
                "kbqwjcazgimhpoelrnaxydifuj",
                "kbqxtcvzgwmhpaelrnaxydifuj",
                "kbqwtcezgsmhqoelrnaxydifub",
                "kbqwtcvzgsmhooelynaxydifuf",
                "kbqwtwvzgsmkpoelrnaxrdifuj",
                "nbqwtcvugsmhpoelrnzxydifuj",
                "kbvwqcvzgsmhpoelsnaxydifuj",
                "kbqwtcyzjsmhpoelrnaxymifuj",
                "kbqwtcvzgsmhpoclrnaxykzfuj",
                "kbbwtcvzgsmhyodlrnaxydifuj",
                "kbwwtcvzgsmytoelrnaxydifuj",
                "kbmwtcczgpmhpoelrnaxydifuj",
                "ubqwtcvzgsmmpoblrnaxydifuj",
                "kbqwtcvzgrmhpoelrnaxnrifuj",
                "kbqwhcvzgsmhpoelynaaydifuj",
                "kbqwtcvzgsmtpoelrcpxydifuj",
                "kdqwtchzgsmhpoelrmaxydifuj",
                "qbqrncvzgsmhpoelrnaxydifuj",
                "kbqwtcvzghshpoelrnaxodifuj",
                "kbqwhcvzgsmhpoelknaxydiwuj",
                "ebqwtcvzgsmhpoelrotxydifuj",
                "kbqwacvzusmhpoelryaxydifuj",
                "kbqwtcvggsmhpoelrnaxygifyj",
                "kbqwtcvzgsmhpoelrnaxycwfuo",
                "kzqwzcvzgsmhpoelrxaxydifuj",
                "khqwtcvzgsmhpoelrnaxldifyj",
                "kbqwtbtzgsmhpoelrnaxydifud",
                "gbqwtcvzgqmhpoelrnaxydifrj",
                "kbqdtqvzgwmhpoelrnaxydifuj",
                "kbqwscvzgsmhpoelrpaxypifuj",
                "kmqwtcdzgsmhpoelenaxydifuj",
                "klqwtcvvgsmhpoelrfaxydifuj",
                "kbuwtcvzgsmhpoelrtaxyuifuj",
                "kbqwtcvrgomhpoelrnaxydijuj",
                "kbqwtgvzgsmhzoelrnpxydifuj",
                "kbqltcvzgsmhooeljnaxydifuj",
                "kbqwtcvzgbmxpoelrnaxydivuj",
                "kbqdtcmzgsmhpoelrnaxydmfuj",
                "kbqwtcazgsmhpoplrnacydifuj",
                "kbqztcvegsmhpoelrnvxydifuj",
                "kbqwtcvzgsmhpoecrnaxydzfsj",
                "kbqwtcvzgsmepoelrnaqydifuf",
                "kbqwtcqzgsmhpoelrnoxydivuj",
                "kbqwtcvzgsmhpoeylnaxydhfuj",
                "kbqwtcvfgsmhpoelrnaxgdifyj",
                "kbqwtcvzgsmhnbelrnaxyfifuj",
                "kbqwtcvzgsmhpoelrnaxbdffmj",
                "kwqwtcvogtmhpoelrnaxydifuj",
                "kdqwtcvzggyhpoelrnaxydifuj",
                "kbqwtuvzgtmhpoelrnaxydifxj",
                "kbqctdvzcsmhpoelrnaxydifuj",
                "kbqwtcvzgsmhpoblrniyydifuj",
                "kbqwucvzzsmhpoelrnvxydifuj",
                "kbqwtcvzgslzpoelrnaxydiruj",
                "kbqwtdmzgsmhpwelrnaxydifuj",
                "kbqwtcvzgsmhpoilrnaxqiifuj",
                "kbqwtcvzgsmhpgelrnaxydisnj",
                "kbdwtqvzgsmhpoelrnaxydivuj",
                "kbqvtdvzgsmhpoelrjaxydifuj",
                "kfqwtcvzgsmhpoeurnyxydifuj",
                "kbqwtcvzgsmhpoglrnaxqkifuj",
                "kbqwtcvrgsmhpoelrnajydifnj",
                "xbqwpcvzgjmhpoelrnaxydifuj",
                "kbqwtcvzgsmhpoelrdaxvdihuj",
                "kbuwtcvzssmhpoklrnaxydifuj",
                "kbqwtcvzgqmhpoelrnzxydifbj",
                "kbqwtcvzgsmhsoeoknaxydifuj",
                "kfqltcvzgsmhpoelrnaxydifnj",
                "qbqwtsvzgsmhpoelrnaxodifuj",
                "kbqwwevzgsmypoelrnaxydifuj",
                "kbqwtcuzgimhpoelrnaxydffuj",
                "kxqwlcvzgsmhpoelrnaxyrifuj",
                "nbqwtcvzgsmhpoelryaxyiifuj",
                "kbqwtcvzgsmhhoxlreaxydifuj",
                "mbqwtcvzfsmxpoelrnaxydifuj",
                "kbqwttvzgsmhpoeqrnaxidifuj",
                "kbqwtcvzgamhpielrnaxyiifuj",
                "rfqwtcvzgsmhpoelrnaxydifun",
                "kbpwtqvzgsmbpoelrnaxydifuj",
                "kbqwtcvzgsmhpoqlroaxydifua",
                "hbqwtcvzksmhpoelrnaxydbfuj",
                "kaqutcvzgsmhpoelrnaxydiiuj",
                "kbqctcvzgsnhpoelrcaxydifuj",
                "kbqwtnvzgsmhpoelrnaxydqfoj",
                "kbqwtcvzhsmhpoelrnaxydifyb",
                "ubqwtcvcgsmhooelrnaxydifuj",
                "kbqwtcvrgsmhpoelrnaxtdivuj",
                "kbqwtcvzgsmhplelrnmxydifaj",
                "ebqwlcvzghmhpoelrnaxydifuj",
                "hbqwtcvzgsmhpoelrnaqyeifuj",
                "kbqstcvzgsmeprelrnaxydifuj",
                "kbqwtcvogsthpoelrnnxydifuj",
                "ybqwtcvzgdmhpoelrnaxydufuj",
                "kbqutcvzgsmhpoelrnaxydifgx",
                "kbqwtcvzgsmhpozlunadydifuj",
                "kkqwtcvzgsmhpuefrnaxydifuj",
                "kbqrtcvzgsmhpoelrnaxcdifuq",
                "kbqwtcvzjsmupoelrnaxydiluj",
                "kbqwmcvzgsuhpoelrnaxydifhj",
                "kbqwfcvzgsmhpoelrnaxydkzuj",
                "kbqatcvzgsdhpoeyrnaxydifuj",
                "kbtwtcvzusmhpoelrxaxydifuj",
                "kbqwtcwzgsmhpoelrnaxysofuj",
                "kbqqtcvmgsmhpoevrnaxydifuj",
                "kbqwjcvzgsmhpoelrnaxydhuuj",
                "mbdwtcvzgsmhpoelqnaxydifuj",
                "kbqwtcvlgsmhpoelrdaxydifaj",
                "kbqwtcvzgsmmpoelrlaxydnfuj",
                "kbqwtchfggmhpoelrnaxydifuj",
                "kbqqtcvzgsyhpoelrnaxyoifuj",
                "knqwtcvzqsmupoelrnaxydifuj",
                "kdqdtcvzgsmhpoelrnaxydmfuj",
                "kbqwtcvzgsmhptelrnawyhifuj",
                "kbqwtcvzgrmhpoeqrnaxydifuw",
                "kbnxtcvzgsmhpoelrnauydifuj",
                "kbqwacvsgsmhpoelrnaxydifgj",
                "kbqwtcvzgsmhpperrnaxydifuc",
                "gbqwtcvzgsqhxoelrnaxydifuj",
                "kbqwtcvzgsmhpoeljgaxydifwj",
                "kbqktcvzgsmhpotlrnatydifuj",
                "bbqwtcvzgsmhpoilrnaxydjfuj",
                "kbqwecvdgsmhpoelrnaxypifuj",
                "keqwtcvzgemhpotlrnaxydifuj",
                "kbqptcvzgsmvpoelrnaxydixuj",
                "kbqwbctzgsmhpoelrnaxydifup",
                "kbqwtcvzgszhpbelrnzxydifuj",
                "mbqwtcvtgsmhpoeyrnaxydifuj",
                "kbqwtcvzgsmhqcelrhaxydifuj",
                "kbqotcvzgsmhooelrnazydifuj",
                "kbqwtcvzgsmhpoelmpaxyiifuj",
                "kbqwtcvwgsmypoclrnaxydifuj",
                "kbqwtcvsgskhpoelrnaxykifuj",
                "kbqwtcvzgszvpoelrnwxydifuj",
                "kbqwtcvzgsmhpoejonaxydrfuj",
                "kbqwtcvzgsmhkoelrnazyqifuj",
                "kbzwtzvzgsmhptelrnaxydifuj",
                "kbqwtcdzgsmhptelrnaxydiduj",
                "kbqwtcvzgamhpoelrnakyzifuj",
                "kbqwtcvzgsmhpoeonnaxydifxj",
                "kbqwtcvzgsmhpoeranaxydifej",
                "kbqwscvzgsmhpoelunaxydimuj",
                "cbqwtcvzgsmhpoelrdaxydefuj",
                "vbqwtcjzgsmhpoelrnaxydifua",
                "kmqwtcvzksmhpoeljnaxydifuj",
                "kbqwtcvzgsmppojlrnasydifuj",
                "kaqwtcvfgsmhpoelrnaxydiauj",
                "khqwccvzgsmhpoelrnaxydifud",
                "vbqwtcvzrsmhpoelrhaxydifuj",
                "kuqwtcvzgsmhpoelgnaiydifuj",
                "kbqwtcvzdsmhpbelvnaxydifuj",
                "kbowtcvzgnmhpoelrfaxydifuj",
                "kbqwtcvsgsmhfoejrnaxydifuj",
                "kbqwtcvzgskhtoelrnxxydifuj",
                "kbqwtcvzgtmhpoevrnaxydivuj",
                "bbqptcgzgsmhpoelrnaxydifuj",
                "kbqwtpvzgsmnpoelhnaxydifuj",
                "kbqwtovzgsmmpoelrnaxydifuw",
                "kbqwtcvzgsihpwelrnaxydsfuj",
                "kbqwtcvzggmhpollrnaxydifsj",
                "kbqwtcjzgsmhpoelrnaxyxifub",
                "ebqwtcvzgsmzpoelrnaaydifuj",
                "kbqwtcvzusmhpoelrnqxydijuj",
                "obqwtcvzgsghpoelrnaxydifkj",
                "kbrwtcvzmdmhpoelrnaxydifuj",
                "kbqwtcvzxsmhpoblrnhxydifuj",
                "kbqwacvzgsahpoelrnaxydiguj",
                "kyqwtcvzgsmipoelrnlxydifuj",
                "kbbwtcvzgsmhboelpnaxydifuj",
                "kbqwtcvzgsmhpoelrnaxhdosuj",
                "kbqwtgvzgxmhpoelrnaxyrifuj",
                "pbqwtsvzgsmhpoelrnabydifuj",
                "kbqrtcvzgsmhpsblrnaxydifuj",
                "kbqwtcvzgsmhpoexrnaaycifuj",
                "kbqxtcvzgsjhkoelrnaxydifuj",
                "kbqwtcvzgsmhpxelrnaxydifby",
                "lbxwtcvzgsmdpoelrnaxydifuj",
                "kbqwtcczgsmhpoklrnzxydifuj",
                "zbqwtcvzgsmhpoelrbaxydifui",
                "krqwtcvzbsmhpoelrjaxydifuj",
                "kbkwtcvzgsmhpoelrnaxydiacj",
                "kbqwtcvzgszhpseprnaxydifuj",
                "kbxwtcvzxsmhpoesrnaxydifuj",
                "kbqwdcvzgsmhpoelrbaxygifuj",
                "kbqwthkzgsmhhoelrnaxydifuj",
                "klqwtchzgamhpoelrnaxydifuj",
                "obqwtcvzgsvcpoelrnaxydifuj",
                "kblwtcvzgsmhpoelrnanydifuw",
                "kbqwtrvzgsmhpoelynaxydifug",
                "kbqwtcvzgsmhcoelmnaxydkfuj",
                "kbqwtcvzgsmhpotlqoaxydifuj",
                "kaqatcvzgsmhpoelrnaxyiifuj",
                "kbqttcvwgsmhpoelrnaxydifgj",
                "kpqwtcvzgsmhpwelynaxydifuj",
                "kbqwucvzgsmhpyelrnaxyxifuj",
                "kbqwucvzgsmhprelrnaxyfifuj",
                "kbqwthvzgsmhphelrnaxylifuj",
                "kbqwtcvzosmhdoelrnaxwdifuj",
                "kbqwtxvsgsphpoelrnaxydifuj",
                "koqwtcvfghmhpoelrnaxydifuj",
                "kbtwicvzpsmhpoelrnaxydifuj",
                "kbawtcvzgsmhmoelrnaxyiifuj",
                "kbqwtcvzgslhpbelrnaxydifuk",
                "kbqttcvzgsmypoelrnaxydifua",
                "kbqwtcvrgqmhpnelrnaxydifuj",
                "kbqwtcvzghmhpoekpnaxydifuj",
                "kbqwtcvzgsmupoelrnaxidifui",
                "kbqwtcvzgsmhpbelrnaxrdifux",
            };

            var amountOfTwoTheSame = 0;
            var amountOfThreeTheSame = 0;

            foreach (var entry in data)
            {
                string newString = string.Concat(entry.OrderBy(x => x));
                var canAddTwo = true;
                var canAddThree = true;
                for (int i = 0 ; i < newString.Length; i++)
                {
                    var count = 1;
                    for (int j = i + 1; j < newString.Length; j++)
                    {
                        if (newString[i].Equals(newString[j]))
                        {
                            count++;
                            i = j - 1;
                        }
                    }
                    if (count == 2 && canAddTwo)
                    {
                        amountOfTwoTheSame++;
                        canAddTwo = false;
                    }
                    if (count == 3 && canAddThree)
                    {
                        amountOfThreeTheSame++;
                        canAddThree = false;
                    }
                    if (!canAddThree && !canAddTwo)
                        break;
                }
            }

            Console.WriteLine("Day 2 - Part 1: " + (amountOfTwoTheSame * amountOfThreeTheSame));

            var resultList = new List<char>();

            for (int i = 0; i < data.Count; i++)
            {
                var firstCharList = data[i].ToList();
                for (int j = i + 1; j < data.Count; j++)
                {
                    var secondCharList = data[j].ToList();
                    resultList = new List<char>();
                    for (int pos = 0; pos < data[i].Length; pos++)
                    {
                        var differ = 0;
                        if (!firstCharList[pos].Equals(secondCharList[pos]))
                        {
                            differ++;
                        } else
                        {
                            resultList.Add(firstCharList[pos]);
                        }
                        if (differ > 1)
                            break;
                    }
                    if (resultList.Count == firstCharList.Count - 1)
                        break;
                }
                if (resultList.Count == firstCharList.Count - 1)
                    break;
            }

            string result = "";
            resultList.ForEach(x => result += x);

            Console.WriteLine("Day 2 - Part 2 : " + result);
            Console.ReadLine();
        }
    }
}
