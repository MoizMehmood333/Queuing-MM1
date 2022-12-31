using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Models.Cache;
using WpfApp1.Models.Repository;

namespace WpfApp1.ViewModels
{
    public class Simulating
    {
        public static Cache m_cacheInstance = Cache.GetCache;
        public static void simultate() {
            if (m_cacheInstance.LstWorkingSimulation != null && m_cacheInstance.LstWorkingSimulation.Count != 0) {
                m_cacheInstance.LstResult = new List<Result>();
                double totalNumOfWaitingCustomers = 0;
                double totalNumOfCustomers = m_cacheInstance.LstWorkingSimulation.Count;
                double totalWaitingTime = 0;
                double totalServiceTime = 0;
                double totalArrivalTime = 0;
                double totalInterArrivalTime = 0;
                double totalTurnAroundTime = 0;
                

                foreach (WorkingOfSimulation working in m_cacheInstance.LstWorkingSimulation)
                {                    
                    if (working.WaitingTime != 0) {
                        totalNumOfWaitingCustomers++;
                        totalWaitingTime += working.WaitingTime;
                    }
                    totalInterArrivalTime += working.InterArrival;
                    totalTurnAroundTime += working.TurnAroundTime;                    
                }
                foreach (Data data in m_cacheInstance.LstData) {
                    totalServiceTime += data.ServiceTime;
                    totalArrivalTime += data.ArrivalTime;
                }

                double avgWaitingtime = totalWaitingTime / totalNumOfCustomers;
                double probCustHasToWait = totalNumOfWaitingCustomers / totalNumOfCustomers;
                double averageServerTime = totalServiceTime / totalNumOfCustomers;
                double averageTimeBetweenArrival = totalInterArrivalTime / totalNumOfCustomers;
                double averageWaitTimeCustWhoWait = totalWaitingTime / totalNumOfWaitingCustomers;
                double averageTimeCustSpendsInSystem = totalTurnAroundTime / totalNumOfCustomers;
                double meu = totalServiceTime / totalNumOfCustomers;
                double lambda = totalArrivalTime / totalNumOfCustomers;

                double rouge = lambda / meu;
                double lq = rouge * rouge;
                double wq = lq / lambda;
                double q = meu / (meu - lambda);
                double w = wq + (1 / meu);

                m_cacheInstance.LstResult.Add(new Result { Description = "Total Number Of Cutomers who Wait", Results = totalNumOfWaitingCustomers });
                m_cacheInstance.LstResult.Add(new Result { Description = "Total Number Of Cutomers", Results = totalNumOfCustomers });
                m_cacheInstance.LstResult.Add(new Result { Description = "Total Waiting Time", Results = totalWaitingTime });
                m_cacheInstance.LstResult.Add(new Result { Description = "Total Service Time", Results = totalServiceTime });
                m_cacheInstance.LstResult.Add(new Result { Description = "Total InterArrival Time", Results = totalInterArrivalTime });
                m_cacheInstance.LstResult.Add(new Result { Description = "Total Turn Around Time", Results = totalTurnAroundTime });



                m_cacheInstance.LstResult.Add(new Result { Description = "Average Waiting time", Results = avgWaitingtime });
                m_cacheInstance.LstResult.Add(new Result { Description = "Average Server time", Results = averageServerTime });
                m_cacheInstance.LstResult.Add(new Result { Description = "Probability a Customer has to Wait", Results = probCustHasToWait });
                m_cacheInstance.LstResult.Add(new Result { Description = "Average Time Between Arrival", Results = averageTimeBetweenArrival });
                m_cacheInstance.LstResult.Add(new Result { Description = "Average Waiting Time for Customers who wait", Results = averageWaitTimeCustWhoWait });
                m_cacheInstance.LstResult.Add(new Result { Description = "Average Time Customers Spend in System", Results = averageTimeCustSpendsInSystem });
                m_cacheInstance.LstResult.Add(new Result { Description = "Avg Idle Time", Results = totalServiceTime/totalServiceTime });
                m_cacheInstance.LstResult.Add(new Result { Description = "Utilization factor", Results = rouge});
                m_cacheInstance.LstResult.Add(new Result { Description = "Avg no of Customers in queue ", Results = lq} );
                m_cacheInstance.LstResult.Add(new Result { Description = "Average waiting Time in queue", Results = wq});
                m_cacheInstance.LstResult.Add(new Result { Description = "Average Number of Customers in queue when not Empty", Results = q }) ;
                m_cacheInstance.LstResult.Add(new Result { Description = "Average Wait Time in System" , Results = w});



                m_cacheInstance.SerializeXMLFiles();
            }
        }
    }
}
