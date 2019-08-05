<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="RptDebit.aspx.cs" Inherits="Reports_RptDebit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="400px" Width="746px">
        <LocalReport ReportPath="RDLC2008\JVDebit.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                    Name="storenewrpt_RptJVCredit" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                    Name="storenewrpt_RptJVDebit" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="storenewrptTableAdapters.RptJVDebitTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="storename" QueryStringField="store" 
                Type="String" />
            <asp:QueryStringParameter Name="voucherno" QueryStringField="jvno" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetData" 
        TypeName="storenewrptTableAdapters.RptJVCreditTableAdapter">
    </asp:ObjectDataSource>
</asp:Content>

