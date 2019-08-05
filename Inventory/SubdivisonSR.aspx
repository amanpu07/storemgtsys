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
                    DataKeyNames="transidsr" AllowPaging="True" PageSize="50" 
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
                            <ItemStyle HorizontalAlign="left"/>
                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name of Store" SortExpression="istore">
                            <ItemTemplate><%#Eval("istore")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="left"/>
                          
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Name of JE" SortExpression="recdempname">
                            <ItemTemplate><%#Eval("recdempname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="right"/>
                            
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
                  <td align="left" colspan="12"  style="height: 15px"><b>SR-Form</b>
                  </td>
                  </tr>
                   <tr  class="tableinnertext" id="Tr7" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Name 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstore" runat="server" Height="20px" 
                        AutoPostBack="true" style="width: auto; background-color: black; color: white; font-weight: bold;"
                        onselectedindexchanged="ddstore_SelectedIndexChanged"  >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>

            
       <tr  class="tableinnertext" id="Tr20" runat="server" visible="false">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Work Name 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddline" runat="server" Height="20px" Width="150px" 
                     AutoPostBack="True" Enabled="true" onselectedindexchanged="ddline_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
             
                   <tr  class="tableinnertext" id="Tr24" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Estimate 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddestimate" runat="server" Height="20px" Enabled="true" Width="265px" 
                       AutoPostBack="false" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>



              <tr  class="tableinnertext" id="Tr1" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>SR Book No.&nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsrbook" ErrorMessage="Enter SR Book No." ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                      </b> 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsrbook" runat="server" CssClass="combotext" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr3" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>SR Page No.&nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsrpage" ErrorMessage="Enter SR Page No." ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                      </b> 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsrpage" runat="server" CssClass="combotext" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr6" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>SR Date&nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsrdate" ErrorMessage="Enter SR Date" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                      &nbsp;
                      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtsrdate" ErrorMessage="Enter Date" ForeColor="Red" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                      </b>&nbsp;</td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsrdate" runat="server" CssClass="combotext" onblur="DoWaterMarkOnBlur(this,'dd-mm-yyyy')" onfocus="DoWaterMarkOnFocus(this,'dd-mm-yyyy')" Text="dd-mm-yyyy" Width="150px" ClientIDMode="static"></asp:TextBox>
                   
<%--                         <asp:ImageButton ID="ImageButton1" runat="server" Height="17px"
            ImageUrl="~/images/calendar.jpg" onclick="ImageButton1_Click" Width="21px" />
