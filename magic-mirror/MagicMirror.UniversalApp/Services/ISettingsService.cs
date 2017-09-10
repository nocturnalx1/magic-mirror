﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMirror.UniversalApp.Services
{
    public interface ISettingsService
    {
        Task SaveSettings();

        void ReadSettings();
    }
}
