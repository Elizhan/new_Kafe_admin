using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.ViewModels
{
    interface ICommandMethod
    {
       void CreateMethod(object p);
        void EditMethod(object p);
        void DeleteMethod(object p);
    }
}
