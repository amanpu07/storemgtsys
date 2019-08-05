<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/MPIndex11.master" AutoEventWireup="true" CodeFile="HomePageMaster.aspx.cs" Inherits="Inventory_HomePageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  &nbsp;&nbsp;&nbsp; 
        <div class="box" align="Right" >  
                    
        <br />
        <br />
           <div id="nav_menu2">
		        <ul>
                 <%-- <li id="menu1"><a href="ItemMaster.aspx"><span><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Item Master</asp:LinkButton></span></a></li>--%>
		      <li id="menu1"><a href="ItemMasterlogin.aspx"><span>Item Master</span></a></li>
               <li id="menu2"><a href="loginmastercreation.aspx"><span>New Sub Division</span></a></li>
		      <%--   <li id="menu2"><a href="Source.aspx"><span>Source Master</span></a></li>
		       <li id="menu3"><a href="storewelcome.aspx"><span>storewelcome</span></a></li>--%>
		       <li id="menu3"><a href="loginmastercreationje.aspx"><span>Add JE</span></a></li>
		        </ul>
	        </div>
            <br />
        <br /><br />
        <br />
            	        <font size="3" color="#b3a386"><strong>STORE MANAGEMENT SYSTEM</strong></font>                   
        </div>
        <br />
        <br />
       
</asp:Content>


