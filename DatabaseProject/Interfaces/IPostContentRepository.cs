using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Interfaces
{
    public interface IPostContentRepository
    {
        List<PostContent> GetContents(int PageNumber,int RecordsPerPage);
        PostContent ContentById (int id);
        PostContent AddContent (PostContentRequest postContent); 
    }
}
