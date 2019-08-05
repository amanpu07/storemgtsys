<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Subdivison.master" AutoEventWireup="true" CodeFile="PasswordChangeSubDivison.aspx.cs" Inherits="Inventory_PasswordChangeSubDivison" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        
        <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
    
                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Change Password</b>
                  </td>
                  </tr>

       
            

</table>       
                   
            
            
       <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
                 <tr class="tableinnertext" id="row3" runat="server"> 
                    <td  style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                         align="left">                       Old Password</td>
                    <td colspan="5">
                            <asp:TextBox ID="txtbxOldPasswd" TextMode="Password" runat="server" Width="150px"
                                     ToolTip="Enter old password here"></asp:TextBox>
                       </td>
                </tr>
               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left">
                    New Password</td>
                    <td colspan="5" style="height: 2px"> 
                         <asp:TextBox ID="txtbxNewPasswd" TextMode="Password" runat="server" Width="150px"
                                    ToolTip="Enter new password here"></asp:TextBox>
                        </td>
                </tr>

                
                <tr class="tableinnertext" id="Tr18" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left"> 
                    Confirm Password
                    </td>
                    <td colspan="5" style="height: 2px"> 
                    <asp:TextBox ID="txtbxConPasswd" TextMode="Password" runat="server" Width="150px"
                                    ToolTip="Enter new password to confirm"></asp:TextBox>
                  </td>
                </tr>
                <tr class="tableinnertext" id="Tr1" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left"> 
                    Employee Name
                    </td>
                    <td colspan="5" style="height: 2px"> 
                    <asp:TextBox ID="txtempname" runat="server" Width="250px"></asp:TextBox>
                  </td>
                </tr>
                 <tr class="tableinnertext" id="Tr2" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; text-align: right;" 
                        align="left"> 
                    Employee Code
                    </td>
                    <td colspan="5" style="height: 2px"> 
                     <asp:TextBox ID="txtempcode" runat="server" Width="150px"></asp:TextBox>
                  </td>
                </tr>
            
    
            
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
            <tr  class="tableinnertext" id="row9" runat="server">
            <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                         align="left"></td>
                <td style="height: 25px; text-align: left;" align="left" colspan="5" >
                
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Proceed" Width="63px" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />&nbsp;<asp:Label ID="lblerr" runat="server" ForeColor="red"  align="right"></asp:Label></td>
            </tr>
            
            <tr  id="row10" runat="server">
                <td align="center" colspan="6" style="height: 25px"> 
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    &nbsp;&nbsp; &nbsp;&nbsp;
                </td>
            </tr>
            </table>
                   
                
                
        </td>
       </tr>
     </table>

</asp:Content>
