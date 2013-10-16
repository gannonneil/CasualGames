using System;
using Microsoft.Xna.Framework;

namespace BiscuitBasher.Base
{
    public class Camera : GameObject3D
    {
        protected Vector3 cameraTarget;
        protected Vector3 camerUpDirection;
        protected Vector3 cameraDirection;

        protected Matrix view;
        protected Matrix projection;

        protected float fieldOfView = MathHelper.PiOver4;
        protected float nearPlane = 0.25f;
        protected float farPlane = 10000;

        protected Vector3 startTarget;

        protected float _aspectRatio = 1.7f;

        public Camera(string id, Vector3 position, Vector3 target, float aspectRatio)
            : base(id, position)
        {
            startTarget = target;
            _aspectRatio = aspectRatio;
        }

        public override void Initialize()
        {
            cameraDirection = Vector3.Zero - World.Translation;
            cameraDirection.Normalize();
            camerUpDirection = Vector3.Up;
            cameraTarget = World.Translation + cameraDirection;

            CreateLookAt(startTarget);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, _aspectRatio, nearPlane, farPlane);

            base.Initialize();
        }

        public override void Update(GameTime gametime)
        {
            CreateLookAt();

            base.Update(gametime);
        }

        public virtual void CreateLookAt()
        {
            cameraTarget = World.Translation + cameraDirection;
            view = Matrix.CreateLookAt(World.Translation, cameraTarget, Vector3.Up);
        }

        public virtual void CreateLookAt(Vector3 target)
        {
            cameraTarget = World.Translation + cameraDirection;
            view = Matrix.CreateLookAt(World.Translation, target, Vector3.Up);
        }

        public Matrix View
        {
            get { return view; }
            set { view = value; }
        }

        public Matrix Projection
        {
            get { return projection; }
            set { projection = value; }
        }
    }
}
