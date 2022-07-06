namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public interface IRequestHandler
    {
        RequestClassModel Handle(RequestClassModel request);
    }
    public class RequestHandler : IRequestHandler
    {
        private DateTime StandardStartingDate = new DateTime(DateTime.Now.Year, 9, 13);

        public RequestClassModel Handle(RequestClassModel request)
        {
            request = HandleDates(request);

            return request;
        }

        private RequestClassModel HandleDates(RequestClassModel request)
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
