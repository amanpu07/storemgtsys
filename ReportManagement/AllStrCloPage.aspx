<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="AllStrCloPage.aspx.cs" Inherits="ReportManagement_AllStrCloPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="400px" Width="748px">
        <LocalReport ReportPath="RDLC2008\AllStrCloBal.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="AllStrCloBal_procClosingBalanceAllStore" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="AllStrCloBalTableAdapters.procClosingBalanceAllStoreTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="iclosingdate" QueryStringField="fromdate" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="iitemtype" QueryStringField="itemtype" 
                Type="String" />
            <asp:QueryStringParameter Name="iitemname" QueryStringField="itemname" 
                Type="String" />
            <asp:Parameter Name="iunit" Type="String" />
            <asp:Parameter Name="iclobalQtystore1" Type="Decimal" />
            <asp:Parameter Name="iclobalQtystore2" Type="Decimal" />
            <asp:Parameter Name="iclobalQtystore3" Type="Decimal" />
            <asp:Parameter Name="iclobalQtystore4" Type="Decimal" />
            <asp:Parameter Name="iclobalQtystore5" Type="Decimal" />
            <asp:Parameter Name="iclobalQtystore6" Type="Decimal" />
            <asp:Parameter Name="iclobalQtystore7" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore1" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore2" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore3" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore4" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore5" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore6" Type="Decimal" />
            <asp:Parameter Name="iclobalValuestore7" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt1" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt2" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt3" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt4" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt5" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt6" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyreceipt7" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued1" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued2" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued3" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued4" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued5" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued6" Type="Decimal" />
            <asp:Parameter Name="iclobalQtyissued7" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt1" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt2" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt3" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt4" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt5" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt6" Type="Decimal" />
            <asp:Parameter Name="iclobalValuereceipt7" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued1" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued2" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued3" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued4" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued5" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued6" Type="Decimal" />
            <asp:Parameter Name="icolbalValueissued7" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty1" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty2" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty3" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty4" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty5" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty6" Type="Decimal" />
            <asp:Parameter Name="itotalclosingQty7" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue1" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue2" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue3" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue4" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue5" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue6" Type="Decimal" />
            <asp:Parameter Name="itotalclosingValue7" Type="Decimal" />
            <asp:Parameter Name="gdcond" Type="String" />
            <asp:Parameter Name="imake" Type="String" />
            <asp:Parameter Name="kunit" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

