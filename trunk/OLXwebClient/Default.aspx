<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>. 
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from 
                ASP.NET. If you have any questions about ASP.NET visit 
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Search Here:</h3>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Lahore</asp:ListItem>
        <asp:ListItem>Multan</asp:ListItem>
        <asp:ListItem>Sialkot</asp:ListItem>
        <asp:ListItem>Jehlum</asp:ListItem>
        <asp:ListItem>Karachi</asp:ListItem>
        <asp:ListItem>Islamabad</asp:ListItem>
        <asp:ListItem>Rawalpindi</asp:ListItem>
        <asp:ListItem>other</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Web Client Search" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Agility Pack Search" OnClick="Button2_Click" />
    <br />
    <br />
    
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>OLX</asp:ListItem>
        <asp:ListItem>Hafeez Centre</asp:ListItem>
    </asp:RadioButtonList>
 


    <br />
    <br />

    <asp:Label ID="Label1" runat="server" Text="No record"></asp:Label>

</asp:Content>