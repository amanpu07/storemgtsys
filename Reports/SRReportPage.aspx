<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="SRReportPage.aspx.cs" Inherits="Reports_SRReportPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="560px" Width="1083px">
        <LocalReport ReportPath="RDLC2008\StoreSR.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                    Name="ReportDataSet_stockissuetable" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                    Name="ReportDataSet_SRReport" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        DeleteMethod="Delete" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.SRReportTableAdapter">
        <DeleteParameters>
            <asp:Parameter Name="Original_itxno" Type="Decimal" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="srchallanbookno" QueryStringField="bookno" 
                Type="String" />
            <asp:QueryStringParameter Name="srchallanpageno" QueryStringField="pageno" 
                Type="String" />
            <asp:QueryStringParameter Name="istore" QueryStringField="store" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.stockissuetableTableAdapter">
    </asp:ObjectDataSource>
</asp:Content>

