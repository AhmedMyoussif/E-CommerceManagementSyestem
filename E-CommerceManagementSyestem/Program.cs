using System;
using System.Collections.Generic;
using System.Linq;
using E_CommerceManagementSyestem.Models;
using E_CommerceManagementSyestem;
using Microsoft.EntityFrameworkCore;
namespace E_CommerceManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== E-Commerce Management System =====");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Order Management");
                Console.WriteLine("3. Customer Management");
                Console.WriteLine("4. Exit");
                Console.Write("Select Your Choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ManageProducts();
                        break;
                    case 2:
                        ManageOrders();
                        break;
                    case 3:
                        ManageCustomers();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ManageProducts()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Product Management =====");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Edit Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Enter your choice: ");

                int choice =int.Parse( Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewProducts();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        EditProduct();
                        break;
                    case 4:
                        DeleteProduct();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ViewProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                var products = context.Products.Select(x=> new {x.ProductId , x.ProductName , x.Price , x.Weight , x.ProductSKU , x.Thumbnail,x.CreateDate , x.Stock });

                Console.Clear();
                if (!products.Any())
                {
                    Console.WriteLine("No products available.");
                }
                else
                {
                    Console.WriteLine("===== Product List =====");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}, Weight :{product.Weight}  , ProductSKU :{product.ProductSKU} ,Thumbnall : {product.Thumbnail} , Date : {product.CreateDate}, Stock: {product.Stock}");
                    }
                }
                Console.WriteLine("\nPress Enter to return...");
                Console.ReadLine();
            }
        }

        static void AddProduct()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.WriteLine("===== Add New Product =====");

                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                if (!double.TryParse(Console.ReadLine(), out double price))
                {
                    Console.WriteLine("Invalid price. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                Console.Write("Enter Stock Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int stock))
                {
                    Console.WriteLine("Invalid quantity. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Enter the weight: ");
                if (!double.TryParse(Console.ReadLine(), out double Weight))
                {
                    Console.WriteLine("Invalid quantity. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }
                var newProduct = new Product { ProductName = name, Price = price, Stock = stock  , Weight = Weight};

                try
                {
                    context.Products.Add(newProduct);
                    context.SaveChanges();

                Console.WriteLine("Product added successfully! Press Enter to return...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }

                Console.ReadLine();
            }
        }

        static void EditProduct()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Product ID to Edit: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    Console.WriteLine("Product not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                Console.Write("Enter New Name (or press Enter to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    product.ProductName = newName;
                }

                Console.Write("Enter New Price (or press Enter to keep current): ");
                string priceInput = Console.ReadLine();
                if (double.TryParse(priceInput, out double newPrice))
                {
                    product.Price =newPrice;
                }

                Console.Write("Enter New Stock Quantity (or press Enter to keep current): ");
                string stockInput = Console.ReadLine();
                if (int.TryParse(stockInput, out int newStock))
                {
                    product.Stock = newStock;
                }

                context.SaveChanges();

                Console.WriteLine("Product updated successfully! Press Enter to return...");
                Console.ReadLine();
            }
        }

        static void DeleteProduct()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Product ID to Delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    Console.WriteLine("Product not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                context.Products.Remove(product);
                context.SaveChanges();

                Console.WriteLine("Product deleted successfully! Press Enter to return...");
                Console.ReadLine();
            }
        }
        static void ManageOrders()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Order Management =====");
                Console.WriteLine("1. View Orders");
                Console.WriteLine("2. Add Order");
                Console.WriteLine("3. Edit Order");
                Console.WriteLine("4. Delete Order");
                Console.WriteLine("5. Veiw Order Datails");
                Console.WriteLine("6. Return to Main Menu");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewOrders();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        EditOrder();
                        break;
                    case 4:
                        DeleteOrder();
                        break;
                    case 5:
                        ViewOrderDetails();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }


        static void ViewOrders()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                var orders = context.Orders.ToList();

                if (!orders.Any())
                {
                    Console.WriteLine("No orders available.");
                }
                else
                {
                    Console.WriteLine("===== Order List =====");
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.OrderId}, Customer ID: {order.CustomerId}, Total Amount: {order.Ammount} , ShippingId:{order.ShippingAddress}, OrderAddress:{order.OrderAddress},OrderEmail:{order.OrderEmail}, OrderDate:{order.OrderDate}");
                    }
                }
                Console.WriteLine("\nPress Enter to return...");
                Console.ReadLine();
            }
        }

        static void AddOrder()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.WriteLine("===== Add New Order =====");

                Console.Write("Enter Customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("Invalid Customer ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    Console.Write("Do you want to add a new customer? (y/n): ");
                    string response = Console.ReadLine().Trim().ToLower();

                    if (response == "y")
                    {
                        AddCustomer();
                        customer = context.Customers.OrderByDescending(c => c.CustomerId).FirstOrDefault();
                        if (customer == null)
                        {
                            Console.WriteLine("Failed to add customer. Press Enter to return...");
                            Console.ReadLine();
                            return;
                        }
                        customerId = customer.CustomerId;
                    }
                    else
                    {
                        Console.WriteLine("Order cannot be added without a valid customer. Press Enter to return...");
                        Console.ReadLine();
                        return;
                    }
                }

                Console.Write("Enter Shipping Address: ");
                string shippingAddress = Console.ReadLine();

                Console.Write("Enter Order Address: ");
                string orderAddress = Console.ReadLine();

                Console.Write("Enter Order Email: ");
                string orderEmail = Console.ReadLine();

                var newOrder = new Order
                {
                    CustomerId = customer.CustomerId,
                    ShippingAddress = shippingAddress,
                    OrderAddress = orderAddress,
                    OrderEmail = orderEmail,
                    //OrderDate = DateTime.Now,
                    OrderStatus = "Pending",
                    OrderDetails = new List<OrderDetail>()
                };

                while (true)
                {
                    Console.Write("Enter Product ID (or 0 to finish): ");
                    if (!int.TryParse(Console.ReadLine(), out int productId) || productId == 0)
                        break;

                    var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (product == null)
                    {
                        Console.WriteLine("Product not found. Try again.");
                        continue;
                    }

                    Console.Write($"Enter Quantity for {product.ProductName}: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Invalid quantity. Try again.");
                        continue;
                    }

                    var orderDetail = new OrderDetail
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Price = product.Price,
                        SKU = "SKU-" + productId
                    };

                    newOrder.OrderDetails.Add(orderDetail);
                }

                newOrder.Ammount = (int)newOrder.OrderDetails.Sum(od => od.Quantity * od.Price);

                try
                {
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    Console.WriteLine(" Order added successfully with products! Press Enter to return...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error: {ex.Message}");
                }

                Console.ReadLine();
            }
        }


        static void EditOrder()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Order ID to Edit: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var order = context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order == null)
                {
                    Console.WriteLine("Order not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                Console.Write("Enter New Total Amount (or press Enter to keep current): ");
                string amountInput = Console.ReadLine();
                if (int.TryParse(amountInput, out int newAmount))
                {
                    order.Ammount = newAmount;
                }

                context.SaveChanges();

                Console.WriteLine("Order updated successfully! Press Enter to return...");
                Console.ReadLine();
            }
        }

        static void DeleteOrder()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Order ID to Delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var order = context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order == null)
                {
                    Console.WriteLine("Order not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                context.Orders.Remove(order);
                context.SaveChanges();

                Console.WriteLine("Order deleted successfully! Press Enter to return...");
                Console.ReadLine();
            }
        }

        static void ViewOrderDetails()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Order ID to view details: ");

                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var order = context.Orders
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .FirstOrDefault(o => o.OrderId == orderId);

                if (order == null)
                {
                    Console.WriteLine("Order not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\n===== Order Details =====");
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Customer ID: {order.CustomerId}");
                Console.WriteLine($"Total Amount: {order.Ammount}");
                Console.WriteLine($"Shipping Address: {order.ShippingAddress}");
                Console.WriteLine($"Order Address: {order.OrderAddress}");
                Console.WriteLine($"Order Email: {order.OrderEmail}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Order Status: {order.OrderStatus}");

                Console.WriteLine("\n===== Order Items =====");
                if (order.OrderDetails != null && order.OrderDetails.Any())
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        Console.WriteLine($"- Product: {orderDetail.Product.ProductName}");
                        Console.WriteLine($"  Quantity: {orderDetail.Quantity}");
                        Console.WriteLine($"  Price per unit: {orderDetail.Product.Price}");
                        Console.WriteLine($"  Total: {orderDetail.Quantity * orderDetail.Product.Price}");
                        Console.WriteLine("---------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No products found in this order.");
                }

                Console.WriteLine("\nPress Enter to return...");
                Console.ReadLine();
            }
        }

        static void ManageCustomers()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Customer Management =====");
                Console.WriteLine("1. View Customers");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Edit Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewCustomers();
                        break;
                    case "2":
                        AddCustomer();
                        break;
                    case "3":
                        EditCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ViewCustomers()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                var customers = context.Customers.ToList();

                if (!customers.Any())
                {
                    Console.WriteLine("No customers available.");
                }
                else
                {
                    Console.WriteLine("===== Customer List =====");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}");
                    }
                }
                Console.WriteLine("\nPress Enter to return...");
                Console.ReadLine();
            }
        }

        static void AddCustomer()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.WriteLine("===== Add New Customer =====");

                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Customer Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                var newCustomer = new Customer
                {
                    Name = name,
                    Email = email
                };

                newCustomer.SetPassword(password);

                try
                {
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    Console.WriteLine("Customer added successfully! Press Enter to return...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to add customer. Error: {ex.Message}");
                 
                }

                Console.ReadLine();
            }
        }


        static void EditCustomer()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Customer ID to Edit: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                Console.Write("Enter New Name (or press Enter to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    customer.Name = newName;
                }

                Console.Write("Enter New Email (or press Enter to keep current): ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    customer.Email = newEmail;
                }

                context.SaveChanges();

                Console.WriteLine("Customer updated successfully! Press Enter to return...");
                Console.ReadLine();
            }
        }

        static void DeleteCustomer()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                Console.Write("Enter Customer ID to Delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found. Press Enter to return...");
                    Console.ReadLine();
                    return;
                }

                context.Customers.Remove(customer);
                context.SaveChanges();

                Console.WriteLine("Customer deleted successfully! Press Enter to return...");
                Console.ReadLine();
            }
        }

    }
}
