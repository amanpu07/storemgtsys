<%@ Page Title="" Language="C#" MasterPageFile="~/Home/MasterLogin.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="Home_LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box" align="right">
       <br /><br /><br />
       <br /><br />
         <br /><br />
          <br /><br />
          <br /><br />
          <br /><br /><br /><br />
          <br /><br />
        <table id="tbl01">
            <tr>
                <td>User ID:</td>
                <td><asp:TextBox ID="txtUser" runat="server" EnableViewState="false" MaxLength="100" Width="150px"></asp:TextBox></td>
            </tr>
            <tr style="height:35px; padding-top:0px;">
                <td>Password:</td>
                <td><asp:TextBox ID="txtPwd" runat="server" EnableViewState="false" MaxLength="100" TextMode="Password"  Width="150px"></asp:TextBox></td>
            </tr>
        </table>
            <asp:Label ID="lblerr" runat="server" ForeColor="red"  align="right"></asp:Label>
            <asp:Button ID="btnLogin" CssClass="button1 blue" runat="server" Text="Login" Width="80px"
            OnClick="btnLogin_Click"  />            
         <br /><br /><br />  
        <font size="3" color="#b3a386"><strong>STORE MANAGEMENT SYSTEM</strong></font>
         <br />  <br />
    </div>
      

</asp:Content>


