using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceTypes
{
    public interface IPrintable<T>
    {
        void Print(T obj);
    }
}
