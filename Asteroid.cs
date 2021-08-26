using Microsoft.Xna.Framework;
using System;

namespace Spaceship
{
    class Asteroid
    {
        public Vector2 position = new Vector2(1000, 300);
        public double speed;
        public int radius = 59;

        public Asteroid(double newSpeed)
        {
            speed = newSpeed;
            Random random = new Random();
            position = new Vector2(1350, random.Next(radius, 721 - radius));
        }

        public void asteroidUpadate(GameTime gameTime)
        {
            position.X -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
