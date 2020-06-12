using DataLayer;
using DomainLibrary.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Transactions;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        TrainingManager tm = new TrainingManager(new UnitOfWork(new TrainingContextTest()));

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void testAddCycling_jaarTeveel()
        {
            tm.AddCyclingTraining(new DateTime(9999, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
        }
        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void testAddCycling_DistanceTeHoog()
        {
            tm.AddCyclingTraining(new DateTime(2000, 4, 21, 16, 00, 00), 1111111, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
        }
        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void testAddCycling_TijdTehoog()
        {
            tm.AddCyclingTraining(new DateTime(2000, 4, 21, 16, 00, 00), 40, new TimeSpan(100, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
        }

        [TestMethod]
        public void TestAddTraining()
        {

            using (new TransactionScope())
            {
                TrainingContextTest db = new TrainingContextTest();
                var originalCount = db.RunningSessions.ToList().Count();
                RunningSession x = new RunningSession(new DateTime(2000, 2, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

                db.RunningSessions.Add(x);
                db.SaveChanges();


                Assert.AreEqual(originalCount + 1, db.RunningSessions.ToList().Count());

            }
        }

             [TestMethod]
        public void TestAddCycling()
        {

            using (new TransactionScope())
            {
                TrainingContextTest db = new TrainingContextTest();
                var originalCount = db.CyclingSessions.ToList().Count();
                CyclingSession x = new CyclingSession(new DateTime(2020, 4, 19, 16, 45, 00), null, new TimeSpan(1, 0, 00), null, 219, TrainingType.Interval, "5x5 min 270", BikeType.IndoorBike);

                db.CyclingSessions.Add(x);
                db.SaveChanges();


                Assert.AreEqual(originalCount + 1, db.CyclingSessions.ToList().Count());

            }

        }
    }
}
