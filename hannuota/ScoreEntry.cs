using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hannuota
{
    public class ScoreEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Moves { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public string TimeTakenFormatted => $"{TimeTaken.Minutes:D2}m:{TimeTaken.Seconds:D2}s"; // 用于显示
        public int DiskCount { get; set; }
        public DateTime DatePlayed { get; set; }

        // 无参数构造函数，用于JSON反序列化
        public ScoreEntry() { }


        public ScoreEntry(string playerName, int score, int moves, TimeSpan timeTaken, int diskCount, DateTime datePlayed)
        {
            PlayerName = playerName;
            Score = score;
            Moves = moves;
            TimeTaken = timeTaken;
            DiskCount = diskCount;
            DatePlayed = datePlayed;
        }
    }
}
