using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using WpfApp1.Models.Cache;
using WpfApp1.Models.Repository;

namespace WpfApp1.ViewModels
{
    public class Working
    {
        public static Cache m_cacheInstance = Cache.GetCache;
        public static void SimulationWorkingCode() {
            if (m_cacheInstance.LstData != null && m_cacheInstance.LstData.Count != 0) {
                m_cacheInstance.LstWorkingSimulation = new List<WorkingOfSimulation>();
                double currStartTime = 0;
                double currEndTime = 0;
                double currInterArrivalTime = m_cacheInstance.LstData[0].ArrivalTime;
                double currResponseTime = 0;
                double currTurnAroundTime = 0;
                double currWaitingTime = 0;

                foreach (Data data in m_cacheInstance.LstData)
                {
                    if (data.ArrivalTime > currStartTime)
                    {
                        currStartTime = data.ArrivalTime;
                    }
                    currEndTime = currStartTime + data.ServiceTime;
                    currInterArrivalTime = data.ArrivalTime-currInterArrivalTime;
                    currResponseTime = currStartTime - data.ArrivalTime;
                    currTurnAroundTime = currEndTime - data.ArrivalTime;
                    currWaitingTime = currTurnAroundTime - data.ServiceTime;
                    m_cacheInstance.LstWorkingSimulation.Add(new WorkingOfSimulation
                    {
                        InterArrival = currInterArrivalTime,
                        StartTime = currStartTime,
                        EndTime = currEndTime,
                        ResponseTime = currResponseTime,
                        TurnAroundTime = currTurnAroundTime,
                        WaitingTime = currWaitingTime
                    }) ;
                    currInterArrivalTime = data.ArrivalTime;
                    currStartTime = currEndTime;
                }
                m_cacheInstance.SerializeXMLFiles();

            }
        }
    }
}
