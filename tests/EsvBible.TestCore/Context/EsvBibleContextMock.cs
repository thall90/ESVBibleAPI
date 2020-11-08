using ThriveNextGen.Data.Contexts;
using ThriveNextGen.Shared.Data.Contexts;

namespace EsvBible.TestCore.Context
{
    public class EsvBibleContextMock
    {
        public readonly IEsvBibleContext Context;

        public EsvBibleContextMock()
        {
            Context = new EsvBibleContext(ContextExtensions.CreateContextOptions<EsvBibleContext>());
        }
    }
}