using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StringCalculator.Api
{
    public static class ApiVersioning
    {
        public const int Min = 1;
        public const int Current = 2;
        public static List<ApiVersion> Versions(int min = Min, int max = Current)
        {
            return Enumerable.Range(min, max - min + 1).Select(x => new ApiVersion(x, 0)).ToList();
        }
    }
}