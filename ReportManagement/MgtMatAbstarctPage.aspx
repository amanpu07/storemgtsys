<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="MgtMatAbstarctPage.aspx.cs" Inherits="Reports_MgtMatAbstarctPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="729px" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="750px">
        <LocalReport ReportPath="RDLC\MaterialwiseAbstract.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="AblowaldatasetTableAdapters.abstractmaterialwiseTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="iitemtype" Type="String" />
            <asp:Parameter DefaultValue="S and T (T) Store, TLSC, Ablowal, Patiala" 
                Name="istorename" Type="String" />
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

