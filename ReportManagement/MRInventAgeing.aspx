<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="MRInventAgeing.aspx.cs" Inherits="ReportManagement_MRInventAgeing" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="542px" Width="743px">
        <LocalReport ReportPath="RDLC2008\MRAgeing.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="MRReports_MRInventAgeing" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="MRReportsTableAdapters.MRInventAgeingTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="storename" Type="String" />
            <asp:QueryStringParameter Name="datestore" QueryStringField="from" 
                Type="DateTime" />
            <asp:Parameter Name="opnrecpt" Type="Decimal" />
            <asp:Parameter Name="opnissued" Type="Decimal" />
            <asp:Parameter Name="recd3" Type="Decimal" />
            <asp:Parameter Name="issued3" Type="Decimal" />
            <asp:Parameter Name="recd6" Type="Decimal" />
            <asp:Parameter Name="issued6" Type="Decimal" />
            <asp:Parameter Name="recd12" Type="Decimal" />
            <asp:Parameter Name="issued12" Type="Decimal" />
            <asp:Parameter Name="recdyear" Type="Decimal" />
            <asp:Parameter Name="issuedyear" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

