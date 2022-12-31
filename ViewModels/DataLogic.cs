using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Cache;
using WpfApp1.Models.Repository;

namespace WpfApp1.ViewModels
{
    public class DataLogic
    {

        public static Cache m_chacheInstance = Cache.GetCache;

        public static void InsertDataInList(double arrivalTime, double serviceTime)
        {
            int id = m_chacheInstance.GetLastUser();
            DataLogic dataLogicInstance = new DataLogic();
            m_chacheInstance.LstData.Add(new Data { Id = id + 1, ArrivalTime = arrivalTime, ServiceTime = serviceTime });
            Data.IsAdded = true;
            m_chacheInstance.SerializeXMLFiles();
        }

    }
}
