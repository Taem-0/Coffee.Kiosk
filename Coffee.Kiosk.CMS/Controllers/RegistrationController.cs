using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class RegistrationController
    {

        private readonly RegistrationValidation _validation;
        private readonly RegistrationService _service;

        public RegistrationController(RegistrationValidation validation, RegistrationService service)
        {
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));    

            _service = service ??throw new ArgumentNullException(nameof(service));
        }

        public ValidationResults Register(RegistrationDTO request)
        {

            ValidationResults result = _validation.Validate(request);

            if (!result.IsValid)
                return result;
            

            _service.RegisterUser(request);

            return result;

        }

    }
}
