namespace Lab1_FeaturesOfTheLanguage
{
    public abstract class Shape
    {
        private int _color;
        public int Color
        {
            get
            {
                switch (_color)
                {
                    case 0b00000000_11111111_00000000_00000000:
                        return Colors.Red;
                    case 0b00000000_00000000_11111111_00000000:
                        return Colors.Green;
                    case 0b00000000_00000000_00000000_11111111:
                        return Colors.Blue;
                    default: return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 1:
                        _color = 0b00000000_11111111_00000000_00000000;
                        break;
                    case 2:
                        _color = 0b00000000_00000000_11111111_00000000;
                        break;
                    case 3:
                        _color = 0b00000000_00000000_00000000_11111111;
                        break;
                    default:
                        break;
                }
            }
        }

        private static class Colors
        {
            public static int Red { get; } = 1;
            public static int Green { get; } = 2;
            public static int Blue { get; } = 3;
        }
        public abstract double GetPerimeter();
        public abstract double GetArea();
    }
}
