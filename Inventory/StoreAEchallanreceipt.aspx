<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreAE.master" AutoEventWireup="true" CodeFile="StoreAEchallanreceipt.aspx.cs" Inherits="Inventory_StoreAEchallanreceipt" %>

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
            <td align="left" style="height: 20px; width: 723px;"><b>Challan Receipt &nbsp;&nbsp; 
                <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label>
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="349px" 
                    Height="18px"></asp:Label>
                </b>&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label></td>
        </tr>
    
       <tr  class="tableinnertext" id="Tr19" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;">
            
            GR Book No.
                    &nbsp; <asp:TextBox ID="txtserbook" runat="server" CssClass="combotext"  
                           Width="119px" >
                    </asp:TextBox>&nbsp;GR Page No.
                     &nbsp;<asp:TextBox ID="txtserpage" runat="server" CssClass="combotext"  
                           Width="119px" >
                    </asp:TextBox>&nbsp; <asp:Button ID="btnsearch" runat="server" CssClass="btn" 
                Text="Search" Width="100px" CausesValidation="false" 
                OnClick="btsearch_Click" />&nbsp; <asp:Button ID="btnsercancel" runat="server" CssClass="btn" 
                Text="Cancel" Width="100px" CausesValidation="False" 
                OnClick="btsearchcancel_Click" />
            
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
                    DataKeyNames="rtxno" AllowPaging="True" PageSize="50" 
                    AutoGenerateSelectButton="false" 
                    onselectedindexchanging="GVInfo_SelectedIndexChanging" 
                    ondatabound="GVInfo_DataBound" onsorting="GVInfo_Sorting">
                     <Columns>
                     
                      <asp:ButtonField CommandName="Select"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Select" Text="Select"  ButtonType="Image" ImageUrl="~/images/sel.png" />

                                                <asp:TemplateField HeaderText="GR No." SortExpression="grbookno">
                            <ItemTemplate><%#Eval("grpageno")%>/<%#Eval("grbookno")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>
                         
                                                <asp:TemplateField HeaderText="GR Date" SortExpression="grdate">
                             <ItemTemplate><%#Eval("grdate","{0:dd-MM-yyyy}")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
                            <ItemTemplate><%#Eval("itemname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="Left"/>
                          
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Unit" SortExpression="unit">
                            <ItemTemplate><%#Eval("unit")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center"/>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grand Total" SortExpression="grandtotal">
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
        <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">
    
                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Receipt Item Details</b>
                  </td>
                  </tr>

       
             <tr  class="tableinnertext" id="row2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    GR No.&nbsp; 
                    
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtgrno" runat="server" CssClass="combotext" Width="200px" 
                        ReadOnly="True"></asp:TextBox>&nbsp;</td>

             </tr>

              <tr class="tableinnertext" id="Tr13" runat="server">
                <td  style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left" >
                    GR Page No. 
                  </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtgrpageno" runat="server" CssClass="combotext"  
                        Width="200px" ReadOnly="True"></asp:TextBox>&nbsp;</td>
                   
             </tr>


       
             <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                    GR Date&nbsp; &nbsp;
                 </td>
                <td style="height: 10px; text-align: left;">

                    <asp:TextBox ID="txtgrdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="200px" ReadOnly="True"></asp:TextBox>
                 &nbsp;&nbsp;</td>
            </tr>

       
            <%-- <tr  class="tableinnertext" id="Tr2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Source 
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstatustype" runat="server" Height="20px" Width="200px" 
                        AutoPostBack="false" Enabled="False"> 
                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>  
                    </asp:DropDownList>&nbsp;</td>
               </tr>--%>


