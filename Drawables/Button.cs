using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine.Drawables
{
    class Button : Clickable
    {
        private SpriteFont _font;
        private Texture2D _dummyTexture;
        private string _text;
        Color _textColor;

        public Button(Editor game, Rectangle targetRectangle) : base(game, targetRectangle) { }
        public Button(Editor game, Rectangle targetRectangle, string text, Color textColor) : base(game, targetRectangle)
        {
            _text = text;
            _textColor = textColor;
        }

        /// <summary>
        /// Load the button's texture
        /// </summary>
        protected override void LoadContent()
        {
            //texture = Game.Content.Load<Texture2D>(asset);
            _dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            _dummyTexture.SetData(new Color[] { Color.White });
            _font = Game.Content.Load<SpriteFont>("fonts/buttonDefault");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            var color = IsTouching ? Color.Gray : Color.White;
            spriteBatch.Begin();
            spriteBatch.Draw(_dummyTexture, Rectangle, color);
            spriteBatch.DrawString(_font, _text, Rectangle.Center.ToVector2() - _font.MeasureString(_text) / 2, _textColor);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void SetFont(SpriteFont font)
        {
            _font = font;
        }
    }
}
