using Invoicing.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoicing.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IBusinessData _data;

        public DashboardController( IBusinessData data)
        {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<decimal> GetSalesRevenue()
        {
            IEnumerable<decimal> tab = new decimal[] { _data.SalesRevenue, _data.Outstanding}; // Dans l'exercice 3 j'ai fait une erreur, j'ai mis 2 fois SalesRevenue

            return tab;

        }

    }
}
