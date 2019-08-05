<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/StoreJE.master" AutoEventWireup="true" CodeFile="testcalendercontrol.aspx.cs" Inherits="Inventory_testcalendercontrol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="17px"
            ImageUrl="~/images/calendar.jpg" onclick="ImageButton1_Click" Width="21px" />
<asp:Calendar ID="Calendar1" runat="server"
            onselectionchanged="Calendar1_SelectionChanged" Visible="False">
        </asp:Calendar>
    </div></asp:Content>

