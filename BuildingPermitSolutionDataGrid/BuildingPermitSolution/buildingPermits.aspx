<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buildingPermits.aspx.cs"
    Inherits="BuildingPermitSolution.buildingPermits" %>

<!DOCTYPE html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/reset.css"/>
    <style type="text/css">
        #container
        {
            margin: 0 auto;
            width: 650px;
        }

        .inputLabel
        {
            float: left;
            width: 250px;
        }

        #insertFeedback
        {
            margin-left: 50px;
        }

        *
        {
            font-family: Arial, sans-serif;
        }

        #inputs > div
        {
            margin-bottom: 6px;
        }

        .inputFeedback
        {
            color: red;
        }

        #submitDiv
        {
            margin-left: 40px;
            margin-top: 20px;
        }

        #currentPermitsDiv
        {
            margin-top: 50px;
        }

        #dgPermits
        {
            margin: 0 auto;
            margin-top: 30px;
            width: 1100px;
        }

        #dgPermits td
        {
            padding: 3px;
        }

        #valSum
        {
            color: red;
        }
    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="container">
            <asp:ValidationSummary runat="server" ID="valSum" DisplayMode="BulletList" ShowSummary="true"/>
            <h1>
                Building Permit Application</h1>
            <div id="inputs">
                <div>
                    <span class="inputLabel">Applicant First Name </span>
                    <input id="tbxApplicantFirstName" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxApplicantFirstName">
                        1 to 40 chars</span>
                </div>
                <div>
                    <span class="inputLabel">Applicant Last Name </span>
                    <input id="tbxApplicantLastName" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxApplicantLastName">
                        1 to 40 chars</span>
                </div>
                <div>
                    <span class="inputLabel">Planned Building Square Footage </span>
                    <input id="tbxSquareFeet" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxSquareFeet">
                        Between 500 and 40000</span>
                </div>
                <div>
                    <span class="inputLabel">Planned Building Height in Feet </span>
                    <input id="tbxHeightInFeet" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxHeightInFeet">
                        Between 10 and 95</span>
                </div>
                <div>
                    <span class="inputLabel">Construction Start Date </span>
                    <input id="tbxStartDate" class="date" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxStartDate">
                        Enter future date.</span>
                </div>
                <div>
                    <span class="inputLabel">Estimated Completion Date</span>
                    <input id="tbxEstimatedEndDate" class="date" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxEstimatedEndDate">
                        Must be after start date.</span>
                </div>
                <div>
                    <span class="inputLabel">Site Address</span>
                    <input id="tbxAddress" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxAddress">1
                        to 49 chars</span>
                </div>
                <div>
                    <span class="inputLabel">Site City</span>
                    <input id="tbxCity" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxCity">1 to
                        35 chars</span>
                </div>
                <div>
                    <span class="inputLabel">Site ZIP</span>
                    <input id="tbxZip" type="text" runat="server"/>
                    <span class="inputFeedback" runat="server" visible="false" id="feedbackTbxZip">Follow
                        '12345' or '12345-6789'</span>
                </div>
                <div>
                    <span class="inputLabel">Remodel or New Construction</span>
                    <asp:DropDownList runat="server" ID="ddlRemodelOrNewConstruction">
                        <asp:ListItem Text="New" Value="n"></asp:ListItem>
                        <asp:ListItem Text="Remodel" Value="r"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="submitDiv">
                    <asp:Button ID="submitButton" type="button" Text="Submit" runat="server" OnClick="SubmitButtonClick" /><span
                        id="insertFeedback" runat="server"></span>
                </div>
            </div>
            <div id="currentPermitsDiv">
                <asp:Button runat="server" ID="searchButton" Text="Load Permits" OnClick="SearchButtonClick"/>
                <asp:RadioButton runat="server" ID="rbtAll" Checked="True" AutoPostBack="true" Text="All Permits"
                    GroupName="searchOptions"/>
                <asp:RadioButton runat="server" ID="rbtByNames" AutoPostBack="true" Text="Search by Name"
                    GroupName="searchOptions"/>
                <div>
                    <span class="inputLabel">First Name</span>
                    <input id="tbxFirstNameSearch" type="text" runat="server"/>
                </div>
                <div>
                    <span class="inputLabel">Last Name</span>
                    <input id="tbxLastNameSearch" type="text" runat="server"/>
                </div>
            </div>
        </div>
        <div id="dgDiv">
            <div id="dgButtons">
                <asp:Button runat="server" ID="deleteDgButton" Enabled="False" Text="Delete" OnClick="DeleteRows"/>
                <asp:Button runat="server" ID="editButton" Enabled="False" Text="Edit" OnClick="SaveOrEditRows"/>
                <asp:Button runat="server" ID="saveButton" Enabled="False" Text="Save" OnClick="SaveOrEditRows"/>
                <asp:Button runat="server" ID="cancelButton" Enabled="False" Text="Cancel" OnClick="CancelEdit"/>
            </div>
            <asp:DataGrid ID="dgPermits" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true"/>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" OnCheckedChanged="HeaderCbxCheckedChanged" AutoPostBack="true"
                                runat="server"/>
                        </HeaderTemplate>
                    </asp:TemplateColumn>
                    <%--<asp:BoundColumn HeaderText="Permit ID" DataField="PermitID" ReadOnly="True" />--%>
                    <asp:TemplateColumn HeaderText="Permit ID">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="PermitIDCell" ReadOnly="true" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "PermitID") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="First">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="FirstNameCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "ApplicantFirstName") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Last">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="LastNameCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "ApplicantLastName") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Remodel or New">
                        <ItemTemplate>
                            <%--                            <asp:TextBox runat="server" ID="RemodelOrNewCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem,"RemodelOrNewConstruction") %>'></asp:TextBox>--%>
                            <%--                            <asp:TextBox runat="server" ID="RemodelOrNewCell" Enabled="false" Text='<%# (String.Equals((Eval("RemodelOrNewConstruction").ToString()).ToLower(),"r")) ? "Remodel" : "New" %>'></asp:TextBox>--%>
                            <asp:DropDownList runat="server" ID="RemodelOrNewCell" Enabled="false" AutoPostBack="False"
                                SelectedValue='<%# Eval("RemodelOrNewConstruction") %>'>
                                <asp:ListItem Text="New" Value="n"></asp:ListItem>
                                <asp:ListItem Text="Remodel" Value="r"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Address">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="AddressCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "Address") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="City">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="CityCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="ZIP">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="ZIPCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "ZIP") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Square Feet">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="SquareFeetCell" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "SquareFeet") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Height">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="HeightCell" Enabled="False" Text='<%# DataBinder.Eval(Container.DataItem, "Height") %>'>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Start Date">
                        <ItemTemplate>
                            <asp:TextBox runat="server" Enabled="False" ID="StartDateCell" CssClass="date" Text='<%# Bind("StartDate", "{0:d}") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Estimated End">
                        <ItemTemplate>
                            <asp:TextBox runat="server" Enabled="False" ID="EndDateCell" CssClass="date" Text='<%# Bind("EndDate", "{0:d}") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </div>
    </div>
    </form>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".date").datepicker();
        });
    </script>
</body>
</html> 