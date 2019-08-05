<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/Subdivison.master" AutoEventWireup="true" CodeFile="SubdivisonSR.aspx.cs" Inherits="Inventory_SubdivisonSR" %>

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
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" style="height: 20px; width: 723px;"><b>
                <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label>
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="349px" 
                    Height="18px"></asp:Label>
                </b>
                 &nbsp;&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label></td>
        </tr>
       <tr class="gridHeader" id="Tr11" runat="server">
            <td align="center" style="height: 20px; width: 723px;">
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Width="209px" 
                    Text="Store Requisition" Font-Bold="True" Font-Size="Large"></asp:Label>
             </td>  
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
                    DataKeyNames="itxno" AllowPaging="True" PageSize="50" 
                    onrowcommand="GVInfo_EditClick" ondatabound="GVInfo_DataBound" 
                    onrowediting="GVInfo_RowEditing" 
                    onselectedindexchanged="GVInfo_SelectedIndexChanged">
                     <Columns>

                       <asp:ButtonField CommandName="Edit"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Edit" Text="Edit"  ButtonType="Image" ImageUrl="~/images/edit.gif" />
                                                   <asp:TemplateField HeaderText="SR No" SortExpression="srchallanpageno">
                            <ItemTemplate><%#Eval("srchallanpageno")%>/<%#Eval("srchallanbookno")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SR Date" SortExpression="srchallandate">
                            <ItemTemplate><%#Eval("srchallandate","{0:dd-MM-yy}")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>
                         
                                                <asp:TemplateField HeaderText="Estimate" SortExpression="nameofestimate">
                             <ItemTemplate><%#Eval("nameofestimate")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="stockitemname">
                            <ItemTemplate><%#Eval("stockitemname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="left"/>
                          
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Quantity Indented" SortExpression="qtyindented">
                            <ItemTemplate><%#Eval("qtyindented")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Balance" SortExpression="balance">
                            <ItemTemplate><%# (Decimal.Parse(Eval("qtysanctioned").ToString()) - Decimal.Parse(Eval("qtydrawn").ToString())).ToString("N2")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="Status" SortExpression="Estatus">
                            <ItemTemplate>
                             <asp:Label ID="lblgridStatus" runat="server" Text='<%#Eval("subdivstatus")%>'></asp:Label>                        
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
                Text= "Add New SR" Width="90px" CausesValidation="False" />
            &nbsp; &nbsp; <asp:Button ID="btCancel1" runat="server" CssClass="btn" 
                Text="Cancel" Width="80px" CausesValidation="False" 
                OnClick="btCancel1_Click" />
                </td>
    </tr>
        
        
        <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
    
                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="6"  style="height: 15px"><b>SR-Form</b>
                  </td>
                  </tr>
                   <tr  class="tableinnertext" id="Tr7" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Name 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstore" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="true" 
                        onselectedindexchanged="ddstore_SelectedIndexChanged"  >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>

            
       <tr  class="tableinnertext" id="Tr20" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Work Name 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddline" runat="server" Height="20px" Width="400px" 
                     AutoPostBack="True" Enabled="true" onselectedindexchanged="ddline_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
             
                   <tr  class="tableinnertext" id="Tr24" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Estimate 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddestimate" runat="server" Height="20px" Width="400px" Enabled="true"
                       AutoPostBack="True" 
                        onselectedindexchanged="ddestimate_SelectedIndexChanged" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
                 <tr class="tableinnertext" id="row3" runat="server"> 
                    <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; height: 1px;" 
                         align="left">
                        Item Type
                        </td>
                    <td colspan="5" style="height: 1px"> 
                        <asp:DropDownList ID="dditemtype" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype_SelectedIndexChanged" 
                            Width="400px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>

               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                        <asp:DropDownList ID="dditemname" runat="server" Height="23px" Width="400px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>
                <tr  class="tableinnertext" id="Tr3" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Goods Type
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddgoodstype" runat="server" Height="23px" Width="150px" 
                        Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList>&nbsp;</td>
               </tr>
 
      <tr class="tableinnertext" id="row5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Unit 
                       
          </td>
                    <td  style="height: 5px; text-align: left; width: 123px;">
                     <asp:TextBox ID="txtunit" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="150px" ReadOnly="True"></asp:TextBox>
                            </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Qty Sanctioned</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtqty" runat="server" CssClass="combotext" 
                        Width="118px" ReadOnly="True"></asp:TextBox>
                    </td>    
                    
                      <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Qty Drawn till date</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtqtydrwn" runat="server" CssClass="combotext" Width="118px" 
                        ReadOnly="True"></asp:TextBox>
                    </td>          
                               </tr>
            
      <tr class="tableinnertext" id="Tr5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Name of Contractor</td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtcontractor" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="150px" ReadOnly="True"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Name of JE</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                     <asp:TextBox ID="txtje" runat="server" CssClass="combotext" Width="118px" 
                        AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Employee Code</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtsdo" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
                               </tr>   
                              <%-- <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Qty In Store
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstrqty" runat="server" style="width: 150px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
               </tr>--%>
                                <tr class="gridHeader" id="Tr2" runat="server">
                  <td align="left" colspan="6"  style="height: 15px"><b>Enter Details</b>
                  </td>
                  </tr>   

                  <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Qty In Store
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstrqty" runat="server" style="width: 150px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
               </tr>
     <tr class="tableinnertext" id="Tr4" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        SR Book No.&nbsp;   <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter SR Book No." 
                        ForeColor="#FF0066" ControlToValidate="txtsrbook">*</asp:RequiredFieldValidator></td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtsrbook" runat="server" CssClass="combotext" Width="150px"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    SR Page No.&nbsp;   <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter SR Page No." 
                        ForeColor="#FF0066" ControlToValidate="txtsrpage">*</asp:RequiredFieldValidator></td>
                <td style="text-align: left; height: 25px; width: 118px;">
                     <asp:TextBox ID="txtsrpage" runat="server" CssClass="combotext" Width="118px"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    SR Date&nbsp;
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter SR Date" 
                        ForeColor="#FF0066" ControlToValidate="txtsrdate">*</asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtsrdate" ErrorMessage="Enter Date" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
          </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtsrdate" runat="server" Text="dd-mm-yyyy" onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" 
                    onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')" CssClass="combotext" Width="119px"></asp:TextBox>
                    </td>
                               </tr>   
                                 <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Qty Indent
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtqtyindent" runat="server" CssClass="combotext" Width="150px"></asp:TextBox></td>
               </tr>
 
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Save" Width="63px" />&nbsp;
                   &nbsp;
                    <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnclear" runat="server" CssClass="btn" 
                        OnClick="btnclear_Click" Text="Click for New SR" Width="125px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnapproval" runat="server" CssClass="btn" 
                        OnClick="btnapproval_Click" Text="Click for Approval" Width="130px" 
                        CausesValidation="true" />
                        &nbsp;&nbsp;                        
                        <asp:Button ID="btndel" runat="server" CssClass="btn" 
                        OnClick="btndel_Click" Text="Delete" Width="63px" 
                        CausesValidation="true" Visible="False" />                       
                       
                        </td>
            </tr>
            
            <tr  id="row10" runat="server">
                <td align="center" colspan="2" style="height: 25px"> 
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label
                        ID="Label1" runat="server" ForeColor="Red" Width="176px"></asp:Label>
                        <asp:Label ID="lblmsg1" runat="server" ></asp:Label>
                </td>
            </tr>
                        </table>
                   
                
                
        </td>
       </tr>
     </table>
</ContentTemplate>
</asp:UpdatePanel>          
</asp:Content>




