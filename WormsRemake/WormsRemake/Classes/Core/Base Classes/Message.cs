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
            private Dictionary<string, object> _attachments;
            private List<string> _validRecipients;

            public string Content { get { return this._message; } set { this._message = value; } }
            public Dictionary<string, object> Attachments { get { return this._attachments; } }
            public List<string> ValidRecipients { get { return this._validRecipients; } set { this._validRecipients = value; } }

            public void Attach(string name, object attachment)
            {
                this._attachments[name] = attachment;
            }

            public Message(string message, params string[] listeners )
            {
                this._message = message.ToUpper();
                this._validRecipients = new List<string>();
                this._attachments = new Dictionary<string, object>();

                foreach (string s in listeners)
                {
                    this._validRecipients.Add(s);
                }
            }
        }
    }
}
