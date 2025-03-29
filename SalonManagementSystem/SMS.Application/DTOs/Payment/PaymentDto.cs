using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class PaymentDto
    {
            public Guid PaymentId { get; set; } // Primary Key

            public Guid AppointmentId { get; set; } // Foreign Key to Appointments Table

            public Guid UserId { get; set; } // Foreign Key to Users Table

            public decimal Amount { get; set; } // Payment amount

            public string Currency { get; set; } // Optional: Currency type (e.g., USD, EUR)

            public string PaymentMethod { get; set; } // Payment method (Card, PayPal, etc.)

            public string Status { get; set; } // Payment status: Successful, Failed, Pending

            public string TransactionId { get; set; } // Unique transaction identifier from payment gateway

            public string PaymentGateway { get; set; } // Payment gateway (e.g., Stripe, PayPal)

            public decimal? DiscountAmount { get; set; } // Optional: Discount amount applied to the payment
            public DateTime? PaymentDate { get; set; } // Optional: Date the payment was completed
      
    }

    }



