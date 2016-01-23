using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueVieiraHallmann
{
    //simple class to keep the month data
    public static class ClassMonth
    {
        public static int getSpecificMonthMaxDay(int nMonth, int nYear)
        {            
            int nReturn = 0;

            switch (nMonth)
            {                     
                case 1: return 31;                    
                case 2: return 28;
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

         //For February code
         //if (nYear % 4 == 0)
         //               return 29;
         //           else

    }
}
