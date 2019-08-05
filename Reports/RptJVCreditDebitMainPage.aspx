<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="RptJVCreditDebitMainPage.aspx.cs" Inherits="Reports_RptJVCreditDebitMainPage" %>


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
                      style="border: thin solid #C0C0C0; text-align: left;">JV Credit/Debit</td>
                  </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                    
                    Select JV type </td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:DropDownList ID="ddjv" runat="server" Width="119px">
                         <asp:ListItem Selected="True">....</asp:ListItem>
                         <asp:ListItem Value="1">JV-Credit</asp:ListItem>
                         <asp:ListItem Value="2">JV-Debit</asp:ListItem>
                     </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Page No." 
                        ForeColor="#FF0066" ControlToValidate="txtjvno">*</asp:RequiredFieldValidator>
                    &nbsp;JV No.</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txtjvno" runat="server" CssClass="combotext" 
                        AutoPostBack="False" Width="119px"></asp:TextBox></td>     
                

            </tr>
    
            
            <tr class="tableinnertext" id="Tr10" runat="server"> 
                    <td style="border: thin solid #C0C0C0; height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left">
                        Store</td>
                    <td colspan="5" style="border: thin solid #C0C0C0; text-align: left"> 
                            <asp:TextBox ID="txtstore" runat="server" style="width: 394px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox>

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

