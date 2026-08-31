namespace AdvancedC_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region starter code

            #endregion

            #region Task01

            /* Write a single method called SearchProducts that accepts 
                two parameters:  
                1. The product list (List<Product>)  
                2. A delegate representing the filter condition (Func<Product , bool>)  
                The method should return a List containing only the products that satisfy the 
                condition. Then, call this method four times with different lambda expressions to 
                perform the following searches:  
                1. All Electronics products  
                2. Products cheaper than $50  
                3. Products that are in stock (Stock > 0)  
                4. Clothing products under $100
            */ 

            // استخدمت func عشان عايزة اباصي الاوبجيكت و بعد كده اعمل فلتر على حسب ما اليوزر يدخل و بعدها يرجع bool 
            // كان ممكن استخدم pridicate بس الفايل كاتب func ف استخدمتها
            Func<Product, bool> isElectronic = p => p.Category == "Electronics";
            Func<Product, bool> isCheaperThan50 = p => p.Price < 50;
            Func<Product, bool> inStock = p => p.Stock > 0;
            Func<Product, bool> clothesUnder100 = p => p.Category == "Clothing";
            List<Product> electronis=Product.SearchProducts(Product.catalog,isElectronic);
            Console.WriteLine("--Electronics--");
            foreach (Product item in electronis)
            {
                //Console.WriteLine($"{item.Name} - {item.Price} (Stock : {item.Stock})");
                Console.WriteLine(item);

            }

            Console.WriteLine("");

            List<Product> cheaperThan50 = Product.SearchProducts(Product.catalog, isCheaperThan50);
            Console.WriteLine("--Under 50$--");

            foreach (Product item in cheaperThan50)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            List<Product> stocked=Product.SearchProducts(Product.catalog, inStock);
            Console.WriteLine("--In stock--");

            foreach (Product item in stocked)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            List<Product> clothesUnderOneHandared=Product.SearchProducts(Product.catalog, clothesUnder100);
            Console.WriteLine("--Clothing under 100$--");

            foreach (Product item in clothesUnderOneHandared)
            {
                if (item.Price < 100) { Console.WriteLine(item); }
                
            }

            #endregion

            #region Task3.1

            /*
            Write a method called PrintReport that accepts the product list and an Action.
            The method loops through all products and calls the action on each one.
            The caller decides what to print by passing a lambda.  
            Scenario 1  Short Report: Print each product as Name - $Price  
            Scenario 2  Detailed Report: Print each product as [Category] Name | Price: $X | Stock: Y 
            */
            Console.WriteLine("");
            Action<Product> shortReport = p => Console.WriteLine($"{p.Name} - ${p.Price}");
            Action<Product> detailedReport = p => Console.WriteLine($"[{p.Category}] {p.Name} | Price:${p.Price} | Stock:{p.Stock}");
            Console.WriteLine("---Short Report---");
            Product.PrintReport(Product.catalog, shortReport);
            Console.WriteLine("");
            Console.WriteLine("---Detailed Report---");
            Product.PrintReport(Product.catalog, detailedReport);

            #endregion

            #region Task3.2
            // هنا محتاجين نرجع سترينج ف هنستخدم ال func
            Console.WriteLine("");
            Func<Product, string> summaryList = p => $"{p.Name} (${p.Price})";
            //Func<Product, string> priceLabel = p => { if(p.Price>100)=>"Expensive" }
            Func<Product, string> priceLabel = p => p.Price>100?$"{p.Name}: Expensive" : $"{p.Name}: Affordable";
            Console.WriteLine("---Summary List---");
            List<string> summary = Product.TransformProducts(Product.catalog, summaryList);
            foreach(string s in summary)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
            Console.WriteLine("---Price labels---");
            List<string> PriceLabel = Product.TransformProducts(Product.catalog, priceLabel);
            foreach (string s in PriceLabel)
            {
                Console.WriteLine(s);
            }
            #endregion
        }
    }
}
