<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="ValueCardMainPage.aspx.cs" Inherits="Reports_ValueCardMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div align="center">
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

     //Function to create numeric text box only - using keycodes
     function AcceptNumericOnly(event, allowPeriod, element) {
         var keyCode = event.which ? event.which : event.keyCode;

         var txtvalue = element.value;
         if (allowPeriod == true) {                 // to allow decimal or not
             if (txtvalue.indexOf(".") == -1) {     // allow only one decimal
                 allowPeriod = true;
             }
             else {
                 allowPeriod = false;
             }
         }

         if ((keyCode >= 48 && keyCode <= 57) ||         //lets allow only numerics 
        ((allowPeriod == true) && (keyCode == 46)) ||  //allow period conditionally based on the control's choice
        (keyCode == 8) || //allow backspace 
        (keyCode == 9) //allow tab
        ) {
             return true;
         }

         return false;
     };

    
  </script>
    
        <table style="width: 100%; border-style: solid; border-width: 1px">
         <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="6" 
                      style="border: thin solid #C0C0C0; text-align: left;">Value Card</td>
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
            
                 <tr>
                <td style="border: thin solid #C0C0C0; text-align: right; font-family: Arial;">
                   &nbsp;&nbsp;
                    &nbsp; Goods Condition</td>
                <td style="border: thin solid #C0C0C0; text-align: left">
                       <asp:DropDownList ID="ddstatus" runat="server" Height="23px" Width="200px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                                 
                        <asp:ListItem  Value="1">Healthy New</asp:ListItem>
                        <asp:ListItem Value="2">Healthy Old/Dismantled</asp:ListItem>
                                            <asp:ListItem  Value="3">Surveyed off</asp:ListItem>
                                            <asp:ListItem  Value="4">Defective but Repairable by PSTCL </asp:ListItem>
                                            <asp:ListItem  Value="5">Defective/Returnable to Firm</asp:ListItem>
                                            <asp:ListItem  Value="6">Obsolete</asp:ListItem>
                                            <asp:ListItem  Value="7">Incomplete</asp:ListItem>
                                            <asp:ListItem  Value="8">Scrap</asp:ListItem>
                    </asp:DropDownList>&nbsp</td>
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
            
        </table>
 
    
        </div>
</asp:Content>

