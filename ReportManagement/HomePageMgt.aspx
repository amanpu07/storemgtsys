<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="HomePageMgt.aspx.cs" Inherits="ReportManagement_HomePageMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;&nbsp;&nbsp; 
        <div class="box" align="Right" >  
                   <asp:Label ID="lblMessage" runat="server"  ForeColor="Black" Font-Bold="True" 
            Font-Size="X-Large" ></asp:Label> 
        <br />
        <br />
           <div id="nav_menu2">
		        <ul>
		        <li id="menu1"><a href="../ReportManagement/AllStrCloMainPage.aspx"><span>Item-Wise Status</span></a></li>
		       <li id="menu2"><a href="../Inventory/mgtmain.aspx"><span>Store-Wise Status</span></a></li>
		        <li id="menu3"><a href="../ReportManagement/MRInventStatusMainPAge.aspx"><span>Closing Balance</span></a></li>
		       <%-- <li id="menu3"><a href="../ReportManagement/MRInventObsoleteMainPage.aspx"><span>Obsol/Unser Inventory</span></a></li>--%>	        
               <li id="menu4"><a href=""><span>....</span></a></li>
 
		        <%--<li id="menu4"><a href="../ReportManagement/MRInventAgeingMainPage.aspx"><span>....</span></a></li>--%>
		        <li id="menu5"><a href=""><span>....</span></a></li>
		         <li id="menu6"><a href=""><span>....</span></a></li>
                <li id="menu7"><a href=""><span>....</span></a></li>
		        <li id="menu8"><a href=""><span>....</span></a></li>
		        <li id="menu9"><a href=""><span></span>....</a></li>
		        
                
		        </ul>
	        </div><br /><br /><br /><br />
	        <font size="3" color="#b3a386"><strong>STORE MANAGEMENT SYSTEM</strong></font>                   
        </div>
        
</asp:Content>

