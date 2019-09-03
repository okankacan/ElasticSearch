using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Business.Interface
{
    public interface IConfiguraionIndex
    {
        string productSuggestIndex { get; }
        string uri { get; }

    }
}