<asp:Calendar ID="Calendar1" runat="server"
            onselectionchanged="Calendar1_SelectionChanged" Visible="False">
        </asp:Calendar>--%>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr8" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>Name of Contractor</b> 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtcontractor" runat="server" AutoPostBack="false" CssClass="combotext" Enabled="true" ReadOnly="false" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr12" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>Employee Code.&nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsdo" ErrorMessage="Enter Employee Code" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                      </b></td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsdo" runat="server" AutoPostBack="false" CssClass="combotext" Enabled="true" ReadOnly="false" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr13" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>Name of JE&nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtje" ErrorMessage="Enter Name of JE" ForeColor="#FF0066">*</asp:RequiredFieldValidator>
                     </b></td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtje" runat="server" AutoPostBack="false" CssClass="combotext" Enabled="true" ReadOnly="false" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>


                <tr class="gridHeader" id="Tr10" runat="server">
                  <td align="left" colspan="12"  style="height: 15px"><b>Items details</b>
                  </td>
                  </tr>  
              <tr class="tableinnertext" id="Tr9" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Item Type</td>
                    <td colspan="5" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Item Name</td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="center">
                    Goods Condition</td>
               <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width:50px;" 
              align="center">
                        Unit</td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="center">
                    Available Qty</td>
                <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="center">
                        Qty Indent</td>
               
                               </tr>          
              <tr class="tableinnertext" id="Tr2" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype1" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype1_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname1" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname1_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype1" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align:center; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit1" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="center" width="70px">
                    <asp:TextBox ID="txtstrqty1" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: center; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent1" runat="server"  CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
                 
              <tr class="tableinnertext" id="Tr5" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype2" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype2_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname2" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname2_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype2" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype2_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit2" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty2" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent2" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
                   
              <tr class="tableinnertext" id="Tr15" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype3" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype3_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname3" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname3_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype3" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype3_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit3" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty3" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent3" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
                
              <tr class="tableinnertext" id="Tr17" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype4" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype4_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname4" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname4_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype4" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype4_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit4" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty4" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent4" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
             
              <tr class="tableinnertext" id="Tr19" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype5" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype5_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname5" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname5_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype5" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype5_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit5" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty5" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent5" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
            
              <tr class="tableinnertext" id="Tr22" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype6" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype6_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname6" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname6_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype6" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype6_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit6" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty6" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent6" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
               
              <tr class="tableinnertext" id="Tr25" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype7" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype7_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname7" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname7_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype7" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype7_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit7" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty7" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent7" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
            
              <tr class="tableinnertext" id="Tr27" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype8" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype8_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname8" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname8_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype8" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype8_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit8" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty8" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent8" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
            
              <tr class="tableinnertext" id="Tr29" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype9" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype9_SelectedIndexChanged" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname9" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname9_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype9" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype9_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit9" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty9" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent9" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        
           
              <tr class="tableinnertext" id="Tr31" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype10" runat="server" AutoPostBack="True" 
                            Height="23px" onselectedindexchanged="dditemtype10_SelectedIndexChanged" 
                            Width="360px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname10" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="True"
                            onselectedindexchanged="dditemname10_SelectedIndexChanged">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype10" runat="server" Height="23px" Width="100px" AutoPostBack="True" 
                        Enabled="true" OnSelectedIndexChanged="ddgoodstype10_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit10" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty10" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent10" runat="server" CssClass="combotext" Width="70px"></asp:TextBox>
                    </td>
               
                               </tr>        

               
               
    <%--   <tr class="tableinnertext" id="row5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Unit 
                       
          </td>
                    <td  style="height: 5px; text-align: left; width: 123px;">
                     <asp:TextBox ID="txtunit" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="150px" ReadOnly="True" Enabled="False"></asp:TextBox>
                            </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Qty Sanctioned</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtqty" runat="server" CssClass="combotext" 
                        Width="118px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>    
                    
                      <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Qty Drawn till date</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                    <asp:TextBox ID="txtqtydrwn" runat="server" CssClass="combotext" Width="118px" 
                        ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>          
                               </tr>
            
      <tr class="tableinnertext" id="Tr5" runat="server">
       <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 144px;" 
              align="left">
                        Name of Contractor</td>
                    <td style="height: 5px; text-align: left; width: 123px;">
                   <asp:TextBox ID="txtcontractor" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="150px" ReadOnly="True" Enabled="False"></asp:TextBox>
          </td>
            <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="200px">
                    Name of JE</td>
                <td style="text-align: left; height: 25px; width: 118px;">
                     <asp:TextBox ID="txtje" runat="server" CssClass="combotext" Width="118px" 
                        AutoPostBack="false" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 135px;" 
              align="left">
                    Employee Code</td>
                <td style="text-align: left; height: 25px; width: 116px;">
                    <asp:TextBox ID="txtsdo" runat="server" CssClass="combotext" Width="119px" 
                        AutoPostBack="false" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
                               </tr>   --%>
                              <%-- <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                       Qty In Store
                    </td>
                <td colspan="5"  style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtstrqty" runat="server" style="width: 150px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
               </tr>
                                <tr class="gridHeader" id="Tr2" runat="server">
                  <td align="left" colspan="6"  style="height: 15px"><b>Enter Details</b>
                  </td>
                  </tr>  --%> 

                 
 
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




