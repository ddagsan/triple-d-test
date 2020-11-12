using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    /// <summary>
    /// it represents national and religious holidays for specific country
    /// </summary>
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
