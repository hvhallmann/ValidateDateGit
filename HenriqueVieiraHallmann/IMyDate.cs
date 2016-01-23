using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueVieiraHallmann
{
    public interface IMyDate
    {     
        /// <summary>
        /// Required method to generate a string date format after user pass the param
        /// </summary>
        /// <param name="op">one character, should be positive or negative</param>
        /// <param name="value">how many minutes the user whants to increase or decrease</param>
        /// <returns></returns>
        string ChangeDaysDate(char op, long value);

        /// <summary>
        /// Contructor class, it parses the param name and validates
        /// </summary>
        /// <param name="date">string that should be date format</param>
        /// <returns>bool validating the creation of object</returns>
        bool CreateDate(string date);

        /// <summary>
        /// This method will increase minutes in the nMinutes property until there is
        /// values to decrease from param as input
        /// </summary>
        /// <param name="nChangeValue">How many minutes to increase</param>
        /// <returns>the instance of MyDate Class</returns>
        MyDate AddMinutes(long nChangeValue);

        /// <summary>
        /// This method will decrease minutes in the nMinutes property until there is
        /// values to decrease from param as input
        /// </summary>
        /// <param name="nChangeValue">How many minutes to decrease</param>
        /// <returns>the instance of MyDate Class</returns>
        MyDate decrementMinutes(long nChangeValue);

        /// <summary>
        /// Override the method ToString to display the date in a human format
        /// </summary>
        /// <returns>Date in br format</returns>
        string ToString();

    }
}
