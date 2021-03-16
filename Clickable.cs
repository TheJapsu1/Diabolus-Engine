using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine
{
    public class Clickable : GameObject
    {
        public event EventHandler AddOnClickListener;
        public Rectangle clickDetectionArea;
        bool isClicked;
        bool wasClicked;

        public bool OnMouseDown { get { return (wasClicked == false) && (isClicked == true); } }
        public bool OnMouseHold { get { return isClicked; } }
        public bool OnMouseUp { get { return (wasClicked == true) && (isClicked == false); } }

        protected Rectangle Rectangle { get { return clickDetectionArea; } }
        protected new Editor Game { get { return (Editor)base.Game; } }

        public Clickable(Game game) : base(game, null) { }
        
        public Clickable(Editor game, Rectangle targetRectangle) : base(game, null)
        {
            clickDetectionArea = targetRectangle;
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            base.Update(gameTime);
        }

        bool hold = false;
        private void HandleInput()
        {
            wasClicked = isClicked;
            isClicked = false;
            Rectangle mouseRect = new Rectangle((int)Input.GetMousePos().X - 5, (int)Input.GetMousePos().Y - 5, 10, 10);

            if (clickDetectionArea.Intersects(mouseRect) && Input.GetLMBDown())
                hold = true;
            if(clickDetectionArea.Intersects(mouseRect) && Input.GetLMB() && hold)
                isClicked = true;
            if (Input.GetLMBUp() || !clickDetectionArea.Intersects(mouseRect))
                hold = false;

            if ((wasClicked == true) && (isClicked == false))
                OnClick();
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
