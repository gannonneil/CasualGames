using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BiscuitBasher.Base;

namespace BiscuitBasher.Objects
{
    public class SimpleColorTriangle : GameObject3D
    {
        VertexPositionColor[] _vertices;
        BasicEffect _effect;

        public SimpleColorTriangle(string id, Vector3 position)
            : base(id, position)
        {

        }

        public override void LoadContent(ContentManager _content)
        {
            //local coordinates, World will transform these to global coords
            _vertices = new VertexPositionColor[3];

            _vertices[0].Position = new Vector3(-1, -1, 0);
            _vertices[0].Color = Color.Green;

            _vertices[1].Position = new Vector3(0, 1, 0);
            _vertices[1].Color = Color.Red;

            _vertices[2].Position = new Vector3(1, -1, 0);
            _vertices[2].Color = Color.Blue;

            _effect = new BasicEffect(Helpers.GraphicsDevice);
            _effect.VertexColorEnabled = true;
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(Camera _camera)
        {
            _effect.View = _camera.View;
            _effect.Projection = _camera.Projection;
            _effect.World = World;

            foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Helpers.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                    PrimitiveType.TriangleList, 
                    _vertices,
                    0,
                    1,
                    VertexPositionColor.VertexDeclaration);
            }

            base.Draw(_camera);
        }
    }
}
