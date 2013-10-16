using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace BiscuitBasher.Base
{
    public delegate void GameObjectEventHandler(string id);

    public class GameObject3D
    {
        public string ID { get; set; }
        public Matrix World { get; set; }

        public event GameObjectEventHandler Destroying;

        public GameObject3D(string id)
        {
            ID = id;
        }

        public GameObject3D(string id, Vector3 position)
        {
            ID = id;

            World = Matrix.Identity * Matrix.CreateTranslation(position);
        }

        public virtual void Initialize() { }
        public virtual void LoadContent(ContentManager content) { }
        public virtual void Update(GameTime gametime) { }
        public virtual void Draw(Camera camera) { }

        public void Destroy()
        {
            if (Destroying != null)
                Destroying(ID);
        }
    }
 
}
