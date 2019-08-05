<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Subdivison.master" AutoEventWireup="true" CodeFile="HomePageSubDivison.aspx.cs" Inherits="Inventory_HomePageSubDivison" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 &nbsp;&nbsp;&nbsp; 
        <div class="box" align="right" >  
                   <asp:Label ID="lblMessage" runat="server"  ForeColor="Black" Font-Bold="True" 
            Font-Size="X-Large" ></asp:Label> 
        <br />
      
           <div id="nav_menu2">
		        <ul>
		        <li id="menu1"><a href="../Inventory/SubdivisonSR.aspx"><span>SR</span></a></li>
                 <li id="menu2"><a href="../Inventory/SubdivisonSRW.aspx"><span>SRW</span></a></li>
		       <li id="menu3"><asp:LinkButton ID="lbEstimate" runat="server" onclick="lbEstimate_Click"> Estimate Master</asp:LinkButton></li>
				  <%-- <li id="menu3"><a href="../Inventory/SubdivisonEstimateMaster.aspx"><span>Estimate Master</span></a></li>--%>
		        <li id="menu4"><a href="../Inventory/SubdivisonLineMaster.aspx"><span>Work Master</span></a></li>
                <li id="menu5"><a href="../Inventory/SubdivisonMCR.aspx"><span>MCR</span></a></li>               
                 <li id="menu6"><a href="../Inventory/InventoryList.xlsx"><span>Item List</span></a></li>                
                <li id="menu7"><a href=""><span>Print SR</span></a></li>
                 <li id="menu8"><a href=""><span>IWR</span></a></li>
               <%--<li id="Li1"><a href="../Reports/SRReportMainPage.aspx"><span>Print SR</span></a></li>--%>
                <li id="menu9"><a href=""><span>....</span></a></li>
                 </ul>
	        </div>
  <br /><br /><br /><br />
	        <font size="3" color="#b3a386"><strong>STORE MANAGEMENT SYSTEM</strong></font>                   
        </div>
        
       </asp:Content>


