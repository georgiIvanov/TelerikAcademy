using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class ScoreEntry
    {
        string playerName;
        int scorePoints;

        public string GetName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public int GetScorePoints
        {
            get { return scorePoints; }
            set { scorePoints = value; }
        }

        public ScoreEntry(string playerName, int playerScore)
        {
            this.playerName = playerName;
            this.scorePoints = playerScore;
        }
    }
}
