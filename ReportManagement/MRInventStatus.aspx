<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="MRInventStatus.aspx.cs" Inherits="ReportManagement_MRInventStatus" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer11" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="443px" Width="745px">
        <LocalReport ReportPath="RDLC2008\MRInventStatus.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="MRReports_MRInventStatus" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetData" 
        TypeName="MRReportsTableAdapters.MRInventStatusTableAdapter" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="storename" Type="String" />
            <asp:QueryStringParameter Name="datestore" QueryStringField="from" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="datestoreto" QueryStringField="to" 
                Type="DateTime" />
            <asp:Parameter Name="opnrecpt" Type="Decimal" />
            <asp:Parameter Name="opnissued" Type="Decimal" />
            <asp:Parameter Name="currecd" Type="Decimal" />
            <asp:Parameter Name="currissued" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

