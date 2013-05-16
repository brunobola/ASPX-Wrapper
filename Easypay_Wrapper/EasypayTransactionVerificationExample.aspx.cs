
using System;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Easypay_Wrapper
{
	public partial class EasypayTransactionVerificationExample : System.Web.UI.Page
	{
		private Easypay_wrapper ep;

		protected void Page_Load (object sender, EventArgs e)
		{
			if (Request ["s"].ToString () != "ok") {
				return;
			}

			//Initialising the object
			ep = new Easypay_wrapper();

			//Loading your credentials
			ep.Username = "";
			ep.CIN 		= 1234;
			ep.Entity 	= Convert.ToInt32( Request ["e"]);

			//Requesting transaction key varefication
			XmlDocument data = ep.GetTransationVerification(Convert.ToInt32( Request ["r"]));

			EasypayCreatePaymentReferenceExample.DisplayXML (lblData, data);
	    }
	}
}
