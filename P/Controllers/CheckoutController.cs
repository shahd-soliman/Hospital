using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P.Models;
using WebApplication3.Client;
using WebApplication3.Help;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin,Patient")]
    public class CheckoutController : Controller
    {
        [TempData]
        public string TotalAmount { get; set; } = null;
        public int total { get; set; }
        private readonly PaypalClient _paypalClient;
        HospitalContext _context = new HospitalContext();
        public CheckoutController(PaypalClient paypalclient)
        {
            _paypalClient = paypalclient;
        }
        public IActionResult Details()
        {
            ViewBag.DocList = _context.Doctors.ToList();
            return View();
        }
        public IActionResult Index(int id)
        {
            ViewBag.ClientId = _paypalClient.ClientId;

            try
            {
                Department dept = _context.Departments.FirstOrDefault(x => x.DeptId == id);
                ViewBag.DollarAmount = dept.Cost;
                total = ViewBag.DollarAmount;
                TotalAmount = total.ToString();
                TempData["TotalAmount"] = TotalAmount;

            }
            catch (Exception)
            {


            }
            return View();

        }

        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            //var optionCust = new CustomerCreateOptions
            //{
            //    Email = stripeEmail,
            //    Name = "Rizwan Yousaf",
            //    Phone = "338595119"
            //};
            //var serviceCust = new CustomerService();
            //Customer customer = serviceCust.Create(optionCust);
            //var optionsCharge = new ChargeCreateOptions
            //{
            //    Amount = Convert.ToInt64(TempData["TotalAmount"]),
            //    Currency = "USD",
            //    Description="Pet Selling amount",
            //    Source=stripeToken,
            //    ReceiptEmail=stripeEmail

            //};
            //var serviceCharge = new ChargeService();
            //Charge charge = serviceCharge.Create(optionsCharge);
            //if(charge.Status=="successded")
            //{
            //    ViewBag.AmountPaid = charge.Amount;
            //    ViewBag.Customer = customer.Name;
            //}
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = TotalAmount;
                var currency = "USD";

                // "reference" is the transaction key
                var reference = GetRandomInvoiceNumber();// "INV002";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                //var response = await _paypalClient.CaptureOrder(orderId);

                //var reference = response.purchase_units[0].reference_id;




                //// Put your logic to save the transaction here
                //// You can use the "reference" variable as a transaction key
                //return Ok(response);
                // استدعاء PayPal لالتقاط الدفع
                var response = await _paypalClient.CaptureOrder(orderId);

                // التحقق من أن response و purchase_units غير فاضية
                if (response != null && response.purchase_units != null && response.purchase_units.Any())
                {
                    // جلب حالة الدفع
                    var status = response.status;

                    // التحقق من حالة الدفع
                    if (status == "COMPLETED")
                    {
                        var reference = response.purchase_units[0].reference_id;

                        if (string.IsNullOrEmpty(reference))
                        {
                            return BadRequest(new { Message = "Reference ID is null or empty." });
                        }

                        // أكمل منطق الحفظ إذا كانت العملية مكتملة
                        var transaction = new Transaction
                        {
                            ReferenceId = reference,
                            OrderId = orderId,
                            Amount = decimal.Parse(response.purchase_units[0].amount.value),
                            Currency = response.purchase_units[0].amount.currency_code,
                            Status = "Completed",
                            CreatedAt = DateTime.UtcNow
                        };

                        _context.Transactions.Add(transaction);
                        await _context.SaveChangesAsync(cancellationToken);

                        return Ok(response);
                    }
                    else if (status == "FAILED")
                    {
                        // إذا فشلت العملية (قد يكون السبب عدم وجود فلوس كافية)
                        return BadRequest(new { Message = "Transaction failed due to insufficient funds or another issue." });
                    }
                    else if (status == "PENDING")
                    {
                        // لو كانت العملية في انتظار (مثلاً في حالة المعالجة)
                        return Ok(new { Message = "Transaction is pending. Please wait." });
                    }
                    else
                    {
                        return BadRequest(new { Message = $"Transaction status: {status}" });
                    }
                }
                else
                {
                    return BadRequest(new { Message = "Invalid response or purchase units are missing." });
                }

            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        public static string GetRandomInvoiceNumber()
        {
            return new Random().Next(999999).ToString();
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
