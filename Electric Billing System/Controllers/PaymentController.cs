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
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IConfiguration config;
        private readonly InterfaceAdminService AdminServices;
        private readonly InterfaceCustomerService CustomerServices;
        private readonly InterfacePaymentService PaymentServices;
        private readonly InterfaceBillService BillServices;
        private readonly EBSDBContext _db;

        public PaymentController(ILogger<PaymentController> logger, IConfiguration config,
            InterfaceAdminService AdminServices, InterfaceCustomerService CustomerServices, EBSDBContext db
            , InterfacePaymentService PaymentServices, InterfaceBillService BillServices)
        {
            _logger = (ILogger<PaymentController>)logger;
            _logger.LogInformation("Bill");
            this.config = config;
            this.AdminServices = AdminServices;
            this.CustomerServices = CustomerServices;
            this.PaymentServices = PaymentServices;
            this.BillServices = BillServices;
            _db = db;
        }
        [HttpGet("{payment_no}")]

        public async Task<ActionResult<Payment>> GetPaymentDetails(int payment_no)
        {
            if (_db.Payment == null)
            {
                return NotFound();
            }
            var Payment = await _db.Payment.FindAsync(payment_no);
            if (Payment == null)
            {
                return NotFound();
            }
            return Payment;
        }

    }
}
