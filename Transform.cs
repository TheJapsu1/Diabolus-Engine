using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine
{
    public class Transform
    {
        public Vector2 position { get; set; }
        public float rotation { get; set; }
        public Vector2 scale { get; set; }

        public Rectangle PosToRect(Vector2 size)
        {
            Rectangle rect = new Rectangle(new Point((int)(position.X - size.X / 2), (int)(position.Y - size.Y / 2)), size.ToPoint());
            return rect;
        }
    }
}
