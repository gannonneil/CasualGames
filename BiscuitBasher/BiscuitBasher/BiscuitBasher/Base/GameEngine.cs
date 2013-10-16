using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using BiscuitBasher.Engines;
using BiscuitBasher.Base;
using BiscuitBasher.Objects;
using BiscuitBasher.Scenes;

namespace BiscuitBasher.Base
{
    public class GameEngine : DrawableGameComponent
    {
        public InputEngine Input { get; set; }
        public CameraEngine Cameras { get; set; }
        public AudioEngine Audio { get; set; }
        public DebugEngine Debug { get; set; }
        public FrameRateCounter FPSCounter { get; set; }
        public NotificationEngine Notifications { get; set; }
        public Crosshair Crosshair { get; set; }

        public Scene ActiveScene { get; set; }

        public GameEngine(Game _game)
            : base(_game)
        {
            _game.Components.Add(this);

            Input = new InputEngine(_game);
            Cameras = new CameraEngine(_game);
            Audio = new AudioEngine(_game);
            FPSCounter = new FrameRateCounter(_game, new Vector2(10, 10));
            Notifications = new NotificationEngine(_game, 3);
            Crosshair = new Crosshair(_game);

            Debug = new DebugEngine();
        }

        public override void Initialize()
        {
            Debug.Initialize();

            base.Initialize();
        }

        private void InitializeScene()
        {
            if (ActiveScene != null)
            {
                for (int i = 0; i < ActiveScene.Objects.Count; i++)
                    ActiveScene.Objects[i].Initialize();
            }
        }

        protected override void LoadContent()
        {
            Debug.LoadContent(Game.Content);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (ActiveScene != null)
                ActiveScene.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Draw3D();

            Draw2D();

            Helpers.RestoreGraphicsDeviceTo3D();

            base.Draw(gameTime);
        }

        public void Draw2D() { }

        public void Draw3D()
        {
            if (Cameras.ActiveCamera != null)
                for (int i = 0; i < ActiveScene.Objects.Count; i++)
                    ActiveScene.Objects[i].Draw(Cameras.ActiveCamera);

            Debug.Draw(Cameras.ActiveCamera);
        }

        public void LoadScene(Scene _scene)
        {
            if (_scene != null)
            {
                ActiveScene = _scene;
                ActiveScene.Initialize();

                for (int i = 0; i < ActiveScene.Objects.Count; i++)
                {
                    ActiveScene.Objects[i].LoadContent(Game.Content);
                }
            }
        }
    }
}
