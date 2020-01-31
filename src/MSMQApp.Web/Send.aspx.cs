using System;
using System.Configuration;
using System.Messaging;

namespace MSMQApp.Web
{
    public partial class Send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            var queue = new MessageQueue(ConfigurationManager.AppSettings["QueuePath"]);

            try
            {
                queue.Send(txtMessage.Text);
            }
            catch (Exception ex)
            {
                litMessage.Text = ex.Message;

                return;
            }

            litMessage.Text = "Message sent successfully";
        }
    }
}
