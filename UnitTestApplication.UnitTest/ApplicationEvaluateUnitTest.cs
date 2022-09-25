using UnitTestApplication.Models;

namespace UnitTestApplication.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        //UnitOfWork_Condition_ExpectedResult
        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var application = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 17,
                }
            };

            //Action
            var result = evaluator.Evaluate(application);

            //Assert
            Assert.That(result, Is.EqualTo(ApplicationResult.AutoRejected));
        }

        //UnitOfWork_Condition_ExpectedResult
        [Test]
        public void Application_WithNoTechStack_TransferredToAutoRejected()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var application = new JobApplication
            {
                Applicant = new Applicant
                {
                    Age = 19,
                },
                TechStackList = new List<string>{""},
            };

            //Action
            var result = evaluator.Evaluate(application);

            //Assert
            Assert.That(result, Is.EqualTo(ApplicationResult.AutoRejected));
        }

        //UnitOfWork_Condition_ExpectedResult
        [Test]
        public void Application_WithTechStackOver75_TransferredToAutoAccepted()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var application = new JobApplication
            {
                Applicant = new Applicant
                {
                    Age = 19,
                },
                TechStackList = new List<string>{"C#", "RabbitMQ", "Micro service", "Visual Studio"},
                YearsOfExperience = 15,
            };

            //Action
            var result = evaluator.Evaluate(application);

            //Assert
            Assert.That(result, Is.EqualTo(ApplicationResult.AutoAccepted));
        }

        //UnitOfWork_Condition_ExpectedResult
        //[Test]
        //public void Application_WithIdentityNumberNotValid_TransferredToAutoAccepted()
        //{
        //    // Arrange
        //    var evaluator = new ApplicationEvaluator();
        //    var application = new JobApplication
        //    {
        //        Applicant = new Applicant(),
        //    };

        //    //Action
        //    var result = evaluator.Evaluate(application);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(ApplicationResult.AutoAccepted));
        //}
    }
}