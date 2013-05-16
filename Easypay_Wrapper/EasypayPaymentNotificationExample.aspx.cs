
using System;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Easypay_Wrapper
{
	public partial class EasypayPaymentNotificationExample : System.Web.UI.Page
	{
		private Easypay_wrapper ep;

		protected void Page_Load(object sender, EventArgs e)
	    {
			//Initialising the object
			ep = new Easypay_wrapper();

			//Loading your credentials
			ep.Username = Request["ep_user"];
			ep.CIN = Convert.ToInt32( Request["ep_cin"] );

			/* First you need to insert the data returned through GET parameter
			   "INSERT INTO `easypay_notifications` ( `ep_cin`, `ep_user`, `ep_doc`)
          		VALUES ('" + Request["ep_cin"] + "', '" + Request["ep_user"] + "', '" + Request["ep_doc"] + "');"
			 */

			//After inserting, you request the detailed information
			XmlDocument data = ep.GetPaymentInfo( Request["ep_doc"] );

			/* Once you got it, you need to update your data
				"UPDATE `easypay_notifications` SET " +
		            "`ep_status` = '"        + data.SelectSingleNode("getautoMB_detail/ep_status").InnerText.ToString() + "'," +
		            "`ep_entity` = '"        + data.SelectSingleNode("getautoMB_detail/ep_entity").InnerText.ToString() + "'," +
		            "`ep_reference` = '"     + data.SelectSingleNode("getautoMB_detail/ep_reference").InnerText.ToString() + "'," +
		            "`ep_value` = '"         + data.SelectSingleNode("getautoMB_detail/ep_value").InnerText.ToString() + "'," +
		            "`ep_date` = '"          + data.SelectSingleNode("getautoMB_detail/ep_date").InnerText.ToString() + "'," +
		            "`ep_payment_type` = '"  + data.SelectSingleNode("getautoMB_detail/ep_payment_type").InnerText.ToString() + "'," +
		            "`ep_value_fixed` = '"   + data.SelectSingleNode("getautoMB_detail/ep_value_fixed").InnerText.ToString() + "'," +
		            "`ep_value_var` = '"     + data.SelectSingleNode("getautoMB_detail/ep_value_var").InnerText.ToString() + "'," +
		            "`ep_value_tax` = '"     + data.SelectSingleNode("getautoMB_detail/ep_value_tax").InnerText.ToString() + "'," +
		            "`ep_value_transf` = '"  + data.SelectSingleNode("getautoMB_detail/ep_value_transf").InnerText.ToString() + "'," +
		            "`ep_date_transf` = '"   + data.SelectSingleNode("getautoMB_detail/ep_date_transf").InnerText.ToString() + "'," +
		            "`t_key` = '"            + data.SelectSingleNode("getautoMB_detail/t_key").InnerText.ToString() + "'" +
		          "WHERE `ep_doc` = '" + data.SelectSingleNode("getautoMB_detail/ep_doc").InnerText.ToString() + "';"
			 */  

			data = null;
	    }
	}
}

