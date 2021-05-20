namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true)
        {

        }
        public SuccessResult():base(true)
        {

        }
    }
}
