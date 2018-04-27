namespace code.map
{
    public class Position2D
    {
        public Position2D() : this(0, 0)
        {
        }

        public Position2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position2D;

            if (position == null)
                return false;

            return x == position.x && y == position.y;
        }

        public override int GetHashCode()
        {
            return 137 * x + 149 * y;
        }

        public override string ToString()
        {
            return "{x: " + x + ", y: " + y + "}";
        }

        public int x { get; set; }

        public int y { get; set; }
    }
}