using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Core
{
    public class ResultHandler<TResult, TError>
    {
        public TError Error { get; }
        public TResult Result { get; }
    }
}
