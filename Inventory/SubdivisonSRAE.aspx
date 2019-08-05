<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/SubDivAE.master" AutoEventWireup="true" CodeFile="SubdivisonSRAE.aspx.cs" Inherits="Inventory_SubdivisonSRAE" %>

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
                </b></td>
        </tr>
           <tr class="gridHeader" id="Tr11" runat="server">
            <td align="center" style="height: 20px; width: 723px;">
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Width="209px" 
                    Text="Store Requisition" Font-Bold="True" Font-Size="Large"></asp:Label>
             </td>  
        </tr>
       <tr  class="tableinnertext" id="Tr21" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;">
            
            SR Book No.
                    &nbsp; <asp:TextBox ID="txtserbook" runat="server" CssClass="combotext"  
                           Width="119px" >
                    </asp:TextBox>&nbsp;SR Page No.
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
                    DataKeyNames="transidsr" AllowPaging="True" PageSize="50" 
                    AutoGenerateSelectButton="false" 
                    onselectedindexchanging="GVInfo_SelectedIndexChanging" 
                    ondatabound="GVInfo_DataBound" onsorting="GVInfo_Sorting">
                     <Columns>
                     
                      <asp:ButtonField CommandName="Select"  ItemStyle-HorizontalAlign="center"  HeaderStyle-CssClass="gridHeader"
                             HeaderText="Select" Text="Select"  ButtonType="Image" ImageUrl="~/images/sel.png" />
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
                          <asp:TemplateField HeaderText="Sent to Store" SortExpression="subdivstatus">
                            
                            <ItemTemplate>   
                             <asp:Label ID="lblgridStatus" runat="server" Text='<%#Eval("subdivstatus")%>'></asp:Label> 
                                (<%# Eval("datesentstore").ToString() == "" ? "S/D" : Eval("datesentstore", "{0:dd-MM-yy}")%>)
                             
                             </ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center" ForeColor="White" Font-Bold="true"/>                             
                        </asp:TemplateField>

                         

                        <asp:TemplateField HeaderText="Store Approval" SortExpression="ifield2">
                            <ItemTemplate>
                             <asp:Label ID="lblgridStatusstr" runat="server" Text='<%#Eval("ifield2")%>'></asp:Label>  
                             (<%# Eval("dateapprovestore").ToString() == "" ? "Store" : Eval("dateapprovestore", "{0:dd-MM-yy}")%>)
                         <%--(<%#Eval("dateapprovestore", "{0:dd-MM-yy}")%>)--%>
                           </ItemTemplate>
                             <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center" ForeColor="White" Font-Bold="true"/>   
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="Date" SortExpression="datesentstore">
                            <ItemTemplate><%#Eval("datesentstore", "{0:dd-MM-yy}")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="center"/>
                            
                        </asp:TemplateField>--%>
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


  <tr class="gridHeader" id="Tr7" runat="server">
                  <td align="left" colspan="12"  style="height: 15px"><b>SR-Form</b>
                  </td>
                  </tr>
                   <tr  class="tableinnertext" id="Tr8" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Store Name 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddstore" runat="server" Height="20px" 
                        AutoPostBack="false" style="width: auto; background-color: black; color: white; font-weight: bold;" Enabled="False"  >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>

            
       <tr  class="tableinnertext" id="Tr9" runat="server" visible="false">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Work Name 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="150px" 
                     AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>
             
                   <tr  class="tableinnertext" id="Tr10" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      Estimate 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="ddestimate" runat="server" Height="20px" Enabled="False" Width="265px" 
                       AutoPostBack="false" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;</td>
               </tr>



              <tr  class="tableinnertext" id="Tr12" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>SR Book No.</b> 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsrbook" runat="server" CssClass="combotext" Width="150px" ReadOnly="True"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr13" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>SR Page No. </b> 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsrpage" runat="server" CssClass="combotext" Width="150px" ReadOnly="True"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr14" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>SR Date</b></td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsrdate" runat="server" CssClass="combotext" ReadOnly="True"></asp:TextBox>
                   

                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr15" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>Name of Contractor</b> 
                  </td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtcontractor" runat="server" AutoPostBack="false" CssClass="combotext" Enabled="false" ReadOnly="true" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr16" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>Employee Code.</b></td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtsdo" runat="server" AutoPostBack="false" CssClass="combotext" Enabled="false" ReadOnly="true" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>
              <tr  class="tableinnertext" id="Tr17" runat="server">
                <td colspan="2" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                      <b>Name of JE</b></td>
                <td colspan="10"  style="height: 10px; text-align: left;">
                    <b>
                    <asp:TextBox ID="txtje" runat="server" AutoPostBack="false" CssClass="combotext" Enabled="false" ReadOnly="true" Width="150px"></asp:TextBox>
                    </b></td>
               </tr>


                <tr class="gridHeader" id="Tr18" runat="server">
                  <td align="left" colspan="12"  style="height: 15px"><b>Items details</b>
                  </td>
                  </tr>  
              <tr class="tableinnertext" id="Tr19" runat="server">
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
              <tr class="tableinnertext" id="Tr22" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype1" runat="server" Height="23px" AutoPostBack="false" Enabled="False"
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname1" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype1" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align:center; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit1" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="center" width="70px">
                    <asp:TextBox ID="txtstrqty1" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: center; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent1" runat="server"  CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>               
                               </tr>        
                 
              <tr class="tableinnertext" id="Tr23" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype2" runat="server" Height="23px" AutoPostBack="false" Enabled="False" 
                            Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname2" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype2" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit2" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty2" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent2" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
                   
              <tr class="tableinnertext" id="Tr25" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype3" runat="server" AutoPostBack="false" Enabled="False"
                            Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname3" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype3" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit3" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty3" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent3" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
                
              <tr class="tableinnertext" id="Tr26" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype4" runat="server" AutoPostBack="false" Enabled="False" Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname4" runat="server" Height="23px" Width="350px" AutoPostBack="false" Enabled="False"
                            AppendDataBoundItems="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype4" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit4" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty4" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent4" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
             
              <tr class="tableinnertext" id="Tr27" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype5" runat="server" AutoPostBack="false" Enabled="False" Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname5" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype5" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit5" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty5" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent5" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
            
              <tr class="tableinnertext" id="Tr28" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype6" runat="server" AutoPostBack="false" Enabled="False" Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname6" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype6" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit6" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty6" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent6" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
               
              <tr class="tableinnertext" id="Tr29" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype7" runat="server" AutoPostBack="false" Enabled="False" Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname7" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype7" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit7" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty7" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent7" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
            
              <tr class="tableinnertext" id="Tr30" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype8" runat="server" AutoPostBack="false" Enabled="False"
                            Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname8" runat="server" Height="23px" Width="350px" AutoPostBack="false" Enabled="False"
                            AppendDataBoundItems="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype8" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit8" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty8" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent8" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
            
              <tr class="tableinnertext" id="Tr31" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype9" runat="server" AutoPostBack="false" Enabled="False"
                            Height="23px" Width="360px" style="margin-bottom: 0px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname9" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype9" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                               <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit9" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty9" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent9" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
           
              <tr class="tableinnertext" id="Tr32" runat="server">
       <td colspan="3" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: auto;" 
              align="left">
                        <asp:DropDownList ID="dditemtype10" runat="server" AutoPostBack="false" Enabled="False" Height="23px" Width="360px">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="5" style="height: 5px; text-align: left; width: auto;">
                   <asp:DropDownList ID="dditemname10" runat="server" Height="23px" Width="350px" 
                            AppendDataBoundItems="False" AutoPostBack="false" Enabled="False">
                  <asp:ListItem Value="0">....</asp:ListItem>
                        </asp:DropDownList>
          </td>
       <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
              align="left">
                    <asp:DropDownList ID="ddgoodstype10" runat="server" Height="23px" Width="100px" AutoPostBack="false" Enabled="False">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>

                    </asp:DropDownList></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 50px;">
                    <asp:TextBox ID="txtunit10" runat="server" CssClass="combotext" AutoPostBack="false" 
                           Width="50px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
            <td colspan="1" style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold;" align="left" width="70px">
                    <asp:TextBox ID="txtstrqty10" runat="server" style="width: 70px; background-color: #b3aaaa; color: #690a00; font-weight: bold;" ReadOnly="True"  CssClass="combotext" AutoPostBack="false" ></asp:TextBox></td>
                <td colspan="1" style="text-align: left; height: 25px; width: 70px;">
                     <asp:TextBox ID="txtqtyindent10" runat="server" CssClass="combotext" Width="70px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
               
                               </tr>        
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                       <asp:Button ID="btnreview" runat="server" CssClass="btn" 
                        OnClick="btnreview_Click" Text="Back to Review" Width="130px" 
                        CausesValidation="false" /> &nbsp;&nbsp; <asp:Button ID="btnapproval" runat="server" CssClass="btn" 
                        OnClick="btnapproval_Click" Text="Click for Approval" Width="130px" 
                        CausesValidation="true" />   &nbsp;&nbsp;
                        <asp:Button ID="btnCancel2" runat="server" CssClass="btn" 
                        OnClick="btnCancel2_Click" Text="Cancel" Width="63px" 
                        CausesValidation="False" />                    
                        &nbsp;&nbsp;  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
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





