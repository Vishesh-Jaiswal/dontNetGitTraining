using ShoppingBLLibrary;
using ShoppingModelLibrary;
namespace ShoppingApp
{
    internal class Program
    {
        IProductService productService;
        ICustomerService customerService;
        public Program()
        {
            productService = new ProductService();
            customerService = new CustomerService();
        }

        void MainMenu()
        {
            Console.WriteLine("1. For Products");
            Console.WriteLine("2. For Customer");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter Your Choice");
        }

        void MainActivities()
        {
            int choice;
            do
            {
                MainMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        StartAdminActivities();
                        break;
                    case 2:
                        StartCustomerActivities();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product Price");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Print All Products");
            Console.WriteLine("0. Main Menu");
            Console.WriteLine("Enter Your Choice");
        }
        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        MainMenu();
                        break;
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdatePrice();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        PrintAllProducts();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        void DisplayCustomerMenu()
        {
            Console.WriteLine("1. Add new user");
            Console.WriteLine("2. Show all customers");
            Console.WriteLine("3. For Login");
            Console.WriteLine("0. For Main Menu");
            Console.WriteLine("Enter Your Choice");
        }
        void StartCustomerActivities()
        {
            int choice;
            do
            {
                DisplayCustomerMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        MainMenu();
                        break;
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        ShowAllCustomers();
                        break;
                    case 3:
                        UserLogin();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        void AddCustomer()
        {
            try
            {
                Customer customer = TakeCustomerDetails();
                var result = customerService.AddCustomer(customer);
                if (result != null)
                {
                    Console.WriteLine("Customer added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        Customer TakeCustomerDetails()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Customer's Email");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Please enter customer's age");
            customer.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the customer's phone number");
            customer.Phone = Console.ReadLine();
            Console.WriteLine("Please enter the a password");
            customer.Password = Console.ReadLine();
            return customer;
        }

        private void ShowAllCustomers()
        {
            Console.WriteLine("***********************************");
            var cutomers = customerService.GetCustomers();
            foreach (var item in cutomers)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        /// <summary>
        /// User Login
        /// </summary>

        void UserLogin()
        {
            try
            {
                string email, passwd;
                Console.WriteLine("Enter your email");
                email = Console.ReadLine();
                Console.WriteLine("Enter your password");
                passwd = Console.ReadLine();
                var result = customerService.Login(email, passwd);
                if (result)
                {
                    Console.WriteLine("Login Success");
                }
            }
            catch(UserNamePasswordIncorrect e)
            {
                Console.WriteLine(e.Message);
            }

        }

        void AddProduct()
        {
            try
            {
                Product product = TakeProductDetails();
                var result = productService.AddProduct(product);
                if (result != null)
                {
                    Console.WriteLine("Product added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        Product TakeProductDetails()
        {
            Product product = new Product();
            Console.WriteLine("Please enter the product name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Please enter the product price");
            product.Price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please enter the product quantity");
            product.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the product description");
            product.Description = Console.ReadLine();
            Console.WriteLine("Please enter the product discount that you can offer");
            product.Discount = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please enter the product picture path");
            product.Picture = Console.ReadLine();
            return product;
        }

        private void UpdatePrice()
        {
            var id = GetProductIdFromUser();
            Console.WriteLine("Please enter the new price");
            float price = Convert.ToSingle(Console.ReadLine());
            Product product = new Product();
            product.Price = price;
            product.Id = id;
            try
            {
                var result = productService.UpdateProductPrice(id, price);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchProductException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void DeleteProduct()
        {
            try
            {
                int id = GetProductIdFromUser();
                if (productService.Delete(id) != null)
                    Console.WriteLine("Product deleted");
            }
            catch (NoSuchProductException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PrintAllProducts()
        {
            Console.WriteLine("***********************************");
            var products = productService.GetProducts();
            foreach (var item in products)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        
        int GetProductIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the product id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        
        static int Main(string[] args)
        {
            Program program = new Program();
            program.MainActivities();
            return 0;
        }
    }
}