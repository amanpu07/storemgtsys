<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/MPIndex12.master" AutoEventWireup="true" CodeFile="SDInventory.aspx.cs" Inherits="Inventory_SDInventory" %>

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

   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  

    <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Daily Stock Position
                </b></td>
        </tr>
        
        <tr  class="tableinnertext" id="Tr8" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;">
            
            Select File
                    &nbsp; <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Pdf File" />&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Upload" onclick="Button1_Click" />
                     &nbsp;<asp:Button ID="Button2" runat="server" Text="View Files" 
                onclick="Button2_Click" />           
            </td>
                      
            
        </tr>
    
        <tr class="tableinnertext" id="view" runat="server">
            <td align="center" colspan="6" style="height: 18px; width: 723px;">
                <asp:Label ID="Label2" runat="server" Text="label"></asp:Label>
                </td>
        </tr>
        
        <tr class="tableinnertext" id="gv" runat="server">
            <td align="center" colspan="6" style="width: 100%">
               <asp:GridView ID="GridView1" runat="server"  CssClass="gridtext" Caption="Pdf Files " 
        CaptionAlign="Top" ToolTip="Pdf FIle DownLoad Tool" CellPadding="2" 
                    OnPageIndexChanging="GridView1_PageIndexChanging"  Width="100%" 
                    DataKeyNames="id" AllowPaging="True" PageSize="40" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                      <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Download" ControlStyle-ForeColor="Blue"/>
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
            
     </table>

</asp:Content>


