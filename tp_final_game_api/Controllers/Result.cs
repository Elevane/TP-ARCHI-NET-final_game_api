namespace tp_final_game_api.Controllers
{
    public class Result<T>
    {

        public T _result { get; set; }
        public string Error { get; set; }
        public int Code { get; set; }

        protected internal Result(T result)
        {
            _result = result;
            Code = 200;
            Error = null;
        }

        protected internal Result()
        {
            if (_result == null)
            {
                Code = 500;
                Error = "Internal server error";
            }
        }

    }

    public class Result : Result<string>
    {
        public Result(string result) : base(result)
        {
        }

        public static Result<T> Ok<T>(T result)
        {
            return new Result<T>(result);
        }



        public static Result Ok()
        {
            return new Result(null);
        }

        public static Result Error(string errorMessage)
        {
            return new Result(errorMessage);

        }
    }
}