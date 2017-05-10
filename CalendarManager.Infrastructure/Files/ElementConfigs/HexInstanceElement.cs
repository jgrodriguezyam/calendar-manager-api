﻿using System.Configuration;

namespace CalendarManager.Infrastructure.Files.ElementConfigs
{
    public class HexInstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("hex", IsKey = true, IsRequired = true)]
        public string Hex
        {
            get { return (string) base["hex"]; }
            set { base["hex"] = value; }
        }
    }
}