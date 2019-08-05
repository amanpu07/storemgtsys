<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="RptCredit.aspx.cs" Inherits="Reports_RptCredit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="400px" Width="747px">
        <LocalReport ReportPath="RDLC2008\JVCredit.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="storenewrpt_RptJVCredit" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="storenewrptTableAdapters.RptJVCreditTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="storename" QueryStringField="store" 
                Type="String" />
            <asp:QueryStringParameter Name="voucherno" QueryStringField="jvno" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

