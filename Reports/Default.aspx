<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Reports._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
           
                <h2>Reports</h2>
            </hgroup>
            <p>
                Select report from the list below, enter report paramaters and export once report is displayed

            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Select the report:</h3>
    <ol id="ReportList" runat="server" class="round">
      
    </ol>
</asp:Content>
