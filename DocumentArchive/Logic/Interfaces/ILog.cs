﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Interfaces
{
    public interface ILog
    {
        void CatchError(Exception ex, object request);
    }
}
