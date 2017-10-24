﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopicClassificationTryItPage.aspx.cs" Inherits="Member_Pages_TopicClassificationTryItPage" %>
<%@ Register TagPrefix="user" TagName="NavBarControl" src="~/Local_Component_Layer/NavBar.ascx"%>
<% if(Session["username"]== null){ 
    Response.Redirect("~/Public_Pages/UserLoginPage.aspx");
}%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Topic Classification</title>
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
						<h3 class="panel-title"> Topic Classification</h3>
						
						
					</div>
					<div class="panel-body">
						
           
        <div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
           <b> Description: </b>The Topic Classification function assigns documents in 12 thematic categories
based on their keywords, idioms and jargon. It can be used to identify the topic of the texts.
          

        </div>
        <div class="col-md-12" style="margin:25px;">
          <p> <b> Service Method name:  </b> getTopicOfDocument()</p>
          <p> <b> Parameter name:  </b> String: input </p>
           <p> <b> return type:  </b> String </p>
            <asp:Label  class="col-md-offset-2 col-md-8" style="color:lightblue; margin-top:25px;margin-bottom:25px " ID="Label1" runat="server" Font-Size="Large"></asp:Label>

        </div>
        <div class="col-md-12" style="margin-top:30px;">
             
              <asp:TextBox class="text-justify"   id="TextBox1" style="min-width:100%;height:250px; " placeholder="Paste your document here...(This document should not contain html or xml tags)" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
              
            
        </div>

         <div class="col-md-12" style="margin-top:30px;margin-bottom:25px; width: 839px;">
                
                 <asp:Button class="col-md-offset-3 col-md-4 btn btn-danger btn-md" ID="Button1" runat="server" Text="Get Topic" OnClick="Topic_Classifcation" />       
         </div>
    </div>
    </div>
    </div>
  
     </div>

    </div>

    </form>
</body>
</html>
