namespace TicTacToe
{
    internal class Program
    {
        static char[] boardPlace = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int flag = 0;
        static int player = 1;
        static int choice;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("  Player1 : X and Player2 : O\n\n");
                PrintBoard();
                //chance of the player
                if (player % 2 == 0)
                {
                    Console.WriteLine("\n  Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("\n  Player 1 Chance");
                }
                Console.WriteLine("\n  Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (boardPlace[choice-1] != 'X' && boardPlace[choice-1] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        boardPlace[choice-1] = 'O';
                        player++;
                    }
                    else
                    {
                        boardPlace[choice-1] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine($"\n\n  {choice}th box is already marked as {boardPlace[choice]}\n" +
                        $"  Enter another choice after the board reloads");
                    Thread.Sleep(2000);
                }
                flag = ConditionsToWin();
            }
            while (flag != 1 && flag != -1);
            Console.Clear();
            PrintBoard();
            if (flag == 1)
                Console.WriteLine($"\n\n  Player {(player % 2) + 1} has won");
            else
                Console.WriteLine("\n\n  Match Draw");
        }
        static void PrintBoard()
        {
            Console.WriteLine($"       |     |     \n" +
                              $"    {boardPlace[0]}  |  {boardPlace[1]}  |  {boardPlace[2]}  \n" +
                              $"  _____|_____|_____\n" +
                              $"       |     |     \n" +
                              $"    {boardPlace[3]}  |  {boardPlace[4]}  |  {boardPlace[5]}  \n" +
                              $"  _____|_____|_____\n" +
                              $"       |     |     \n" +
                              $"    {boardPlace[6]}  |  {boardPlace[7]}  |  {boardPlace[8]}  \n" +
                              $"       |     |     ");
        }

        static int ConditionsToWin()
        {
            //winning conditions
            //first row
            if (boardPlace[0] == boardPlace[1] && boardPlace[1] == boardPlace[2])
                return 1;
            //second row
            else if (boardPlace[3] == boardPlace[4] && boardPlace[4] == boardPlace[5])
                return 1;
            //third row
            else if (boardPlace[6] == boardPlace[7] && boardPlace[7] == boardPlace[8])
                return 1;
            //first column
            else if (boardPlace[0] == boardPlace[3] && boardPlace[3] == boardPlace[6])
                return 1;
            //second column
            else if (boardPlace[1] == boardPlace[4] && boardPlace[4] == boardPlace[7])
                return 1;
            //third column
            else if (boardPlace[2] == boardPlace[5] && boardPlace[5] == boardPlace[8])
                return 1;
            //first diagonal
            else if (boardPlace[0] == boardPlace[4] && boardPlace[4] == boardPlace[8])
                return 1;
            //second diagonal
            else if (boardPlace[2] == boardPlace[4] && boardPlace[4] == boardPlace[6])
                return 1;
            //draw condition
            else if (boardPlace[0] != '1' && boardPlace[1] != '2' && boardPlace[2] != '3' && boardPlace[3] != '4' &&
                boardPlace[4] != '5' && boardPlace[5] != '6' && boardPlace[6] != '7' &&
                boardPlace[7] != '8' && boardPlace[8] != '9')
                return -1;
            //still playing condition
            else
                return 0;
        }
    }
}
