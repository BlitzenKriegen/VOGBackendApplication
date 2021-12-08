using Newtonsoft.Json;
using System;

namespace project
{
    /**
     * The turnInfo object holds the turn number,
     * the character that a player used and board the
     * location of the board the player played on.
     */
    public class turnInfo
    {
        private int turnNum;
        private char playedInfo;
        private int boardloc;

        public turnInfo(int tern,char data,int boardinp)
        {
            turnNum = tern;
            playedInfo = data;
            boardloc = boardinp;
        }

        public int getTermNum()
        {
            return turnNum;
        }
        public void SetTermNum(int newNum)
        {
            this.turnNum = newNum;
        }
        public char getPlayedInfo()
        {
            return playedInfo;
        }
        public void setPlayedInfo(char data)
        {
            this.playedInfo = data;
        }
        public int getBoardInp()
        {
            return boardloc;
        }
        public void setBoardInp(int newNum)
        {
            this.boardloc = newNum;
        }
    }

    internal class Program
    {
        static int offset = 48;         //To get rid of ASCII values
        static void Main(string[] args)
        {
            char[] board = new char[9] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
            turnInfo move = new turnInfo(0,' ',0);
            String input = null;
            initalizeBoard(board);
            for (int turn = 0; turn < 9; turn++)
            {
                input = gameTurn(turn);
                move = (turnInfo)JsonConvert.DeserializeObject(input);
                writeChange(board,move);
            }
        }

        private static void writeChange(char[] board, turnInfo move)
        {
            board[move.getTermNum()] = move.getPlayedInfo();
            for(int i = 0; i < 25; i++)
            {
                System.Console.WriteLine();                     //clear the console
            }
            initalizeBoard(board);
        }

        private static String gameTurn(int turn)
        {
            char userinput = (char)Console.Read();
            int boardloc = Console.Read() - offset;
            turnInfo boardElm = new turnInfo(turn,userinput,boardloc);
            string jsonData = JsonConvert.SerializeObject(boardElm);
            return jsonData;
        }

        private static void initalizeBoard(char[] board) 
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    writeRow(i, j, board);
                }
                System.Console.WriteLine();
                System.Console.WriteLine("---+---+---");
            }
            for(int i = 0; i < 3; i++)
            {
                writeRow(2, i, board);
            }
        }
        private static void writeRow(int i, int j, char[] board)
        {
                int index = i + j * 3;
                System.Console.Write(" " + board[index]);
                if (j != 2)
                {
                    System.Console.Write(" |");
                }
        }
    }
}
