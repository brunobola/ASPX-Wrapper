
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Easypay_Wrapper
{
	public partial class EasypayCreatePaymentReferenceExample : System.Web.UI.Page
	{
		private Easypay_wrapper ep;

		private string strURL {
			get{ return  ViewState ["url"].ToString(); }
			set{ ViewState["url"] = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
	    {
			//Initialising the object
			ep = new Easypay_wrapper();

			//Loading your credentials
			ep.Username = "";
			ep.CIN = 123;
			ep.Entity = 10611;

			ep_box.Visible = false;
	    }

		//Create Reference
		public virtual void button1Clicked (object sender, EventArgs args)
		{
			//ID of my product/service = 1
			// and it costs 10.01€
			XmlDocument reference = ep.CreateReference("1", "10.01");

			lblEntity.Text 		= reference.SelectSingleNode("getautoMB/ep_entity").InnerText.ToString();
			lblReference.Text 	= reference.SelectSingleNode("getautoMB/ep_reference").InnerText.ToString();
			lblValue.Text 		= reference.SelectSingleNode("getautoMB/ep_value").InnerText.ToString();
			strURL = reference.SelectSingleNode("getautoMB/ep_link").InnerText.ToString();

			ep_box.Visible = true;
		}	

		//Redirect to easypay website
		public virtual void redirectPagamento (object sender, EventArgs args)
		{
			Response.Redirect(strURL);
		}

		//Misc Function just to display the xml returned from API calls
		public static void DisplayXML (Label lbl, XmlDocument xml)
		{
			if (xml == null) {
				lbl.Text = "Error";
			} else {
				lbl.Text = xml.InnerXml.Replace("</", "%%").Replace("<", "<br />&lt;").Replace("%%", "&lt;/");
			}
		}
	}
}

