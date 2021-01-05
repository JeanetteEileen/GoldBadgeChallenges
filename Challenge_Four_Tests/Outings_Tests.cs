using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_Four;
using System.Collections.Generic;
namespace Challenge_Four_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private OutingsRepository _repository;
        private Outings _content;
        [TestInitialize]
        public void Arrange()
        {
            //Arrange method to avoid adding info for each test
            _content = new Outings();
            _repository = new OutingsRepository();

            //Assign Outing to be added at the start of the program
            _content.TypeOfEvent = EventType.Golf;
            _content.DateOfEvent = new DateTime(2018, 04, 27).Date;
            _content.NumPeopleAttend = 99;
            _content.CostPerPerson = 105.25;
            _content.TotalCostEvent = 10419.75;

            //Add the Outings to the List
            _repository.AddEventToList(_content);
        }
        [TestMethod]
        public void TestAddEvent()
        {
            //Assign Outing to be added at the start of the program
            _content.TypeOfEvent = EventType.Concert;
            _content.DateOfEvent = new DateTime(2018, 05, 31).Date;
            _content.NumPeopleAttend = 32;
            _content.CostPerPerson = 65.15;
            _content.TotalCostEvent = 2084.80;
            // Add the Outings to the List
            _repository.AddEventToList(_content);

            double expected = 2084.80;
            double actual = _content.TotalCostEvent;
            Console.WriteLine(expected);
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetOutingsList()
        {
            List<Outings> eventList = _repository.GetEventList();
            Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", "Type of Outing", "Date of Event", "Number of Attendees", "Cost per Person", "Total Cost of Event");

            foreach (Outings content in eventList)
            {
                Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
            }
        }
        [TestMethod]
        public void TestGetEventGolf()
        {
            _repository.GetEventGolf(_content.TypeOfEvent);

            Outings actual = new Outings();
            Outings expect = new Outings();
            actual.TypeOfEvent = EventType.Golf;
            expect.TypeOfEvent = _content.TypeOfEvent;
            Console.WriteLine(actual.TypeOfEvent);
            Assert.AreEqual(actual.TypeOfEvent, expect.TypeOfEvent);
        }
        [TestMethod]
        public void TestGetEventConcert()
        {
            _repository.GetEventConcert(_content.TypeOfEvent);

            Outings actual = new Outings();
            Outings expect = new Outings();
            //expected event type
            expect.TypeOfEvent = EventType.Concert;
            //acctual event type
            actual.TypeOfEvent = _content.TypeOfEvent;
            Console.WriteLine("expected event: " + expect.TypeOfEvent);
            Console.WriteLine("actual event: " + actual.TypeOfEvent);
            Assert.AreNotEqual(actual.TypeOfEvent, expect.TypeOfEvent);
        }
        [TestMethod]
        public void TestGetAmusementPark()
        {
            _repository.GetEventAmusementPark(_content.TypeOfEvent);

            Outings actual = new Outings();
            Outings expect = new Outings();
            //expected event type of Amusement Park
            expect.TypeOfEvent = EventType.Amusement_Park;
            //actual event type
            actual.TypeOfEvent = _content.TypeOfEvent;
            Console.WriteLine("expected event: " + expect.TypeOfEvent);
            Console.WriteLine("actual event: " + actual.TypeOfEvent);
            Assert.AreNotEqual(actual.TypeOfEvent, expect.TypeOfEvent);
        }
        [TestMethod]
        public void TestEventBowling()
        {
            _repository.GetEventBowling(_content.TypeOfEvent);

            Outings actual = new Outings();
            Outings expect = new Outings();
            //expected event type of Bowling
            expect.TypeOfEvent = EventType.Bowling;
            //actual event type
            actual.TypeOfEvent = _content.TypeOfEvent;
            Console.WriteLine("expected event: " + expect.TypeOfEvent);
            Console.WriteLine("actual event: " + actual.TypeOfEvent);
            Assert.AreNotEqual(actual.TypeOfEvent, expect.TypeOfEvent);
        }
        [TestMethod]
        public void TestCalculateTotalCostEvent()
        {
            int numPeople = 99;
            double CostPerson = 105.25;
            double expected = numPeople * CostPerson;
            double actual = _content.TotalCostEvent;
            Assert.AreEqual(expected, actual);
            Console.WriteLine($"{ expected}", $"{actual}");
        }
        [TestMethod]
        public void TestTotalCoast()
        {
            //Assign Outing to be added at the start of the program
            _content.TypeOfEvent = EventType.Concert;
            _content.DateOfEvent = new DateTime(2018, 05, 31).Date;
            _content.NumPeopleAttend = 32;
            _content.CostPerPerson = 65.15;
            _content.TotalCostEvent = 2084.80;
            // Add the Outings to the List
            _repository.AddEventToList(_content);

            double expected = 2084.80 + 10419.75;
            //double actual = .TotalCostAllEvents();

        }
    }
}
