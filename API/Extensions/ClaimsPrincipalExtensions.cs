﻿
using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string RetreiveEmailFromPrincipal(this ClaimsPrincipal user)
        {
           return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
           // this can be simplified to usereturn user?.FindFirstValue(ClaimTypes.Email)
        }
    }
}
