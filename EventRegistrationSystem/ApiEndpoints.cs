namespace EventRegistrationSystem;

public class ApiEndpoints
{
    private const string ApiBase = "/api"; // Base URL for the API

    public class Events 
    {
        private const string BaseUrl = $"{ApiBase}/events";

        public const string GetAll = BaseUrl;
        public const string GetById = $"{BaseUrl}/{{eventId}}";

        public const string Create = BaseUrl;

        public const string CreateRegistration = $"{BaseUrl}/{{eventId}}/registrations";
        public const string GetRegistrations = $"{BaseUrl}/{{eventId}}/registrations";
    }

    public class Users
    {
        private const string BaseUrl = $"{ApiBase}/users";

        public const string Register = BaseUrl;
        public const string Login = $"{BaseUrl}/sessions";
    }
}
