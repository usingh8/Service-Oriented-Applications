<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>XML Processing Services</title>
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
						<h3 class="panel-title"> Service 1: Search Key in XML</h3>
					</div>
					<div class="panel-body" style="padding:25px;">				
                        <div class="col-md-12" style="margin-top:25px;margin-bottom:50px;">
                         <div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter the URL of XML </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
                        </div>
                        <div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
                            <div  class="col-md-offset-2 col-md-4">      Enter the Key to Search: </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
                        </div>
                          <div  class="col-md-offset-4 col-md-4" style="margin-top:50px;margin-bottom:20px;">
                                <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Search Key" OnClick="Button1_Click"  />
                          </div>
                          <div  class="col-md-offset-1 col-md-10" style="margin-top:25px;">   
                                <asp:Label runat="server" ID="Label1" Text="" Visible="false" Font-Size="20pt" ></asp:Label>
                          </div>
                        <div class="col-md-offset-3 col-md-6" style="margin-top:30px;">
             
                          <asp:TextBox class="text-justify"  Visible="false"  id="TextBox3" Font-Size="15pt" style="min-width:100%;height:230px; "  runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        </div>
                    </div>
               </div>
        </div>


        <div class="col-md-offset-2 col-md-8">
				<div class="panel panel-success">
					<div class="panel-heading">
						<h3 class="panel-title"> Service 2: Add Person in XML</h3>
					</div>
					<div class="panel-body" style="padding:25px;">				
                        <div class="col-md-12" style="margin-top:25px;margin-bottom:50px;">

                          <div  class="col-md-offset-3 col-md-6" style="margin-top:25px;margin-bottom:25px;">   
                                <asp:Label runat="server" ID="Label2" Text="" Visible="false" Font-Size="20pt" ></asp:Label>
                          </div>
                         <div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter the URL of XML </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter First Name </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></div>
                        </div>
                        <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter Last Name </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter User Id </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter Password </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox7" type="password" runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Encryption</div>
                            <div  class=" col-md-6">  <asp:CheckBox ID="CheckBox1" runat="server" /></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter Work Phone </div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox8" type="number"  runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter Cell Phone</div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox9" type="number" runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Enter Cell Provide</div>
                            <div  class=" col-md-6"> <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></div>
                        </div>
                         <div class="col-md-12" style="margin-top:10px;margin-bottom:10px;">
                             <div  class="col-md-offset-2 col-md-4">      Select Category</div>
                             <select id="testSelect" runat="server" class=" col-md-offset-1 col-md-2" name="D1">
                                                        <option value="Friend">Friend</option>
                                                        <option value ="Family">Family</option>
                                                        <option value ="Work">Work</option>
                              </select>  
                                           

                            
                        </div>
                       
                          <div  class="col-md-offset-4 col-md-4" style="margin-top:50px;margin-bottom:20px;">
                                <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Add Person" OnClick="Button2_Click"  />
                                <button  id='Button3' class="btn btn-danger" runat="server"  value='Reset' onclick="document.getElementById('form1').reset();">Reset</button>
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
