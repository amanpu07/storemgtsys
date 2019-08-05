<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/MPIndex11.master" AutoEventWireup="true" CodeFile="ItemMaster.aspx.cs" Inherits="Inventory_ItemMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  

    <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Add Item Name 
                
                </b></td>
        </tr>
        
       
    
       
       
                   

            
       <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
                 <tr class="tableinnertext" id="row3" runat="server"> 
                    <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; height: 1px;" 
                         align="left">
                        Item Type</td>
                    <td colspan="5" style="height: 1px"> 
                        <asp:DropDownList ID="dditemtype" runat="server" 
                            Height="23px"  
                            Width="400px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0" Selected="True">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;<%--<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator8" runat="server" ErrorMessage="Select Item Type" 
                        ForeColor="#FF0066" ControlToValidate="dditemtype" InitialValue="0">*</asp:RequiredFieldValidator>--%></td>
                </tr>

              <%--<tr class="tableinnertext" id="Tr18" runat="server">
                     <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Item Type</td> 
                    <td>
                        <asp:DropDownList ID="drpItemType" runat="server" Width="380px" 
                            AutoPostBack="True" onselectedindexchanged="drpItemType_SelectedIndexChanged">
                        </asp:DropDownList> </td> 
               </tr>--%>
              
               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtname" runat="server" CssClass="combotext" Width="400px" 
                            ></asp:TextBox></td>
                </tr>

               <tr class="tableinnertext" id="Tr1" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Code</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtcode" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
               
            <tr class="tableinnertext" id="Tr7" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Unit</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtunit" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
  <tr class="tableinnertext" id="Tr8" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Status</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtstatus" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
       

            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="6" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Add New Item Name" Width="150px" />&nbsp;
             
                    &nbsp;                        
                        <asp:Button ID="btndel" runat="server" CssClass="btn" 
                        OnClick="btndel_Click" Text="Delete" Width="63px" />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
            </tr>
            
           <tr class="gridHeader" id="Tr2" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Add Item Type 
                 
                </b></td>
        </tr>
        <tr class="tableinnertext" id="Tr3" runat="server"> 
                    <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; height: 1px;" 
                         align="left">
                        Item Type</td>
                    <td colspan="5" style="height: 1px"> 
                        <asp:TextBox ID="txtitemtype" runat="server" CssClass="combotext" Width="400px" 
                            ></asp:TextBox></td>
                </tr> <tr class="tableinnertext" id="Tr4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtitemname" runat="server" CssClass="combotext" Width="400px" 
                            ></asp:TextBox></td>
                </tr>

               <tr class="tableinnertext" id="Tr5" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Code</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtitemcode" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
               
           
           <tr class="tableinnertext" id="Tr9" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Unit</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtunit1" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox></td>
                </tr>
 
  <tr class="tableinnertext" id="Tr10" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Status</td>
                    <td colspan="5" style="height: 2px"> 
                       <asp:TextBox ID="txtstatus1" runat="server" CssClass="combotext" Width="200px" 
                            ></asp:TextBox><asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                </tr>
 
       

            <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="6" >
                    <asp:Button ID="btnProceed1" runat="server" CssClass="btn" 
                        OnClick="btnProceed1_Click"  Text="Add New Item Type" Width="150px" />&nbsp;
             
                    &nbsp;                        
                        <asp:Button ID="btndel1" runat="server" CssClass="btn" 
                        OnClick="btndel1_Click" Text="Delete" Width="63px" />
                        </td>
            </tr>
            
            </table>
                   
                
                
       <%-- </td>
       </tr>--%>
     </table>
             
</asp:Content>



