using System.Collections.Generic;

namespace MyEvernote.DTO.Response
{
    public class ResponseMessage<T> where T : class
    {
        public ResponseMessage()
        {
            IsSuccess = true;
            Messages = new List<string>();
        }

        public bool IsSuccess { get; set; }

        public List<string> Messages { get; set; }

        public T Result { get; set; }
    }
}
