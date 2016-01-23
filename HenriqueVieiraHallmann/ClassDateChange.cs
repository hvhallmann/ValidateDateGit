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
            MyDate oInputDate = new MyDate(date);

            if (!oInputDate.isValid)
                return oInputDate.sReason;
            else
            {
                return oInputDate.ChangeDaysDate(op, value);
            }            
        }

        
    }
}
