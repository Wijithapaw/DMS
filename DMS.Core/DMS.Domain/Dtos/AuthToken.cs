using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Domain.Dtos
{
    public class AuthToken
    {
        public string  Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
