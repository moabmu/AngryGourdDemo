using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input.Touch;
using Windows.Devices.Sensors;

namespace AngryGourdDemo
{
    /// <summary>
    /// This is a simple game called AngryGroud.
    /// The code is attached to a workshop about MonoGame for absolute beginners.
    /// The game is not completeو and the code is written in such a manner to be appropriate for beginners.
    /// </summary>
    public class AngryGourdGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GSprite _background, _gourd;
        Hero _hero;
        RenderContainer _renderContainer;
        public AngryGourdGame()
        {
            graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _renderContainer = new RenderContainer();

            _background = new GSprite("Backgrounds/Background1") { Position = new Vector2(0,0) };
            _gourd = new GSprite("Sprites/Gourd") { Position = new Vector2(15 , 25) };
            _hero = new Hero();
            _hero.Initialize();

            //var _accelerometer = Accelerometer.GetDefault();
            //if(_accelerometer != null)
            //{
            //    _accelerometer.ReportInterval = _accelerometer.MinimumReportInterval;
            //    _accelerometer.ReadingChanged += _accelerometer_ReadingChanged;
            //}

            var _accelerometer = Accelerometer.GetDefault();
            if (_accelerometer != null)
            {
                _accelerometer.ReportInterval = _accelerometer.MinimumReportInterval;
                _accelerometer.ReadingChanged += _accelerometer_ReadingChanged;
            }

            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            TouchPanel.EnabledGestures = GestureType.DoubleTap;

            base.Initialize();
        }

        private void _accelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            _hero.MoveSpeedMultiplier = (float)args.Reading.AccelerationY;
#if DEBUG
            Debug.WriteLine(String.Format("_hero.MoveSpeedMultiplier = {0,5:0.00}", _hero.MoveSpeedMultiplier));
#endif
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _renderContainer.SpriteBatch = spriteBatch;
            _renderContainer.GraphicsDevice = graphics.GraphicsDevice;

            _background.LoadContent(this.Content);
            _gourd.LoadContent(this.Content);
            _hero.LoadContent(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _renderContainer.GameTime = gameTime;
            _gourd.Update(_renderContainer);

            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gs = TouchPanel.ReadGesture();
                if(gs.GestureType == GestureType.DoubleTap)
                {
                    // flip hero direction
                    _hero.FlipDirection();
                }
            }
            _hero.Update(_renderContainer);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // Let's suppose our screen size is a fixed size 800 * 480, later on we will handle it to work with any screen size
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            _background.Draw(_renderContainer);
            _gourd.Draw(_renderContainer);
            _hero.Draw(_renderContainer);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
