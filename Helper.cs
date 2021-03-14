using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine
{
    public static class Helper
    {
        public static Vector2 GetScreenPosition(ScreenPosition screenPosition, GraphicsDevice graphicsDevice)
        {
            Vector2 screenSize = graphicsDevice.Viewport.Bounds.Size.ToVector2();
            switch (screenPosition)
            {
                case ScreenPosition.TopLeft:
                    return new Vector2(0, 0);
                case ScreenPosition.TopCenter:
                    return new Vector2(screenSize.X / 2, 0);
                case ScreenPosition.TopRight:
                    return new Vector2(screenSize.X, 0);
                case ScreenPosition.MiddleLeft:
                    return new Vector2(0, screenSize.Y / 2);
                case ScreenPosition.MiddleCenter:
                    return new Vector2(screenSize.X / 2, screenSize.Y / 2);
                case ScreenPosition.MiddleRight:
                    return new Vector2(screenSize.X, screenSize.Y / 2);
                case ScreenPosition.BottomLeft:
                    return new Vector2(0, screenSize.Y);
                case ScreenPosition.BottomCenter:
                    return new Vector2(screenSize.X / 2, screenSize.Y);
                case ScreenPosition.BottomRight:
                    return new Vector2(screenSize.X, screenSize.Y);
                default:
                    return new Vector2(screenSize.X / 2, screenSize.Y / 2);
            }
        }

        public static Vector2 GetViewportSize(GraphicsDevice graphicsDevice)
        {
            return graphicsDevice.Viewport.Bounds.Size.ToVector2();
        }

        public enum ScreenPosition
        {
            TopLeft = 0,
            TopCenter = 1,
            TopRight = 2,
            MiddleLeft = 3,
            MiddleCenter = 4,
            MiddleRight = 5,
            BottomLeft = 6,
            BottomCenter = 7,
            BottomRight = 8,
        }

        public enum TextAlignment
        {
            TopLeft = 1,
            Top = 2,
            TopRight = 3,
            Left = 4,
            Center = 5,
            Right = 6,
            BottomLeft = 7,
            Bottom = 8,
            BottomRight = 9,
        }
    }
}
