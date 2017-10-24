<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavBar.ascx.cs" Inherits="Local_Component_Layer_NavBar" %>
    <nav class="navbar navbar-inverse" style="margin-top:30px;"">
          <div class="container-fluid">
            <div class="navbar-header">
              <a class="navbar-brand" onclick="goToHome();return false;">Document Analysis System</a>
            </div>
            <ul class="nav navbar-nav">
                <asp:Button ID="Button4"  runat="server" class="btn btn-danger navbar-btn" Text="Home" OnClick="Button4_Click"   />
                <asp:Button ID="Button6"  runat="server" class="btn btn-danger navbar-btn" Text="Profile" OnClick="Button8_Click"   />
            </ul>
                
            <ul class="nav navbar-nav navbar-right">
              <asp:Button ID="HomeButton"  runat="server" style="display:none" class="btn btn-danger navbar-btn" Text="" OnClick="HomeButton_Click"/>
              <asp:Button ID="Button1"  runat="server" class="btn btn-danger navbar-btn" Text="LogOut" OnClick="Button1_Click"   />
            </ul>
          </div>
      </nav>
   <script type='text/javascript'>
      
       function goToHome() {
             
           $('#HomeButton').trigger('click');
               
        }
       
    </script>