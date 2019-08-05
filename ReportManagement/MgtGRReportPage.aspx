<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="MgtGRReportPage.aspx.cs" Inherits="ReportManagement_MgtGRReportPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="726px">
        <LocalReport ReportPath="RDLC\GR.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.stockreceipttableTableAdapter" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_rtxno" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="scurdate" Type="DateTime" />
            <asp:Parameter Name="storename" Type="String" />
            <asp:Parameter Name="grbookno" Type="Decimal" />
            <asp:Parameter Name="grpageno" Type="Decimal" />
            <asp:Parameter Name="grdate" Type="DateTime" />
            <asp:Parameter DbType="Time" Name="grtime" />
            <asp:Parameter Name="typeofwork" Type="String" />
            <asp:Parameter Name="stockstatus" Type="String" />
            <asp:Parameter Name="field1" Type="String" />
            <asp:Parameter Name="goodstype" Type="String" />
            <asp:Parameter Name="stockrecddate" Type="String" />
            <asp:Parameter Name="stockinspectdate" Type="String" />
            <asp:Parameter Name="storechallanno" Type="String" />
            <asp:Parameter Name="srwchallanDate" Type="String" />
            <asp:Parameter Name="pono" Type="String" />
            <asp:Parameter Name="podate" Type="String" />
            <asp:Parameter Name="itemno" Type="Decimal" />
            <asp:Parameter Name="itype" Type="String" />
            <asp:Parameter Name="itemcode" Type="String" />
            <asp:Parameter Name="itemname" Type="String" />
            <asp:Parameter Name="make" Type="String" />
            <asp:Parameter Name="unit" Type="String" />
            <asp:Parameter Name="qtyrecd" Type="Decimal" />
            <asp:Parameter Name="qtyaccepted" Type="Decimal" />
            <asp:Parameter Name="rate" Type="Decimal" />
            <asp:Parameter Name="subtotal" Type="Decimal" />
            <asp:Parameter Name="edpercentage" Type="Decimal" />
            <asp:Parameter Name="cesspercentage" Type="Decimal" />
            <asp:Parameter Name="highereducesspercentage" Type="Decimal" />
            <asp:Parameter Name="total" Type="Decimal" />
            <asp:Parameter Name="cstvatpercentage" Type="Decimal" />
            <asp:Parameter Name="freight" Type="Decimal" />
            <asp:Parameter Name="grandtotal" Type="Decimal" />
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="smonth" Type="String" />
            <asp:Parameter Name="syear" Type="String" />
            <asp:Parameter Name="storelocationcode" Type="String" />
            <asp:Parameter Name="subdivision" Type="String" />
            <asp:Parameter Name="divisionreturnchange" Type="String" />
            <asp:Parameter Name="locationcode" Type="String" />
            <asp:Parameter Name="estimateno" Type="String" />
            <asp:Parameter Name="nameofwork" Type="String" />
            <asp:Parameter Name="scrap" Type="String" />
            <asp:Parameter Name="scrapcodeno" Type="String" />
            <asp:Parameter Name="insurance" Type="Decimal" />
            <asp:Parameter Name="stockrole" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="field2" Type="String" />
            <asp:Parameter Name="field3" Type="String" />
            <asp:Parameter Name="field4" Type="Decimal" />
            <asp:Parameter Name="field5" Type="Decimal" />
            <asp:Parameter Name="field6" Type="Decimal" />
            <asp:Parameter Name="field7" Type="Decimal" />
            <asp:Parameter Name="field8" Type="Decimal" />
            <asp:Parameter Name="field9" Type="Decimal" />
            <asp:Parameter Name="voucherno" Type="String" />
            <asp:Parameter Name="voucherdate" Type="String" />
            <asp:Parameter Name="grouphead" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="grbookno" QueryStringField="bookno" 
                Type="Decimal" />
            <asp:QueryStringParameter Name="grpageno" QueryStringField="pageno" 
                Type="Decimal" />
            <asp:QueryStringParameter Name="store" QueryStringField="store" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="scurdate" Type="DateTime" />
            <asp:Parameter Name="storename" Type="String" />
            <asp:Parameter Name="grbookno" Type="Decimal" />
            <asp:Parameter Name="grpageno" Type="Decimal" />
            <asp:Parameter Name="grdate" Type="DateTime" />
            <asp:Parameter DbType="Time" Name="grtime" />
            <asp:Parameter Name="typeofwork" Type="String" />
            <asp:Parameter Name="stockstatus" Type="String" />
            <asp:Parameter Name="field1" Type="String" />
            <asp:Parameter Name="goodstype" Type="String" />
            <asp:Parameter Name="stockrecddate" Type="String" />
            <asp:Parameter Name="stockinspectdate" Type="String" />
            <asp:Parameter Name="storechallanno" Type="String" />
            <asp:Parameter Name="srwchallanDate" Type="String" />
            <asp:Parameter Name="pono" Type="String" />
            <asp:Parameter Name="podate" Type="String" />
            <asp:Parameter Name="itemno" Type="Decimal" />
            <asp:Parameter Name="itype" Type="String" />
            <asp:Parameter Name="itemcode" Type="String" />
            <asp:Parameter Name="itemname" Type="String" />
            <asp:Parameter Name="make" Type="String" />
            <asp:Parameter Name="unit" Type="String" />
            <asp:Parameter Name="qtyrecd" Type="Decimal" />
            <asp:Parameter Name="qtyaccepted" Type="Decimal" />
            <asp:Parameter Name="rate" Type="Decimal" />
            <asp:Parameter Name="subtotal" Type="Decimal" />
            <asp:Parameter Name="edpercentage" Type="Decimal" />
            <asp:Parameter Name="cesspercentage" Type="Decimal" />
            <asp:Parameter Name="highereducesspercentage" Type="Decimal" />
            <asp:Parameter Name="total" Type="Decimal" />
            <asp:Parameter Name="cstvatpercentage" Type="Decimal" />
            <asp:Parameter Name="freight" Type="Decimal" />
            <asp:Parameter Name="grandtotal" Type="Decimal" />
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="smonth" Type="String" />
            <asp:Parameter Name="syear" Type="String" />
            <asp:Parameter Name="storelocationcode" Type="String" />
            <asp:Parameter Name="subdivision" Type="String" />
            <asp:Parameter Name="divisionreturnchange" Type="String" />
            <asp:Parameter Name="locationcode" Type="String" />
            <asp:Parameter Name="estimateno" Type="String" />
            <asp:Parameter Name="nameofwork" Type="String" />
            <asp:Parameter Name="scrap" Type="String" />
            <asp:Parameter Name="scrapcodeno" Type="String" />
            <asp:Parameter Name="insurance" Type="Decimal" />
            <asp:Parameter Name="stockrole" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="field2" Type="String" />
            <asp:Parameter Name="field3" Type="String" />
            <asp:Parameter Name="field4" Type="Decimal" />
            <asp:Parameter Name="field5" Type="Decimal" />
            <asp:Parameter Name="field6" Type="Decimal" />
            <asp:Parameter Name="field7" Type="Decimal" />
            <asp:Parameter Name="field8" Type="Decimal" />
            <asp:Parameter Name="field9" Type="Decimal" />
            <asp:Parameter Name="voucherno" Type="String" />
            <asp:Parameter Name="voucherdate" Type="String" />
            <asp:Parameter Name="grouphead" Type="String" />
            <asp:Parameter Name="Original_rtxno" Type="Decimal" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    </asp:Content>

