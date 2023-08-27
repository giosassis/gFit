﻿using System;
using System.ComponentModel.DataAnnotations;

namespace gFit.Context.DTOs
{
    public class ResetPasswordDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? NewPassword { get; set; }
    }
}
