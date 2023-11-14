<%@ Page Title="Institutions " Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Insitutions.aspx.cs" Inherits="CitizenScienceDB_AN.Insitutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Repeater ID="Institution" runat="server">
            <ItemTemplate>
                <a href="ResearchAreas.aspx?InstituitonID=<%# Eval("InstitutionID") %>">
                    <%# Eval("InstitutionName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>
