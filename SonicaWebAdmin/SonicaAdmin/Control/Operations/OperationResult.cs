namespace SonicaWebAdmin.SonicaAdmin.Control.Operations
{
    public class OperationResult
    {
        public static CanceledResult Canceled = new CanceledResult();
        public static FailedButCanRetryResult FailedButCanRetry(string errorMessage)=> new FailedButCanRetryResult(errorMessage);
        public static FailedResult Failed(string errorMessage) => new FailedResult(errorMessage);
        public static  SuccessfullyResult Successfully(string joyfulMessage)=> new SuccessfullyResult(joyfulMessage);

        public static ConcreteResult Content(object result) => new ConcreteResult(result);

        public class CanceledResult : OperationResult
        {

        }
        public class FailedButCanRetryResult: OperationResult
        {
            public string ErrorMessage { get; }

            public FailedButCanRetryResult(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }

        public class FailedResult : OperationResult
        {
            public string ErrorMessage { get; }

            public FailedResult(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }

        public class SuccessfullyResult : OperationResult
        {
            public string JoyfulMessage { get; }

            public SuccessfullyResult(string joyfulMessage)
            {
                JoyfulMessage = joyfulMessage;
            }
        }
        public class ConcreteResult : OperationResult
        {
            public object Result { get; }

            public ConcreteResult(object concreteResult)
            {
                Result = concreteResult;
            }
        }
    }
}
