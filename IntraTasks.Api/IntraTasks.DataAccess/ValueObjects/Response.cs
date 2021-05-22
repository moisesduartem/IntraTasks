namespace IntraTasks.DataAccess.ValueObjects
{
    public class Response<T>
    {
        public bool Successfully { get; set; }
        public string Message { get; set; } = "";
        public T Data { get; set; }
    }
}
