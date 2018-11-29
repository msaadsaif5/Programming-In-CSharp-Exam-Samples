using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceTypes
{
    public interface IDownloadable
    {
        void Download(string path, string format);
    }
}
