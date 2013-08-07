using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _01.DateTimeServicesLib
{
    [ServiceContract]
    public interface IDateService
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}
