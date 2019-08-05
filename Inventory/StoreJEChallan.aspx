<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreJE.master" AutoEventWireup="true" CodeFile="StoreJEChallan.aspx.cs" Inherits="Inventory_StoreJEChallan" %>

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

    <%--  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
<ProgressTemplate>
    <div class="modal">
        <div class="center">
            <img alt="" src="..\images\loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>--%>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate> 

    <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
        <tr class="gridHeader" id="r1" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Store Challan Information&nbsp; 
               <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label>
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="287px" 
                    Height="18px"></asp:Label>
                </b>&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label></td>
        </tr>
        
        <tr class="tableinnertext" id="view" runat="server">
            <td align="center" colspan="6" style="height: 18px; width: 723px;">
                 You are viewing page <b><%=GVChallanInfo.PageIndex + 1%></b> of <b><%=GVChallanInfo.PageCount%><font color="maroon"></font></b>
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
               <asp:GridView ID="GVChallanInfo" runat="server"  CssClass="gridtext" 
                    AutoGenerateColumns="False" CellPadding="2" 
                    OnPageIndexChanging="GVChallanInfo_PageIndexChanging" 
                    OnRowEditing="GVChallanInfo_RowEditing" OnSorting="GVChallanInfo_Sorting" Width="100%" 
                    DataKeyNames="itxno" AllowPaging="True" PageSize="50" 
                    onrowcommand="GVChallanInfo_EditClick" 
                    ondatabound="GVChallanInfo_DataBound">
                     <Columns>
                     <asp:ButtonField CommandName="Edit"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Edit" Text="Edit"  ButtonType="Image" ImageUrl="~/images/edit.gif" />
                        
                        <asp:TemplateField HeaderText="Challan No." SortExpression="Challanno">
                            <ItemTemplate><%#Eval("srchallanpageno")%>/<%#Eval("srchallanbookno")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Challan Date" SortExpression="srchallandate">
                            <ItemTemplate><%#Eval("srchallandate","{0:dd-MM-yyyy}")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
                            <ItemTemplate><%#Eval("stockitemname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Grand Total" SortExpression="grandtotal">
                            <ItemTemplate><%#Eval("grandtotal")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="right"/>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                            <asp:Label ID="lblgridStatus" runat="server" Text='<%#Eval("ifield2") %>'></asp:Label> 
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center"/>
                        </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Record(s) Found</EmptyDataTemplate>
                    <PagerStyle ForeColor="#804040" HorizontalAlign="Left" Font-Bold="True"/>
                    <HeaderStyle BackColor="Silver" />
                </asp:GridView></td></tr> <tr id="can" runat="server" class="tableinnertext">
        <td align="center" style="height: 4px; width: 723px;">
        <asp:Button ID="btnAddNew" runat="server" CssClass="btn" OnClick="btnAddNew_Click" 
                Text= "Add New Challan Item" Width="154px" CausesValidation="False" />
            &nbsp; &nbsp; <asp:Button ID="btCancel1" runat="server" CssClass="btn" 
                Text="Cancel" Width="100px" CausesValidation="False" 
                OnClick="btCancel1_Click" /></td>
    </tr>
        
        
        <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
    
                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Challan Item Details</b>
                  </td>
                  </tr>

       
             <tr  class="tableinnertext" id="row2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    Challan Book No.&nbsp; <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Challan Book No." 
                        ForeColor="#FF0066" ControlToValidate="txtchalbookno">*</asp:RequiredFieldValidator>
                    
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtchalbookno" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>&nbsp;</td>

             </tr>

              <tr class="tableinnertext" id="Tr13" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    Challan Page No. <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Challan Page No." 
                        ForeColor="#FF0066" ControlToValidate="txtchalpageno">*</asp:RequiredFieldValidator>
                  </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtchalpageno" runat="server" CssClass="combotext"  Width="200px"></asp:TextBox>&nbsp;</td>
                   
             </tr>


       
             <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                   Challan Date&nbsp; <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Challan Date" 
                        ForeColor="#FF0066" ControlToValidate="txtchaldate">*</asp:RequiredFieldValidator>
                  &nbsp; <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtchaldate" ErrorMessage="Enter Date" ForeColor="Red" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                 </td>
                <td style="height: 10px; text-align: left;">

                    <asp:TextBox ID="txtchaldate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="200px"></asp:TextBox>
                 &nbsp;&nbsp;</td>
            </tr>

       
            <%-- <tr  class="tableinnertext" id="Tr2" runat="server">
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
               </tr>--%>
               <tr  class="tableinnertext" id="Tr18" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Name
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstore" runat="server" Height="20px" Width="400px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label4" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>

             <tr  class="tableinnertext" id="Tr3" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Goods Condition <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select Goods Condition" 
                        ForeColor="#FF0066" ControlToValidate="ddstatus" InitialValue="0">*</asp:RequiredFieldValidator>
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddstatus" runat="server" Height="23px" Width="200px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                    </asp:DropDownList>&nbsp;</td>
               </tr>

             <tr  class="tableinnertext" id="Tr4" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Indent No./Delivery Order No. 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstoindentno" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>
                    &nbsp;</td>
               </tr>

       
             <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Indent No./Delivery Order Date 
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstoindentdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                  
                    CssClass="combotext" Width="200px"></asp:TextBox>&nbsp;&nbsp;</td>
               </tr>

       
              <tr  class="tableinnertext" id="Tr12" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Group Head
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddgrouphead" runat="server" Height="23px" Width="200px" 
                        AutoPostBack="True" onselectedindexchanged="ddgrouphead_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                        
                                         </asp:DropDownList>&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label>
                    &nbsp;</td>
               </tr>

 <tr  class="tableinnertext" id="Tr23" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Sub-Group Head 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddsubgrp" runat="server" Height="23px" Width="200px">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>              
                        
                                         </asp:DropDownList>
                    &nbsp;</td>
               </tr>
              <tr class="gridHeader" id="Tr7" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Items</b>
                  </td>
              </tr>
