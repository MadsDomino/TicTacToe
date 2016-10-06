namespace TicTacToe.UnitTests
{
    public class NextPlayerService
    {
        public int Turnnumber = 1;

        public int Playerturn = 1;

        public NextPlayerService()
        {
        }

        public void NextPlayer()
        {
            if (Playerturn == 2)
                Turnnumber++;

            if (Playerturn == 1)
                Playerturn = 2;
            else
                Playerturn = 1;
        }
    }
}