using Ls.Models;
using Ls.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ls.Service
{
    public interface IWebSiteBaseInfoService
    {
        WebSiteBaseInfo GetInfo();
    }
    public class WebSiteBaseInfoService: IWebSiteBaseInfoService
    {
        private IWebSiteBaseInfoRepository _websiteBaseInfoRepository;

        public WebSiteBaseInfoService(IWebSiteBaseInfoRepository websiteBaseInfoRepository)
        {
            _websiteBaseInfoRepository = websiteBaseInfoRepository;
        }

        public WebSiteBaseInfo GetInfo()
        {
            return _websiteBaseInfoRepository.GetAll().First();
        }
    }
}
