<%@ Page Language="C#" Inherits="Easypay_Wrapper.EasypayCreatePaymentReferenceExample" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Easypay Create Payment Reference Example</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Button id="button1" runat="server" Text="Create Reference." OnClick="button1Clicked" />
		<br />
		<div runat="server" id="ep_box" style="float: left; text-align:center; border: 1px solid #ddd; border-radius: 5px; width: 210px; min-height: 70px; padding:10px;" >
            <img src="http://store.easyp.eu/img/easypay_logo_nobrands-01.png" style="height:40px; margin-bottom: 10px;" title="Se quer pagar uma referência multibanco utilize a easypay" alt="Se quer pagar uma referência multibanco utilize a easypay" />
            <div style="width: 190px; float: left; padding: 10px; border: 1px solid #ccc; border-radius: 5px; background-color:#eee;">
                <img src="http://store.easyp.eu/img/MB_bw-01.png" />
                
                <div style="padding: 5px; padding-top: 10px; clear: both;">
                    <span style="font-weight: bold;float: left;;">Entity:</span>
                    <span style="color: #0088cc; float: right"><asp:Label id="lblEntity" runat="server" ></asp:Label> (Easypay)</span>
                </div>

                <div style="padding: 5px;clear: both;">
                    <span style="font-weight: bold;float: left;">Reference:</span>
                    <span style="color: #0088cc; float: right"><asp:Label id="lblReference" runat="server" ></asp:Label></span>
                </div>
                
                <div style="padding: 5px; clear: both;">
                    <span style="font-weight: bold;float: left;">Value:</span>
                    <span style="color: #0088cc; float: right"><asp:Label id="lblValue" runat="server" ></asp:Label> &euro;</span>
                </div>
            </div>
            <div style="margin-top: 10px; width: 190px; float: left; padding: 10px; border: 1px solid #ccc; border-radius: 5px; background-color:#eee;">
                <asp:Literal runat="server" id="lUrl"></asp:Literal>
                <img src="http://store.easyp.eu/img/visa_mc_bw-01.png" />
                <div style="padding: 5px; padding-top: 10px; clear: both;" >
                    <asp:LinkButton id="lbutton1" runat="server" Text="Pay Now!" onClick="redirectPagamento" Style="color: #0088cc; text-decoration: none;" />
                </div>
            </div>
        </div>		
	</form>
</body>
</html>
