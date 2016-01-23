using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HenriqueVieiraHallmann;

namespace UnitTestChangeDate
{
    /// <summary>
    /// This unit test will test everything related to MyDate class
    /// </summary>
    [TestClass]
    public class UnitTestValidateDate
    {        

        [TestMethod]
        public void TestMethodValidateEmptyValues()
        {            
            // arrange
            MyDate oDate = new MyDate("");            
            // assert
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual("Please insert the correct pattern", oDate.sReason);

            //----------------------------
            
            oDate = new MyDate("asd");            
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual(" - Problem to parse date, invalid format, use the correct pattern dd/MM/yyyy HH24:mi", oDate.sReason);

            //----------------------------

            oDate = new MyDate("12/as/2134");
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual(" - Problem to parse date, invalid format, use the correct pattern dd/MM/yyyy HH24:mi", oDate.sReason);

            //----------------------------
            //no hour informed
            oDate = new MyDate("12/12/2134");
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual("You missed to inform the hours", oDate.sReason);

            //----------------------------
            //extra space
            oDate = new MyDate("12/12/2134   23:00");
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual(" - Problem to parse date, invalid format, use the correct pattern dd/MM/yyyy HH24:mi", oDate.sReason);
        }

        [TestMethod]
        public void TestMethodValidateWrongValues()
        {
            // arrange
            MyDate oDate = new MyDate("12/13/2134 23:00");
            // assert
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual("Month should be between 1 and 12", oDate.sReason);

            //----------------------------

            oDate = new MyDate("32/11/2134 23:00");
            
            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual("Day should be between 1 and 31", oDate.sReason);

            //----------------------------

            oDate = new MyDate("30/02/2134 25:00");

            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual("Hours should be between 00 and 24", oDate.sReason);

            //----------------------------

            oDate = new MyDate("30/02/2134 22:70");

            Assert.AreEqual(false, oDate.isValid);
            Assert.AreEqual("Minutes should be between 0 and 59", oDate.sReason);
        }
        
        [TestMethod]
        public void TestPublicMethods()
        {
            // arrange
            MyDate oDate = new MyDate("12/12/2134 13:00");
            oDate = oDate.AddMinutes(25);
            // assert
            Assert.AreEqual("12/12/2134 13:25", oDate.ToString());            

            //----------------------------
            oDate = new MyDate("12/12/2134 13:00");
            oDate = oDate.AddMinutes(90);
            
            Assert.AreEqual("12/12/2134 14:30", oDate.ToString());

            //--------Change a day--------------------
            oDate = new MyDate("12/12/2134 23:00");
            oDate = oDate.AddMinutes(90);
            
            Assert.AreEqual("13/12/2134 00:30", oDate.ToString());

            //----------------------------
            oDate = new MyDate("12/12/2134 23:00");
            oDate = oDate.decrementMinutes(90);

            Assert.AreEqual("12/12/2134 21:30", oDate.ToString());

            //--------Change a day--------------------
            oDate = new MyDate("12/12/2134 02:00");
            oDate = oDate.decrementMinutes(140);

            Assert.AreEqual("11/12/2134 23:40", oDate.ToString());
        }

        [TestMethod]
        public void TestMainMethod()
        {
            // arrange
            MyDate oDate = new MyDate("12/12/2134 13:00");
            
            // assert
            Assert.AreEqual("12/12/2134 13:25", oDate.ChangeDaysDate('+', 25));

            //----------------------------
            oDate = new MyDate("12/12/2134 02:00");
            Assert.AreEqual("Wrong character for op; only + and - are allowed", oDate.ChangeDaysDate('*', 250));

            //----------ZERO VALUES------------------
            oDate = new MyDate("12/12/2134 02:00");
            Assert.AreEqual("12/12/2134 02:00", oDate.ChangeDaysDate('+', 0));

            //----------------------------
            oDate = new MyDate("12/12/2134 02:00");
            Assert.AreEqual("12/12/2134 02:00", oDate.ChangeDaysDate('-', -0));

            //----------ONE VALUE------------------
            oDate = new MyDate("12/12/2134 02:00");
            Assert.AreEqual("12/12/2134 02:01", oDate.ChangeDaysDate('+', 1));

            //----------------------------
            oDate = new MyDate("12/12/2134 02:00");
            Assert.AreEqual("12/12/2134 01:59", oDate.ChangeDaysDate('-', -1));
        }

        [TestMethod]
        public void TestClassDateChange()
        {
            // arrange
            ClassDateChange oDateChange = new ClassDateChange();
            // assert
            Assert.AreEqual("04/03/2010 17:40", oDateChange.ChangeDate("01/03/2010 23:00", '+', 4000));

            //----------------------------

            oDateChange = new ClassDateChange();
            Assert.AreEqual("27/02/2010 04:20", oDateChange.ChangeDate("01/03/2010 23:00", '-', 4000));

            //WRONG VALUES----------------------------

            oDateChange = new ClassDateChange();
            Assert.AreEqual("Month should be between 1 and 12", oDateChange.ChangeDate("01/13/2010 23:00", '-', 4000));

            //WRONG VALUES----------------------------

            oDateChange = new ClassDateChange();
            Assert.AreEqual("Wrong character for op; only + and - are allowed", oDateChange.ChangeDate("01/12/2010 23:00", '*', 4000));


            //SUPER VALUES------ALMOST ONE YEAR----------------------

            oDateChange = new ClassDateChange();
            Assert.AreEqual("27/12/2016 23:00", oDateChange.ChangeDate("01/01/2016 23:00", '+', 518400));


            //SUPER VALUES------AFTER ONE YEAR----------------------

            oDateChange = new ClassDateChange();
            Assert.AreEqual("24/09/2017 19:00", oDateChange.ChangeDate("01/01/2016 23:00", '+', 908400));

        }
    }
}
