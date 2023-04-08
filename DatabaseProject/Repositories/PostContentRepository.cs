using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Repositories
{
    public class PostContentRepository :IPostContentRepository
    {
        WatnContentDbContext _DbContext;
        public PostContentRepository(WatnContentDbContext DbContext)
        {
            _DbContext = DbContext;

        }       
        public List<PostContent> GetContents(int PageNumber, int RecordsPerPage)
        { 
            var webContents = _DbContext.PostContents
                .Include(a=>a.Author)
                .Include(p=>p.PostType).Skip((PageNumber - 1) * RecordsPerPage)
                                    .Take(RecordsPerPage).ToList().OrderByDescending(a=>a.DatePublished).ToList();
            return webContents;
        }
        public PostContent ContentById(int id)
        {
            var webContent = _DbContext.PostContents.Find(id);
            return webContent;
        }
        public PostContent AddContent(PostContentRequest postContentRequest)
        {
            Author author = new Author();
            author.Author1 = postContentRequest.Author;
            author.IsActive= true;
            _DbContext.Authors.Add(author);

            _DbContext.SaveChanges();

            PostType postType = new PostType();
            postType.PostType1 = postContentRequest.PostType;
            postType.IsActive = true;

            _DbContext.PostTypes.Add(postType);
            _DbContext.SaveChanges();

            PostContent obj = new PostContent();
            obj.Title = postContentRequest.Title;
            obj.DatePublished = postContentRequest.DatePublished;
            obj.AuthorId = author.Id;
            obj.PostTypeId = postType.Id;
            obj.TheContent=postContentRequest.TheContent;
            obj.IsActive = postContentRequest.IsActive;  
            _DbContext.PostContents.Add(obj);
            _DbContext.SaveChanges();

            return obj;
        }
    }
}
