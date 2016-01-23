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
            
            if(!oInputDate.isValid)          
                return oInputDate.sReason; 
                       
            if (value < 0)
                value = value * (-1);

            if (op == '+')
                oInputDate.AddMinutes(value);
            if (op == '-')
                oInputDate.decrementMinutes(value);
            
            return oInputDate.ToString();
        }

        
    }
}
