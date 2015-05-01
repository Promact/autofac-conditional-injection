using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFacConditionalResolution.Core
{
    public class TwitterRepository : ISocialMediaRepository
    {
        private string _provider = "Twitter";
        public string GetProvider()
        {
            return _provider;
        }
    }
}