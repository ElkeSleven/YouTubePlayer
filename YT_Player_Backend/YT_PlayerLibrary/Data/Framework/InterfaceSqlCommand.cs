using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YT_PlayerLibrary.Entities; //


namespace YT_PlayerLibrary.Data.Framework
{
    internal interface InterfaceSqlCommand<T>
    {
        SelectResult select();
        //InsertResult Insert(T t);

    }
}
