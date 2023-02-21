namespace Validation.Domain.Responses
{
    public class CustomerResult
    {
        public bool Success { get; private set; }
        public string[] Errors { get; private set; }
        public int? ErrorCode { get; private set; }
        public Customer[] Data { get; private set; }

        private CustomerResult(bool success, string[] errors, Customer[] data, int? errorCode = null)
        {
            Success = success;
            Errors = errors;
            Data = data;
            ErrorCode = errorCode;
        }

        public static CustomerResult Ok(Customer[] data)
        {
            return new CustomerResult(true, null, data);
        }

        public static CustomerResult Failure(string[] errors, int errorCode)
        {
            return new CustomerResult(false, errors, null, errorCode);
        }

    }


}
