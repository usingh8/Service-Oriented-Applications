<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLoginPage.aspx.cs" Inherits="UserLoginPage" %>
<%@ Register TagPrefix="user" TagName="LoginControl" src="~/Local_Component_Layer/LoginControl.ascx"%>
<%@ Register TagPrefix="user" TagName="ForgetPasswordControl" src="~/Local_Component_Layer/ForgetPasswordControl.ascx"%>
<%  if (Session["usertype"]!=null) { if (Session["usertype"].Equals("admin"))
        {
            Response.Redirect("~/Staff_Pages/AdminDashBoard.aspx");
        }
        else if (Session["usertype"].Equals("member"))
        {
            Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");
        }
        else if (Session["usertype"].Equals("user"))
        {
            Response.Redirect("~/Member_Pages/UserMemberDashBoard.aspx");
        } }%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>User Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   

</head>
<body>
    <form id="form1" runat="server">
       <div class="container" style="margin-top:100px;">
		<div class="row">
			<div class="col-md-offset-2 col-md-8">
				<div class="panel panel-success">
					<div class="panel-heading">
						<h3 class="panel-title"> User Login Box</h3>
                         <asp:Button ID="Button5" style="margin-top:-25px;" class="pull-right btn btn-danger btn-md" runat="server" Text="Go Back" OnClick="Go_Back_Click"   />
					</div>
					       <div class="panel-body" style="padding:25px;">
                                  <div class="col-md-12" style="margin-top:10px; color:red;font-size:18px;text-align:center;"  runat="server" id="label1" />
                           <% if((ViewState["state"] == null)) { %>
                            <user:LoginControl ID="MyLogin" BackColor="#ccccff" RunAt="server" />
                            <asp:HiddenField ID="UserType" value="user" runat="server" />
                             
                            <div  class="col-md-12" style="margin-top:50px;margin-bottom:20px;">
                                <asp:Button ID="Button1" class="col-md-offset-2 col-md-3 btn btn-danger btn-md" runat="server" Text="Login" OnClick="Button1_Click"   />
                                <asp:Button ID="Button2" class="col-md-offset-1 col-md-3 btn btn-danger btn-md" runat="server" Text="Forgot Password" OnClick="Button2_Click"   />
                            </div>
                            <% } %>
                           
                            <% if(ViewState["state"] != null && ViewState["state"].ToString().Equals("forgetpassword")) { %>
                                <user:ForgetPasswordControl ID="ForgetPasswordControl1" BackColor="#ccccff" RunAt="server" />
                                <asp:HiddenField ID="HiddenField1" value="user" runat="server" />
                             
                            <% } %>
                           
                           </div>
                    </div>
                </div>
            </div>
          </div>
    <div>
    
    </div>
    </form>
</body>
</html>


