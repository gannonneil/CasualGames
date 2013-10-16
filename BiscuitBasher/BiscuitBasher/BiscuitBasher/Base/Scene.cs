using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BiscuitBasher.Base
{
    public class Scene
    {
        public string ID { get; set; }

        protected List<GameObject3D> _sceneObjects = new List<GameObject3D>();
        public List<GameObject3D> Objects { get { return _sceneObjects; } }

        protected GameEngine Engine;

        public Scene(string id, GameEngine engine)
        {
            ID = id;
            Engine = engine;
        }

        public virtual void Initialize() 
        {
            for (int i = 0; i < _sceneObjects.Count; i++)
                _sceneObjects[i].Initialize();
        }

        public virtual void Update(GameTime gametime)
        {
            for (int i = 0; i < _sceneObjects.Count; i++)
                _sceneObjects[i].Update(gametime);

            HandlInput();
        }

        protected virtual void HandlInput() { }

        public void AddObject(GameObject3D _newObject)
        {
            _newObject.Destroying += new GameObjectEventHandler(_newObject_Destroying);
            _sceneObjects.Add(_newObject);
        }

        void _newObject_Destroying(string id)
        {
            RemoveObject(id);
        }

        public void RemoveObject(string id)
        {
            for (int i = 0; i < _sceneObjects.Count; i++)
                if (_sceneObjects[i].ID == id)
                    _sceneObjects.RemoveAt(i);
        }
    }
}
