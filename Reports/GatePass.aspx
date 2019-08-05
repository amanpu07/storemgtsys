<%@ Page Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="GatePass.aspx.cs" Inherits="Reports_GatePass" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="580px" Width="750px">
        <LocalReport ReportPath="RDLC2008\PassGate.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="ReportDataSet_gatepass" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.gatepassTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="scchbookno" QueryStringField="bookno" 
                Type="Int32" />
            <asp:QueryStringParameter Name="scchpageno" QueryStringField="pageno" 
                Type="Int32" />
            <asp:QueryStringParameter Name="srchdate" QueryStringField="date" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

