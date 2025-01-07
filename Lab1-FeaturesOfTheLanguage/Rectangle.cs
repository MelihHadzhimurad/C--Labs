namespace Lab1_FeaturesOfTheLanguage
{
    public class Rectangle : Shape, ICheckForElipse
    {
        private float _longSide;
        private float _shortSide;

        public Rectangle(float shortSide, float longSide)
        {
            _longSide = longSide;
            _shortSide = shortSide;
        }

        public override double GetArea()
        {
            return (_longSide * _shortSide);
        }

        public override double GetPerimeter()
        {
            return ((_longSide * 2) + (_shortSide * 2));
        }

        public bool IsElipse()
        {
            return false;
        }
    }
}
