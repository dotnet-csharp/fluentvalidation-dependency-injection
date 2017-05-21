using System;

namespace Tut.Repositories
{
    public interface IDbFactory : IDisposable
    {
        DIContext Init();
        int Commit();
    }
}