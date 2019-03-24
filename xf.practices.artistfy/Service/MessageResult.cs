using System;
namespace xf.practices.artistfy.Service
{
    public class MessageResult<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}