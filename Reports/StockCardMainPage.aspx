<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="StockCardMainPage.aspx.cs" Inherits="Reports_StockCardMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
 
    
        <table style="width: 100%; border-style: solid; border-width: 1px">
         <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="6" 
                      style="border: thin solid #C0C0C0; text-align: left;">Stock Card</td>
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

