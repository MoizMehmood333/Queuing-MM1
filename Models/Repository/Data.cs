using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Serialization;

namespace WpfApp1.Models.Repository
{
    public class Data
    {
        private int m_id; 
        private double m_arrivalTime;
        private double m_serviceTime;
        private static bool m_isAdded; 
        public int Id { get { return m_id; } set{ m_id = value; } }
        public double ArrivalTime { get { return m_arrivalTime; } set { m_arrivalTime = value; } }
        public double ServiceTime{ get { return m_serviceTime; } set { m_serviceTime = value; } }
        public static bool IsAdded { get{ return m_isAdded; } set { m_isAdded = value; } }
    }
}
