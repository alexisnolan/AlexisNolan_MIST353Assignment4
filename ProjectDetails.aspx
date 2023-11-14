<%@ Page Title="ProjectDetails" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="CitizenScienceDB_AN.ProjectDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <%--Gridview not repeater becuase there is not data being pulled / connections off of them--%> 
    
    <main>
        <asp:gridview runat="server" ID="ProjectDetailss"></asp:gridview>
    </main>

</asp:Content>
