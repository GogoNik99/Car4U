using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car4U.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string RangeMessage = "Price per month must be a positive number and less than {2} leva";
    }
}
