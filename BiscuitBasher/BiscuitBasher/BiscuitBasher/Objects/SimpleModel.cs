using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BiscuitBasher.Engines;

using BiscuitBasher.Base;

namespace BiscuitBasher.Objects
{
    public class SimpleModel : GameObject3D
    {
        public Model Model3D { get; set; }
        public Matrix[] BoneTransforms { get; set; }
        string _asset;

        public SimpleModel(string id, string asset, Vector3 position)
            : base(id, position)
        {
            _asset = asset;
        }

        public override void LoadContent(ContentManager _content)
        {
            if (!string.IsNullOrEmpty(_asset))
            {
                Model3D = _content.Load<Model>("Models\\" + _asset);

                BoneTransforms = new Matrix[Model3D.Bones.Count];
                Model3D.CopyAbsoluteBoneTransformsTo(BoneTransforms);
            }

            base.LoadContent(_content);
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(Camera camera)
        {
            foreach (ModelMesh mesh in Model3D.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = camera.View;
                    effect.Projection = camera.Projection;
                    effect.World = BoneTransforms[mesh.ParentBone.Index] * World;

                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }

            base.Draw(camera);
        }
    }
}
