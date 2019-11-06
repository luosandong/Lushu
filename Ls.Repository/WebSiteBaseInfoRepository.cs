using Ls.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Repository
{
    public interface IWebSiteBaseInfoRepository :IBaseRepository<WebSiteBaseInfo>
    {

    }
    public class WebSiteBaseInfoRepository:BaseRepository<WebSiteBaseInfo>, IWebSiteBaseInfoRepository
    {
    }
}
