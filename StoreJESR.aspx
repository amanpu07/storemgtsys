<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreJE.master" AutoEventWireup="true" CodeFile="StoreJESR.aspx.cs" Inherits="Inventory_StoreJESR" %>

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
                    Height="18px"></asp:Label>&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
                </b></td>
        </tr>
      <tr class="gridHeader" id="Tr12" runat="server">
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
                    OnPageIndexChanging="GVInfo_PageIndexChanging" Width="100%" 
                    DataKeyNames="itxno" AllowPaging="True" PageSize="50" 
                    AutoGenerateSelectButton="false" 
                    onselectedindexchanging="GVInfo_SelectedIndexChanging" 
                    ondatabound="GVInfo_DataBound" onsorting="GVInfo_Sorting">
                     <Columns>
                     
                      <asp:ButtonField CommandName="Select"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Select" Text="Select"  ButtonType="Image" ImageUrl="~/images/sel.png" />

                                 <asp:TemplateField HeaderText="Sub Division" SortExpression="nameofsubdivision">
                            <ItemTemplate><%#Eval("nameofsubdivision")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="left"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="SR No" SortExpression="srchallanpageno">
                            <ItemTemplate><%#Eval("srchallanpageno")%>/<%#Eval("srchallanbookno")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SR Date" SortExpression="srchallandate">
                            <ItemTemplate><%#Eval("srchallandate","{0:dd-MM-yyyy}")%></ItemTemplate>
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
                                                 <asp:TemplateField HeaderText="Estimate Qty" SortExpression="totalqtyestimate">
                            <ItemTemplate><%#Eval("totalqtyestimate")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="Qty Drawn till date" SortExpression="qtydrawntilldate">
                            <ItemTemplate><%#Eval("qtydrawntilldate")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Quantity Indented" SortExpression="qtyindented">
                            <ItemTemplate><%#Eval("qtyindented")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>
                               
                        
                        <%--<asp:TemplateField HeaderText="Balance" SortExpression="balance">
                            <ItemTemplate><%# (Decimal.Parse(Eval("totalqtyestimate").ToString()) - Decimal.Parse(Eval("qtydrawntilldate").ToString())).ToString("N2")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Right"/>
                            
                        </asp:TemplateField>--%>
                        <%--  <asp:TemplateField HeaderText="Status" SortExpression="subdivstatus">
                            <ItemTemplate>
                             <asp:Label ID="lblgridStatus" runat="server" Text='<%#Eval("subdivstatus")%>'></asp:Label>                        
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center"/>                             
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Store Status" SortExpression="ifield2">
                            <ItemTemplate>
                             <asp:Label ID="lblgridStatusstr" runat="server" Text='<%#Eval("ifield2")%>'></asp:Label>                        
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center"/>
                             
                       </asp:TemplateField> --%>
                        </Columns>
                        <EmptyDataTemplate>No Record(s) Found</EmptyDataTemplate>
                    <PagerStyle ForeColor="#804040" HorizontalAlign="Left" Font-Bold="True"/>
                    <HeaderStyle BackColor="Silver" />
                </asp:GridView>
            </td>
        </tr>
                   
        <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
    
                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="6"  style="height: 15px"><b>SR-Form</b>
                  </td>
                  </tr>
                  <tr  class="tableinnertext" id="Tr10" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Sub-Divison 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:TextBox ID="txtsubdivison" runat="server" CssClass="combotext" 
                        Width="400px" ReadOnly="True"></asp:TextBox></td>
               </tr>
                  <tr  class="tableinnertext" id="Tr24" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Estimate 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddestimate" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="false" Enabled="False" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
       <tr  class="tableinnertext" id="Tr20" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Work Name 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddline" runat="server" Height="20px" Width="400px" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
             

                 <tr class="tableinnertext" id="row3" runat="server"> 
                    <td style="font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px; height: 1px;" 
                         align="left">
                        Item Type
                        </td>
                    <td colspan="5" style="height: 1px"> 
                        <asp:DropDownList ID="dditemtype" runat="server" AutoPostBack="false" 
                            Height="23px" Width="400px" style="margin-bottom: 0px" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>

               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                        <asp:DropDownList ID="dditemname" runat="server" Height="23px" Width="400px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
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
                               
     <tr class="tableinnertext" id="Tr4" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        SR Book No.</td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtsrbook" runat="server" CssClass="combotext" Width="150px" 
                            ReadOnly="True"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    SR Page No.</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                     <asp:TextBox ID="txtsrpage" runat="server" CssClass="combotext" Width="118px" 
                         ReadOnly="True"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    SR Date
          </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtsrdate" runat="server" CssClass="combotext" Width="119px" 
                        ReadOnly="True"></asp:TextBox>
                    </td>
                               </tr>   
                                 <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Qty Indent
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtqtyindent" runat="server" CssClass="combotext" 
                        Width="150px" ReadOnly="True"></asp:TextBox></td>
               </tr>
  <tr class="gridHeader" id="Tr2" runat="server">
                  <td align="left" colspan="6"  style="height: 15px"><b>Enter Details</b>
                  </td>
                  </tr> 

                  <tr  class="tableinnertext" id="Tr11" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Qty In Store
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstrqty" runat="server" style="width: 150px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" ></asp:Label>&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                        Font-Underline="True" ForeColor="Blue" onclick="LinkButton1_Click">Click here for Enter the Opening Balance</asp:LinkButton>
                      </td>
                      
               </tr>
                   <tr  class="tableinnertext" id="Tr8" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Debit <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator15" runat="server" ErrorMessage="Select Debit!" 
                        ForeColor="#FF0066" ControlToValidate="ddgrphead" InitialValue="0">*</asp:RequiredFieldValidator>
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddgrphead" runat="server" Height="20px" Width="150px" 
                        AutoPostBack="true" Enabled="true" 
                        onselectedindexchanged="ddgrphead_SelectedIndexChanged" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
               <tr  class="tableinnertext" id="Tr9" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Credit 
                  </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddsubgrphead" runat="server" Height="20px" Width="150px" 
                        AutoPostBack="false" Enabled="true" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
                   <tr class="tableinnertext" id="Tr1" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                         Quantity to be Issued&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                        ControlToValidate="txtissuedqty" ErrorMessage="Enter Issued Qty " 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator>  &nbsp;  
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToCompare="txtqtyindent" ControlToValidate="txtissuedqty" 
                        ErrorMessage="Issued Quantity must be less than Indented Quantity !"  ForeColor="#FF0066" Operator="LessThanEqual" Type="Double">*</asp:CompareValidator> 
                    </td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtissuedqty" runat="server" CssClass="combotext" Width="150px" AutoPostBack="true"
                            onkeypress="return AcceptNumericOnly(event,true,this);" 
                        ontextchanged="txtissuedqty_TextChanged"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Value per Item&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtissuedvalue" ErrorMessage="Enter Issued Value " 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator></td>
                <td style="text-align: left; height: 25px; width: 118px;">
                     <asp:TextBox ID="txtissuedvalue" runat="server" CssClass="combotext" Width="118px" AutoPostBack="true"
                         ReadOnly="false" onkeypress="return AcceptNumericOnly(event,true,this);" 
                        ontextchanged="txtissuedvalue_TextChanged"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Total Value</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txttotal" runat="server" style="width: 119px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false"></asp:TextBox>
                    </td>
                               </tr>   
                               <tr class="tableinnertext" id="Tr7" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Storage Charge %&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                            ControlToValidate="txtstorage" ErrorMessage="Enter Storage Charge %" 
                            ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                       
          </td>
                    <td  style="height: 5px; text-align: left; width: 123px;">
                     <asp:TextBox ID="txtstorage" runat="server" CssClass="combotext" AutoPostBack="true" 
                           Width="150px" ReadOnly="false" onkeypress="return AcceptNumericOnly(event,true,this);" 
                        ontextchanged="txtstorage_TextChanged" ></asp:TextBox>
                            </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Grand Total </td>
                <td colspan="4" style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtgrandtotal" runat="server" style="width: 118px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false"></asp:TextBox>
                    </td>            
                               </tr>

        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                        <asp:Button ID="btnapproval" runat="server" CssClass="btn" 
                        OnClick="btnapproval_Click" Text="Send for Approval" Width="130px" 
                        CausesValidation="true" />   &nbsp;&nbsp;
                        <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />                    
                        &nbsp;
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





