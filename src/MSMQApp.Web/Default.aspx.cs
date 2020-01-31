using System;
using System.Configuration;
using System.Messaging;

namespace MSMQApp.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var queue = new MessageQueue(ConfigurationManager.AppSettings["QueuePath"]);

                try
                {
                    if (!MessageQueue.Exists(queue.Path))
                    {
                        MessageQueue.Create(queue.Path);
                    }
                }
                catch (Exception ex)
                {
                    litMessage.Text = ex.Message;

                    return;
                }

                litMessage.Text = "Connection established successfully";
            }
        }
    }
}
