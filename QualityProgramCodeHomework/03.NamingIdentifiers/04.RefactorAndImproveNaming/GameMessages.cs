using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    static class GameMessages
    {
        public const string INITIAL_MESSAGE = "Lets play Minesweeper! Command 'top' shows highscores, 'restart' generates new game and 'exit' quits the game";
        public const string ENTER_ROW_COLUMN = "Please enter row and column: ";
        public const string BYE_MESSAGE = "Bye bye!";
        public const string INVALID_COMMAND = "\nError! Wrong command.\n";
        public const string ON_DEATH = "Ka-Booom! You lost with {0} score.\nEnter your nickname: ";
        public const string ON_WIN_CONGRATULATIONS = "Yay! You opened {0} squares and all your limbs are intact";
        public const string ON_WIN_ENTERNAME = "Write your name, hero: ";
        public const string EXIT_MESSAGE = "Made in gentleman Bulgaria. Ho-ho-ho - Pardon me for my laugh.\nLike a sir.";
        public const string SCORE_OPEN = "\nScoreboard: ";
        public const string SCORE_ENTRY = "{0}. {1} --> {2} squares";
        public const string SCORE_EMPTY = "Empty scoreboard";
    }
}
