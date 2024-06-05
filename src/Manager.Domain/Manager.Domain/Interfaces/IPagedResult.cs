using Manager.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Manager.Domain.Interfaces;


public interface IPagedRepository<T> where T : Base,new()
{
            public List<T> Item { get; set; }
            public int totsl { get; get; }
            public int Page { get; set }
            public int PerPage { get; set; }
            public int PageCount { get; set; }
            
}