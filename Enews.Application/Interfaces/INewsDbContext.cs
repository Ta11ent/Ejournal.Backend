﻿using Enews.Domain;
using Microsoft.EntityFrameworkCore;

namespace Enews.Application.Interfaces
{
    public interface INewsDbContext
    {
        DbSet<News> News { get; set; }
        DbSet<NewsFile> NewsFiles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
