using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueVieiraHallmann
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassDateChange oClassDate = new ClassDateChange();
            string sResult = oClassDate.ChangeDate("01/03/2010 23:00", '+', 4000);

            System.Console.WriteLine(sResult);//"04/03/2010 17:40"            

            System.Console.Read();
        }
    }
}
