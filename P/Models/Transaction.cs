using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models
{
    public class Transaction
    {
        [Key] // المفتاح الرئيسي
        public int Id { get; set; }

        [Required] // الرقم المرجعي من PayPal
        public string ReferenceId { get; set; }

        [Required] // رقم الطلب المرتبط بالعملية
        public string OrderId { get; set; }

        [Required] // المبلغ المدفوع
        public decimal Amount { get; set; }

        [Required] // العملة المستخدمة
        public string Currency { get; set; }

        [Required] // حالة العملية (مثلاً: Completed, Failed, Pending)
        public string Status { get; set; }

        [Required] // وقت إنشاء العملية
        public DateTime CreatedAt { get; set; }

        // ممكن تضيف خصائص إضافية لو عندك معلومات تانية
        // مثلاً ID المستخدم أو أي معلومات إضافية تحتاجها.
    
}
}
