using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Diabolus_Engine
{
    class Input
    {
        private static KeyboardState _currentKeyState;
        private static KeyboardState _previousKeyState;
        private static MouseState _currentMouseState;
        private static MouseState _previousMouseState;

        public static KeyboardState GetState()
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            return _currentKeyState;
        }

        public static bool GetKey(Keys key)
        {
            return _currentKeyState.IsKeyDown(key);
        }

        public static bool GetKeyDown(Keys key)
        {
            return _currentKeyState.IsKeyDown(key) && !_previousKeyState.IsKeyDown(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return _currentKeyState.IsKeyUp(key) && !_previousKeyState.IsKeyUp(key);
        }

        public static Vector2 GetMousePos()
        {
            return new Vector2(_currentMouseState.X, _currentMouseState.Y);
        }

        public static bool GetLMB()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool GetLMBDown()
        {
            return (_currentMouseState.LeftButton == ButtonState.Pressed) && !(_previousMouseState.LeftButton == ButtonState.Pressed);
        }

        public static bool GetLMBUp()
        {
            return (_currentMouseState.LeftButton == ButtonState.Released) && !(_previousMouseState.LeftButton == ButtonState.Released);
        }

        public static bool GetRMB()
        {
            return _currentMouseState.RightButton == ButtonState.Pressed;
        }

        public static bool GetRMBDown()
        {
            return (_currentMouseState.RightButton == ButtonState.Pressed) && !(_previousMouseState.RightButton == ButtonState.Pressed);
        }

        public static bool GetRMBUp()
        {
            return (_currentMouseState.RightButton == ButtonState.Released) && !(_previousMouseState.RightButton == ButtonState.Released);
        }

        public static bool GetXMB1()
        {
            return _currentMouseState.XButton1 == ButtonState.Pressed;
        }

        public static bool GetXMB1Down()
        {
            return (_currentMouseState.XButton1 == ButtonState.Pressed) && !(_previousMouseState.XButton1 == ButtonState.Pressed);
        }

        public static bool GetXMB1Up()
        {
            return (_currentMouseState.XButton1 == ButtonState.Released) && !(_previousMouseState.XButton1 == ButtonState.Released);
        }

        public static bool GetXMB2()
        {
            return _currentMouseState.XButton2 == ButtonState.Pressed;
        }

        public static bool GetXMB2Down()
        {
            return (_currentMouseState.XButton2 == ButtonState.Pressed) && !(_previousMouseState.XButton2 == ButtonState.Pressed);
        }

        public static bool GetXMB2Up()
        {
            return (_currentMouseState.XButton2 == ButtonState.Released) && !(_previousMouseState.XButton2 == ButtonState.Released);
        }
    }
}
