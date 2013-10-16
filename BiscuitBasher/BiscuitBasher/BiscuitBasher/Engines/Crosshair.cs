using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace BiscuitBasher.Engines
{
    public class Crosshair : DrawableGameComponent
    {
        Rectangle bounds;
        Texture2D image;
        SpriteBatch batch;

        public Crosshair(Game game)
            : base(game)
        {
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            image = Game.Content.Load<Texture2D>("Textures\\hammer");
            bounds = new Rectangle(0, 0, 64, 64);
            batch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            bounds.X = (int)InputEngine.MousePosition.X;
            bounds.Y = (int)InputEngine.MousePosition.Y;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            batch.Begin();
            batch.Draw(image, bounds, Color.White);
            batch.End();

            base.Draw(gameTime);
        }
    }
}
