namespace LudoGame
{
    public class Square
    {
        Piece piece { get ; set; }
        int squareNr { get; set; }
        public Square(int Id)
        {
            squareNr = Id;
        }
    }
}
