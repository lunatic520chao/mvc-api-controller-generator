using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvcwithSqliteDemo.Sql.Entities;

    public class SqlContext : DbContext
    {
        public SqlContext (DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public DbSet<mvcwithSqliteDemo.Sql.Entities.DepartMember> DepartMember { get; set; }
    }
