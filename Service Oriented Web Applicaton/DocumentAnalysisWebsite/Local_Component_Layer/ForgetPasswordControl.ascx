<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForgetPasswordControl.ascx.cs" Inherits="ForgetPasswordControl" %>
<div style="font-size:20px;"> 
<div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
                             <div  class="col-md-offset-2 col-md-8" style="font-size:25px;">    Please Enter Your Username
                              </div>
  </div>
 <div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
                             <div  class="col-md-offset-2 col-md-3" style="text-align:right">      Username : </div>
                            <div  class=" col-md-7"> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
 </div>
<div class="col-md-12" style="margin-top:25px;margin-bottom:25px;">
        		      <div class="col-md-12" style="margin-top:10px; color:blue;font-size:18px;text-align:center;"  runat="server" id="label1" />

</div>
 <div  class="col-md-offset-4 col-md-4" style="margin-top:50px;margin-bottom:20px;">
                                <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Forgot Password" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" class="btn btn-danger" runat="server" Visible="false" Text="Go to Login" OnClick="Button2_Click" />
</div>
</div>