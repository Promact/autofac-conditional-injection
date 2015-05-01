using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFacConditionalResolution.Core
{
    public class FacebookRepository : ISocialMediaRepository
    {
        private string _provider = "Facebook";
        public string GetProvider()
        {            
            return _provider;
        }
    }
}