<%@ Page Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="ChallanMonthlyReport.aspx.cs" Inherits="Reports_ChallanMonthlyReport" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="501px" Width="750px">
        <LocalReport ReportPath="RDLC2008\MonthlyChallan.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                    Name="ReportDataSet_ChallanMonthlyReport" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                    Name="grsrchalmonthly_ChallanMonthlyReportnew" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="grsrchalmonthlyTableAdapters.ChallanMonthlyReportnewTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="from" QueryStringField="from" Type="DateTime" />
            <asp:QueryStringParameter Name="to" QueryStringField="to" Type="DateTime" />
            <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.ChallanMonthlyReportTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="from" QueryStringField="from" Type="DateTime" />
            <asp:QueryStringParameter Name="to" QueryStringField="to" Type="DateTime" />
            <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

