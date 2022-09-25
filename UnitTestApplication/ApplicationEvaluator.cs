using UnitTestApplication.Models;
using UnitTestApplication.Services;

namespace UnitTestApplication
{
    public class ApplicationEvaluator
    {
        private const int minAge = 18;
        private const int autoAcceptedYearsOfExperience = 15;
        private List<string> techStackList = new() { "C#", "RabbitMQ", "Micro service", "Visual Studio" };
        private IdentityValidator _identityValidator;

        public ApplicationEvaluator()
        {
            _identityValidator = new IdentityValidator();
        }

        public ApplicationResult Evaluate(JobApplication application)
        {
            if (application.Applicant.Age < minAge)
                return ApplicationResult.AutoRejected;

            var validIdentity = _identityValidator.IsValid(application.Applicant.IdentityNumber);
            if (!validIdentity)
                return ApplicationResult.TransferredToHr;

            var similarityRate = GetTechStackSimilarityRate(application.TechStackList);

            if (similarityRate < 25)
            {
                return ApplicationResult.AutoRejected;
            }
            if (similarityRate >= 75 && application.YearsOfExperience >= autoAcceptedYearsOfExperience)
            {
                return ApplicationResult.AutoAccepted;
            }

            return ApplicationResult.AutoAccepted;
        }

        private int GetTechStackSimilarityRate(List<string> techStacks)
        {
            var matchedCount = techStacks
                .Count(x => techStackList.Contains(x, StringComparer.OrdinalIgnoreCase));
            return (int)((double)matchedCount / techStackList.Count) * 100;
        }
    }

    public enum ApplicationResult
    {
        AutoRejected,
        TransferredToHr,
        TransferredToLead,
        TransferredToCto,
        AutoAccepted
    }

}