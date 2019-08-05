<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="WorkwisRpt.aspx.cs" Inherits="Reports_WorkwisRpt" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="494px" Width="751px">
        <LocalReport ReportPath="RDLC2008\Workwise.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="AllStrCloBal_stockissuetable" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetData" 
        TypeName="AllStrCloBalTableAdapters.stockissuetableTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="istore" QueryStringField="store" 
                Type="String" />
            <asp:QueryStringParameter Name="nameofwork" QueryStringField="work" 
                Type="String" />
            <asp:QueryStringParameter Name="stockitemcode" QueryStringField="itemcode" 
                Type="String" />
            <asp:QueryStringParameter Name="srchallandatefrom" QueryStringField="from" 
                Type="String" />
            <asp:QueryStringParameter Name="srchallandateto" QueryStringField="to" 
                Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="srchallanbookno" Type="String" />
            <asp:Parameter Name="srchallanpageno" Type="String" />
            <asp:Parameter Name="srchallandate" Type="DateTime" />
            <asp:Parameter Name="estimateno" Type="String" />
            <asp:Parameter Name="nameofsubdivision" Type="String" />
            <asp:Parameter Name="nameofdivision" Type="String" />
            <asp:Parameter Name="nameofwork" Type="String" />
            <asp:Parameter Name="contractorname" Type="String" />
            <asp:Parameter Name="stockitemyype" Type="String" />
            <asp:Parameter Name="stockitemcode" Type="String" />
            <asp:Parameter Name="stockitemname" Type="String" />
            <asp:Parameter Name="goodstype" Type="String" />
            <asp:Parameter Name="firm" Type="String" />
            <asp:Parameter Name="unit" Type="String" />
            <asp:Parameter Name="issuedqty" Type="Decimal" />
            <asp:Parameter Name="qtyvalue" Type="Decimal" />
            <asp:Parameter Name="storagecharges" Type="Decimal" />
            <asp:Parameter Name="totalvalue" Type="Decimal" />
            <asp:Parameter Name="grandtotal" Type="Decimal" />
            <asp:Parameter Name="recdempname" Type="String" />
            <asp:Parameter Name="recdsdoname" Type="String" />
            <asp:Parameter Name="grouphead" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>

</asp:Content>

