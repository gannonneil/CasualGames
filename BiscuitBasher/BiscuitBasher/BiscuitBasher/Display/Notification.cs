using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace BiscuitBasher.Display
{
    public class Notification
    {
        public float Lifetime { get; set; }
        public string Message { get; set; }
        public Color Color { get; set; }

        public Notification() { }

        public Notification(string message, float lifetime)
        {
            Message = message;
            Lifetime = lifetime;
            Color = Color.White;
        }


        public Notification(string message, float lifetime, Color color)
        {
            Message = message;
            Lifetime = lifetime;
            Color = color;
        }
    }
}
