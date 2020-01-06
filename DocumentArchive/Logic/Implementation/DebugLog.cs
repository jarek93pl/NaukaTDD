using DocumentArchive.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation
{
    public class DebugLog : ILog
    {
        public void CatchError(Exception ex, object request)
        {
        }
    }
}
