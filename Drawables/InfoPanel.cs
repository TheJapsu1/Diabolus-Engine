using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static Diabolus_Engine.Helper;

namespace Diabolus_Engine.Drawables
{
    public class InfoPanel : DrawableGameComponent
    {
        Texture2D dummyTexture;
        SpriteFont font;
        Game game;
        private Vector2 infoPanelPadding = new Vector2(30, 30);
        private Vector2 infoPanelSize;
        private const string infoPanelText =
            "Esc = exit editor\n" +
            "C = open console\n" +
            "Time since editor start:";

        public InfoPanel(Game game) : base(game)
        {
            // Choose a high number, so we will draw on top of other components.
            DrawOrder = 1000;
            this.game = game;
        }

        protected override void LoadContent()
        {
            font = game.Content.Load<SpriteFont>("fonts/title");
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { new Color(1, 1, 1, 100) });

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            infoPanelSize.X = font.MeasureString(infoPanelText).X + infoPanelPadding.X;
            infoPanelSize.Y = font.MeasureString(infoPanelText).Y * 2 + infoPanelPadding.Y;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(dummyTexture, new Rectangle((GetScreenPosition(ScreenPosition.BottomLeft, GetViewportSize(GraphicsDevice)) - new Vector2(0, infoPanelSize.Y)).ToPoint(), infoPanelSize.ToPoint()), Color.White);
            spriteBatch.DrawString(font, gameTime.TotalGameTime.ToString(@"hh\:mm\:ss\:ff"), new Vector2(0, GetViewportSize(GraphicsDevice).Y - font.MeasureString(infoPanelText).Y), Color.White);
            spriteBatch.DrawString(font, infoPanelText, new Vector2(0, GetViewportSize(GraphicsDevice).Y - font.MeasureString(infoPanelText).Y * 2), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
