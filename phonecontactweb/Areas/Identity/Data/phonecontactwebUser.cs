﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace phonecontactweb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the phonecontactwebUser class
public class phonecontactwebUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }


    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string NickName { get; set; }
}

