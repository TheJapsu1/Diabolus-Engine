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

        public static KeyboardState GetState()
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
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
    }
}
