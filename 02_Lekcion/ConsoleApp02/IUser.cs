using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp02
{
    internal interface IUser<T>
    {
        T Id { get; }
    }
}
