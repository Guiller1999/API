using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class ObjResult<T>
    {
        public int Status { get; set; }

        public T Result { get; set; }
    }
}
