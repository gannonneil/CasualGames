using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System.Threading;

namespace BiscuitBasher.Engines
{
    public class AudioEngine : GameComponent
    {
        private Dictionary<string, Song> _songs = new Dictionary<string, Song>();
        private Dictionary<string, SoundEffect> _effects = new Dictionary<string, SoundEffect>();

        public Dictionary<string, Song> LoadedSongs { get { return _songs; } }
        public Dictionary<string, SoundEffect> LoadedEffects { get { return _effects; } }

        public AudioEngine(Game _game)
            : base(_game)
        {
            _game.Components.Add(this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void LoadSong(string name)
        {
            if (Game.Content != null && !_songs.ContainsKey(name))
            {
                var song = Game.Content.Load<Song>("Audio\\Songs\\" + name);
                _songs.Add(name, song);
            }
        }

        public void RemoveSong(string name)
        {
            if (_songs.ContainsKey(name))
                _songs.Remove(name);
        }

        public void LoadEffect(string name)
        {
            if (Game.Content != null && !_effects.ContainsKey(name))
            {
                var effect = Game.Content.Load<SoundEffect>("Audio\\Effects\\" + name);
                _effects.Add(name, effect);
            }
        }

        public void RemoveEffect(string name)
        {
            if (_effects.ContainsKey(name))
                _effects.Remove(name);
        }

        public void PlaySong(string name)
        {
            if (_songs.ContainsKey(name))
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(_songs[name]);
            }
        }

        public void PlayEffect(string name)
        {
            if (_effects.ContainsKey(name))
            {
                _effects[name].Play();
            }
        }
    }
}
