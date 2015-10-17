<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CHorEG_v3.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> CHorEG? </h2>
    <h3>Choose which object was invented first...</h3>
    <p>
        <div id="left_col">
            This...
            <asp:ImageButton ID="ImgL" runat="server" ImageAlign="AbsMiddle" Height="300px" Width="300px" OnClick="ImgL_Click" />
            <asp:Button id="btLeft" runat="server" Text="This" OnClick="btLeft_Click"></asp:Button>
        </div>
        <div id="right_col">
            Or that...
            <asp:ImageButton ID="ImgR" runat="server" ImageAlign="AbsMiddle" Height="300px" Width="300px" OnClick="ImgR_Click" />
            <asp:Button id="btRight" runat="server" Text="That" OnClick="btRight_Click"></asp:Button>
        </div>
    </p>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
</asp:Content>