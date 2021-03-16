using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine.Drawables
{
    class Segment : Clickable
    {
        Game _game;
        private Texture2D handle;
        private Vector2 handleSize = new Vector2(50, 50);

        public Segment(Game game) : base(game)
        {
            _game = game;
        }

        public override void Initialize()
        {
            Random random = new Random();
            transform.position = new Vector2(random.Next(50, 400), random.Next(50, 400));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            handle = new Texture2D(GraphicsDevice, 1, 1);
            handle.SetData(new Color[] { new Color(1, 1, 1, 100) });

            base.LoadContent();
        }

        bool grabbing = false;
        public override void Update(GameTime gameTime)
        {
            clickDetectionArea = transform.PosToRect(handleSize);
            if (OnMouseHold)
                grabbing = true;
            if(grabbing)
                transform.position = Input.GetMousePos();
            if (Input.GetLMBUp())
                grabbing = false;
            base.Update(gameTime);
            DebugConsole.Log("MousePos: " + Input.GetMousePos());
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(handle, new Rectangle(transform.position.ToPoint(), new Point(50, 50)), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
