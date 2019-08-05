<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="MgtRptMainPage.aspx.cs" Inherits="Inventory_MgtRptMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;&nbsp;&nbsp; 
        <div class="box" align="center" >  
                   <asp:Label ID="lblMessage" runat="server"  ForeColor="Black" Font-Bold="True" 
            Font-Size="X-Large" ></asp:Label> 
        <br />
        <br />
           <div id="nav_menu2">
		        <ul>
		       <li id="menu1"><a href="../ReportManagement/MgtGRMainPage.aspx"><span>GR Report</span></a></li>
		        <%--<li id="menu2"><a href="StoreSRForm.aspx"><span>SR/Issue Report</span></a></li>--%>
		        <li id="menu2"><a href="../Reports/ChallanReportMainPage.aspx"><span>Store Challan Report</span></a></li>
		        <li id="menu3"><a href="../Reports/ValueCardMainPage.aspx"><span>Value Card Report</span></a></li>
		        <li id="menu4"><a href="../Reports/StockCardMainPage.aspx"><span>Stock Card Report</span></a></li>
                <li id="menu5"><a href="../Reports/RptReceivedMainPage.aspx"><span>Monthly Receipt</span></a></li>
		        <%--<li id="menu5"><a href="../Reports/MonthlyGRReportMainPage.aspx"><span>Monthly G.R. Report</span></a></li>--%>
                <li id="menu6"><a href="../Reports/RptIssuedMainPage.aspx"><span>Monthly Issued</span></a></li>
                <li id="menu7"><a href="../Reports/MonthlySRReportMainPage.aspx"><span>Monthly S.R. Report</span></a></li>
                <li id="menu8"><a href="../Reports/MonthlyChallanReportMainPage.aspx"><span>Monthly Challan Report</span></a></li>
                <li id="menu9"><a href="../Reports/GatePassMainPage.aspx"><span>Gate Pass</span></a></li>
		       <%-- <li id="menu7"><a href=""><span></span>aman</a></li>--%>
		        <%-- <li id="menu8"><a href=""><span>Form 8</span></a></li>
                <li id="menu9"><a href=""><span>Form 9</span></a></li>--%>
		        </ul>
	        </div>
    <div id="nav_menu2">
		        <ul>	      
		        <li id="menu1"><a href="../Reports/RptExpenditureMainPage.aspx"><span>220KV/66KV Estimate</span></a></li>
                <li id="menu2"><a href="../ReportManagement/MgtMatAbstract.aspx"><span>Abstarct Material wise</span></a></li>
                <li id="menu3"><a href="../Reports/MatAbstarctMainPage.aspx"><span>Abstarct Group Head</span></a></li>		        
		        <li id="menu4"><a href=""><span>....</span></a></li>
		        <li id="menu5"><a href=""><span>....</span></a></li>
		        <li id="menu6"><a href=""><span>....</span></a></li>
<%--		        <li id="menu7"><a href=""><span>Form 7</span></a></li>
		        <li id="menu8"><a href=""><span>Form 8</span></a></li>
		        <li id="menu9"><a href=""><span>Form 9</span></a></li>
               <%-- %><li id="Li1"><a href="..\HTML\DefaultHP.aspx?page='LastPay.pdf'"><span>Last Pay Certificate</span></a></li> --%>
               </ul>
                		       
	        </div>
	        <font size="3" color="#b3a386"><strong>INVENTORY MANAGEMENT SYSTEM</strong></font>                   
        </div>
        
        <%--</span>--%>

</asp:Content>



