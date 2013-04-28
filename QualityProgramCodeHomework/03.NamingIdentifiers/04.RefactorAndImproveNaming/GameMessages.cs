using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    static class GameMessages
    {
        public const string InitialMessage = "Lets play Minesweeper! Command 'top' shows highscores, 'restart' generates new game and 'exit' quits the game";
        public const string EnterRowColumn = "Please enter row and column: ";
        public const string ByeMessage = "Bye bye!";
        public const string InvalidCommand = "\nError! Wrong command.\n";
        public const string OnDeath = "Ka-Booom! You lost with {0} score.\nEnter your nickname: ";
        public const string OnWinCongratulations = "Yay! You opened {0} squares and all your limbs are intact";
        public const string OnWinEnterName = "Write your name, hero: ";
        public const string ExitMessage = "Made in gentleman Bulgaria. Ho-ho-ho - Pardon me for my laugh.\nLike a sir.";
        public const string ScoreOpen = "\nScoreboard: ";
        public const string ScoreEntry = "{0}. {1} --> {2} squares";
        public const string ScoreEmpty = "Empty scoreboard";
    }
}
