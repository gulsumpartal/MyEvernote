using System.Collections.Generic;

namespace MyEvernote.BusinessLayer.Response
{
    public class ResponseMessage<T> where T : class
    {
        public ResponseMessage()
        {
            IsSuccess = true;
            Errors = new List<string>();
        }

        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }

        public T Result { get; set; }
    }
}
