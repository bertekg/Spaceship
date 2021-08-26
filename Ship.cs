using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    class Ship
    {
        public Vector2 position = new Vector2(100, 100);
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
