using System.Data.Entity;

namespace AddTextToImage.Data.Context
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
