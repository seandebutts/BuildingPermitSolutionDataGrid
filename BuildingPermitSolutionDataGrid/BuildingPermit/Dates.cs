namespace BuildingPermit
{
    #region

    using System;

    #endregion

    public abstract class Dates
    {
        #region Fields

        protected DateTime endDate = DateTime.MinValue;

        protected DateTime startDate = DateTime.MinValue;

        #endregion

        #region Public Properties

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        #endregion
    }
}