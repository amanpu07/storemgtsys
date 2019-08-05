<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="GatePassMainPage.aspx.cs" Inherits="Reports_GatePassMainPage" %>

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
                      style="border: thin solid #C0C0C0; text-align: left;">Gate Pass</td>
                  </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                    
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Book No." 
                        ForeColor="#FF0066" ControlToValidate="txtbookno">*</asp:RequiredFieldValidator>
                    &nbsp;Book No.</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txtbookno" runat="server" CssClass="combotext" 
                        AutoPostBack="False" Width="119px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Page No." 
                        ForeColor="#FF0066" ControlToValidate="txtpageno">*</asp:RequiredFieldValidator>
                    &nbsp;Page No.</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txtpageno" runat="server" CssClass="combotext" 
                        AutoPostBack="False" Width="119px"></asp:TextBox></td>     
                

            </tr>
            <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   
                    &nbsp; <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtdate" ErrorMessage="Enter Only Date Format" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                 &nbsp;
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Date" 
                        ForeColor="#FF0066" ControlToValidate="txtdate">*</asp:RequiredFieldValidator>
                    &nbsp;Date</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                     <asp:TextBox ID="txtdate" runat="server" Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="119px"></asp:TextBox></td>

                        
                

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

