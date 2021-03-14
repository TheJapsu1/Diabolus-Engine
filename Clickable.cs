using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine
{
    class Clickable : DrawableGameComponent
    {
        public event EventHandler AddOnClickListener;
        readonly Rectangle rectangle;
        bool wasClicked;
        bool isClicked;

        public bool IsTouching { get { return isClicked; } }
        public bool IsClicked { get { return (wasClicked == true) && (isClicked == false); } }

        protected Rectangle Rectangle { get { return rectangle; } }
        protected new Editor Game { get { return (Editor)base.Game; } }

        
        public Clickable(Editor game, Rectangle targetRectangle) : base(game)
        {
            rectangle = targetRectangle;
        }

        
        protected void HandleInput()
        {
            wasClicked = isClicked;
            isClicked = false;

            MouseState mouse = Mouse.GetState();

            Rectangle mouseRect = new Rectangle((int)mouse.Position.X - 5, (int)mouse.Position.Y - 5, 10, 10);

            if (rectangle.Intersects(mouseRect) && (mouse.LeftButton == ButtonState.Pressed))
                isClicked = true;

            if ((wasClicked == true) && (isClicked == false))
            {
                OnClick();
            }
        }

        public void OnClick()
        {
            if (AddOnClickListener != null)
            {
                AddOnClickListener(this, EventArgs.Empty);
            }
        }

    }
}
