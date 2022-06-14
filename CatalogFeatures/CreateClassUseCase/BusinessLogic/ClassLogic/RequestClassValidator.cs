namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public interface IRequestClassValidator
    {
        RequestClassModel Validate(RequestClassModel request);
    }
    public class RequestClassValidator : IRequestClassValidator
    {
        private DateTime StandardStartingDate = new DateTime(DateTime.Now.Year, 9, 13);

        public RequestClassModel Validate(RequestClassModel request)
        {
            request = ValidateDates(request);

            return request;
        }

        private RequestClassModel ValidateDates(RequestClassModel request)
        {
            if (request.StartDate == null)
            {
                request.StartDate = StandardStartingDate;
            }
            request.EndDate = new DateTime(request.StartDate.Value.Year + 1, 8, 31);

            return request;
        }
    }
}
