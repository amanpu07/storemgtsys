<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/MPIndex11.master" AutoEventWireup="true" CodeFile="ItemMasterlogin.aspx.cs" Inherits="Inventory_ItemMasterlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  

   
       <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
                
               
            <tr class="tableinnertext" id="Tr7" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    User Name</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtuser" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
  <tr class="tableinnertext" id="Tr8" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Password</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtpwd" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
       

            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: left;" align="center" colspan="6" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Login" Width="100px" />&nbsp;
             
                                          <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
            </tr>
   

      </table>
             
</asp:Content>