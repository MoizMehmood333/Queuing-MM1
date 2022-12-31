using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1.Models.Repository;

namespace WpfApp1.Models.Cache
{

    public class Cache
    {
        //lists 
        private List<Data> m_lstData;
        private List<Result> m_lstResult;
        private List<WorkingOfSimulation> m_lstWorkingSimulation;

        //cache singleton instance
        private static Cache m_GetCacheInstance;


        //properties to access the private lists.
        private uint m_UserID;

        public List<Data> LstData
        {
            get { return m_lstData; }
            set { m_lstData = value; }
        }

        public List<Result> LstResult
        {
            get { return m_lstResult; }
            set { m_lstResult = value; }
        }
        public List<WorkingOfSimulation> LstWorkingSimulation
        {
            get { return m_lstWorkingSimulation; }
            set { m_lstWorkingSimulation = value; }
        }

        //property to access the Cache Singleton Class.
        public static Cache GetCache
        {
            get
            {
                if (m_GetCacheInstance == null)
                {
                    m_GetCacheInstance = new Cache();
                }
                return m_GetCacheInstance;
            }
            set { m_GetCacheInstance = value; }
        }



        //De-serializatoin Method
        public void DeSerializeXMLFiles()
        {
            if (LstData == null)
            {
                LstData = new List<Data>();
                LstResult = new List<Result>();
                LstWorkingSimulation = new List<WorkingOfSimulation>();
                if (File.Exists(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\Data.xml"))
                {
                    var dataXmlSerializer = new XmlSerializer(typeof(List<Data>));
                    using (var reader = new StreamReader(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\Data.xml"))
                    {
                        LstData = (List<Data>)dataXmlSerializer.Deserialize(reader);
                    }
                }
                if (File.Exists(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\Result.xml"))
                {
                    var resultXmlSerializer = new XmlSerializer(typeof(List<Result>));
                    using (var reader = new StreamReader(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\Result.xml"))
                    {
                        LstResult = (List<Result>)resultXmlSerializer.Deserialize(reader);
                    }
                }
                if (File.Exists(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\WorkingSimulation.xml"))
                {
                    var workingOfSimulationXmlSerializer = new XmlSerializer(typeof(List<WorkingOfSimulation>));
                    using (var reader = new StreamReader(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\WorkingSimulation.xml"))
                    {
                        LstWorkingSimulation = (List<WorkingOfSimulation>)workingOfSimulationXmlSerializer.Deserialize(reader);
                    }
                }
            }

            if (LstData != null)
            {
                return;
            }

        }


        //serializing the files
        public void SerializeXMLFiles()
        {
            if (Data.IsAdded)
            {

                var dataXmlSerializer = new XmlSerializer(typeof(List<Data>));
                using (var writer = new StreamWriter(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\Data.xml"))
                {
                    dataXmlSerializer.Serialize(writer, LstData);
                }
                Data.IsAdded = false;
                return;
            }
            var resultXmlSerializer = new XmlSerializer(typeof(List<Result>));
            using (var writer = new StreamWriter(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\Result.xml"))
            {
                resultXmlSerializer.Serialize(writer, LstResult);
            }
            var workingSimulationXmlSerializer = new XmlSerializer(typeof(List<WorkingOfSimulation>));
            using (var writer = new StreamWriter(@"C:\Users\Muhammad Moiz\Desktop\OR Queuing Project\WpfApp1\XML\WorkingSimulation.xml"))
            {
                workingSimulationXmlSerializer.Serialize(writer, LstWorkingSimulation);
            }
        }

        public int GetLastUser()
        {
            if (LstData != null) {
                if (LstData.Count != 0) {
                    return LstData[LstData.Count - 1].Id;                  
                }
                return 0;
            }
            return 0;
        }

    }
}
