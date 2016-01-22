using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueVieiraHallmann
{
    public class ClassDateChange
    {
        //main function to change the date
        //it was implemented simple to maintain the code manutenability
        //as new requirements may come
        public string ChangeDate(string date, char op, long value)
        {

			
            if (date == null || op == null)
                return null;

            if (value < 0)
                value = value * (-1);

            int nDay = 0;
            int nMonth = 0;
            int nYear = 0;
            int nHours = 0;
            int nMinutes = 0;

            try
            {
                nDay = int.Parse(date.Substring(0, 2));
                nMonth = int.Parse(date.Substring(3, 2));
                nYear = int.Parse(date.Substring(6, 4));
                nHours = int.Parse(date.Substring(11, 2));
                nMinutes = int.Parse(date.Substring(14, 2));
            }
            catch(Exception)
            {
                return null;
            }

            //validate the given values
            if (nDay > 31 || nDay < 1)
                return null;
            if (nMonth > 12 || nDay < 1)
                return null;
            if (nHours > 24 || nHours < 0)
                return null;
            if (nMinutes > 59 || nHours < 0)
                return null;
            
            if (op == '+')
                incrementOperator(ref value, ref nMinutes, ref nHours, ref nDay, ref nMonth, ref nYear);
            if (op == '-')
                decrementOperator(ref value, ref nMinutes, ref nHours, ref nDay, ref nMonth, ref nYear);
           
            string sResult = formatValue(nDay) + "/" + formatValue(nMonth) + "/" + nYear.ToString() + " " + formatValue(nHours) + ":" + formatValue(nMinutes);

            return sResult;
        }

        //main function to calculate the increase operation        
        private void incrementOperator(ref long nChangeValue
            , ref int nChangeMinutes
            , ref int nChangeHours
            , ref int nChangeDay
            , ref int nChangeMonth
            , ref int nChangeYear)
        {            
            while (nChangeValue > 0)
            {
                --nChangeValue;
                nChangeMinutes++;

                if (nChangeMinutes > 59)
                {
                    nChangeMinutes = 0;
                    nChangeHours++;

                    if (nChangeHours > 23)
                    {
                        nChangeHours = 0;
                        
                        incrementDay(ref nChangeDay, ref nChangeMonth, ref nChangeYear);
                    }

                }
            }
        }

        private void incrementDay(ref int nCurrentDay, ref  int nCurrentMonth, ref int nCurrentYear)
        {
            ClassMonth oMonth = new ClassMonth(nCurrentDay, nCurrentMonth, nCurrentYear);
            int nMonthMaxValue = oMonth.getSpecificMonth(nCurrentMonth);

            nCurrentDay++;
            if (nCurrentDay > nMonthMaxValue)
            {
                nCurrentMonth++;
                nCurrentDay = 1;

                if (nCurrentMonth > 12)
                {
                    nCurrentYear++;
                    nCurrentMonth = 1;
                }

            }

        }

        //main function to calculate the decrease operation
        private void decrementOperator(ref long nChangeValue
            , ref int nChangeMinutes
            , ref int nChangeHours
            , ref int nChangeDay
            , ref int nChangeMonth
            , ref int nChangeYear)
        {
            while (nChangeValue > 0)
            {
                --nChangeValue;
                nChangeMinutes--;

                if (nChangeMinutes < 0)
                {
                    nChangeMinutes = 59;
                    nChangeHours--;

                    if (nChangeHours < 0)
                    {
                        nChangeHours = 23;
                       
                        decrementDay(ref nChangeDay, ref nChangeMonth, ref nChangeYear);
                    }

                }
            }
        }

        private void decrementDay(ref int nCurrentDay, ref  int nCurrentMonth, ref int nCurrentYear)
        {
            ClassMonth oMonth = new ClassMonth(nCurrentDay, nCurrentMonth, nCurrentYear);
            

            nCurrentDay--;
            if (nCurrentDay < 1)
            {
                //get the previous month maximum days
                int nMonthMaxValue = oMonth.getSpecificMonth(nCurrentMonth > 1 ? nCurrentMonth - 1 : 12);

                nCurrentMonth--;
                
                nCurrentDay = nMonthMaxValue;

                if (nCurrentMonth < 1)
                {
                    nCurrentYear--;
                    nCurrentMonth = 12;
                }

            }

        }

        //add 0 as a prefix for values < 10       
        private string formatValue(int _nValue)
        {

            if (_nValue < 10)
            {
                return "0" + _nValue.ToString();
            }
            else
            {
                return _nValue.ToString();
            }

        }
    }
}
