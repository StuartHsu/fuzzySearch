using System.Text.Json;

namespace Week5.Service
{
    public class FuzzySearchService : IFuzzySearchService
    {
        public FuzzySearchService()
        {

        }

        public List<string> GetWordList()
        {
            var data = new List<string>();
            using (StreamReader r = new StreamReader("dictionary.json"))
            {
                string json = r.ReadToEnd();
                data = JsonSerializer.Deserialize<List<string>>(json);
            }

            return data;
        }

        // private int LevenshteinDistance(string src, string target)
        // {
        //     int[,] d = new int[src.Length + 1, target.Length + 1];
        //     char[] str1 = src.ToCharArray();
        //     char[] str2 = target.ToCharArray();

        //     for (var i = 0; i <= str1.Length; i++)
        //     {
        //         d[i, 0] = i;
        //     }
        //     for (var j = 0; j <= str2.Length; j++)
        //     {
        //         d[0, j] = j;
        //     }
        //     for (var i = 1; i <= str1.Length; i++)
        //     {
        //         for (var j = 1; j <= str2.Length; j++)
        //         {
        //             int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
        //             var deletion = d[i - 1, j];
        //             var insertion = d[i, j - 1];
        //             var substitution = d[i - 1, j - 1];

        //             d[i, j] = Math.Min(deletion + 1, Math.Min(insertion + 1, substitution + cost));
        //         }
        //     }

        //     return d[str1.Length, str2.Length];
        // }

        // public List<string> Search(string src, List<string> wordList, double fuzzyness)
        // {
        //     List<string> foundWords = new List<string>();

        //     foreach (string word in wordList)
        //     {
        //         // 取得 Levenshtein Distance
        //         int levenshteinDistance = LevenshteinDistance(src, word);
        //         Console.WriteLine(levenshteinDistance);

        //         // 取得較長字串的長度
        //         int length = Math.Max(src.Length, word.Length);

        //         // 計算分數
        //         double score = 1.0 - (double)levenshteinDistance / length;

        //         Console.WriteLine("Compared word: {0}, score: {1}", word, score.ToString("F2"));

        //         // Match?
        //         if (score > fuzzyness)
        //             foundWords.Add(word);
        //     }

        //     return foundWords;
        // }
    }
}