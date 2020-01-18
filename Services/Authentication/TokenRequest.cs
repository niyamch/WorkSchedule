﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Service.Authentication
{
    public class TokenRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }

}
