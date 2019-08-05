<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="HomePageStoreAE.aspx.cs" Inherits="Inventory_HomePageStoreAE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp; 
        <div class="box" align="right" >  
                   <asp:Label ID="lblMessage" runat="server"  ForeColor="Black" Font-Bold="True" 
            Font-Size="X-Large" ></asp:Label> 
        <br />
      
           <div id="nav_menu2">
		        <ul>
                 <li id="menu1"><a href="../Inventory/StoreAEGR.aspx"><span>GR</span></a></li>
                 <li id="menu2"><a href="../Inventory/StoreAESRW.aspx"><span>SRW</span></a></li>
                 <li id="menu3"><a href="../Inventory/StoreAEchallanreceipt.aspx"><span>Challan Receipt</span></a></li>
		        <li id="menu4"><a href="../Inventory/StoreAESR.aspx"><span>SR</span></a></li>
		        <li id="menu5"><a href="../Inventory/StoreAEChallan.aspx"><span>Challan Issue</span></a></li>
                <li id="menu6"><a href="../Inventory/StoreAEDGR.aspx"><span>DGR</span></a></li>
                <li id="menu7"><a href="../Inventory/StoreAEJVCredit.aspx"><span>JV-Credit(GR)</span></a></li>
                <li id="menu8"><a href="../Inventory/StoreAEJVDebit.aspx"><span>JV-Debit(SR/Ch)</span></a></li>
                <li id="menu9"><a href="../Inventory/ReportMainPage.aspx"><span>Reports</span></a></li>
                
                 </ul>
	        </div>
  <br /><br /><br /><br />
	        <font size="3" color="#b3a386"><strong>STORE MANAGEMENT SYSTEM</strong></font>                   
        </div>
        
       </asp:Content>




