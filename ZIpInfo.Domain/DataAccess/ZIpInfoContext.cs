using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZipInfoEntity = ZipInfo.Domain.DataAccess.Entities.ZipInfo;

namespace ZipInfo.Domain.DataAccess
{
    public class ZIpInfoContext : DbContext
    {
        public ZIpInfoContext(DbContextOptions<ZIpInfoContext> options) : base(options)
        {

        }

        public DbSet<ZipInfoEntity> ZipInfos { get; set; }
    }
}
