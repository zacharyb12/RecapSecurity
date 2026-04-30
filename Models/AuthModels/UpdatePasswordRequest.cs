using System;
using System.Collections.Generic;
using System.Text;

namespace Models.AuthModels
{
    public class UpdatePasswordRequest
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
