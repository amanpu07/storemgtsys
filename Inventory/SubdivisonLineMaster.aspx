<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Subdivison.master" AutoEventWireup="true" CodeFile="SubdivisonLineMaster.aspx.cs" Inherits="Inventory_SubdivisonLineMaster"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtline.ClientID%>").value == "") {
                alert("Line Name can not be blank");
                document.getElementById("<%=txtline.ClientID%>").focus();
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
<ProgressTemplate>
    <div class="modal">
        <div class="center">
            <img alt="" src="..\images\loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate> 
    <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="Tr1" runat="server">
            <td align="left" style="height: 20px; width: 723px;"><b>Work Master
                <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label>
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="349px" 
                    Height="18px"></asp:Label>
                </b></td>
        </tr>
        
        <tr class="tableinnertext" id="view" runat="server">
            <td align="center" style="height: 18px; width: 723px;">
                 You are viewing page <b><%=GVInfo.PageIndex + 1%></b> of <b><%=GVInfo.PageCount%><font color="maroon"></font></b>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Label ID="lblRecordCount" runat="server"></asp:Label>
                </td>
        </tr>
        
        <tr class="tableinnertext" id="gv" runat="server">
            <td align="center" style="width: 100%">
               <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
               <asp:Label ID="lblSortInformation" runat="server" ForeColor="Red"></asp:Label>
               <asp:Label ID="lblShow1" runat="server" ForeColor="Red"></asp:Label>
               <asp:GridView ID="GVInfo" runat="server"  CssClass="gridtext" 
                    AutoGenerateColumns="False" CellPadding="2" 
                    OnPageIndexChanging="GVInfo_PageIndexChanging" OnSorting="GVInfo_Sorting" Width="100%" 
                    DataKeyNames="Lineid" AllowPaging="True" PageSize="50" 
                    onrowcommand="GVInfo_EditClick" ondatabound="GVInfo_DataBound" 
                    onrowediting="GVInfo_RowEditing" 
                    onselectedindexchanged="GVInfo_SelectedIndexChanged">
                     <Columns>

                       <asp:ButtonField CommandName="Edit"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Edit" Text="Edit"  ButtonType="Image" ImageUrl="~/images/edit.gif" />
                                                         <asp:TemplateField HeaderText="Work Name" SortExpression="LineName">
                            <ItemTemplate><%#Eval("LineName")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="Left"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>   
 
                                              
                          <asp:TemplateField HeaderText="Status" SortExpression="Estatus">
                            <ItemTemplate>
                             <asp:Label ID="lblgridStatus" runat="server" Text='<%#Eval("Estatus") %>'></asp:Label>                             
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center"/>
                             
                        </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Record(s) Found</EmptyDataTemplate>
                    <PagerStyle ForeColor="#804040" HorizontalAlign="Left" Font-Bold="True"/>
                    <HeaderStyle BackColor="Silver" />
                </asp:GridView>
            </td>
        </tr>
            <tr id="can" runat="server" class="tableinnertext">
        <td align="center" style="height: 4px; width: 723px;">
        <asp:Button ID="btnAddNew" runat="server" CssClass="btn" OnClick="btnAddNew_Click" 
                Text= "Add New Work" Width="154px" CausesValidation="False" />
            &nbsp; &nbsp; <asp:Button ID="btCancel1" runat="server" CssClass="btn" 
                Text="Cancel" Width="100px" CausesValidation="False" 
                OnClick="btCancel1_Click" /></td>
    </tr>
         <tr   runat="server" id="txtbox" width="100%">
         <td >  
    <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Add Line 
                
                </b>&nbsp;
                
                </td>
        </tr>         
        <tr class="tableinnertext" id="Tr3" runat="server"> 
                    <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; height: 1px;" 
                         align="left">
                        Work Name&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtline" ErrorMessage="Enter Line" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator>

                        </td>
                    <td colspan="5" style="height: 1px"> 
                        <asp:TextBox ID="txtline" runat="server" CssClass="combotext" Width="453px"></asp:TextBox></td>  </tr>
      
            <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed1_Click"  Text="Save" Width="70px" />&nbsp;
                   &nbsp;
                    <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnclear" runat="server" CssClass="btn" 
                        OnClick="btnclear_Click" Text="Click for New Work" Width="150px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnapproval" runat="server" CssClass="btn" 
                        OnClick="btnapproval_Click" Text="Click for Approval" Width="130px" 
                        CausesValidation="true" />
                        &nbsp;&nbsp;                        
                        <asp:Button ID="btndel" runat="server" CssClass="btn" 
                        OnClick="btndel_Click" Text="Delete" Width="63px" 
                        CausesValidation="true" Visible="False" />                       
                        &nbsp;&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label> 
                        </td>
            </tr>
            
            <tr  id="row10" runat="server">
                <td align="center" colspan="2" style="height: 25px"> 
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label
                        ID="Label2" runat="server" ForeColor="Red" Width="176px"></asp:Label>
                </td>
            </tr>
                        </table>               
                
                
        </td>
       </tr>
     </table>
</ContentTemplate>
</asp:UpdatePanel>          
</asp:Content>

