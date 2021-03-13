using Diabolus_Engine.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Diabolus_Engine.Helper;
using System.Runtime.InteropServices;
using System;

namespace Diabolus_Engine
{
    public class Editor : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D planetSprite;
        private SpriteFont font;

        public Editor()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width / 2;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height / 2;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.AllowUserResizing = true;

            Components.Add(new InfoPanel(this));

            base.Initialize();
        }

        //load textures, models, fonts, music, etc here
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            planetSprite = Content.Load<Texture2D>("sprites/2");
            font = Content.Load<SpriteFont>("fonts/title");
            Services.AddService(typeof(SpriteBatch), spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                CloseEditor();
            if (Keyboard.GetState().IsKeyDown(Keys.C))
                CreateConsole();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(44, 62, 80));

            spriteBatch.Begin();
            spriteBatch.Draw(planetSprite, new Rectangle(0, 0, 200, 200), Color.White);
            spriteBatch.DrawString(font, "Diabolus Engine", new Vector2(GetScreenPosition(ScreenPosition.TopCenter, GetViewportSize(GraphicsDevice)).X - font.MeasureString("Diabolus Engine").X / 2, font.MeasureString("Diabolus Engine").Y), Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //handle stuff before closing
        void CloseEditor()
        {
            Exit();
        }

        [DllImport("kernel32")]
        static extern bool AllocConsole();
        private void CreateConsole()
        {
            AllocConsole();
            Console.Title = "Diabolus debugger";
            Console.WriteLine("Debugging started");
        }
    }
}
