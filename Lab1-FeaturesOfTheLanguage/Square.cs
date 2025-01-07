namespace Lab1_FeaturesOfTheLanguage
{
    public class Square : Rectangle
    {
        public Square(float side) : base(side, side) { }

        public static double CalculateArea(float side)
        {
            return side * side;
        }
    }
}
