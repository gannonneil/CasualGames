using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using BiscuitBasher.Display;

namespace BiscuitBasher.Engines
{
    public class NotificationEngine : DrawableGameComponent
    {
        SpriteBatch _batch;
        SpriteFont _sfont;

        static List<Notification> _notifications = new List<Notification>();
        static Queue<Notification> _queuedNotification = new Queue<Notification>();

        private static int _maxNotifications;

        public NotificationEngine(Game game, int maxNotifications)
            : base(game)
        {
            _maxNotifications = maxNotifications;

            Game.Components.Add(this);
        }

        protected override void LoadContent()
        {
            _batch = new SpriteBatch(GraphicsDevice);
            _sfont = Game.Content.Load<SpriteFont>("Fonts\\sfont");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateNotifications(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        private void UpdateNotifications(float elapsedTime)
        {
            for (int i = 0; i < _notifications.Count; i++)
            {
                //a notification with the lifteim -9 will never be removed
                if (_notifications[i].Lifetime != -9)
                {
                    //take away the time passed since the last frame
                    //from the notifications lifetime
                    _notifications[i].Lifetime -= elapsedTime;

                    //if the lifetime is now 0 or less
                    if (_notifications[i].Lifetime <= 0)
                    {
                        //remove if from teh list
                        _notifications.RemoveAt(i);

                        //if there are quesed notifications and the max is not reached then add one to the list
                        if (_queuedNotification.Count > 0 && _notifications.Count < _maxNotifications)
                        {
                            AddNotification(_queuedNotification.Dequeue());
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            DrawNotfications();

            base.Draw(gameTime);
        }

        public void DrawNotfications()
        {
            _batch.Begin();

            for (int i = 0; i < _notifications.Count; i++)
            {
                _batch.DrawString(
                    _sfont,
                    _notifications[i].Message,
                    new Vector2((GraphicsDevice.Viewport.Width / 2 - MeasureWidth(_notifications[i].Message) /2), 22 * i),
                        _notifications[i].Color);
            }

            _batch.End();
        }

        private float MeasureWidth(string text)
        {
            return _sfont.MeasureString(text).X;
        }

        public static void AddNotification(Notification _newNotification)
        {
            if (_newNotification != null)
            {
                // if we have the max number of notifications on the screen
                //add them to the queue
                if (_notifications.Count >= _maxNotifications)
                    _queuedNotification.Enqueue(_newNotification);
                else
                    _notifications.Add(_newNotification);
            }
        }
    }
}
