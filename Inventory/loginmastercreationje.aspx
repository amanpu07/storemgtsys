<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/MPIndex11.master" AutoEventWireup="true" CodeFile="loginmastercreationje.aspx.cs" Inherits="Inventory_loginmastercreationje" %>

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
                &nbsp; 
                <asp:Label
                        ID="lblaeeremarks" runat="server" ForeColor="Red" Width="349px" 
                    Height="18px"></asp:Label>
                </b>&nbsp;  <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ></asp:Label></td>
        </tr>
              
               <tr   runat="server" id="txtbox" width="100%">
         <td > 
            
         <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%">



                 <tr class="gridHeader" id="row1" runat="server">
                  <td align="left" colspan="2" style="height: 15px"><b>Login Details</b>
                  </td>
                  </tr>

         
               <tr  class="tableinnertext" id="Tr15" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 200px;" 
                     align="left">
                    Name of Divison
                  </td>
                <td style="height: 10px; text-align: left;">
                   <asp:DropDownList ID="dddiv" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="True" onselectedindexchanged="dddiv_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label></td>
               </tr>
                <tr  class="tableinnertext" id="Tr1" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
                     align="left">
                      DDO Loc Code</td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtloc" runat="server" CssClass="combotext" Width="100px" 
                        Enabled="False" ReadOnly="True"></asp:TextBox>
                    &nbsp;</td>
               </tr>
               <tr  class="tableinnertext" id="Tr13" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
                     align="left">
                      Name of Sub Divison</td>
                <td style="height: 10px; text-align: left;">
                    <asp:DropDownList ID="ddsubdiv" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="false">
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Red" 
                            Text="*"></asp:Label>
                    &nbsp;</td>
               </tr>
       
                  
                   <tr  class="tableinnertext" id="Tr20" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
                     align="left">
                      User Name (JE)&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtuser" ErrorMessage="Enter User Name" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator></td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtuser" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>
                    &nbsp;</td>
               </tr>
                   <tr  class="tableinnertext" id="Tr22" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
                     align="left">
                      Password (JE)&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtpwd" ErrorMessage="Enter Password" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator></td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtpwd" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>
                    &nbsp;</td>
               </tr>
                   <tr  class="tableinnertext" id="Tr2" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
                     align="left">
                      Employee Code (JE)&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtempcode" ErrorMessage="Enter Employee Code" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator></td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtempcode" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>
                    &nbsp;</td>
               </tr>
                   <tr  class="tableinnertext" id="Tr3" runat="server">
                <td style="height: 10px; font-family: Arial; font-size: 8pt; font-weight: bold; width: 100px;" 
                     align="left">
                      Employee Name (JE)&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtempname" ErrorMessage="Enter Employee Name" 
                        ForeColor="#FF0066">*</asp:RequiredFieldValidator></td>
                <td style="height: 10px; text-align: left;">
                    <asp:TextBox ID="txtempname" runat="server" CssClass="combotext" Width="200px"></asp:TextBox>
                    &nbsp;</td>
               </tr>
                        

         </table>
        <table align="center" border="1" cellpadding="2" cellspacing="2" class="text3" width="100%" >
               
            <tr  class="tableinnertext" id="row9" runat="server">
                <td style="height: 25px; text-align: center;" align="center" colspan="2" >
                    <asp:Button ID="Proceed" runat="server" CssClass="btn" 
                        OnClick="btnProceed_Click"  Text="Save" Width="63px" />&nbsp;&nbsp;
                        <asp:Button ID="btnclear" runat="server" CssClass="btn" 
                        OnClick="btnclear_Click" Text="Click for New Login Details" Width="180px" 
                        CausesValidation="False" />  
                       &nbsp; 
                <asp:Label
                        ID="lblMessage2" runat="server" ForeColor="Red" Width="209px"></asp:Label> </td>
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
              
              
               <tr  class="tableinnertext" id="Tr21" runat="server">
            <td align="left" colspan="6" style="height: 20px; width: 723px;">
            
            Select Divison
                    &nbsp; <asp:DropDownList ID="dddivsearch" runat="server" Height="20px" Width="400px" 
                        AutoPostBack="false" >
                                        <asp:ListItem Selected="True" Value="0">....</asp:ListItem>                     
                    </asp:DropDownList>&nbsp; <asp:Button ID="btnsearch" runat="server" CssClass="btn" 
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
                    AutoGenerateColumns="False" CellPadding="2" Width="100%" 
                    DataKeyNames="username" AllowPaging="True" PageSize="50" 
                    onpageindexchanging="GVInfo_PageIndexChanging">
                     <Columns>                 
                                                                       <asp:TemplateField HeaderText="Sub Div Name" SortExpression="subdivisionname">
                             <ItemTemplate><%#Eval("subdivisionname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="left"/>
                           
                        </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="Div Name" SortExpression="divisonname">
                            <ItemTemplate><%#Eval("divisonname")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="left"/>
                            <%--<HeaderStyle HorizontalAlign="Center" />--%>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="DDO LOC Code" SortExpression="storelocationcode">
                            <ItemTemplate><%#Eval("storelocationcode")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="Center"/>                            
                        </asp:TemplateField> 
                        
                           <asp:TemplateField HeaderText="Role" SortExpression="rolename">
                            <ItemTemplate><%#Eval("rolename")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="center"/>
                          
                        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="User Name" SortExpression="username">
                            <ItemTemplate><%#Eval("username")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                            <ItemStyle HorizontalAlign="left"/>
                          
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Password" SortExpression="userpassword">
                            <ItemTemplate><%#Eval("userpassword")%></ItemTemplate>
                            <HeaderStyle CssClass="gridHeader"  />
                             <ItemStyle HorizontalAlign="left"/>
                            
                        </asp:TemplateField>                        
                        
                        </Columns>
                        <EmptyDataTemplate>No Record(s) Found</EmptyDataTemplate>
                    <PagerStyle ForeColor="#804040" HorizontalAlign="Left" Font-Bold="True"/>
                    <HeaderStyle BackColor="Silver" />
                </asp:GridView>
            </td>
        </tr>
     </table>
</ContentTemplate>
</asp:UpdatePanel>          
</asp:Content>





