namespace BuildingPermit
{
    #region

    using System;

    #endregion

    public class BuildingP : Dates
    {
        #region Constructors and Destructors

        public BuildingP(BuildingPDirty buildingPDirtyC)
        {
            if (buildingPDirtyC.PassedValidation)
            {
                if (buildingPDirtyC.PermitIdStr != "")
                {
                    PermitId = int.Parse(buildingPDirtyC.PermitIdStr);
                }

                ApplicantFirstName = buildingPDirtyC.ApplicantFirstNameStr;
                ApplicantLastName = buildingPDirtyC.ApplicantLastNameStr;
                SquareFeet = float.Parse(buildingPDirtyC.SquareFeetStr);
                Height = float.Parse(buildingPDirtyC.HeightInFeetStr);
                StartDate = DateTime.Parse(buildingPDirtyC.StartDateStr);

                if (buildingPDirtyC.EstimatedEndDateStr != "")
                {
                    EndDate = DateTime.Parse(buildingPDirtyC.EstimatedEndDateStr);
                }
                else
                {
                    EndDate = DateTime.MaxValue;
                }

                Address = buildingPDirtyC.AddressStr;
                City = buildingPDirtyC.CityStr;
                Zip = buildingPDirtyC.ZipStr;
                RemodelOrNewConstruction = buildingPDirtyC.RemodelOrNewConstructionStr;
            }
        }

        #endregion

        #region Public Properties

        public string Address { get; set; }

        public string ApplicantFirstName { get; set; }

        public string ApplicantLastName { get; set; }

        public string City { get; set; }

        public float Height { get; set; }

        public int PermitId { get; set; }

        public string RemodelOrNewConstruction { get; set; }

        public float SquareFeet { get; set; }

        public string Zip { get; set; }

        #endregion
    }
}