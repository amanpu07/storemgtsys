<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/MPIndex11.master" AutoEventWireup="true" CodeFile="Source.aspx.cs" Inherits="Inventory_Source" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  

    <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Add Source Name 
                
                </b></td>
        </tr>
        
       
    
       
       
                   

            
       <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
             
        <tr class="tableinnertext" id="Tr3" runat="server"> 
                    <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; height: 1px;" 
                         align="left">
                        Source Name</td>
                    <td colspan="5" style="height: 1px"> 
                        <asp:TextBox ID="txtsource" runat="server" CssClass="combotext" Width="400px" 
                            ></asp:TextBox></td>
                </tr> <tr class="tableinnertext" id="Tr4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Store Name</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtstore" runat="server" CssClass="combotext" Width="400px" 
                            ></asp:TextBox></td>
                </tr>

              
            <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="6" >
                    <asp:Button ID="btnProceed1" runat="server" CssClass="btn" 
                        OnClick="btnProceed1_Click"  Text="Add New Source Name" Width="150px" />&nbsp;
             
                    &nbsp;                        
                        <asp:Button ID="btndel1" runat="server" CssClass="btn" 
                        OnClick="btndel1_Click" Text="Delete" Width="63px" />
                        </td>
            </tr>
            
            </table>
                   
                
     </table>
             
</asp:Content>





