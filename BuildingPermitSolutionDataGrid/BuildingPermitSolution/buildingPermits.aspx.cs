#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using BuildingPermit;

using BusinessLogic;

using DataAccess;

#endregion

namespace BuildingPermitSolution
{
    public partial class buildingPermits : Page
    {
        #region Public Methods and Operators

        public void CancelEdit(object sender, EventArgs e)
        {
            try
            {
                LoadPermits();
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error reloading permits. ", "");
            }
        }

        public void DeleteRows(object sender, EventArgs e)
        {
            try
            {
                bool atLeastOneCheckboxedChecked = false;
                List<int> permitIdList = new List<int>();

                DataGrid DgPermits = dgPermits;

                foreach (DataGridItem row in DgPermits.Items)
                {
                    var cbx = row.FindControl("CheckBox1");

                    if (cbx is CheckBox)
                    {
                        CheckBox c = (CheckBox)cbx;
                        if (c.Checked)
                        {
                            TableCell tbc = row.Cells[1];

                            foreach (var tbx in tbc.Controls)
                            {
                                if (tbx is TextBox)
                                {
                                    TextBox tb = (TextBox)tbx;

                                    int permitIdInt = int.Parse(tb.Text);
                                    permitIdList.Add(permitIdInt);
                                    atLeastOneCheckboxedChecked = true;
                                }
                            }
                        }
                    }
                }

                if (atLeastOneCheckboxedChecked)
                {
                    DataA dataA = new DataA();

                    dataA.DeletePermits(permitIdList);

                    LoadPermits();
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error deleting permit(s). ", "");
            }
        }

        public void HeaderCbxCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbxHeader = (CheckBox)sender;

                bool atLeastOneCheckboxIsChecked = false;

                foreach (DataGridItem row in dgPermits.Items)
                {
                    var cbx = row.FindControl("CheckBox1");

                    if (cbx is CheckBox)
                    {
                        CheckBox c = (CheckBox)cbx;

                        if (cbxHeader.Checked)
                        {
                            c.Checked = true;
                            atLeastOneCheckboxIsChecked = true;
                        }
                        else
                        {
                            c.Checked = false;
                        }
                    }
                }
                ToggleDeleteAndEditButtons();
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error while toggling checkboxes. ", "");
            }
        }

        public void ReportExceptions(Exception ex, string customMessageToClient, string customMessageToDev)
        {
            CustomValidator err = new CustomValidator();
            err.IsValid = false;
            err.ErrorMessage = customMessageToClient + "If you continue to see this message, contact Web support.";
            Page.Validators.Add(err);
        }

