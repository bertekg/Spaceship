using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D shipSprite;
        Texture2D asteroidSprite;
        Texture2D spaceSprite;
        SpriteFont gameFont;
        SpriteFont timerFont;

        Ship player = new Ship();
        Controller gameController = new Controller();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipSprite = Content.Load<Texture2D>("ship");
            asteroidSprite = Content.Load<Texture2D>("asteroid");
            spaceSprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameController.inGame == true)
            {
                player.shipUpdate(gameTime);
            }
            gameController.controllerUpdate(gameTime);

            foreach (Asteroid asteroid in gameController.asteroids)
            {
                asteroid.asteroidUpadate(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
            foreach (Asteroid asteroid in gameController.asteroids)
            {
                _spriteBatch.Draw(asteroidSprite, new Vector2(asteroid.position.X - asteroid.radius, asteroid.position.Y - asteroid.radius), Color.White);
            }
            _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - (shipSprite.Width / 2), player.position.Y - (shipSprite.Height / 2)), Color.White);
            if (gameController.inGame == false)
            {
                string menuMessage = "Press Enter to Begin!";
                Vector2 menuMessageSize = gameFont.MeasureString(menuMessage);
                int halfWidth = _graphics.PreferredBackBufferWidth / 2;
                _spriteBatch.DrawString(gameFont, menuMessage, new Vector2(halfWidth - (menuMessageSize.X / 2), 200), Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
