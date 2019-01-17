namespace BrickEngine.Utility
{
    public struct Vector2i
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2i operator +(Vector2i vector)
        {
            var temp = new Vector2i();
            temp.X += vector.X;
            temp.Y += vector.Y;
            return temp;
        }

        public static Vector2i operator -(Vector2i vector)
        {
            var temp = new Vector2i();
            temp.X -= vector.X;
            temp.Y -= vector.Y;
            return temp;
        }

    }
}
