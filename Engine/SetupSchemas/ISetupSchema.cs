using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Timespan.Eras;

namespace WarSimulator.Engine.SetupSchemas
{
    public interface ISetupSchema
    {
        public List<Era> SetupSchema();
    }
}
