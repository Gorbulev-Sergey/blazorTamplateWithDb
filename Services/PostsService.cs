using blazorProject5.Data;
using blazorProject5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorProject5.Services
{
    public class PostsService
    {
        DbContextOptions<ApplicationDbContext> options;

        public PostsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }
        public virtual List<post> get()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.posts.Include(t => t.tags).OrderBy(d=>d.date).ToList();
            }
        }
        public void add(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.posts.Add(item);
                context.SaveChanges();
            }
        }
        public void delete(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.posts.Remove(item);
                context.SaveChanges();
            }
        }
        public void edit(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var tags = item.tags;
                item.tags = null;
                context.Update(item);
                context.SaveChanges();
                item.tags = tags;
            }
            using (var context = new ApplicationDbContext(options))
            {
                post post_from_db = context.posts.Include(t => t.tags).FirstOrDefault(p => p.id == item.id);
                List<tag> new_tags = item.tags;
                List<tag> old_tags = post_from_db.tags;
                List<tag> for_add = new_tags.Where(t => t.posts.Count == 0).ToList();
                List<tag> for_delete = old_tags.Where(x=>new_tags.All(a=>a.id!=x.id)).ToList();
                post_from_db.tags.AddRange(for_add);
                foreach (var i in for_delete)
                {
                    post_from_db.tags.Remove(i);
                }
                context.SaveChanges();
            }
        }
    }
}
