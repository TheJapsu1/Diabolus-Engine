using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diabolus_Engine
{
    public class DiabolusBehaviour : DrawableGameComponent
    {
        public Transform transform = new Transform();

        public DiabolusBehaviour(Game game) : base(game) { }
    }
}
