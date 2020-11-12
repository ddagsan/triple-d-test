using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.SupportedFile.Formats
{
    public interface ISupportedFormat
    {   
        byte[] GetAsByte();
    }
}
