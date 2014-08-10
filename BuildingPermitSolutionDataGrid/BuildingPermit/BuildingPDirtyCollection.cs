namespace BuildingPermit
{
    #region

    using System.Collections.Generic;

    #endregion

    public class BuildingPDirtyCollection
    {
        #region Constructors and Destructors

        public BuildingPDirtyCollection()
        {
            this.BuildingPDirtyList = new List<BuildingPDirty>();
        }

        #endregion

        #region Public Properties

        public List<BuildingPDirty> BuildingPDirtyList { get; set; }

        #endregion
    }
}