// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

namespace TravelDatabase
{
    [Devin]
    public class CustomerAccount
    {
        public string FirstName { get; set; } // 25 char
        public string LastName { get; set; } // 25 char
        public string Address { get; set; } // 75 char
        public string City { get; set; } // 50 char
        public string ProvinceCode { get; set; } // 2 char
        public string PostalCode { get; set; } // 7 char (with space)
        public string Country { get; set; } // can be null in DB
        public string HomePhone { get; set; } // can be null in DB

        // TODO: Field is REQUIRED in DB, but must be made optional for project requirement
        public string BusinessPhone { get; set; }

        // TODO: Field is REQUIRED in DB, but (must?) be made optional for project requirement
        //       I think we should use email addresses as UserId's, explaining that an email
        //       address is not only unique to the individual, but provides a mechanism for
        //       automatic account recovery as a potential upgrade. Unless, of course, the
        //       company is adamant that some user's won't be able to set up an email account.
        public string Email { get; set; }


        // Here's where this entity differs from an exact representation of the table.
        // -- 1. AgentID is optional in the DB. For now, I've left it off because it's not strictly
        //       necessary for the required use case (register customer & view customer invoices.)
        // -- 2. We gotta figure out how much these motherfuckers owe. It looks like the total is
        //       just the price+commission in the BookingDetails table. That's the final charge,
        //       with one "gotcha"...
        // -- 3. There is a confusing "FeeId" FK which references a very specific amount. (Stuff like 
        //       "No Charge" and "$25 refund" are included in the Fees table.)
        // -- 4. To store totals, we'll need a new entity to store the fee name + amounts.

        // BookingInvoice entity: 
        //     int BookingDetailsId, decimal BasePrice, decimal AgencyCommission, string FeeId, string FeeName, decimal FeeAmount
        // --------------------------------------
        // SELECT c.CustomerId, bd.BasePrice, bd.AgencyCommission, f.FeeId, f.FeeName, f.FeeAmt
        // FROM BookingDetails bd, Bookings b, Fees f, Customers c
        // WHERE bd.BookingId=b.BookingId AND bd.FeeId= f.FeeId AND b.CustomerId=c.CustomerId

        // public List<BookingInvoice> Bookings { get; } = new List<BookingInvoice>(); // Readonly (no update/delete by customer)
    }
}
