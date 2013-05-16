using System;
using System.Xml;
using System.Collections.Generic;
using System.Web.Configuration;

public class Easypay_wrapper
{
	//Username used to connect through easypay api
	public string Username {
        get { return strUsername; }
        set { strUsername = value; }
    }
	private string strUsername;

	//Entity used to connect through easypay api
	public int Entity {
        get { return strEntity; }
        set { strEntity = value; }
    }
	private int strEntity;

	//CIN used to connect through easypay api
	public int CIN {
		get { return intCIN; }
        set { intCIN = value; }
	}
	private int intCIN;

	//Country used to connect through easypay api
	public string Country {
		get { return strCountry; }
        set { strCountry = value; }
	}
	private string strCountry = "PT";
	
	//Language used to connect through easypay api
	public string Language {
		get { return strLanguage; }
        set { strLanguage = value; }
	}
	private string strLanguage = "PT";
	
	public string Server_Test {
		get { return "http://test.easypay.pt/_s/";}
	}

	public string Server_Production {
		get { return "https://www.easypay.pt/_s/";}
	}

	//Sets if the connection is production or test
	public bool isLive {
		get { return bLive; }
        set { bLive = value; }
	}
	private bool bLive = false;

	//Enum to the existing APIs
	public enum api{
		api_easypay_01BG,
		api_easypay_05AG,
		api_easypay_03BG,
		api_easypay_040BG1,
		api_easypay_07BG,
		api_easypay_23AG
	}

	//Enum to the Reference Type
	public enum ReferenceType{
		normal,
		boleto,
		recurring,
		moto
	}

	//Enum to the Payment Type
	public enum PaymentType{
		creditcard,
		recurring
	}

	/// <summary>
	/// Creates a new reference.
	/// </summary>
	/// <returns>
	/// The reference.
	/// </returns>
	/// <param name='t_key'>
	/// T_key.
	/// </param>
	/// <param name='t_value'>
	/// T_value.
	/// </param>
	/// <param name='type'>
	/// Type.
	/// </param>
	public XmlDocument CreateReference (string t_key, string t_value, ReferenceType type = ReferenceType.normal,
	                                    string name = "", string description = "", string observation = "", string mobile = "", string email = "")
	{
		List<string> lParams = new List<string> { 
			"ep_cin=" 		+ CIN, 
			"ep_user=" 		+ Username, 
			"ep_entity=" 	+ Entity, 
			"ep_ref_type=auto", 
			"t_key=" 		+ t_key, 
			"t_value=" 		+ t_value, 
			"ep_country=" 	+ Country, 
			"ep_language=" 	+ Language, 
			"name=" 		+ name, 
			"description=" 	+ description, 
			"observation=" 	+ observation, 
			"mobile=" 		+ mobile, 
			"email=" 		+ email
		};

		switch (type) {
		case ReferenceType.boleto:
			lParams.Add ("ep_type=boleto");
			break;
		case ReferenceType.recurring:
			lParams.Add ("ep_rec_type=yes");
			break;
		case ReferenceType.moto:
			lParams.Add ("ep_type=moto");
			break;
		default:
			break;
		}

		try {
			XmlDocument x = new XmlDocument ();
			x.Load (getUrl (api.api_easypay_01BG, lParams));

			return x;
		} catch (Exception) {
			return null;
		}
	}

	/// <summary>
	/// Requests a payment.
	/// </summary>
	/// <returns>
	/// The payment.
	/// </returns>
	/// <param name='reference'>
	/// Reference.
	/// </param>
	/// <param name='key'>
	/// Key.
	/// </param>
	/// <param name='type'>
	/// Type.
	/// </param>
	public XmlDocument RequestPayment (int reference, string key, PaymentType type = PaymentType.creditcard)
	{
		List<string> lParams = new List<string> { 
			"u=" + Username, 
			"e=" + Entity, 
			"r=" + reference.ToString(), 
			"l=" + Language, 
			"k=" + key
		};

		switch (type){
			case PaymentType.recurring: lParams.Add("ep_rec_type=yes"); break;
			default: break;
		}

		try{
			XmlDocument x = new XmlDocument();
			x.Load(getUrl(api.api_easypay_05AG, lParams));

			return x;
		} catch (Exception) {
			return null;
		}
	}

	/// <summary>
	/// Request for the detailed payment information
	/// </summary>
	/// <returns>
	/// The payment info.
	/// </returns>
	/// <param name='ep_doc'>
	/// Ep_doc.
	/// </param>
	public XmlDocument GetPaymentInfo (string ep_doc)
	{
		List<string> lParams = new List<string> { 
			"ep_user=" 	+ Username, 
			"ep_cin=" 	+ CIN, 
			"ep_doc=" 	+ ep_doc
		};
		
		try {
			XmlDocument x = new XmlDocument();
			x.Load(getUrl(api.api_easypay_03BG, lParams));

			return x;
		} catch (Exception) {
			return null;
		}
	}

	/// <summary>
	/// Gets a Transaction key verification.
	/// </summary>
	/// <returns>
	/// The Transaction key verification.
	/// </returns>
	/// <param name='reference'>
	/// Reference.
	/// </param>
	public XmlDocument GetTransationVerification (int reference)
	{
		List<string> lParams = new List<string> { 
			"ep_user=" 	+ Username, 
			"ep_cin=" 	+ CIN, 
			"e=" 		+ Entity, 
			"r=" 		+ reference, 
			"c=" 		+ Country
		};

		XmlDocument x = new XmlDocument();
		x.Load(getUrl(api.api_easypay_03BG, lParams));

		return x;
	}

	/// <summary>
	/// Gets the API URL.
	/// </summary>
	/// <returns>
	/// The URL.
	/// </returns>
	/// <param name='x'>
	/// Api
	/// </param>
	/// <param name='p'>
	/// List of parameters
	/// </param>
	private string getUrl (api x, List<string> p = null){
		string url = string.Format("{0}{1}.php", (isLive ?  Server_Production : Server_Test), x );
		if( p != null)
			url += "?" + String.Join( "&" , p);

		return url.Replace(" ", "+");
	}
}


