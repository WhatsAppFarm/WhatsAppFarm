using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using WhatsAppFarm.Server.Data;

namespace WhatsAppFarm.Server.Controllers
{
    public partial class ExportpostgresController : ExportController
    {
        private readonly postgresContext context;
        private readonly postgresService service;

        public ExportpostgresController(postgresContext context, postgresService service)
        {
            this.service = service;
            this.context = context;
        }
    }
}
