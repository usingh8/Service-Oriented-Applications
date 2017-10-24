<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>Document Analysis</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   

</head>
<body>
    <form id="form1" runat="server">
      <div class="container" style="margin-top:100px;">
		<div class="row">
             
			<div class="col-md-offset-1 col-md-10">
                <div class="jumbotron" style="">
                
                 <h1>Document Analysis System</h1> 
                 <p>We offer several tools to analyze documents</p>
                 
                 
                 <p>1:- Document Similarity Service</p>
                 <p>2:- Document Content Classification Service
                 </p> 
                   <p>3:- Sentiment Analysis (Public Service)</p>
                 <p>Please Select User Type</p>
                  </br>
                      <asp:Button ID="Button1" class="col-md-offset-2 col-md-3 btn btn-primary btn-md" runat="server" Text="Sign In" OnClick="Button1_Click"   />
                     
                     <asp:Button ID="Button2" class="col-md-offset-1 col-md-3 btn btn-primary btn-md" runat="server" Text="Sign Up" OnClick="Button2_Click"   />
                </br>
                </br>
              </div>
                </div>
            </div>
          </div>


    </form>
</body>
</html>
