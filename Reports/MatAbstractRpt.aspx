<%@ Page Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="MatAbstractRpt.aspx.cs" Inherits="Reports_MatAbstractRpt" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="690px" Width="750px">
        <LocalReport ReportPath="RDLC2008\MaterialAbstract.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="Ablowaldataset_abstractmaterialwise" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="AblowaldatasetTableAdapters.abstractmaterialwiseTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="iitemtype" Type="String" />
            <asp:QueryStringParameter Name="istorename" QueryStringField="store" 
                Type="String" />
            <asp:QueryStringParameter Name="ifrom" QueryStringField="from" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="ito" QueryStringField="to" Type="DateTime" />
            <asp:Parameter Name="iopnbalrecpt" Type="Decimal" />
            <asp:Parameter Name="iopnbalissued" Type="Decimal" />
            <asp:Parameter Name="irecptdurmonth" Type="Decimal" />
            <asp:Parameter Name="iissuedurmonthsr" Type="Decimal" />
            <asp:Parameter Name="iissuedurmonthchallan" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

