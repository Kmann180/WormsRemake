using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        public class Message
        {
            private string _message;
            private object _attachment;
            private List<string> _validRecipients;

            public string Content { get { return this._message; } set { this._message = value; } }
            public object Attachment { get { return this._attachment; } }
            public List<string> ValidRecipients { get { return this._validRecipients; } set { this._validRecipients = value; } }

            public void Attach(object attachment)
            {
                this._attachment = attachment;
            }

            public Message(string message, params string[] listeners )
            {
                this._message = message.ToUpper();
                this._validRecipients = new List<string>();
                this._attachment = null;

                foreach (string s in listeners)
                {
                    this._validRecipients.Add(s);
                }
            }
        }
    }
}
