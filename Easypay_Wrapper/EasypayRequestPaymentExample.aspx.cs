
using System;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Easypay_Wrapper
{
	public partial class EasypayRequestPaymentExample : System.Web.UI.Page
	{
		private Easypay_wrapper ep;

		protected void Page_Load(object sender, EventArgs e)
	    {
			//Initialising the object
			ep = new Easypay_wrapper();

			//Loading your credentials
			ep.Username = "TESTE300810";
			ep.CIN = 3016;
			ep.Entity = 10611;
			
			XmlDocument data = ep.RequestPayment(Convert.ToInt32(Request["r"]), Request["k"], Easypay_wrapper.PaymentType.creditcard);

			EasypayCreatePaymentReferenceExample.DisplayXML(lblData, data);
	    }
	}
}

