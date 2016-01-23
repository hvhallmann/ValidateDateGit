using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueVieiraHallmann
{
    //simple class to keep the month data
    public class ClassMonth
    {

        public int nDay = 0;
        public int nMonth = 0;
        public int nYear = 0;
        
        public ClassMonth(int _nDay, int _nMonth, int _nYear)
        {
            nDay = _nDay;
            nMonth = _nMonth;
            nYear = _nYear;
        }

        public int getDay()
        {
            return nDay;
        }

        public int getMonth()
        {
            return nMonth;
        }

        public int getYear()
        {
            return nYear;
        }

        public int getSpecificMonth(int nValue)
        {
            int nReturn = 0;

            switch (nValue)
            {                     
                case 1: return 31;                    
                case 2:
                    if (this.nYear % 4 == 0)
                        return 29;
                    else
                        return 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                    
            }

            return nReturn;
        }


    }
}
