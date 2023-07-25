using EBS.DomainLayer.Models;
using EBS.RepositoryLayer;
using EBS.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electric_Billing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly IConfiguration config;
        private readonly InterfaceAdminService AdminServices;
        private readonly InterfaceCustomerService CustomerServices;
        private readonly InterfacePaymentService PaymentServices;
        private readonly InterfaceBillService BillServices;
        private readonly EBSDBContext _db;

        public BillController(ILogger<BillController> logger, IConfiguration config,
            InterfaceAdminService AdminServices, InterfaceCustomerService CustomerServices, EBSDBContext db
            , InterfacePaymentService PaymentServices, InterfaceBillService BillServices)
        {
            _logger = (ILogger<BillController>)logger;
            _logger.LogInformation("Bill");
            this.config = config;
            this.AdminServices = AdminServices;
            this.CustomerServices = CustomerServices;
            this.PaymentServices = PaymentServices;
            this.BillServices = BillServices;
            _db = db;
        }

        [HttpGet("{bill_id}")]

        public async Task<ActionResult<Bill>> GetBillDetails(int bill_id)
        {
            if (_db.Bill == null)
            {
                return NotFound();
            }
            var Bill = await _db.Bill.FindAsync(bill_id);
            if (Bill == null)
            {
                return NotFound();
            }
            return Bill;
        }
    }
}
