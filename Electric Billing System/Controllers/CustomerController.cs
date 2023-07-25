using EBS.DomainLayer.Models;
using EBS.RepositoryLayer;
using EBS.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CustomerController : ControllerBase
    {
        private readonly EBSDBContext _db;
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration config;
        private readonly InterfaceCustomerService CustomerServices;
        private readonly InterfaceAdminService AdminServices;
        private readonly InterfacePaymentService PaymentServices;
        private readonly InterfaceBillService BillServices;
        


        public CustomerController(ILogger<CustomerController> logger, IConfiguration config,
            InterfaceCustomerService CustomerServices, EBSDBContext db, InterfaceAdminService AdminServices
            , InterfacePaymentService PaymentServices, InterfaceBillService BillServices
            )
        {
            _logger = (ILogger<CustomerController>)logger;
            _logger.LogInformation("Customer");
            this.config = config;
            this.CustomerServices = CustomerServices;
            this.AdminServices = AdminServices;
            this.PaymentServices = PaymentServices;
            this.BillServices = BillServices;
            _db = db;
            
        }

        [HttpPost(nameof(CustomerRegistration))]
        public ActionResult CustomerRegistration(Customer CustomerRegistration)
        {
            try
            {
                

                CustomerServices.CustomerRegistration(CustomerRegistration);

                return Ok("New Customer " +CustomerRegistration.customer_name+ " Registered");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpPut(nameof(EditProfile))]
        public ActionResult EditProfile(Customer EditProfile)
        {
            try
            {
                CustomerServices.EditProfile(EditProfile);

                return Ok("Profile Updated");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }

        [HttpGet("{customer_id}")]

        public async Task<ActionResult<Customer>> GetCustomerDetails(int customer_id)
        {
            if(_db.Customer == null)
            {
                return NotFound();
            }
            var Customer = await _db.Customer.FindAsync(customer_id);
            if(Customer == null)
            {
                return NotFound();
            }
            return Customer;
            
        }
        [HttpDelete(nameof(DeleteProfile))]
        public async Task<ActionResult> DeleteProfile(int customer_id)
        {
            try
            {
                var Customer = await _db.Customer.FindAsync(customer_id);
                CustomerServices.DeleteCustomer(customer_id);

                return Ok("Customer " + Customer.customer_name + " Removed");

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");
        }

        //PAYMENT

        [HttpPut(nameof(UpdatePayment))]
        public ActionResult UpdatePayment(Payment UpdatePayment)
        {
            try
            {
                PaymentServices.UpdatePayment(UpdatePayment);

                return Ok("Payment successful");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        //BILL
        [HttpGet(nameof(BillList))]
        public ActionResult BillList()
        {
            try
            {
                var Bill = BillServices.BillList();
                if (Bill != null)
                {
                    return Ok(Bill);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }

            return BadRequest("Not found");
        }






    }
}
