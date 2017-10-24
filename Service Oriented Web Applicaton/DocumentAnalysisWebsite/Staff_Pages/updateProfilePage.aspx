<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateProfilePage.aspx.cs" Inherits="updateProfilePage" %>
<%@ Register TagPrefix="user" TagName="NavBarControl" src="~/Local_Component_Layer/NavBar.ascx"%>
<% if(Session["username"]== null){ 
    Response.Redirect("~/Public_Pages/UserLoginPage.aspx");
}%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member DashBoard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
       <script type='text/javascript'>
      
        function deleteUser() {

            if (confirm("Do you really want to delete this user?"))
            {
                $('#Button7').trigger('click');
            }
               
        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
       <user:NavBarControl ID="MyNavBar"  RunAt="server" />
    <div>
        <div class="container" >
		<div class="row">
			<div class="col-md-offset-2 col-md-8">
				<div class="panel panel-success">
					<div class="panel-heading">
						<h3 class="panel-title"> Welcome : <%:Request.Cookies["myCookieId"] != null ? Request.Cookies["myCookieId"]["fullname"] : " User" %></h3>
                          <asp:Button ID="Button5" style="margin-top:-25px;" class="pull-right btn btn-danger btn-md" runat="server" Text="Go Back" OnClick="Button4_Click"   />
					</div>
                    <div class="panel-body" style="font-size:18px;">
                   <div class="col-md-12" style="margin-top:25px; margin-bottom:25px; text-align:center;">
                           <h2> User's Profile</h2>
                   </div>  
                    <div class="col-md-12">
                            <div class="col-md-offset-3 col-md-8" style="margin-top:10px; text-align:center; color:blue;font-size:18px;"  runat="server" id="label1" />
                    </div>
                   <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <div class="col-md-offset-2 col-md-3"> Full Name : </div>
                       <asp:TextBox class="col-md-3" runat="server" Text="" ID="textbox1"></asp:TextBox>
                   </div>
                   <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <div class="col-md-offset-2 col-md-3"> UserName : </div>
                       <asp:TextBox class="col-md-3" readonly="true" runat="server" Text="" ID="textbox2"></asp:TextBox>
                   </div>

                   <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">
                       <div class="col-md-12">
                       <div class="col-md-offset-2 col-md-3"> Password : </div>
                       <asp:TextBox class="col-md-3" runat="server" type="password" Text="" ID="textbox3"></asp:TextBox>
                       <asp:Button Text="Reset Password" class="col-md-offset-1 col-md-3 btn btn-danger" runat="server" OnClick="Button2_Click" ID="button2"/>
                       </div>
                       
                    </div>
                  <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                      
                      <asp:Button class="col-md-offset-4 col-md-3 btn btn-danger btn-md" OnClick="Button3_Click" Text="Update" runat="server" ID="button3"/>
                      <%if (Session["usertype"].Equals("admin"))
                          { %>
                            <button class="col-md-offset-1 col-md-3 btn btn-danger" onclick="deleteUser();return false;">Delete</button>
                     <%} %>
                          <asp:Button style="display:none" class="col-md-offset-4 col-md-3 btn btn-danger btn-md" OnClick="Button7_Click" Text="Delete" runat="server" ID="Button7"/>  
                      </div>
                    
                      </div>  
                        </div>
                    </div>
                </div>
  
            </div>
    </div>
    </form>
       <script type='text/javascript'>
           $(document).ready(function () {

               if ($('#label1').text() == "User Removed Successfully") {
                   alert($('#label1').text());
                   $('#Button5').trigger('click');

               }
           });

    </script>
</body>
</html>
