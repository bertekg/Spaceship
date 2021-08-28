using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2;
        public double maxTime = 2;
        public double minTime = 0.4;
        public int nextSpeed = 240;
        public bool inGame = false;
        public double totalTime = 0;

        public void controllerUpdate(GameTime gameTime)
        {
            if (inGame == true)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                totalTime += gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    inGame = true;
                    totalTime = 0;
                    timer = 2;
                    maxTime = 2;
                    nextSpeed = 240;
                }
            }

            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                timer += maxTime;

                maxTime -= 0.05;
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
