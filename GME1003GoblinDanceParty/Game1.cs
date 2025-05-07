﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Media;

namespace GME1003GoblinDanceParty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declare some variables
        private int _numStars;          //how many stars?
        private List<int> _starsX;      //list of star x-coordinates
        private List<int> _starsY;      //list of star y-coordinates
        private List<float> _starRotation; //list of star rotations
        private List<float> _starTransparency; //list of star transparencies
        private List<float> _starScale; //list of star sizes
        private List<Color> _starColor; //list of colors

        private Texture2D _starSprite;  //the sprite image for our star

        private Random _rng;            //for all our random number needs


        //***This is for the goblin. Ignore it.
        Goblin goblin;
        Song music;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _rng = new Random();        //finish setting up our Randon 
            _numStars = _rng.Next(100, 301); //random number between 100 and 300
            _starsX = new List<int>();  //stars X coordinate
            _starsY = new List<int>();  //stars Y coordinate
            _starRotation = new List<float>(); // star rotation
            _starTransparency = new List<float>(); // star transparency
            _starScale = new List<float>(); // star scale
            _starColor = new List<Color>(); // star colour

            //use a separate for loop for each list - for practice
            //List of X coordinates
            for (int i = 0; i < _numStars; i++)
            {
                _starsX.Add(_rng.Next(0, 801)); //all star x-coordinates are between 0 and 801
            }

            //List of Y coordinates
            for (int i = 0; i < _numStars; i++)
            {
                _starsY.Add(_rng.Next(0, 481)); //all star y-coordinates are between 0 and 480
            }

            for (int i = 0; i < _numStars; i++)
            {
                _starColor.Add(new Color(
                    128 + _rng.Next(0, 129),
                    128 + _rng.Next(0, 129),
                    128 + _rng.Next(0, 129)
                    ));
            }

            for (int i = 0; i <= _numStars; i++)
            {
                _starScale.Add(_rng.Next(50, 100) / 200f);
            }

            for (int i = 0; i < _numStars; i++)
            {
                _starTransparency.Add(_rng.Next(25, 101) / 100f);
            }

            for (int i = 0; i < _numStars; i++)
            {
                _starRotation.Add(_rng.Next(0, 101) / 100f);
            }


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load out star sprite
            _starSprite = Content.Load<Texture2D>("starSprite");


            //***This is for the goblin. Ignore it for now.
            goblin = new Goblin(Content.Load<Texture2D>("goblinIdleSpriteSheet"), 400, 400);
            music = Content.Load<Song>("chiptune");

            //if you're tired of the music player, comment this out!
            MediaPlayer.Play(music);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //***This is for the goblin. Ignore it for now.
            goblin.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin();

            //it would be great to have a background image here! 
            //you could make that happen with a single Draw statement.

            //this is where we draw the stars...
            for (int i = 0; i < _numStars; i++)
            {
                _spriteBatch.Draw(_starSprite,
                    new Vector2(_starsX[i], _starsY[i]),    //set the star position
                    null,                                   //ignore this
                    _starColor[i] * _starTransparency[i],         //set colour and transparency
                    _starRotation[i],                          //set rotation
                    new Vector2(_starSprite.Width / 2, _starSprite.Height / 2), //ignore this
                    new Vector2(_starScale[i], _starScale[i]),    //set scale (same number 2x)
                    SpriteEffects.None,                     //ignore this
                    0f);                                    //ignore this
            }
            _spriteBatch.End();



            //***This is for the goblin. Ignore it for now.
            goblin.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
