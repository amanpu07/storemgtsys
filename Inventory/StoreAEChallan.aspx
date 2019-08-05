<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="StoreAEChallan.aspx.cs" Inherits="Inventory_StoreAEChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
            <td align="left" colspan="6" style="height: 20px; width: 723px;"><b>Store Challan Information&nbsp; 
               <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label>
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="287px" 
                    Height="18px"></asp:Label>
                </b>&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label></td>
        </tr>
        
       <tr  class="tableinnertext" id="Tr8" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;">
            
                Challan Book No. &nbsp; <asp:TextBox ID="txtserbook" runat="server" CssClass="combotext"  
                           Width="119px" >
                    </asp:TextBox>&nbsp;Challan Page No. &nbsp;<asp:TextBox ID="txtserpage" runat="server" CssClass="combotext"  
                           Width="119px" >
                    </asp:TextBox>&nbsp; <asp:Button ID="btnsearch" runat="server" CssClass="btn" 
                Text="Search" Width="100px" CausesValidation="false" 
                OnClick="btsearch_Click" />&nbsp; <asp:Button ID="btnsercancel" runat="server" CssClass="btn" 
                Text="Cancel" Width="100px" CausesValidation="False" 
                OnClick="btsearchcancel_Click" />
            
            </td>
                      
            
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
                    OnPageIndexChanging="GVChallanInfo_PageIndexChanging" Width="100%" 
                    DataKeyNames="itxno" AllowPaging="True" PageSize="50" 
                    AutoGenerateSelectButton="false" 
                    onselectedindexchanging="GVChallanInfo_SelectedIndexChanging" 
                    ondatabound="GVChallanInfo_DataBound" onsorting="GVChallanInfo_Sorting">
                     <Columns>
                      <asp:ButtonField CommandName="Select"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Select" Text="Select"  ButtonType="Image" ImageUrl="~/images/sel.png" />
          
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
                </asp:GridView></td></tr> 
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
                    Challan Book No.
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtchalbookno" runat="server" CssClass="combotext" 
                        Width="200px" ReadOnly="True"></asp:TextBox>&nbsp;</td>

             </tr>

              <tr class="tableinnertext" id="Tr13" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    Challan Page No.
                  </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtchalpageno" runat="server" CssClass="combotext"  
                        Width="200px" ReadOnly="True"></asp:TextBox>&nbsp;</td>
                   
             </tr>


       
             <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                   Challan Date
                 </td>
                <td style="height: 10px; text-align: left;">

                    <asp:TextBox ID="txtchaldate" runat="server" CssClass="combotext" Width="200px" 
                        ReadOnly="True"></asp:TextBox>
                 &nbsp;&nbsp;</td>
            </tr>

       
             <%--<tr  class="tableinnertext" id="Tr2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Source
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstatustype" runat="server" Height="20px" Width="200px" 
                        AutoPostBack="false" Enabled="False"> 
                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem> 
                    </asp:DropDownList></asp:Label></td>
               </tr>


<tr  class="tableinnertext" id="Tr20" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Line Name/Work Name
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddline" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="false" Enabled="False">
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
                   <asp:DropDownList ID="ddfirm" runat="server" Height="20px" Width="400px" 
                        Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>--%>
               <tr  class="tableinnertext" id="Tr18" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Name
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstore" runat="server" Height="20px" Width="400px" 
                        Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>

             <tr  class="tableinnertext" id="Tr3" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Goods Condition
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddstatus" runat="server" Height="23px" Width="200px" 
                        Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                    </asp:DropDownList>&nbsp;</td>
               </tr>

             <tr  class="tableinnertext" id="Tr4" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Indent No./Delivery Order No. 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstoindentno" runat="server" CssClass="combotext" 
                        Width="200px" ReadOnly="True"></asp:TextBox>
                    &nbsp;</td>
               </tr>

       
             <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Indent No./Delivery Order Date 
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstoindentdate" runat="server" CssClass="combotext" 
                        Width="200px" ReadOnly="True"></asp:TextBox></td>
               </tr>

       
              <tr  class="tableinnertext" id="Tr12" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Group Head
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddgrouphead" runat="server" Height="23px" Width="200px" 
                        AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                        
                                         </asp:DropDownList>
                    &nbsp;</td>
               </tr>

 <tr  class="tableinnertext" id="Tr23" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Sub-Group Head 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddsubgrp" runat="server" Height="23px" Width="200px" 
                        Enabled="False">
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
                        <asp:DropDownList ID="dditemtype" runat="server" AutoPostBack="false" 
                            Height="23px" Width="400px" style="margin-bottom: 0px" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                </tr>
               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                        <asp:DropDownList ID="dditemname" runat="server" Height="23px" Width="400px" 
                            AppendDataBoundItems="False" Enabled="False" >
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
                    Qty Requested</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtqtyreq" runat="server" CssClass="combotext" Width="118px" 
                        ReadOnly="True" ></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Qty Issued</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                   <asp:TextBox ID="txtqtyissued" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
      <tr class="tableinnertext" id="Tr5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Rate </td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtrate" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="119px" ReadOnly="True"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Total</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txttotal" runat="server" style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True" CssClass="combotext" Width="119px"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Storage Charges %
          </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtstorage" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="false" ReadOnly="True"></asp:TextBox>
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
          </td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                    <asp:TextBox ID="txtempcode" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false" ReadOnly="True"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Employee Name
          </td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtempname" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Desgination
          </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    
                    <asp:TextBox ID="txtdesg" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>

         </table>
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
               
              <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                        <asp:Button ID="btnapproval" runat="server" CssClass="btn" 
                        OnClick="btnapproval_Click" Text="Click for Approval" Width="130px" 
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




