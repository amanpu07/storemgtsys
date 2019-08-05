<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="RptReceivedFirm.aspx.cs" Inherits="Reports_RptReceivedFirm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="501px" Width="745px">
        <LocalReport ReportPath="RDLC2008\firmmnthlyrecd.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="monthlyrecdissued_mnthlyfirmrecd" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="monthlyrecdissued_monthlyrecdfirm" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetData" 
        TypeName="monthlyrecdissuedTableAdapters.monthlyrecdfirmTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="monthlyrecdissuedTableAdapters.monthlyrecdfirmTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="from" QueryStringField="from" Type="DateTime" />
            <asp:QueryStringParameter Name="to" QueryStringField="to" Type="DateTime" />
            <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
            <asp:QueryStringParameter Name="status" QueryStringField="type" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


