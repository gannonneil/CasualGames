using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiscuitBasher.Base;
using BiscuitBasher.Objects;
using BiscuitBasher.Engines;
using BiscuitBasher.Display;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BiscuitBasher.Scenes
{
    public class Level0 : Scene
    {
        Camera _simpleCamera;

        Ray _hammerRay;
        BoundingBox biscuit;

        List<BoundingBox> _boxes = new List<BoundingBox>();

        public Level0(GameEngine _engine)
            : base("Level0", _engine)
        {

        }

        public override void Initialize()
        {
            _simpleCamera = new Camera(
                                    "cam0",
                                    new Vector3(0, 0, 20),
                                    new Vector3(0, 5, -10),
                                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.AspectRatio);

            Engine.Cameras.AddCamera(_simpleCamera);


            //AddObject(new SimpleModel("test", "block", new Vector3(0, 0, 0)));

            biscuit = new BoundingBox(new Vector3(-10, -10, -20), new Vector3(10, 10, -20));
            DebugEngine.AddBoundingBox(biscuit, Color.Red, 10000);

            BoundingBox top = new BoundingBox(new Vector3(-20, 15, -20), new Vector3(20, 15, -20));
            BoundingBox bottom = new BoundingBox(new Vector3(-20, -15, -20), new Vector3(20, -15, -20));

            DebugEngine.AddBoundingBox(top, Color.Yellow, 10000);
            DebugEngine.AddBoundingBox(bottom, Color.Yellow, 10000);


            base.Initialize();
        }

        public override void Update(GameTime gametime)
        {
            UpdateBackground();

            base.Update(gametime);
        }

        private void UpdateBackground()
        {
        }

        protected override void HandlInput()
        {
            //temporay test code
            if (InputEngine.IsMouseLeftClick())
            {
                _hammerRay = new Ray(_simpleCamera.World.Translation, Vector3.Forward);

                float? result = _hammerRay.Intersects(biscuit);

                if (_hammerRay != null)
                {
                    NotificationEngine.AddNotification(new Notification("Biscuit Hit!", 1000));
                }
            }

            base.HandlInput();
        }
    }
}
