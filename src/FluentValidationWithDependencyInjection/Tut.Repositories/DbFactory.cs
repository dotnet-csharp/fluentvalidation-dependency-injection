using System;

namespace Tut.Repositories
{
    public sealed class DbFactory : IDbFactory
    {
        private DIContext _context;

        public DIContext Init()
        {
            return _context ?? (_context = new DIContext());
        }

        /// <summary>
        ///     Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            DisposeCore(true);
            GC.SuppressFinalize(this);
        }

        private void DisposeCore(bool disposing)
        {
            if (!disposing) return;
            _context?.Dispose();
            _context = null;
        }
    }
}