﻿using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}