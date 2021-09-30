using blazorProject5.Data;
using blazorProject5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorProject5.Services
{
    public class TagsService
    {
        DbContextOptions<ApplicationDbContext> options;

        public TagsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }
        public virtual List<tag> get()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.tags.OrderBy(d => d.date).ToList();
            }
        }
        public void add(tag item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.tags.Add(item);
                context.SaveChanges();
            }
        }
        public void delete(tag item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.tags.Remove(item);
                context.SaveChanges();
            }
        }
        public void edit(tag item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.tags.Update(item);
                context.SaveChanges();
            }
        }
    }
}
