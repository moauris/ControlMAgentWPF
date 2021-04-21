using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CtmaApp.ValidationRules
{
    public class IPAddressValidation : ValidationRule
    {
        public bool IsIPv4 { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string ipAddressString = (string)value;
            IPAddress iPAddress;

            if (IPAddress.TryParse(ipAddressString, out iPAddress))
            {
                int ByteLen = iPAddress.GetAddressBytes().Length;
                if (IsIPv4 && (ByteLen == 4))
                {
                    return ValidationResult.ValidResult;
                }
                if (!IsIPv4 && (ByteLen == 16))
                {
                    return ValidationResult.ValidResult;
                }
            }
            string whichIP = IsIPv4 ? "IPv4" : "IPv6";
            return new ValidationResult(false, $"{value.ToString()} cannot be parsed as an valid {whichIP} Address.");
            
        }
    }
}
