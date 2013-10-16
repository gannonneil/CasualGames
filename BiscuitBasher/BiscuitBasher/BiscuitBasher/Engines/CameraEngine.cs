using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using BiscuitBasher.Base;

namespace BiscuitBasher.Engines
{
    public class CameraEngine : GameComponent
    {
        private Dictionary<string, Camera> cameras;
        private Camera activeCamera;
        private string activeCameraID;

        public CameraEngine(Game _game)
            : base(_game)
        {
            cameras = new Dictionary<string, Camera>();

            _game.Components.Add(this);
        }

        public List<string> GetCurrentCameras()
        {
            return cameras.Keys.ToList();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gametime)
        {
            if (activeCamera != null)
                activeCamera.Update(gametime);

            base.Update(gametime);
        }

        public void SetActiveCamera(string id)
        {
            if (cameras.ContainsKey(id))
            {
                if (activeCameraID != id)
                {
                    activeCamera = cameras[id];
                    activeCamera.Initialize();

                    activeCameraID = id;
                }
            }
        }

        public void AddCamera(Camera camera)
        {
            if (!cameras.ContainsKey(camera.ID))
            {
                cameras.Add(camera.ID, camera);

                if (cameras.Count == 1)
                    SetActiveCamera(camera.ID);
            }
        }

        public void RemoveCamera(string id)
        {
            if (cameras.ContainsKey(id))
            {
                if (cameras.Count > 1)
                {
                    cameras.Remove(id);
                }
            }
        }

        public Camera ActiveCamera
        {
            get { return activeCamera; }
        }
    }
}
