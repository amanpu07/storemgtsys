<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreJE.master" AutoEventWireup="true" CodeFile="StoreJEJVCredit.aspx.cs" Inherits="Inventory_StoreJEJVCredit" %>

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
        <ContentTemplate>  <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Journal Voucher Information&nbsp; 
                <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label>
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="320px" 
                    Height="18px"></asp:Label>
                </b>&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label></td>
        </tr>
        <tr class="tableinnertext" id="view" runat="server">
            <td align="center" colspan="6" style="height: 18px; width: 723px;">
                 You are viewing page <b></b> of <b><font color="maroon"></font></b>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Label ID="lblRecordCount" runat="server"></asp:Label>
                </td>
        </tr>
        
        <tr class="tableinnertext" id="gv" runat="server">
            <td align="center" colspan="6" style="width: 100%">
               <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
               <asp:Label ID="lblSortInformation" runat="server" ForeColor="Red"></asp:Label>
               <asp:Label ID="lblShow1" runat="server" ForeColor="Red"></asp:Label>
               <asp:GridView ID="GVInfo" runat="server"  CssClass="gridtext" 
                    AutoGenerateColumns="False" CellPadding="2" 
                    OnPageIndexChanging="GVInfo_PageIndexChanging" OnSorting="GVInfo_Sorting" Width="100%" 
                    DataKeyNames="rtxno" AllowPaging="True" PageSize="50" 
                    onrowcommand="GVInfo_EditClick" ondatabound="GVInfo_DataBound" 
                    onrowediting="GVInfo_RowEditing">
                     <Columns>
                       <asp:ButtonField CommandName="Edit"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Edit" Text="Edit"  ButtonType="Image" ImageUrl="~/images/edit.gif" />
                                                <asp:TemplateField HeaderText="Voucher No." SortExpression="voucherno">
                            <ItemTemplate><%#Eval("voucherno")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>
                         
                                                <asp:TemplateField HeaderText="Voucher Date" SortExpression="voucherdate">
                             <ItemTemplate><%#Eval("voucherdate", "{0:dd-MM-yyyy}")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
                            <ItemTemplate><%#Eval("itemname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="Left"/>
                          
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit Amount" SortExpression="grandtotal">
                            <ItemTemplate><%#Eval("grandtotal")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                             <asp:Label ID="lblgridStatus" runat="server" Text='<%#Eval("field2") %>'></asp:Label>                             
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
        <td align="center" colspan="6" style="height: 4px; width: 723px;">
        <asp:Button ID="btnAddNew" runat="server" CssClass="btn" OnClick="btnAddNew_Click" 
                Text= "Add New Voucher Item" Width="154px" CausesValidation="False" />
            &nbsp; &nbsp; <asp:Button ID="btCancel1" runat="server" CssClass="btn" 
                Text="Cancel" Width="100px" CausesValidation="False" 
                OnClick="btCancel1_Click" /></td>
    </tr>
        
        
        <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
    
                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Journal Voucher Details</b>
                  </td>
                  </tr>
                   <tr  class="tableinnertext" id="Tr12" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    Journal Voucher No.&nbsp; 
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter Journal Voucher No." 
                        ForeColor="#FF0066" ControlToValidate="txtjvn">*</asp:RequiredFieldValidator>
                    
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtjvn" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>&nbsp;</td>

             </tr>

       <tr  class="tableinnertext" id="Tr19" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                   Journal Voucher Date&nbsp; 
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator22" runat="server" ErrorMessage="Enter Journal Voucher Date" 
                        ForeColor="#FF0066" ControlToValidate="txtjvdate">*</asp:RequiredFieldValidator>
                  &nbsp; <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToValidate="txtjvdate" ErrorMessage="Enter Date" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                 </td>
                <td style="height: 10px; text-align: left;">

                    <asp:TextBox ID="txtjvdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="200px"></asp:TextBox>
                 &nbsp;&nbsp;</td>
            </tr>
             <tr  class="tableinnertext" id="row2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    GR No.&nbsp; <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter GR No." 
                        ForeColor="#FF0066" ControlToValidate="txtgrno">*</asp:RequiredFieldValidator>
                    
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtgrno" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>&nbsp;</td>

             </tr>

              <tr class="tableinnertext" id="Tr13" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    GR Page No. <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter GR Page No." 
                        ForeColor="#FF0066" ControlToValidate="txtgrpageno">*</asp:RequiredFieldValidator>
                  </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtgrpageno" runat="server" CssClass="combotext"  Width="200px"></asp:TextBox>&nbsp;</td>
                   
             </tr>       
             <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                   GR Date&nbsp; <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter GR Date" 
                        ForeColor="#FF0066" ControlToValidate="txtgrdate">*</asp:RequiredFieldValidator>
                  &nbsp; <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtgrdate" ErrorMessage="Enter Date" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                 </td>
                <td style="height: 10px; text-align: left;">

                    <asp:TextBox ID="txtgrdate" runat="server" Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="200px"></asp:TextBox>
                 &nbsp;&nbsp;</td>
            </tr>
             <tr  class="tableinnertext" id="Tr2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Source 
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstatustype" runat="server" Height="20px" Width="200px" 
                        AutoPostBack="True" onselectedindexchanged="ddstatustype_SelectedIndexChanged"> 
                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>  
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label4" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>
<tr  class="tableinnertext" id="Tr20" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Line Name/Work Name
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddline" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="True" onselectedindexchanged="ddline_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
<tr  class="tableinnertext" id="Tr21" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                     Sub-Division
                  </td>
                <td style="height: 10px; text-align: left;">
          <asp:DropDownList ID="ddsubdiv" runat="server" Height="20px" Width="400px" 
                        Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>
