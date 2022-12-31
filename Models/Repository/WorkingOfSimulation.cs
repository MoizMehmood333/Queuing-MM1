using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models.Repository
{
    public class WorkingOfSimulation
    {
        private double m_interArrival;
        private  double m_startTime;
        private  double m_endTime;
        private double m_turnAroundTime;
        private  double m_waitingTime;
        private double m_responseTime;
        public double InterArrival { get { return m_interArrival; } set { m_interArrival= value; } }
        public double StartTime { get { return m_startTime; } set { m_startTime = value; } }
        public double EndTime { get { return m_endTime; } set { m_endTime= value; } }
        public double TurnAroundTime { get { return m_turnAroundTime; } set { m_turnAroundTime= value; } }
        public double WaitingTime{ get { return m_waitingTime; } set { m_waitingTime= value; } }
        public double ResponseTime{ get { return m_responseTime; } set { m_responseTime= value; } }









    }
}
