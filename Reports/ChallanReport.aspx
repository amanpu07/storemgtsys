<%@ Page Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="ChallanReport.aspx.cs" Inherits="Reports_ChallanReport" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="805px" Width="750px">
        <LocalReport ReportPath="RDLC2008\StoreChallan.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="ReportDataSet_stockissuetable" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetData" 
        TypeName="ReportDataSetTableAdapters.stockissuetableTableAdapter" 
        DeleteMethod="Delete" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_itxno" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="issuetype" Type="String" />
            <asp:Parameter Name="istore" Type="String" />
            <asp:Parameter Name="imonth" Type="String" />
            <asp:Parameter Name="iyear" Type="String" />
            <asp:Parameter Name="icurdate" Type="DateTime" />
            <asp:Parameter Name="srchallanbookno" Type="String" />
            <asp:Parameter Name="srchallanpageno" Type="String" />
            <asp:Parameter DbType="Time" Name="srchtime" />
            <asp:Parameter Name="srchallandate" Type="DateTime" />
            <asp:Parameter Name="indentorgncode" Type="String" />
            <asp:Parameter Name="allocationno" Type="String" />
            <asp:Parameter Name="storeissueno" Type="String" />
            <asp:Parameter Name="category" Type="String" />
            <asp:Parameter Name="projectcode" Type="String" />
            <asp:Parameter Name="estimateno" Type="String" />
            <asp:Parameter Name="nameofsubdivision" Type="String" />
            <asp:Parameter Name="nameofdivision" Type="String" />
            <asp:Parameter Name="nameofwork" Type="String" />
            <asp:Parameter Name="contractorname" Type="String" />
            <asp:Parameter Name="cminno" Type="String" />
            <asp:Parameter Name="cmindate" Type="String" />
            <asp:Parameter Name="typeofwork" Type="String" />
            <asp:Parameter Name="nameofestimate" Type="String" />
            <asp:Parameter Name="suballocationno" Type="String" />
            <asp:Parameter Name="stockitemyype" Type="String" />
            <asp:Parameter Name="stockitemcode" Type="String" />
            <asp:Parameter Name="stockitemname" Type="String" />
            <asp:Parameter Name="goodstype" Type="String" />
            <asp:Parameter Name="firm" Type="String" />
            <asp:Parameter Name="unit" Type="String" />
            <asp:Parameter Name="unitcode" Type="String" />
            <asp:Parameter Name="totalqtyestimate" Type="Decimal" />
            <asp:Parameter Name="qtydrawntilldate" Type="Decimal" />
            <asp:Parameter Name="qtyindented" Type="Decimal" />
            <asp:Parameter Name="issuedqty" Type="Decimal" />
            <asp:Parameter Name="qtyvalue" Type="Decimal" />
            <asp:Parameter Name="storagecharges" Type="Decimal" />
            <asp:Parameter Name="totalvalue" Type="Decimal" />
            <asp:Parameter Name="grandtotal" Type="Decimal" />
            <asp:Parameter Name="itemrecdempcode" Type="String" />
            <asp:Parameter Name="recdempname" Type="String" />
            <asp:Parameter Name="recdsdoname" Type="String" />
            <asp:Parameter Name="issueofficername" Type="String" />
            <asp:Parameter Name="designation" Type="String" />
            <asp:Parameter Name="issuedate" Type="String" />
            <asp:Parameter Name="ipono" Type="String" />
            <asp:Parameter Name="ipodate" Type="String" />
            <asp:Parameter Name="storename" Type="String" />
            <asp:Parameter Name="storelocationcode" Type="String" />
            <asp:Parameter Name="saono" Type="String" />
            <asp:Parameter Name="saodate" Type="String" />
            <asp:Parameter Name="nameofemptransfer" Type="String" />
            <asp:Parameter Name="transtorelocationcode" Type="String" />
            <asp:Parameter Name="transtorename" Type="String" />
            <asp:Parameter Name="storeindentno" Type="String" />
            <asp:Parameter Name="storeindentdate" Type="String" />
            <asp:Parameter Name="vehicleno" Type="String" />
            <asp:Parameter Name="noofbundle" Type="String" />
            <asp:Parameter Name="biltino" Type="String" />
            <asp:Parameter Name="interunittransfer" Type="String" />
            <asp:Parameter Name="billno" Type="String" />
            <asp:Parameter Name="drivername" Type="String" />
            <asp:Parameter Name="weightt" Type="String" />
            <asp:Parameter Name="storechargepercentage" Type="Decimal" />
            <asp:Parameter Name="recdqty" Type="Decimal" />
            <asp:Parameter Name="acceptedqty" Type="Decimal" />
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="entryno" Type="String" />
            <asp:Parameter Name="entrydate" Type="String" />
            <asp:Parameter Name="refno" Type="String" />
            <asp:Parameter Name="userrole" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="ifield2" Type="String" />
            <asp:Parameter Name="ifield3" Type="String" />
            <asp:Parameter Name="ifield4" Type="Decimal" />
            <asp:Parameter Name="ifield5" Type="Decimal" />
            <asp:Parameter Name="ifield6" Type="Decimal" />
            <asp:Parameter Name="ifield7" Type="Int32" />
            <asp:Parameter Name="ifield8" Type="Int32" />
            <asp:Parameter Name="ifield9" Type="Int32" />
            <asp:Parameter Name="stockstatus" Type="String" />
            <asp:Parameter Name="grouphead" Type="String" />
            <asp:Parameter Name="voucherno" Type="String" />
            <asp:Parameter Name="voucherdate" Type="String" />
            <asp:Parameter Name="Original_itxno" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="srchallanbookno" QueryStringField="bookno" 
                Type="String" />
            <asp:QueryStringParameter Name="srchallanpageno" QueryStringField="pageno" 
                Type="String" />
            <asp:QueryStringParameter Name="istore" QueryStringField="store" 
                Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="issuetype" Type="String" />
            <asp:Parameter Name="istore" Type="String" />
            <asp:Parameter Name="imonth" Type="String" />
            <asp:Parameter Name="iyear" Type="String" />
            <asp:Parameter Name="icurdate" Type="DateTime" />
            <asp:Parameter Name="srchallanbookno" Type="String" />
            <asp:Parameter Name="srchallanpageno" Type="String" />
            <asp:Parameter DbType="Time" Name="srchtime" />
            <asp:Parameter Name="srchallandate" Type="DateTime" />
            <asp:Parameter Name="indentorgncode" Type="String" />
            <asp:Parameter Name="allocationno" Type="String" />
            <asp:Parameter Name="storeissueno" Type="String" />
            <asp:Parameter Name="category" Type="String" />
            <asp:Parameter Name="projectcode" Type="String" />
            <asp:Parameter Name="estimateno" Type="String" />
            <asp:Parameter Name="nameofsubdivision" Type="String" />
            <asp:Parameter Name="nameofdivision" Type="String" />
            <asp:Parameter Name="nameofwork" Type="String" />
            <asp:Parameter Name="contractorname" Type="String" />
            <asp:Parameter Name="cminno" Type="String" />
            <asp:Parameter Name="cmindate" Type="String" />
            <asp:Parameter Name="typeofwork" Type="String" />
            <asp:Parameter Name="nameofestimate" Type="String" />
            <asp:Parameter Name="suballocationno" Type="String" />
            <asp:Parameter Name="stockitemyype" Type="String" />
            <asp:Parameter Name="stockitemcode" Type="String" />
            <asp:Parameter Name="stockitemname" Type="String" />
            <asp:Parameter Name="goodstype" Type="String" />
            <asp:Parameter Name="firm" Type="String" />
            <asp:Parameter Name="unit" Type="String" />
            <asp:Parameter Name="unitcode" Type="String" />
            <asp:Parameter Name="totalqtyestimate" Type="Decimal" />
            <asp:Parameter Name="qtydrawntilldate" Type="Decimal" />
            <asp:Parameter Name="qtyindented" Type="Decimal" />
            <asp:Parameter Name="issuedqty" Type="Decimal" />
            <asp:Parameter Name="qtyvalue" Type="Decimal" />
            <asp:Parameter Name="storagecharges" Type="Decimal" />
            <asp:Parameter Name="totalvalue" Type="Decimal" />
            <asp:Parameter Name="grandtotal" Type="Decimal" />
            <asp:Parameter Name="itemrecdempcode" Type="String" />
            <asp:Parameter Name="recdempname" Type="String" />
            <asp:Parameter Name="recdsdoname" Type="String" />
            <asp:Parameter Name="issueofficername" Type="String" />
            <asp:Parameter Name="designation" Type="String" />
            <asp:Parameter Name="issuedate" Type="String" />
            <asp:Parameter Name="ipono" Type="String" />
            <asp:Parameter Name="ipodate" Type="String" />
            <asp:Parameter Name="storename" Type="String" />
            <asp:Parameter Name="storelocationcode" Type="String" />
            <asp:Parameter Name="saono" Type="String" />
            <asp:Parameter Name="saodate" Type="String" />
            <asp:Parameter Name="nameofemptransfer" Type="String" />
            <asp:Parameter Name="transtorelocationcode" Type="String" />
            <asp:Parameter Name="transtorename" Type="String" />
            <asp:Parameter Name="storeindentno" Type="String" />
            <asp:Parameter Name="storeindentdate" Type="String" />
            <asp:Parameter Name="vehicleno" Type="String" />
            <asp:Parameter Name="noofbundle" Type="String" />
            <asp:Parameter Name="biltino" Type="String" />
            <asp:Parameter Name="interunittransfer" Type="String" />
            <asp:Parameter Name="billno" Type="String" />
            <asp:Parameter Name="drivername" Type="String" />
            <asp:Parameter Name="weightt" Type="String" />
            <asp:Parameter Name="storechargepercentage" Type="Decimal" />
            <asp:Parameter Name="recdqty" Type="Decimal" />
            <asp:Parameter Name="acceptedqty" Type="Decimal" />
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="entryno" Type="String" />
            <asp:Parameter Name="entrydate" Type="String" />
            <asp:Parameter Name="refno" Type="String" />
            <asp:Parameter Name="userrole" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="ifield2" Type="String" />
            <asp:Parameter Name="ifield3" Type="String" />
            <asp:Parameter Name="ifield4" Type="Decimal" />
            <asp:Parameter Name="ifield5" Type="Decimal" />
            <asp:Parameter Name="ifield6" Type="Decimal" />
            <asp:Parameter Name="ifield7" Type="Int32" />
            <asp:Parameter Name="ifield8" Type="Int32" />
            <asp:Parameter Name="ifield9" Type="Int32" />
            <asp:Parameter Name="stockstatus" Type="String" />
            <asp:Parameter Name="grouphead" Type="String" />
            <asp:Parameter Name="voucherno" Type="String" />
            <asp:Parameter Name="voucherdate" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>

