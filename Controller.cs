using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Spaceship
{
    class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2;
        public double maxTime = 2;
        public double minTime = 0.5;
        public int nextSpeed = 240;

        public void controllerUpdate(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                timer += maxTime;

                maxTime -= 0.1;
                if (maxTime < minTime)
                {
                    maxTime = minTime;
                }
                if (nextSpeed < 720)
                {
                    nextSpeed += 4;
                }
            }
        }
    }
}