        public void SaveOrEditRows(object sender, EventArgs e)
        {
            try
            {
                if (dgPermits.Items.Count > 0)
                {
                    Button btn = (Button)sender;
                    string senderValue = btn.Text;

                    if (senderValue == "Edit")
                    {
                        cancelButton.Enabled = true;
                        saveButton.Enabled = true;
                    }

                    BuildingPDirtyCollection buildingPDirtyCollection = new BuildingPDirtyCollection();

                    foreach (DataGridItem row in dgPermits.Items)
                    {
                        var cbx = row.FindControl("CheckBox1");

                        if (cbx is CheckBox)
                        {
                            CheckBox cb = (CheckBox)cbx;
                            if (cb.Checked)
                            {
                                BuildingPDirty buildingPDirtySave = new BuildingPDirty();

                                foreach (var c in row.Cells)
                                {
                                    if (c is TableCell)
                                    {
                                        TableCell t = (TableCell)c;

                                        foreach (var ctl in t.Controls)
                                        {
                                            if (ctl is TextBox)
                                            {
                                                TextBox tb = (TextBox)ctl;

                                                if (senderValue == "Edit")
                                                {
                                                    tb.Enabled = true;
                                                }
                                                else if (senderValue == "Save")
                                                {
                                                    string tbId = tb.ID;

                                                    switch (tbId)
                                                    {
                                                        case "PermitIDCell":
                                                            buildingPDirtySave.PermitIdStr = tb.Text;
                                                            break;
                                                        case "FirstNameCell":
                                                            buildingPDirtySave.ApplicantFirstNameStr = tb.Text;
                                                            break;
                                                        case "LastNameCell":
                                                            buildingPDirtySave.ApplicantLastNameStr = tb.Text;
                                                            break;
                                                        //case "RemodelOrNewCell":
                                                        //    buildingPDirtySave.RemodelOrNewConstructionStr = tb.Text;
                                                        //    break;
                                                        case "AddressCell":
                                                            buildingPDirtySave.AddressStr = tb.Text;
                                                            break;
                                                        case "CityCell":
                                                            buildingPDirtySave.CityStr = tb.Text;
                                                            break;
                                                        case "ZIPCell":
                                                            buildingPDirtySave.ZipStr = tb.Text;
                                                            break;
                                                        case "SquareFeetCell":
                                                            buildingPDirtySave.SquareFeetStr = tb.Text;
                                                            break;
                                                        case "HeightCell":
                                                            buildingPDirtySave.HeightInFeetStr = tb.Text;
                                                            break;
                                                        case "StartDateCell":
                                                            buildingPDirtySave.StartDateStr = tb.Text;
                                                            break;
                                                        case "EndDateCell":
                                                            buildingPDirtySave.EstimatedEndDateStr = tb.Text;
                                                            break;
                                                    }
                                                }
                                            }
                                            else if (ctl is DropDownList)
                                            {
                                                DropDownList ddl = (DropDownList)ctl;
                                                if (senderValue == "Edit")
                                                {
                                                    ddl.Enabled = true;
                                                }
                                                else if (senderValue == "Save")
                                                {
                                                    if (ddl.ID == "RemodelOrNewCell")
                                                    {
                                                        buildingPDirtySave.RemodelOrNewConstructionStr = ddl.SelectedValue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (senderValue == "Save")
                                {
                                    buildingPDirtyCollection.BuildingPDirtyList.Add(buildingPDirtySave);
                                }
                            }
                        }
                    }

                    if (senderValue == "Save")
                    {
                        BuildPCollection buildPCollection = new BuildPCollection();

                        foreach (BuildingPDirty buildingPDirty in buildingPDirtyCollection.BuildingPDirtyList)
                        {
                            Validator validatorSave = new Validator(buildingPDirty);
                            if (validatorSave.AllAreValid)
                            {
                                buildingPDirty.PassedValidation = true;
                                BuildingP buildingP = new BuildingP(buildingPDirty);
                                buildPCollection.BuildingPList.Add(buildingP);
                            }
                        }

                        DataA dataA = new DataA();

                        if (dataA.UpdatePermitData(buildPCollection) > 0)
                        {
                            insertFeedback.InnerHtml = "<span style='color:green;font-weight:bold;'>Changes Saved</span>";
                        }
                        else
                        {
                            insertFeedback.InnerHtml =
                                "<span style='color:red;font-weight:bold;'>Errors while saving. Please try again.</span>";
                        }

                        LoadPermits();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error while saving or editing permit(s). ", "");
            }
        }

        public void ToggleDeleteAndEditButtons()
        {
            try
            {
                if (dgPermits.Items.Count > 0)
                {
                    bool isAtLeastOneChecked = false;

                    foreach (DataGridItem row in dgPermits.Items)
                    {
                        var cbx = row.FindControl("CheckBox1");

                        if (cbx is CheckBox)
                        {
                            CheckBox c = (CheckBox)cbx;
                            if (c.Checked)
                            {
                                isAtLeastOneChecked = true;
                                break;
                            }
                        }
                    }

                    if (isAtLeastOneChecked)
                    {
                        deleteDgButton.Enabled = true;
                        editButton.Enabled = true;
                    }
                    else
                    {
                        deleteDgButton.Enabled = false;
                        editButton.Enabled = false;
                        saveButton.Enabled = false;
                    }
                }
                else
                {
                    deleteDgButton.Enabled = false;
                    editButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error toggling buttons. ", "");
            }
        }

        public void ToggleSearchBoxes()
        {
            try
            {
                if (rbtAll.Checked)
                {
                    tbxFirstNameSearch.Disabled = true;
                    tbxLastNameSearch.Disabled = true;
                }
                else
                {
                    tbxFirstNameSearch.Disabled = false;
                    tbxLastNameSearch.Disabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error toggling search boxes. ", "");
            }
        }

        #endregion

        #region Methods

        protected int LoadPermits()
        {
            int rowsReturned = 0;
            try
            {
                DataA dataA = new DataA();

                string firstNameWhereStr = "";
                string lastNameWhereStr = "";

                if (rbtByNames.Checked)
                {
                    firstNameWhereStr = tbxFirstNameSearch.Value;
                    lastNameWhereStr = tbxLastNameSearch.Value;
                }

                DataTable dtPermits = dataA.SearchBuildingPermits(firstNameWhereStr, lastNameWhereStr);

                rowsReturned = dtPermits.Rows.Count;

                if (rowsReturned > 0)
                {
                    dgPermits.DataSource = dtPermits;
                }
                else
                {
                    dgPermits.DataSource = null;
                }
                dgPermits.DataBind();
                ToggleDeleteAndEditButtons();
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error while loading permits. ", "");
            }
            return rowsReturned;
        }

        protected void SearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (LoadPermits() == 0)
                {
                    insertFeedback.InnerHtml = "<span style='color:blue;font-weight:bold;'>No results.</span>";
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Search Error. ", "");
            }
        }

        protected void SubmitButtonClick(object sender, EventArgs e)
        {
            try
            {
                BuildingPDirty buildingPDirty = new BuildingPDirty(
                    tbxApplicantFirstName.Value,
                    tbxApplicantLastName.Value,
                    tbxSquareFeet.Value,
                    tbxHeightInFeet.Value,
                    tbxStartDate.Value,
                    tbxEstimatedEndDate.Value,
                    tbxAddress.Value,
                    tbxCity.Value,
                    tbxZip.Value,
                    ddlRemodelOrNewConstruction.SelectedValue);

                Validator validatorSubmission = new Validator(buildingPDirty);

                if (!validatorSubmission.AllAreValid)
                {
                    buildingPDirty.PassedValidation = false;
                    ToggleInputValidationMessages(validatorSubmission);
                }
                else
                {
                    buildingPDirty.PassedValidation = true;

                    BuildingP buildingP = new BuildingP(buildingPDirty);
                    ToggleInputValidationMessages(validatorSubmission);

                    BuildPCollection buildingPCollection = new BuildPCollection();
                    buildingPCollection.BuildingPList.Add(buildingP);

                    DataA dataA = new DataA();

                    if (dataA.InsertPermitData(buildingPCollection) == 1)
                    {
                        insertFeedback.InnerHtml =
                            "<span style='color:green;font-weight:bold;'>Application submitted</span>";
                    }
                    else
                    {
                        insertFeedback.InnerHtml =
                            "<span style='color:red;font-weight:bold;'>Application submission failed. Please try again.</span>";
                    }

                    LoadPermits();
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error while saving new permit. ", "");
            }
        }

        protected void ToggleInputValidationMessages(Validator validator)
        {
            try
            {
                feedbackTbxApplicantFirstName.Visible = false;
                feedbackTbxApplicantLastName.Visible = false;
                feedbackTbxSquareFeet.Visible = false;
                feedbackTbxHeightInFeet.Visible = false;
                feedbackTbxStartDate.Visible = false;
                feedbackTbxEstimatedEndDate.Visible = false;
                feedbackTbxAddress.Visible = false;
                feedbackTbxCity.Visible = false;
                feedbackTbxZip.Visible = false;
                insertFeedback.InnerHtml = "";

                if (!validator.AllAreValid)
                {
                    if (!(validator.IsApplicantFirstNameValid))
                    {
                        feedbackTbxApplicantFirstName.Visible = true;
                    }

                    if (!(validator.IsApplicantLastNameValid))
                    {
                        feedbackTbxApplicantLastName.Visible = true;
                    }

                    if (!(validator.IsSquareFeetValid))
                    {
                        feedbackTbxSquareFeet.Visible = true;
                    }

                    if (!(validator.IsHeightValid))
                    {
                        feedbackTbxHeightInFeet.Visible = true;
                    }

                    if (!(validator.IsStartDateValid))
                    {
                        feedbackTbxStartDate.Visible = true;
                    }

                    if (!(validator.IsEstimatedEndDateValid))
                    {
                        feedbackTbxEstimatedEndDate.Visible = true;
                    }

                    if (!(validator.IsAddressValid))
                    {
                        feedbackTbxAddress.Visible = true;
                    }

                    if (!(validator.IsCityValid))
                    {
                        feedbackTbxCity.Visible = true;
                    }

                    if (!(validator.IsZipValid))
                    {
                        feedbackTbxZip.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Error while creating validation error message. ", "");
            }
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                ToggleSearchBoxes();
                ToggleDeleteAndEditButtons();

                if (dgPermits.Items.Count == 0)
                {
                    deleteDgButton.Enabled = false;
                    editButton.Enabled = false;
                    saveButton.Enabled = false;
                    cancelButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ReportExceptions(ex, "Page Load Error. ", "");
            }
        }

        #endregion
    }
}