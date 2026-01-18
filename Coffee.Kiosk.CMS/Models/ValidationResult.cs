using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class ValidationResults
    {

        public bool IsValid => Errors.Count == 0;
        public Dictionary<string, string> Errors { get; } = new();

        public void AddError(string field, string message)
        {
            Errors[field] = message;
        }


    }
}
