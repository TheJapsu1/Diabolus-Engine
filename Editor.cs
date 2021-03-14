using Diabolus_Engine.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static Diabolus_Engine.Helper;

namespace Diabolus_Engine
{
    public class Editor : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private bool safeMode = false;
        private List<Rectangle> buttons = new List<Rectangle>();

        public Editor()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width / 2;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height / 2;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            Window.AllowUserResizing = true;

            //create our info panel
            Components.Add(new InfoPanel(this));

            //create our button rectangles
            buttons.Add(new Rectangle(GetScreenPosition(ScreenPosition.BottomRight, GraphicsDevice).ToPoint(), new Point(100, 60)));

            //create our debug console
            DebugConsole.Create();

            //create buttons
            foreach (Rectangle rect in buttons)
            {
                Rectangle rectangle = rect;
                rectangle.Location -= rect.Size;
                Button button = new Button(this, rectangle, "Exit", Color.Black);
                button.AddOnClickListener += CloseEditor;
                Components.Add(button);
            }

            base.Initialize();
        }

        //load textures, models, fonts, music, etc here
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _planetSprite = Content.Load<Texture2D>("sprites/2");
            _font = Content.Load<SpriteFont>("fonts/title");
            Services.AddService(typeof(SpriteBatch), _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            Input.GetState();
            if (Input.GetKeyDown(Keys.Escape))
                CloseEditor(null, null);
            if (Input.GetKeyDown(Keys.F5))
                safeMode = !safeMode;

            if (safeMode)
                Window.IsBorderless = true;
            else
                Window.IsBorderless = false;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(44, 62, 80));

            base.Draw(gameTime);
        }

        //handle stuff before closing
        void CloseEditor(object sender, EventArgs e)
        {
            DebugConsole.ConfirmLeave(this);
        }
    }
}
