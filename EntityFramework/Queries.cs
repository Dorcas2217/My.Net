using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Queries
    {
        NorthwindContext context = new NorthwindContext();

        public void customersList()
        {
            Console.WriteLine("Entrez le nom de la ville :");
            string nameVille = Console.ReadLine();
            var customers = from Customer c in context.Customers 
                                             where (c.City == nameVille)
                                             select new
                                             {
                                                 c.CustomerId, 
                                                 c.CompanyName
                                             };

            Console.WriteLine("Liste des clients de la ville " + nameVille + " :");

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CustomerId + " : " + customer.CompanyName);
            }
        }

        public void productsList_LazyLoading()
        {
            Console.WriteLine("Liste des produits de la catégorie Beverages et condiments : (Lazy loading)");


            var categories = from Category c in context.Categories
                             where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                             select c;
                             
            foreach(var category in categories)
            {
                Console.WriteLine("\nCategorie : " + category.CategoryName + "\n");

                foreach (var product in category.Products)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

        public void productsList_EagerLoading()
        {
            Console.WriteLine("Liste des produits de la catégorie Beverages et condiments : (Eager loading)");


            var categories = from Category c in context.Categories.Include("Products")
                             where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                             select c;

            foreach (var category in categories)
            {
                Console.WriteLine("\nCategorie : " + category.CategoryName + "\n");

                foreach (var product in category.Products)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

        public void OrderList()
        {
            Console.WriteLine(" Entrez l'ID du client : ");
            string IDCustomer = Console.ReadLine()!;

            var orders = from Order o in context.Orders
                         where (o.CustomerId == IDCustomer && o.ShippedDate != null)
                         orderby o.OrderDate descending 
                         select new
                         {
                             o.CustomerId,
                             o.OrderDate,
                             o.ShippedDate
                         };
            foreach (var order in orders)
            {
                Console.WriteLine("CustomerID : " + order.CustomerId + " OrderDate : " + order.OrderDate + " ShippedDate : " + order.ShippedDate);
            }

        }

        public void TotalSales()
        {
            var totalSales = from OrderDetail od in context.OrderDetails
                             orderby od.ProductId
                             group od by od.ProductId ;
                             
            
            foreach (IGrouping<int, OrderDetail> orderDetail in totalSales)
            {
                Console.WriteLine(orderDetail.Key + " ---> " + orderDetail.Sum(o => o.Quantity * o.UnitPrice));
            }
        }

        public void EmployeesWestern()
        {
            var employees = from Employee e in context.Employees
                            where e.Territories.Any(e => e.Region.RegionDescription == "Western")
                            select new
                            {
                                e.FirstName,
                                e.LastName
                            };

        Console.WriteLine(" Les employés qui ont sous leur responsabilité la région Western :");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }
        }

        public void territoriesRmploye()
        {
            var territories = context.Employees
            .Where(e => e.InverseReportsToNavigation.Any(et => et.LastName == "Suyama"))
            .SelectMany(e => e.Territories)
            .ToList();

            Console.WriteLine(" Les territoires gérés par le supérieur de suyama Michael:");

            foreach (Territory territory in territories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
        }

        public void nameCompanyToUpper ()
        {
            var customers = from Customer c in context.Customers
                            select c;
            Console.WriteLine("\n Liste des entreprises en minuscule (si pas encore exécuté ): \n ");

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CompanyName);
                customer.CompanyName = customer.CompanyName.ToUpper();
            }

            context.SaveChanges();

            var test = from Customer c in context.Customers
                            select c;

            Console.WriteLine("\n Liste des entreprises en majuscule : \n ");
            foreach (var customer in test)
            {
                Console.WriteLine(customer.CompanyName);
            }

        }

        public void addCategory()
        {
            Console.WriteLine(" Entrez le nom de la categorie : \n ");
            string nameCategory = Console.ReadLine()!;
            Category category = new Category();
            category.CategoryName = nameCategory;
           
            context.Add(category);
            
            try
            {
            context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }   
            
            var Categories = from Category c in context.Categories
                             select c;

            foreach (var ca in Categories)
            {
                Console.WriteLine(ca.CategoryName);
            }
        }

        public void DeleteCategory()
        {
            Console.WriteLine(" Entrez le nom de la categorie : \n ");
            string nameCategory = Console.ReadLine()!;
            Category? category = context.Categories.FirstOrDefault(e => e.CategoryName == nameCategory);

            if (category != null)
            {
                context.Remove(category);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("La catégorie n'existe pas");
            }

            var Categories = from Category c in context.Categories
                             select c;

            foreach (var ca in Categories)
            {
                Console.WriteLine(ca.CategoryName);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans mon super exercice Entity Framework ! (Semaine 3) ");
            Console.WriteLine("Entrez le numéro d'un exercice : "); 
            int numExo = Convert.ToInt32(Console.ReadLine());

            Queries queries = new Queries();
            
            switch (numExo)
            {
                case 1:
                    queries.customersList();
                    break;
                case 2:
                    queries.productsList_LazyLoading();
                    break;
                case 3:
                    queries.productsList_EagerLoading();
                    break;
                case 4:
                    queries.OrderList();
                    break;
                case 5:
                    queries.TotalSales();
                    break;
                case 6:
                    queries.EmployeesWestern();
                    break;
                case 7:
                    queries.territoriesRmploye();
                    break;
                case 8:
                    queries.nameCompanyToUpper();
                    break;
                case 9:
                    queries.addCategory();
                    break;
                case 10:
                    queries.DeleteCategory();
                    break;


            }

        }
    }
}
