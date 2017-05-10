﻿using System.Configuration;

namespace CalendarManager.Infrastructure.Files.ElementConfigs
{
    public class FileInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileInstanceElement) element).Name;
        }
    }
}