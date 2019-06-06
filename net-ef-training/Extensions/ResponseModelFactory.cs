namespace net_ef_training.Extensions
{
    public class ResponseModelFactory
    {
        public static ResponseModel CreateInstance => new ResponseModel();

        /// <summary>
        ///
        /// </summary>
        public static ResponseResultModel CreateResultInstance => new ResponseResultModel();
    }
}