﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    class Ship
    {
        static public Vector2 defaultPoition = new Vector2(640, 360);
        public Vector2 position = defaultPoition;
        public double speed = 180;
        private float currentSpeed = 0f;

        public void shipUpdate(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            currentSpeed = (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                position.X += currentSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= currentSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                position.Y += currentSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position.Y -= currentSpeed;
            }
        }
    }
}
