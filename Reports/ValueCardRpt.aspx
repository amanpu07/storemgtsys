<%@ Page Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="ValueCardRpt.aspx.cs" Inherits="Reports_ValueCardRpt" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="400px" Width="643px">
        <LocalReport ReportPath="RDLC2008\CardValue.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="ReportDataSet_ValuecardProc" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.ValuecardProcTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="istockdate" Type="DateTime" />
            <asp:Parameter DbType="Time" Name="iitime" />
            <asp:QueryStringParameter Name="iitemcode" QueryStringField="itemcode" 
                Type="String" />
            <asp:Parameter Name="iitemtype" Type="String" />
            <asp:Parameter Name="iitemname" Type="String" />
            <asp:Parameter Name="iunit" Type="String" />
            <asp:Parameter Name="ireceived_issued" Type="String" />
            <asp:Parameter Name="ifirstrefno" Type="String" />
            <asp:Parameter Name="ismonth" Type="String" />
            <asp:Parameter Name="ibookno" Type="String" />
            <asp:Parameter Name="ipageno" Type="String" />
            <asp:Parameter Name="iqtyaccepted" Type="Decimal" />
            <asp:Parameter Name="isrissuedqty" Type="Decimal" />
            <asp:Parameter Name="ibalanceqty" Type="Decimal" />
            <asp:Parameter Name="iireceiptvalue" Type="Decimal" />
            <asp:Parameter Name="iiissuedvalue" Type="Decimal" />
            <asp:Parameter Name="iibalancevalue" Type="Decimal" />
            <asp:Parameter Name="igoodstype" Type="String" />
            <asp:Parameter Name="iremarks" Type="String" />
            <asp:Parameter Name="tempRecqty" Type="Decimal" />
            <asp:Parameter Name="tempissuedqty" Type="Decimal" />
            <asp:Parameter Name="tempbalqty" Type="Decimal" />
            <asp:Parameter Name="tempReceiptvalue" Type="Decimal" />
            <asp:Parameter Name="tempIssuedValue" Type="Decimal" />
            <asp:Parameter Name="tempbalValue" Type="Decimal" />
            <asp:Parameter Name="itransactionno" Type="Decimal" />
            <asp:Parameter Name="ireceiptvalue" Type="String" />
            <asp:Parameter Name="issuedvalue" Type="String" />
            <asp:QueryStringParameter Name="istorename" QueryStringField="store" 
                Type="String" />
            <asp:QueryStringParameter Name="goodstatus" QueryStringField="status" 
                Type="String" />
            <asp:Parameter Name="tempdatetime" Type="DateTime" />
            <asp:QueryStringParameter Name="istockdatefrom" QueryStringField="from" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="istockdateto" QueryStringField="to" 
                Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>




