﻿using Domain.IRepository;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
