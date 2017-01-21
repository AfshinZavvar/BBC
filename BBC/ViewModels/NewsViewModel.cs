using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBC.Models;

namespace BBC.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<INews> News { get; set; }
    }
}