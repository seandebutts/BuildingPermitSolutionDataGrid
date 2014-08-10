namespace BusinessLogic
{
    #region

    using System;
    using System.Text.RegularExpressions;

    #endregion

    public class GenericValidator
    {
        #region Public Methods and Operators

        /// Check if a given date is within a given range.
        public bool MinMaxDateRangeValidation(
            DateTime min,
            bool isMinimumInclusive,
            DateTime max,
            bool isMaximumInclusive,
            string testStr)
        {
            bool isValid = true;

            try
            {
                DateTime dateTest = DateTime.Parse(testStr);

                if (isMinimumInclusive && isMaximumInclusive && !(dateTest >= min && dateTest <= max))
                {
                    isValid = false;
                }
                else if (isMinimumInclusive && !isMaximumInclusive && !(dateTest >= min && dateTest < max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && isMaximumInclusive && !(dateTest > min && dateTest <= max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && !isMaximumInclusive && !(dateTest > min && dateTest < max))
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        /// This method checks whether a float value is within a specified range.
        public bool MinMaxRangeValidationFloat(
            float min,
            bool isMinimumInclusive,
            float max,
            bool isMaximumInclusive,
            string testStr)
        {
            bool isValid = true;

            float valueAsFloat;

            try
            {
                valueAsFloat = float.Parse(testStr);

                if (isMinimumInclusive && isMaximumInclusive && !(valueAsFloat >= min && valueAsFloat <= max))
                {
                    isValid = false;
                }
                else if (isMinimumInclusive && !isMaximumInclusive && !(valueAsFloat >= min && valueAsFloat < max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && isMaximumInclusive && !(valueAsFloat > min && valueAsFloat <= max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && !isMaximumInclusive && !(valueAsFloat > min && valueAsFloat < max))
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        /// This method checks whether an int value is within a specified range.
        public bool MinMaxRangeValidationInt(
            int min,
            bool isMinimumInclusive,
            int max,
            bool isMaximumInclusive,
            string testStr)
        {
            bool isValid = true;

            int valueAsInt;

            try
            {
                valueAsInt = int.Parse(testStr);

                if (isMinimumInclusive && isMaximumInclusive && !(valueAsInt >= min && valueAsInt <= max))
                {
                    isValid = false;
                }
                else if (isMinimumInclusive && !isMaximumInclusive && !(valueAsInt >= min && valueAsInt < max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && isMaximumInclusive && !(valueAsInt > min && valueAsInt <= max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && !isMaximumInclusive && !(valueAsInt > min && valueAsInt < max))
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        /// Check whether a string's character count is within a given range.
        public bool MinMaxStringLengthValidation(
            int min,
            bool isMinimumInclusive,
            int max,
            bool isMaximumInclusive,
            string testStr)
        {
            bool isValid = true;

            try
            {
                int intStringLength = testStr.Length;

                if (isMinimumInclusive && isMaximumInclusive && !(intStringLength >= min && intStringLength <= max))
                {
                    isValid = false;
                }
                else if (isMinimumInclusive && !isMaximumInclusive && !(intStringLength >= min && intStringLength < max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && isMaximumInclusive
                         && !(intStringLength > min && intStringLength <= max))
                {
                    isValid = false;
                }
                else if (!isMinimumInclusive && !isMaximumInclusive
                         && !(intStringLength > min && intStringLength < max))
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        /// Check whether a given zip code is in valid format (5 or 9 digits, with dash if the latter is the case)
        public bool ZipCodeRegexValidation(string zipStr)
        {
            bool isValid = true;

            try
            {
                if (!(Regex.IsMatch(zipStr, @"^\d{5}(?:[-]\d{4})?$"))) //REGEX
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        #endregion
    }
}