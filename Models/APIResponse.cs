namespace Celestica.Models
{
    public class APIResponse<T>
    {
        public APIResponse()
        {
            this.status = true;
            this.message = string.Empty;
        }
        public bool status { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public T data { get; set; }
    }
}
