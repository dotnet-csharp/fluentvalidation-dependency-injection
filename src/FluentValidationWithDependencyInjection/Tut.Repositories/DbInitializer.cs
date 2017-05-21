using System.Data.Entity;

namespace Tut.Repositories
{
    public class DbInitializer : CreateDatabaseIfNotExists<DIContext>
    {
        protected override void Seed(DIContext context)
        {
            base.Seed(context);
        }
    }
}