namespace Lab1_FeaturesOfTheLanguage
{
    public class Circle : Shape, ICheckForElipse
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return 2*(3.14*(_radius * _radius));
        }

        public override double GetPerimeter()
        {
            return 2 * (3.14 * _radius);
        }

        public bool IsElipse()
        {
            return true;
        }
    }
}
