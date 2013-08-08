using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringSearchCountLib
{
    [ServiceContract]
    public interface IStringSearchCount
    {
        [OperationContract]
        int TimesStringFound(string text, string searched);
    }
}
