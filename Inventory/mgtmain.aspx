<%@ Page Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="mgtmain.aspx.cs" Inherits="Inventory_mgtmain" Title="Untitled Page" %>

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
                      style="border: thin solid #C0C0C0; text-align: left;">Closing Balance Sheet</td>
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
                    &nbsp;&nbsp; Date&nbsp;</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txtfromdate" runat="server" Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="119px"></asp:TextBox>&nbsp;dd-mm-yyyy</td>
            </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Select Store" 
                        ForeColor="#FF0066" ControlToValidate="ddstore" InitialValue="0">*</asp:RequiredFieldValidator>
                    &nbsp;Select Store&nbsp;</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:DropDownList ID="ddstore" runat="server" Height="20px" Width="400px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                                       <%-- <asp:ListItem Value="1">Store-Ablowal+Jamsher</asp:ListItem>
                                        <asp:ListItem Value="2">Store-Moga+Jalandhar</asp:ListItem>--%>
                                          <asp:ListItem Value="1">AEE STORE PSTCL ABLOWAL</asp:ListItem>
                                        <asp:ListItem Value="2">AEE STORE PSTCL JAMSHER</asp:ListItem>
                                         <asp:ListItem Value="3">AEE STORE PSTCL SAHNEWAL</asp:ListItem>
                                         <asp:ListItem Value="4">AEE STORE PSTCL MOGA</asp:ListItem>
                                        <asp:ListItem Value="5">AEE CO&C STORE PSTCL LUDHIANA</asp:ListItem>
                                       
                    </asp:DropDownList></td>
            </tr>
            <%--<tr class="tableinnertext" id="Tr10" runat="server"> 
                    <td style="border: thin solid #C0C0C0; height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left">
                        Store</td>
                    <td colspan="5" style="border: thin solid #C0C0C0; text-align: left"> 
                            <asp:TextBox ID="txtstore" runat="server" style="width: 394px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox>

                    </td>
                </tr>--%>
                <tr>
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





