using PostApp.Tables;
using System.Diagnostics;

namespace PostApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PostContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
