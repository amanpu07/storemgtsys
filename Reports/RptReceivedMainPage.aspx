<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="RptReceivedMainPage.aspx.cs" Inherits="Reports_RptReceivedMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">

    function DoWaterMarkOnFocus(txt, text) {

        if (txt.value == text) {

            txt.value = "";

        }

    }

    function DoWaterMarkOnBlur(txt, text) {

        if (txt.value == "") {

            txt.value = text;

        }

    }
  </script>

<div align="center">
 
    
        <table style="width: 100%; border-style: solid; border-width: 1px">
         <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="6" 
                      style="border: thin solid #C0C0C0; text-align: left;">Receipt during Month</td>
                  </tr>
                   <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                    &nbsp;<asp:CompareValidator 
                        ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtfromdate" ErrorMessage="Enter Date" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>&nbsp;
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter From Date" 
                        ForeColor="#FF0066" ControlToValidate="txtfromdate">*</asp:RequiredFieldValidator>
                    &nbsp;From Date</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txtfromdate" runat="server" Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="119px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                     &nbsp;<asp:CompareValidator 
                        ID="CompareValidator2" runat="server" 
                        ControlToValidate="txttodate" ErrorMessage="Enter Date" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>&nbsp;
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter to Date" 
                        ForeColor="#FF0066" ControlToValidate="txttodate">*</asp:RequiredFieldValidator>
                    &nbsp;To Date</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txttodate" runat="server" Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="119px"></asp:TextBox></td>
            </tr>
           
            
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   &nbsp;&nbsp; &nbsp; Source</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                    <asp:DropDownList ID="ddstatustype" runat="server" Height="20px" Width="400px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                                         <asp:ListItem  Value="Firm">Firm</asp:ListItem>
                        <asp:ListItem Value="Work">Work</asp:ListItem>
                        <asp:ListItem Value="Other Store">Other Store</asp:ListItem>  
                    </asp:DropDownList></td>
            </tr>
            <tr class="tableinnertext" id="Tr10" runat="server"> 
                    <td style="border: thin solid #C0C0C0; height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left">
                        Store</td>
                    <td colspan="5" style="border: thin solid #C0C0C0; text-align: left"> 
                            <asp:TextBox ID="txtstore" runat="server" style="width: 400px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox>

                    </td>
                </tr><tr>
                <td style="border: thin solid #C0C0C0">
                    &nbsp;</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                   <asp:Button ID="btnproceed" runat="server" CssClass="btn" OnClick="btnproceed_Click" 
                Text= "Proceed" Width="100px" /></td>
            </tr>
            <tr><td colspan="6">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                </td></tr>
        </table>
 
    
        </div>
</asp:Content>


