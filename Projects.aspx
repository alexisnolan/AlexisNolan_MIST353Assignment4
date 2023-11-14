<%@ Page Title="Projects" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="CitizenScienceDB_AN.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Repeater ID="Projectss" runat="server">
            <ItemTemplate>
                <a href="ProjectDetails.aspx?ProjectID=<%# Eval("ProjectID") %>">
                    <%# Eval("ProjectName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>
