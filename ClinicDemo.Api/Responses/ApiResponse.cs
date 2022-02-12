namespace ClinicDemo.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, bool status)
        {
            Data = data;
            Status = status;
        }

        public ApiResponse(bool status)
        {
            Status = status;
        }

        public T Data { get; set; }
        public bool Status { get; set; }

    }
}
