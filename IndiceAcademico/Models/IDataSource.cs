using System.Collections.Generic;

namespace IndiceAcademico.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}