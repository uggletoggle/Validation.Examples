using Validation.Services.Dtos;

namespace Validation.Services.Responses
{
    public class CustomerResult
    {
        public bool Success { get; private set; }
        public string[] Errors { get; private set; }
        public int? ErrorCode { get; private set; }
        public CustomerReadDto[] Data { get; private set; }

        private CustomerResult(bool success, string[] errors, CustomerReadDto[] data, int? errorCode = null)
        {
            Success = success;
            Errors = errors;
            Data = data;
            ErrorCode = errorCode;
        }

        public static CustomerResult Ok(CustomerReadDto[] data)
        {
            return new CustomerResult(true, null, data);
        }

        public static CustomerResult Failure(string[] errors, int errorCode)
        {
            return new CustomerResult(false, errors, null, errorCode);
        }

    }


}
