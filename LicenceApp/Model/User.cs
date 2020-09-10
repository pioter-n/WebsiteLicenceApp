using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LicenceApp.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }

    }
}
