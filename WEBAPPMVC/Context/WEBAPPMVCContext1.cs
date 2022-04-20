using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBAPPMVC.Models;

namespace WEBAPPMVC.Context
{
    public class WEBAPPMVCContext1 : DbContext
    {
        public DbSet<MODEL1> MODELs { get; set; }
    }
}