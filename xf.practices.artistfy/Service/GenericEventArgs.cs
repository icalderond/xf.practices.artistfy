using System;
namespace xf.practices.artistfy.Service
{
    public class GenericEventArgs<T> : EventArgs
    {
        public T Result { get; private set; }
        public GenericEventArgs(T _result)
        {
            Result = _result;
        }
    }
}
