<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Management.master" AutoEventWireup="true" CodeFile="AllStrCloMainPage.aspx.cs" Inherits="ReportManagement_AllStrCloMainPage" %>

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
                    &nbsp;&nbsp;
                    Item Type</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:DropDownList ID="dditemtype" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype_SelectedIndexChanged" 
                            Width="400px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   &nbsp;&nbsp;
                    &nbsp; Item Name</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                    <asp:DropDownList ID="dditemname" runat="server" Height="23px" Width="400px" 
                            AppendDataBoundItems="False" 
                            onselectedindexchanged="dditemname_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
            </tr>
           <%-- <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls Select Store" 
                        ForeColor="#FF0066" ControlToValidate="ddstore" InitialValue="0">*</asp:RequiredFieldValidator>
                    &nbsp;Select Store&nbsp;</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:DropDownList ID="ddstore" runat="server" Height="20px" Width="200px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                                        <asp:ListItem Value="1">Store-Ablowal+Jamsher</asp:ListItem>
                                        <asp:ListItem Value="2">Store-Moga+Jalandhar</asp:ListItem>
                                        <asp:ListItem Value="3">Store-Sahnewal</asp:ListItem>
                                        <asp:ListItem Value="4">Store-Ludhiana</asp:ListItem>
                                         <asp:ListItem Value="5">Store-Jalandhar(Civil)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>--%>
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