</table>       
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
                            onselectedindexchanged="dditemname_SelectedIndexChanged"
                            AutoPostBack="True">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>
      <tr class="tableinnertext" id="row5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Unit 
                       
          </td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                     <asp:TextBox ID="txtunit" runat="server" style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True" CssClass="combotext" Width="119px"></asp:TextBox>
                            </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Qty Requested
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtqtyreq" ErrorMessage="Enter Qty Requested" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                    &nbsp;</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtqtyreq" runat="server" CssClass="combotext" 
                        Width="118px" 
                        onkeypress="return AcceptNumericOnly(event,true,this);" 
                        ontextchanged="txtqtyreq_TextChanged"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Qty Issued
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                        ControlToValidate="txtqtyissued" ErrorMessage="Enter Qty Issued" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                    &nbsp;</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                   <asp:TextBox ID="txtqtyissued" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="True" ontextchanged="txtqtyissued_TextChanged"
                        onkeypress="return AcceptNumericOnly(event,true,this);">                        
                        </asp:TextBox>
                    </td>
            </tr>
      <tr class="tableinnertext" id="Tr5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Rate <asp:RequiredFieldValidator ID="RequiredFieldValidator16" 
                            runat="server" ControlToValidate="txtrate" ErrorMessage="Enter Rate" 
                            ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                        &nbsp;</td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtrate" runat="server" CssClass="combotext" AutoPostBack="True" 
                           Width="119px" ontextchanged="txtrate_TextChanged" 
                           onkeypress="return AcceptNumericOnly(event,true,this);">
                    </asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Total</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txttotal" runat="server" style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True" CssClass="combotext" Width="119px"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Storage Charges %
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                        ControlToValidate="txtstorage" ErrorMessage="Enter Storage %" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
          </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtstorage" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="True" ontextchanged="txtstorage_TextChanged"
                        onkeypress="return AcceptNumericOnly(event,true,this);"></asp:TextBox>
                    </td>
            </tr>
      
            <tr class="tableinnertext" id="Tr10" runat="server"> 
                    <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Grand Total</td>
                    <td colspan="5"> 
                            <asp:TextBox ID="txtgrandtotal" runat="server" style="width: 400px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox>

                    </td>
                </tr>
                 <tr class="tableinnertext" id="Tr11" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Employee Code
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtempcode" ErrorMessage="Enter Employee Code" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
          </td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                    <asp:TextBox ID="txtempcode" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Employee Name
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtempname" ErrorMessage="Enter Employee Name" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
          </td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtempname" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false"></asp:TextBox>
                    </td>
                    <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Desgination
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtdesg" ErrorMessage="Enter Designation" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
          </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    
                    <asp:TextBox ID="txtdesg" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false"></asp:TextBox>
                    </td>
            </tr>

         </table>
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
               
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Save" Width="63px" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />&nbsp;&nbsp;                        
                        <asp:Button ID="btnclear" runat="server" CssClass="btn" 
                        OnClick="btnclear_Click" Text="Click for New Challan" Width="150px" 
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
                <td align="center" colspan="2" style="height: 25px"> 
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



