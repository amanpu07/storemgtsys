<%@ Page Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="AbstractIssue.aspx.cs" Inherits="Reports_AbstractIssue" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="771px" Width="750px">
        <LocalReport ReportPath="RDLC2008\AbstractIssued.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="Ablowaldataset_MainAbstractIssue" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="AblowaldatasetTableAdapters.MainAbstractIssueTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="from" QueryStringField="from" Type="String" />
            <asp:QueryStringParameter Name="to" QueryStringField="to" Type="String" />
            <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

