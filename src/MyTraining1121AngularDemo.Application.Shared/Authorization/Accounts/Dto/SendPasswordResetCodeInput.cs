﻿using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace MyTraining1121AngularDemo.Authorization.Accounts.Dto
{
    public class SendPasswordResetCodeInput
    {
        [Required]
        [MaxLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}