<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSignUpPage.aspx.cs" Inherits="Public_Pages_UserSignUpPage" %>

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
						<h3 class="panel-title"> User Signup Box</h3>
                        <asp:Button ID="Button5" style="margin-top:-25px;" class="pull-right btn btn-danger btn-md" runat="server" Text="Go Back" OnClick="Go_Back_Click"   />
					</div>
					       <div class="panel-body" style="padding:25px;">
                              
                           <div class="col-md-12" style="margin-top:25px; margin-bottom:25px; text-align:center;">
                           <h2> Sign Up</h2>
                   </div>    
                   <div class="col-md-12">
                            <div class="col-md-offset-3 col-md-8" style="margin-top:10px;text-align:center; color:blue;font-size:18px;"  runat="server" id="label1" />
                    </div>
                   <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <div class="col-md-offset-1 col-md-5" style="text-align:right"> Full Name : </div>
                       <asp:TextBox class="col-md-3" runat="server" Text="" ID="textbox1"></asp:TextBox>
                   </div>
                   <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <div class="col-md-offset-1 col-md-5" style="text-align:right"> UserName : </div>
                       <asp:TextBox class="col-md-3"  runat="server" Text="" ID="textbox2"></asp:TextBox>
                   </div>
                  
                 
                     
                        <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <div class="col-md-offset-1 col-md-5" style="text-align:right"> New Password : </div>
                       <asp:TextBox class="col-md-3"  runat="server"  type="password" Text="" ID="textbox3"></asp:TextBox>
                        </div>
                        <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <div class="col-md-offset-1 col-md-5" style="text-align:right"> Confirm New Password : </div>
                       <asp:TextBox class="col-md-3"  runat="server" type="password" Text="" ID="textbox4"></asp:TextBox>
                        </div>
                      <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                       <asp:RadioButton id="radio1" class="col-md-offset-3 col-md-3" style="text-align:right"  Value="User" Text="User" runat="server" GroupName="UserType"></asp:RadioButton>
                       <asp:RadioButton id="radio2" runat="server" class="col-md-offset-1 col-md-3" style="text-align:left" Value="Staff" Text="Staff" GroupName="UserType"></asp:RadioButton>
                    
                        </div>
                    <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">
                         <div class="col-md-12">
                          <asp:Image class="col-md-offset-3 col-md-6" ID="Image1" runat="server" />
                             </div>
                        <div class="col-md-12" style="margin-top:15px;">
                         <div class="col-md-offset-1 col-md-5" style="text-align:right"> Enter Captcha : </div>
                            <asp:TextBox class="col-md-3"  runat="server" type="password" Text="" ID="textbox5"></asp:TextBox>
                         </div>
                   </div>
                               
                  <div class="col-md-12" style="margin-top:25px; margin-bottom:25px;">

                      
                      <asp:Button class="col-md-offset-4 col-md-3 btn btn-danger btn-md" OnClick="SignUp_click" Text="Sign Up" runat="server" ID="SignUp"/>
                       
                       <asp:Button ID="Button2" class="col-md-offset-4 col-md-3 btn btn-danger btn-md" style="display:none;" OnClick="Button2_click" Text="Sign Up" runat="server" />
                   </div>
                    
                            
                           
                         
                           
                           </div>
                    </div>
                </div>
            </div>
          </div>
    <div>
    
    </div>
    </form>
       <script type='text/javascript'>
           $(document).ready(function () {
             
               if ($('#label1').text() == "Account Created Successfully!" ) {
                   alert($('#label1').text());
                   $('#Button2').trigger('click');

               }
           });

    </script>
</body>
</html>