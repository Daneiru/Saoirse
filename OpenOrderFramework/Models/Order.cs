using OpenOrderFramework.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OpenOrderFramework.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        public Order() {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [ScaffoldColumn(false)]
        public int OrderID { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [DisplayName("Current Status")]
        public OrderStatus OrderStatus { get; set; }

        public string TrackingNumber { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        public string Comments { get; set; }

        #region Address
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }
        #endregion

        #region Cc Info
        [Display(Name = "Experation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Experation { get; set; }

        [Display(Name = "Credit Card")]
        [NotMapped]
        [Required]
        [DataType(DataType.CreditCard)]
        public String CreditCard { get; set; }

        [Display(Name = "Credit Card Type")]
        [NotMapped]
        public String CcType { get; set; }

        public bool SaveInfo { get; set; }
        #endregion

        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public decimal ShippingCost { get; set; }

        #region 1 : m 
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion


        public string ToString(Order order) {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<p>Order Information for Order: "+ order.OrderID +"<br>Placed at: " + order.OrderDate +"</p>").AppendLine();
            strBuilder.Append("<p>Name: " + order.FirstName + " " + order.LastName + "<br>");
            strBuilder.Append("Address: " + order.Address + " " + order.City + " " + order.State + " " + order.PostalCode + "<br>");
            strBuilder.Append("Contact: " + order.Email + "     " + order.Phone + "</p>");
            strBuilder.Append("<p>Charge: " + order.CreditCard + " " + order.Experation.ToString("dd-MM-yyyy") + "</p>");
            strBuilder.Append("<p>Credit Card Type: " + order.CcType + "</p>");

            strBuilder.Append("<br>").AppendLine();
            strBuilder.Append("<Table>").AppendLine();

            // Display header 
            string header = "<tr> <th>Item Name</th>" + "<th>Quantity</th>" + "<th>Price</th> <th></th> </tr>";
            strBuilder.Append(header).AppendLine();

            String output = String.Empty;
            try {
                foreach (var item in order.OrderDetails) {
                    strBuilder.Append("<tr>");
                    output = "<td>" + item.Item.Name + "</td>" + "<td>" + item.Quantity + "</td>" + "<td>" + item.Quantity * item.UnitPrice + "</td>";
                    strBuilder.Append(output).AppendLine();
                    Console.WriteLine(output);
                    strBuilder.Append("</tr>");
                }
            } catch (Exception ex) { output = "No items ordered."; }

            strBuilder.Append("</Table>");
            strBuilder.Append("<b>");

            // Display footer 
            string footer = String.Format("{0,-12}{1,12}\n", "Total", order.Total);
            strBuilder.Append(footer).AppendLine();
            strBuilder.Append("</b>");

            return strBuilder.ToString(); // Return.
        }
    }

    public enum OrderStatus
    {
        Submitted,
        PaymentProcessed,
        PaymentFailed,
        CreationStarted,
        Shipped
    }

    public enum ShipmentType
    {
        USPSPriority,
        USPSExpress,
    }
}