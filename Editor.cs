using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Diabolus_Engine
{
    public class Editor : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D planetSprite;
        //private Texture2D backgroundSprite;
        private SpriteFont font;

        public Editor()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //initialize stuff here
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        //load textures, models, fonts, music, etc here
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            planetSprite = Content.Load<Texture2D>("sprites/2");
            //backgroundSprite = Content.Load<Texture2D>("sprites/background");
            font = Content.Load<SpriteFont>("fonts/title");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                CloseEditor();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(40, 40, 40));

            spriteBatch.Begin();

            //spriteBatch.Draw(backgroundSprite, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(planetSprite, new Rectangle(0, 0, 200, 200), Color.White);
            spriteBatch.DrawString(font, "Diabolus Engine", new Vector2(400 - font.MeasureString("Diabolus Engine").X / 2, font.MeasureString("Diabolus_Engine").Y), Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //handle stuff before closing
        void CloseEditor()
        {
            Exit();
        }
    }
}
