<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMemberDashBoard.aspx.cs" Inherits="UserDashBoard" %>
<%@ Register TagPrefix="user" TagName="NavBarControl" src="~/Local_Component_Layer/NavBar.ascx"%>
<% if(Session["username"]== null){ 
    Response.Redirect("~/Public_Pages/UserLoginPage.aspx");
}%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User DashBoard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   

</head>
<body>
    
    <form id="form1" runat="server">
        <user:NavBarControl ID="MyNavBar"  RunAt="server" />
     <div class="container" style="margin-top:100px;">
		<div class="row">
			<div class="col-md-offset-2 col-md-8">
				<div class="panel panel-success">
					<div class="panel-heading">
						<h3 class="panel-title"> Welcome : <%:Request.Cookies["myCookieId"] != null ? Request.Cookies["myCookieId"]["fullname"] : " User" %></h3>
                        
					</div>
                    <div class="panel-body">

                        <div class="col-md-12">
                             <div class="col-md-12 text-justify" style="margin:25px;">
                                            <h3>Topic Classification Service</h3>
                                           <b> Description: </b>The Topic Classification function assigns documents in 12 thematic categories
                                based on their keywords, idioms and jargon. It can be used to identify the topic of the texts.
           

                             </div>
       

                            <div class="col-md-12" style="margin-top:30px;margin-bottom:25px;">
                
                             <asp:Button class="col-md-offset-3 col-md-6 btn btn-danger btn-md" ID="Button2" runat="server" Text="Topic Classification Svc Try Out Page" OnClick="Button2_Click" />       
                             </div>
             
                       

                         
                        <div class="col-md-12 text-justify" style="margin:25px;">
                                <h3>Document Similarity</h3>
                               <b> Description: </b>The Document Similarity function estimates the degree of similarity between two documents. It can be used to detect duplicate webpages or detect plagiarism.
           

                         </div>
       

                        <div class="col-md-12" style="margin-top:30px;margin-bottom:25px;">
                
                         <asp:Button class="col-md-offset-3 col-md-6 btn btn-danger btn-md" ID="Button4" runat="server" Text="Doc Similarity Service Try Out Page" OnClick="Button3_Click" />       
                         </div>
             
                        <div class="col-md-12 text-justify" style="margin:25px;">
                                <h3>Sentiment Analysis (Public Service )</h3>
                               <b> Description: </b>The Sentiment Analysis function classifies documents as positive, negative or neutral (lack of sentiment) depending on whether they express a positive, negative or neutral opinion.
           

                         </div>
       

                        <div class="col-md-12" style="margin-top:30px;margin-bottom:25px;">
                
                         <asp:Button class="col-md-offset-3 col-md-6 btn btn-danger btn-md" ID="Button1" runat="server" Text="Sentiment Analysis Service Try Out Page" OnClick="Sentiment_Analysis_page_Click" />       
                         </div>
       

                        </div>
                    </div>
                    </div>
                </div>
            </div>
         </div>
          
       
    </form>
</body>
</html>
