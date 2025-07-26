namespace MICRUDGABRIEL.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static ServiceResult SuccessResult(string message) =>
            new ServiceResult { Success = true, Message = message };

        public static ServiceResult Failure(string message) =>
            new ServiceResult { Success = false, Message = message };
    }
}
