using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueVieiraHallmann
{
    public class MyDate
    {
        public bool isValid { get; private set; }
        public String sReason { get; private set; }
        
        public int nMinutes { get; private set; }
        public int nHours { get; private set; }
        public int nDay { get; private set; }
        public int nMonth { get; private set; }
        public int nYear { get; private set; }
       

        public MyDate(string date)
        {
            isValid = this.CreateDate(date); 
        }

        public bool CreateDate(string date)
	    {
            isValid = true;
            sReason = "";
           
            if (date == null )
            {
                isValid = false;
                sReason = "Please insert the correct pattern ";
            }

            this.nDay = 0;
            this.nMonth = 0;
            this.nYear = 0;
            this.nHours = 0;
            this.nMinutes = 0;

            try
            {
                nDay = int.Parse(date.Substring(0, 2));
                nMonth = int.Parse(date.Substring(3, 2));
                nYear = int.Parse(date.Substring(6, 4));
                nHours = int.Parse(date.Substring(11, 2));
                nMinutes = int.Parse(date.Substring(14, 2));
            }
            catch (Exception)
            {
                isValid = false;
                sReason = "Problem to parse date, invalid format, use the correct pattern dd/MM/yyyy HH24:mi";
            }

            //validate the given values
            if (nDay > 31 || nDay < 1)
            {
                isValid = false;
                sReason = "Day should be between 1 and 31";
            }
            if (nMonth > 12 || nDay < 1)
            {
                isValid = false;
                sReason = "Month should be between 1 and 12";
            }
            if (nHours > 24 || nHours < 0)
            {
                isValid = false;
                sReason = "Hours should be between 00 and 24";
            }
            if (nMinutes > 59 || nHours < 0)
            {
                isValid = false;
                sReason = "Minutes should be between 0 and 59";
            }

            return isValid;
        }
   
        public void AddMinutes(long nChangeValue)
        {
            
            while (nChangeValue > 0)
            {                
                --nChangeValue;         
       
                    nMinutes++;
                
                if (nMinutes > 59)
                {
                    nMinutes = 0;
                    nHours++;

                    if (nHours > 23)
                    {
                        nHours = 0;

                        addDays();
                    }
                }                
            }
        }

        //turn class month static
        public void addDays()
        {
            ClassMonth oMonth = new ClassMonth(nDay, nMonth, nYear);
            int nMonthMaxValue = oMonth.getSpecificMonth(nMonth);
            
            nDay++;            

            if (nDay > nMonthMaxValue)
            {
                nMonth++;
                nDay = 1;

                if (nMonth > 12)
                {
                    nYear++;
                    nMonth = 1;
                }
            }            
        }

        //main function to calculate the decrease operation
        public void decrementMinutes(long nChangeValue)
        {
            while (nChangeValue > 0)
            {
                --nChangeValue;
                nMinutes--;

                if (nMinutes < 0)
                {
                    nMinutes = 59;
                    nHours--;

                    if (nHours < 0)
                    {
                        nHours = 23;

                        decrementDays();
                    }

                }
            }
        }

        public void decrementDays()
        {
            ClassMonth oMonth = new ClassMonth(nDay, nMonth, nYear);

            nDay--;
            if (nDay < 1)
            {
                //get the previous month maximum days
                int nMonthMaxValue = oMonth.getSpecificMonth(nMonth > 1 ? nMonth - 1 : 12);

                nMonth--;

                nDay = nMonthMaxValue;

                if (nMonth < 1)
                {
                    nYear--;
                    nMonth = 12;
                }
            }

        }

        public override string ToString()
        {           
            string sResult = formatValue(nDay) + "/" + formatValue(nMonth) + "/" + nYear.ToString() + " " + formatValue(nHours) + ":" + formatValue(nMinutes);

            return sResult;            
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
