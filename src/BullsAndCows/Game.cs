using System.IO;
using System.Threading;

namespace BullsAndCows
{
    public class Game
    {
        private readonly TextWriter _textWriter;
        private readonly TextReader _textReader;
        
        public Game(TextWriter textWriter, TextReader textReader)
        {
            _textReader = textReader;
            _textWriter = textWriter;
        }

        public void StartGuessNumber()
        {
            var mainRow = Row.GetRandomRow();
            while (true)
            {
                _textWriter.WriteLine("Your turn");
                var currentRow = new Row(_textReader.ReadLine());
                var result = Row.Check(currentRow, mainRow);
                _textWriter.WriteLine(result.ToString());

                if (result.IsWin)
                {
                    break;
                }

                Thread.Sleep(3000);
            }
        }
    }
}