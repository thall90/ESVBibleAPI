using System;
using Microsoft.EntityFrameworkCore;

namespace EsvBible.TestCore.Context
{
    public static class ContextExtensions
    {
        public static DbContextOptions<TContext> CreateContextOptions<TContext>()
            where TContext : DbContext
        {
            return new DbContextOptionsBuilder<TContext>()
                .UseInMemoryDatabase($"{Guid.NewGuid()}")
                .Options;
        }
    }
}