<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreJE.master" AutoEventWireup="true" CodeFile="HomePageStoreJE.aspx.cs" Inherits="Inventory_HomePageStoreJE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;&nbsp;&nbsp; 
        <div class="box" align="right" >  
                   <asp:Label ID="lblMessage" runat="server"  ForeColor="Black" Font-Bold="True" 
            Font-Size="X-Large" ></asp:Label> 
        <br />
      
           <div id="nav_menu2">
		        <ul>
                 <li id="menu1"><a href="../Inventory/StoreJEGR.aspx"><span>GR</span></a></li>
                 <li id="menu2"><a href="../Inventory/StoreJESRW.aspx"><span>SRW</span></a></li>
                <li id="menu3"><a href="../Inventory/StoreJEchallanreceipt.aspx"><span>Challan Receipt</span></a></li>
		        <li id="menu4"><a href="../Inventory/StoreJESR.aspx"><span>SR</span></a></li>
		        <li id="menu5"><a href="../Inventory/StoreJEChallan.aspx"><span>Challan Issue</span></a></li>                
                <li id="menu6"><a href="../Inventory/StoreJEDGR.aspx"><span>DGR</span></a></li>
                <li id="menu7"><a href="../Inventory/StoreJEJVCredit.aspx"><span>JV-Credit(GR)</span></a></li>
                <li id="menu8"><a href="../Inventory/StoreJEJVDebit.aspx"><span>JV-Debit(SR/Ch)</span></a></li>
                <li id="menu9"><a href="../Inventory/MasterFirm.aspx"><span>Firm Master</span></a></li>
                <%--<li id="menu10"><a href="../Inventory/OpeningBalance.aspx"><span>Opening Bal</span></a></li>--%>
                 <%--<li id="menu8"><a href="../Inventory/testcalendercontrol.aspx"><span>Calender</span></a></li>--%>
               <%-- <li id="menu11"><a href=""><span>....</span></a></li>
                <li id="menu12"><a href=""><span>....</span></a></li>--%>
                <%--<li id="menu11"><a href="../Inventory/MasterFirm.aspx"><span>Firm Master</span></a></li>
                <li id="menu12"><a href="../Inventory/OpeningBalance.aspx"><span>Opening Bal</span></a></li>--%>
                 </ul>
	        </div>
  <br />
  
    <div id="nav_menu2">
		        <ul>
                 <li id="menu10"><a href="../Inventory/OpeningBalance.aspx"><span>Opening Bal</span></a></li>
                 <li id="menu11"><a href="../Inventory/InventoryList.xlsx"><span>Item List</span></a></li>
                <li id="menu12"><a href=""><span>....</span></a></li>
		        <li id="menu13"><a href=""><span>....</span></a></li>
		        <li id="menu14"><a href=""><span>....</span></a></li>                
                <li id="menu15"><a href=""><span>....</span></a></li>
               <%-- <li id="menu16"><a href=""><span>....</span></a></li>
                <li id="menu17"><a href=""><span>....</span></a></li>
                <li id="menu18"><a href=""><span>....</span></a></li>
                <li id="Li10"><a href="../Inventory/OpeningBalance.aspx"><span>Opening Bal</span></a></li>--%>
                
                 </ul>
	        </div>
  
  <br /><br /><br />
	        <font size="3" color="#b3a386"><strong>STORE MANAGEMENT SYSTEM</strong></font>                   
        </div>
        
       </asp:Content>



