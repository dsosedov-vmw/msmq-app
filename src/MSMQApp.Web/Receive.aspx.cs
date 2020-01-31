using System;
using System.Configuration;
using System.IO;
using System.Messaging;

namespace MSMQApp.Web
{
    public partial class Receive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            var queue = new MessageQueue(ConfigurationManager.AppSettings["QueuePath"]);

            Message msg;

            try
            {
                msg = queue.Receive(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                litMessage.Text = ex.Message;

                return;
            }

            msg.Formatter = new ActiveXMessageFormatter();

            string msgBody;

            using (var sr = new StreamReader(msg.BodyStream))
            {
                msgBody = sr.ReadToEnd();
            }

            litMessage.Text = msgBody;
        }
    }
}
