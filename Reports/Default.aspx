<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Reports_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="339px" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="748px">
    <LocalReport ReportPath="Rdlc\Report.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:pstclinventoryConnectionString %>" 
    SelectCommand="gatepass" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:QueryStringParameter Name="scchbookno" QueryStringField="bookno" 
            Type="Int32" />
        <asp:QueryStringParameter Name="scchpageno" QueryStringField="pageno" 
            Type="Int32" />
        <asp:QueryStringParameter DbType="Date" Name="srchdate" 
            QueryStringField="date" />
        <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>


