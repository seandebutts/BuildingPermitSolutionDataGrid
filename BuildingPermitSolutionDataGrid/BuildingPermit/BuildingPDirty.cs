namespace BuildingPermit
{
    public class BuildingPDirty
    {
        #region Fields

        private string addressStr = "";

        private string applicantFirstNameStr = "";

        private string applicantLastNameStr = "";

        private string cityStr = "";

        private string estimatedEndDateStr = "";

        private string heightInFeetStr = "";

        private string permitIdStr = "";

        private string remodelOrNewConstructionStr = "";

        private string squareFeetStr = "";

        private string startDateStr = "";

        private string zipStr = "";

        #endregion

        #region Constructors and Destructors

        public BuildingPDirty()
        {
            PassedValidation = false;
        }

        public BuildingPDirty(
            string applicantFirstNameStrC,
            string applicantLastNameStrC,
            string squareFeetStrC,
            string heightInFeetStrC,
            string startDateStrC,
            string estimatedEndDateStrC,
            string addressStrC,
            string cityStrC,
            string zipStrC,
            string remodelOrNewConstructionStrC)
        {
            PassedValidation = false;
            ApplicantFirstNameStr = applicantFirstNameStrC;

            ApplicantLastNameStr = applicantLastNameStrC;

            SquareFeetStr = squareFeetStrC;

            HeightInFeetStr = heightInFeetStrC;

            StartDateStr = startDateStrC;

            EstimatedEndDateStr = estimatedEndDateStrC;

            AddressStr = addressStrC;

            CityStr = cityStrC;

            ZipStr = zipStrC;

            RemodelOrNewConstructionStr = remodelOrNewConstructionStrC;
        }

        public BuildingPDirty(
            string applicantFirstNameStrC,
            string applicantLastNameStrC,
            string squareFeetStrC,
            string heightInFeetStrC,
            string startDateStrC,
            string estimatedEndDateStrC,
            string addressStrC,
            string cityStrC,
            string zipStrC,
            string remodelOrNewConstructionStrC,
            string permitIdStrC)
        {
            PassedValidation = false;
            ApplicantFirstNameStr = applicantFirstNameStrC;

            ApplicantLastNameStr = applicantLastNameStrC;

            SquareFeetStr = squareFeetStrC;

            HeightInFeetStr = heightInFeetStrC;

            StartDateStr = startDateStrC;

            EstimatedEndDateStr = estimatedEndDateStrC;

            AddressStr = addressStrC;

            CityStr = cityStrC;

            ZipStr = zipStrC;

            PermitIdStr = permitIdStrC;

            RemodelOrNewConstructionStr = remodelOrNewConstructionStrC;
        }

        #endregion

        #region Public Properties

        public string AddressStr
        {
            get
            {
                return addressStr;
            }
            set
            {
                addressStr = value;
            }
        }

        public string ApplicantFirstNameStr
        {
            get
            {
                return applicantFirstNameStr;
            }
            set
            {
                applicantFirstNameStr = value;
            }
        }

        public string ApplicantLastNameStr
        {
            get
            {
                return applicantLastNameStr;
            }
            set
            {
                applicantLastNameStr = value;
            }
        }

        public string CityStr
        {
            get
            {
                return cityStr;
            }
            set
            {
                cityStr = value;
            }
        }

        public string EstimatedEndDateStr
        {
            get
            {
                return estimatedEndDateStr;
            }
            set
            {
                estimatedEndDateStr = value;
            }
        }

        public string HeightInFeetStr
        {
            get
            {
                return heightInFeetStr;
            }
            set
            {
                heightInFeetStr = value;
            }
        }

        public bool PassedValidation { get; set; }

        public string PermitIdStr
        {
            get
            {
                return permitIdStr;
            }
            set
            {
                permitIdStr = value;
            }
        }

        public string RemodelOrNewConstructionStr
        {
            get
            {
                return remodelOrNewConstructionStr;
            }
            set
            {
                remodelOrNewConstructionStr = value;
            }
        }

        public string SquareFeetStr
        {
            get
            {
                return squareFeetStr;
            }
            set
            {
                squareFeetStr = value;
            }
        }

        public string StartDateStr
        {
            get
            {
                return startDateStr;
            }
            set
            {
                startDateStr = value;
            }
        }

        public string ZipStr
        {
            get
            {
                return zipStr;
            }
            set
            {
                zipStr = value;
            }
        }

        #endregion
    }
}