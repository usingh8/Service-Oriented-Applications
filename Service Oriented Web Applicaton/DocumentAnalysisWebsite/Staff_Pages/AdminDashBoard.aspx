<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminDashBoard.aspx.cs" Inherits="AdminDashBoard" %>
<%@ Register TagPrefix="user" TagName="NavBarControl" src="~/Local_Component_Layer/NavBar.ascx"%>
<% if(Session["username"]== null){ 
    Response.Redirect("~/Public_Pages/UserLoginPage.aspx");
}
   if(!Session["usertype"].Equals("admin")){ 
        Session.Clear();
    Response.Redirect("~/Public_Pages/UserLoginPage.aspx");
}
 %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member DashBoard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   
            <script type='text/javascript'>
      
        function goToUpdatePage(clck) {
            $('#userName').val(clck);
             
            $('#Button2').trigger('click');
               
        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <user:NavBarControl ID="MyNavBar"  RunAt="server" />
    <div class="container" >
		<div class="row">
			<div class="col-md-offset-2 col-md-8">
				<div class="panel panel-success">
					<div class="panel-heading">
						<h3 class="panel-title"> Welcome : <%:Request.Cookies["myCookieId"] != null ? Request.Cookies["myCookieId"]["fullname"] : " User" %></h3>
                         
					</div>
                    <div class="panel-body">
                         
                        <div class="col-md-offset-2 col-md-10"><h2> List of All Staff Members and Users </h2></div>
                     <asp:Button ID="Button2" runat="server" style="display:none" Text="" OnClick="Button2_Click" />
                        <div class="col-md-offset-1 col-md-10"  runat="server" style="margin-top:50px; border: 1px solid lightblue; min-height:300px;" id="myDiv">
                        </div>
                        <asp:HiddenField ID="userName" runat="server" value=""/>
                        </div>
                        </div>
                    </div>
                </div>
  
            </div>
        
    </form>
</body>
</html>
