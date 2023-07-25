using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBS.ServiceLayer;
using EBS.DomainLayer.Models;
using Microsoft.Extensions.Logging;
using EBS.RepositoryLayer;
using Microsoft.Extensions.Configuration;

namespace Electric_Billing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration config;
        private readonly InterfaceAdminService AdminServices;
        private readonly InterfaceCustomerService CustomerServices;
        private readonly InterfacePaymentService PaymentServices;
        private readonly InterfaceBillService BillServices;
        private readonly EBSDBContext _db;

        public AdminController(ILogger<AdminController> logger, IConfiguration config,
            InterfaceAdminService AdminServices, InterfaceCustomerService CustomerServices, EBSDBContext db
            , InterfacePaymentService PaymentServices, InterfaceBillService BillServices)
        {
            _logger = (ILogger<AdminController>)logger;
            _logger.LogInformation("Admin");
            this.config = config;
            this.AdminServices = AdminServices;
            this.CustomerServices = CustomerServices;
            this.PaymentServices = PaymentServices;
            this.BillServices = BillServices;
            _db = db;
        }

        [HttpPost(nameof(AdminRegistration))]
        public ActionResult AdminRegistration(Admin AdminRegistration)
        {
            try
            {

                AdminServices.AdminRegistration(AdminRegistration);

                return Ok("Admin " + AdminRegistration.admin_name + " Registered");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        

        [HttpPut(nameof(EditProfile))]
        public ActionResult EditProfile(Admin EditProfile)
        {
            try
            {
                AdminServices.EditProfile(EditProfile);

                return Ok("Profile Updated");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpGet("{admin_id}")]

        public async Task<ActionResult<Admin>> GetCustomerDetails(int admin_id)
        {
            if (_db.Admin == null)
            {
                return NotFound();
            }
            var Admin = await _db.Admin.FindAsync(admin_id);
            if (Admin == null)
            {
                return NotFound();
            }
            return Admin;
        }

        [HttpGet(nameof(CustomersList))]
        public ActionResult CustomersList()
        {
            try
            {
                var customers = CustomerServices.CustomersList();
                if (customers != null)
                {
                    return Ok(customers);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }

            return BadRequest("Not found");
        }
        [HttpDelete(nameof(DeleteCustomer))]
        public async Task<ActionResult> DeleteCustomer(int customer_id)
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

        [HttpGet(nameof(PaymentsList))]
        public ActionResult PaymentsList()
        {
            try
            {
                var Payment = PaymentServices.PaymentsList();
                if (Payment != null)
                {
                    return Ok(Payment);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }

            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertPayment))]
        public ActionResult InsertPayment(Payment InsertPayment)
        {
            try
            {


                PaymentServices.InsertPayment(InsertPayment);

                return Ok("Payment of Rs" + InsertPayment.payment_billamount + " is added");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }

        [HttpDelete(nameof(DeletePayment))]
        public async Task<ActionResult> DeletePayment(int payment_no)
        {
            try
            {
                var Payment = await _db.Payment.FindAsync(payment_no);
                PaymentServices.DeletePayment(payment_no);

                return Ok("Payment Details Removed");

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
        [HttpPost(nameof(InsertBill))]
        public ActionResult InsertBill(Bill InsertBill)
        {
            try
            {


                BillServices.InsertBill(InsertBill);

                return Ok("Bill of Rs" + InsertBill.bill_amount + " is added");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpPut(nameof(EditBill))]
        public ActionResult EditBill(Bill EditBill)
        {
            try
            {
                BillServices.EditBill(EditBill);

                return Ok("Bill Edited successfully");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpDelete(nameof(DeleteBill))]
        public async Task<ActionResult> DeleteBill(int bill_id)
        {
            try
            {
                var Bill = await _db.Bill.FindAsync(bill_id);
                BillServices.DeleteBill(bill_id);

                return Ok("Bill Details Removed");

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");
        }








    }
}