<%--<tr  class="tableinnertext" id="Tr20" runat="server">
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
               </tr>--%>
              <%-- <tr  class="tableinnertext" id="Tr15" runat="server">
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

               <tr class="tableinnertext" id="Tr14" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                       align="left">
                    Date of Goods Receipt</td>
                  <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtreceiptdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                  
                    CssClass="combotext" Width="200px" ReadOnly="True"></asp:TextBox></td>
                             
            </tr>
             <tr  class="tableinnertext" id="row8" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                     Date of Goods Measurement</td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtinspectdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                    CssClass="combotext" Width="200px" ReadOnly="True"></asp:TextBox></td>
               </tr>


               <tr class="tableinnertext" id="Tr16" runat="server">
              <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                       align="left">
                       Challan No.</td>
                      <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtsrwno" runat="server" CssClass="combotext" Width="300px" 
                              TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                    
             </tr>

              <tr class="tableinnertext" id="Tr17" runat="server">
               <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                      align="left">
                        Date of Challan No.</td>
                      <td style="text-align: left; height: 10px;">
                    <asp:TextBox ID="txtsrwdate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                  
                    CssClass="combotext" Width="200px" ReadOnly="True"></asp:TextBox></td>
             </tr>

       
             <tr  class="tableinnertext" id="Tr4" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Indent No. 
                    </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtpono" runat="server" CssClass="combotext" Width="200px" 
                        ReadOnly="True"></asp:TextBox>
                    &nbsp;</td>
               </tr>

       
             <tr  class="tableinnertext" id="Tr6" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Indent Date 
                 </td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtpodate" runat="server"  Text="dd-mm-yyyy" 
                    onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')"
                  
                    CssClass="combotext" Width="200px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;</td>
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
                        </asp:DropDownList>&nbsp;</td>
                </tr>
               <tr class="tableinnertext" id="row4" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Item Name</td>
                    <td colspan="5" style="height: 2px"> 
                        <asp:DropDownList ID="dditemname" runat="server" Height="23px" Width="400px" 
                            AppendDataBoundItems="False" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>
                 <tr class="tableinnertext" id="Tr2" runat="server"> 
                    <td style="height: 2px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
                        align="left">
                    Unit</td>
                    <td colspan="5" style="height: 2px"> 
                         <asp:TextBox ID="txtunit" runat="server" style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True" CssClass="combotext" Width="119px"></asp:TextBox>
                       </td>
                </tr>
      <tr class="tableinnertext" id="row5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                         
                       
           Qty Receipt &nbsp;</td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                         <asp:TextBox ID="txtrquantity" runat="server" CssClass="combotext" 
                             ReadOnly="True" Width="118px"></asp:TextBox>
                         </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Qty Accepted &nbsp;&nbsp;</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtrvalue" runat="server" AutoPostBack="false" 
                        CssClass="combotext" ReadOnly="True" Width="119px"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Qty Value&nbsp;&nbsp;</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtrate" runat="server" AutoPostBack="false" 
                        CssClass="combotext" ReadOnly="True" Width="119px"></asp:TextBox>
                    </td>
            </tr>
      <tr class="tableinnertext" id="Tr5" runat="server" visible="false">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        CST/VAT % </td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                        <asp:TextBox ID="txtvat" runat="server" AutoPostBack="false" 
                            CssClass="combotext" ReadOnly="True" Width="119px"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Sub Total</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtsubtotal" runat="server" style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True" CssClass="combotext" Width="119px"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    ED %
                    </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txted" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
      <tr class="tableinnertext" id="Tr8" runat="server" visible="false">
       <td style="height: 25px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Cess % on ED 
                        </td>
                    <td style="height: 25px; text-align: left; width: 123px;">
                    <asp:TextBox ID="txtcess" runat="server" CssClass="combotext" Width="119px" 
                            AutoPostBack="false" ReadOnly="True"></asp:TextBox>
          </td>
            <td style="height: 25px; font-family: Arial; font-size: 8pt; font-weight: bold;" 
              align="left" width="200px">
                    H Edu Cess % on ED
                    </td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtheducess" runat="server" CssClass="combotext" 
                        AutoPostBack="false" Width="118px" ReadOnly="True"></asp:TextBox>
                    </td>
                <td style="height: 25px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    &nbsp;</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    &nbsp;</td>
            </tr>
      <tr class="tableinnertext" id="Tr9" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Total</td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                        <asp:TextBox ID="txttotal" runat="server" CssClass="combotext" ReadOnly="True" 
                            style="background-color: #b3aaaa; color: #690a00; font-weight: bold;" 
                            Width="119px"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Freight
                    </td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtfreight" runat="server" CssClass="combotext" Width="118px" 
                        AutoPostBack="false" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Price Variation Amt.
                    </td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtprcvar" runat="server" CssClass="combotext" Width="119px" 
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



