namespace BuildingPermit
{
    #region

    using System.Collections.Generic;

    #endregion

    public class BuildPCollection
    {
        #region Constructors and Destructors

        public BuildPCollection()
        {
            this.BuildingPList = new List<BuildingP>();
        }

        #endregion

        #region Public Properties

        public List<BuildingP> BuildingPList { get; set; }

        #endregion
    }
}