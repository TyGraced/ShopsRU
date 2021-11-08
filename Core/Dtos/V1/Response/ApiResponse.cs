namespace Core.Dtos.V1.Response
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data{ get; set; }   
    }
}