</td>
               </tr>
<tr  class="tableinnertext" id="Tr22" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Division
                  </td>
                <td style="height: 10px; text-align: left;">
                  <asp:DropDownList ID="dddiv" runat="server" Height="20px" Width="400px" 
                        Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList></td>
               </tr>
               <tr  class="tableinnertext" id="Tr15" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Firm Name
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddfirm" runat="server" Height="20px" Width="400px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
               <tr  class="tableinnertext" id="Tr18" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Name
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstore" runat="server" Height="20px" Width="400px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>

             <tr  class="tableinnertext" id="Tr3" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Goods Condition <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Goods Condition" 
                        ForeColor="#FF0066" ControlToValidate="ddstatus" InitialValue="0">*</asp:RequiredFieldValidator>
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddstatus" runat="server" Height="23px" Width="200px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                    </asp:DropDownList>&nbsp;</td>
               </tr>   
               <tr class="tableinnertext" id="Tr16" runat="server">
              <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                       align="left">
                       SRW/Challan No./Invoice no.</td>
                      <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtsrwno" runat="server" CssClass="combotext" Width="200px"></asp:TextBox></td>
             </tr>

              <tr class="tableinnertext" id="Tr17" runat="server">
               <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                      align="left">
                        Date of SRW/Challan No./Invoice no.</td>
                      <td style="text-align: left; height: 10px;">
                    <asp:TextBox ID="txtsrwdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                  
                    CssClass="combotext" Width="200px"></asp:TextBox></td>
             </tr>

       
             <tr  class="tableinnertext" id="Tr4" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      P.O. No./Indent No. 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtpono" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>
                    &nbsp;</td>
               </tr>

       
             <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      P.O. Date/Indent Date 
                      </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtpodate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                  
                    CssClass="combotext" Width="200px"></asp:TextBox>&nbsp;&nbsp;</td>
               </tr>

       
             


              <tr class="gridHeader" id="Tr7" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Items</b>
                  </td>
              </tr>


</table>       
                   
            
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
       <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
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
                        </asp:DropDownList>&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label>
                     </td>
                </tr>
               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                        <asp:DropDownList ID="dditemname" runat="server" Height="23px" Width="400px" 
                            AppendDataBoundItems="False" 
                            onselectedindexchanged="dditemname_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>               

               <tr class="tableinnertext" id="Tr212" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                        Unit
                        </td>
                    <td colspan="5" style="height: 2px">  
                      <asp:TextBox ID="txtunit" runat="server" style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True" CssClass="combotext" Width="200px"></asp:TextBox>
                     </td>
                </tr>
                 <tr  class="tableinnertext" id="Tr23" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Debit</td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddgrouphead" runat="server" Height="23px" Width="200px" 
                        AutoPostBack="True" onselectedindexchanged="ddgrouphead_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                        
                                         </asp:DropDownList>&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label>
                    &nbsp;</td>
               </tr>

 <tr  class="tableinnertext" id="Tr24" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Credit 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddsubgrp" runat="server" Height="23px" Width="200px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>              
                        
                                         </asp:DropDownList>
                    &nbsp;</td>
               </tr>               <tr  class="tableinnertext" id="Tr8" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                     JV-Status 
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddjvstatus" runat="server" Height="20px" Width="200px" 
                        AutoPostBack="False"> 
                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>  
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label5" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>

<tr class="tableinnertext" id="Tr9" runat="server"  visible="true">
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                        Credit Amount
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="txtcreditamt" ErrorMessage="Enter Credit Amount" 
                            ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="5" style="height: 2px"> 
                    
                  <asp:TextBox ID="txtcreditamt" runat="server" CssClass="combotext" onkeypress="return AcceptNumericOnly(event,true,this);" Width="200px">0.00</asp:TextBox>
                  &nbsp;
                     </td>
                </tr>
                <tr class="tableinnertext" id="Tr11" runat="server"> 
                    <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 101px;" 
                        align="left">
                    Remarks</td>
                    <td colspan="5"> 
                    <asp:TextBox ID="txtremarks" runat="server" style="width: 400px;" 
                            CssClass="combotext" AutoPostBack="false" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                </tr>
         </table>
        
        </ContentTemplate>      
 </asp:UpdatePanel>
    
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="6" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Save" Width="63px" />&nbsp;
                   &nbsp;
                    <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnclear" runat="server" CssClass="btn" 
                        OnClick="btnclear_Click" Text="Click for New Voucher" Width="150px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnapproval" runat="server" CssClass="btn" 
                        OnClick="btnapproval_Click" Text="Click for Approval" Width="130px" 
                        CausesValidation="False" />
                        &nbsp;&nbsp;                        
                        <asp:Button ID="btndel" runat="server" CssClass="btn" 
                        OnClick="btndel_Click" Text="Delete" Width="63px" 
                        CausesValidation="False" Visible="False" />
                        </td>
            </tr>
            
            <tr  id="row10" runat="server">
                <td align="center" colspan="6" style="height: 25px"> 
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label
                        ID="Label1" runat="server" ForeColor="Red" Width="176px"></asp:Label>
                </td>
            </tr>
            
            </table>
        </td>
       </tr>
     </table>
</ContentTemplate>
</asp:UpdatePanel>          
</asp:Content>








