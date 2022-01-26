using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSamples
{
    public class SamplesViewModel
    {
        #region Constructor
        public SamplesViewModel()
        {
            // Load all Product Data
            Products = ProductRepository.GetAll();
            // Load all Sales Data
            Sales = SalesOrderDetailRepository.GetAll();
        }
        #endregion

        #region Properties
        public bool UseQuerySyntax { get; set; } = true;
        public List<Product> Products { get; set; }
        public List<SalesOrderDetail> Sales { get; set; }
        public string ResultText { get; set; }
        #endregion

        #region Count
        /// <summary>
        /// Gets a total number of products in a collection
        /// </summary>
        public void Count()
        {
            int value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod).Count();
            }
            else
            {
                // Method Syntax (No LINQ)
                value = Products.Count();
            }

            ResultText = $"Total Products = {value}";
        }
        #endregion

        #region CountFiltered
        /// <summary>
        /// You can apply a where clause, or a predicate in Count()
        /// </summary>
        public void CountFiltered()
        {
            string search = "Red";
            int value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod).Count(prod => prod.Color == search);
            }
            else
            {
                // Method Syntax
                value = Products.Count(prod => prod.Color == search);
            }

            ResultText = $"Total Products with a color of 'Red' = {value}";
        }
        #endregion

        #region Sum
        /// <summary>
        /// Get a total value from a numeric property
        /// </summary>
        public void Sum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Sum();
                //// alternate syntax
                //value = (from prod in Products
                //         select prod).Sum(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Sum(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Total of all List Prices = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region Minimum
        /// <summary>
        /// Get the minimum value in a collection
        /// </summary>
        public void Minimum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Min();
                //// alternate syntax
                //value = (from prod in Products
                //         select prod).Min(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Min(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Minimum List Price = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region Maximum
        /// <summary>
        /// Get the maximum value in a collection
        /// </summary>
        public void Maximum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Max();
                //// alternate syntax
                //value = (from prod in Products
                //         select prod).Max(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Max(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Maximum List Price = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region Average
        /// <summary>
        /// Get the average value in a collection
        /// </summary>
        public void Average()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Average();
                //// alternate syntax
                //value = (from prod in Products
                //         select prod).Average(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Average(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Average List Price = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region AggregateSum
        /// <summary>
        /// Simulate Sum() using the Aggregate method
        /// </summary>
        public void AggregateSum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod)
                         .Aggregate(0M, (sum, prod) => sum += prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Aggregate(0M,
                    (sum, prod) => sum += prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Total of all List Prices = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region AggregateCustom
        /// <summary>
        /// Simulate Sum() using the Aggregate method
        /// </summary>
        public void AggregateCustom()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from sale in Sales
                         select sale)
                         .Aggregate(0M,
                         (sum, sale) =>
                         sum += (sale.OrderQty * sale.UnitPrice));
            }
            else
            {
                // Method Syntax
                value = Sales.Aggregate(0M,
                    (sum, sale) => sum += (sale.OrderQty * sale.UnitPrice));
            }

            if (value.HasValue)
            {
                ResultText = $"Total of all List Prices = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region AggregateUsingGrouping
        /// <summary>
        /// Group products by Size property and calculate min/max/average prices
        /// </summary>
        public void AggregateUsingGrouping()
        {
            StringBuilder sb = new StringBuilder(2048);

            if (UseQuerySyntax)
            {
                // Query syntax
                var stats = (from prod in Products
                             group prod by prod.Size into sizeGroup
                             where sizeGroup.Count() > 0
                             select new
                             {
                                 Size = sizeGroup.Key,
                                 TotalProducts = sizeGroup.Count(),
                                 Max = sizeGroup.Max(s => s.ListPrice),
                                 Min = sizeGroup.Min(s => s.ListPrice),
                                 Average = sizeGroup.Average(s => s.ListPrice),
                             }
                             into result
                             orderby result.Size
                             select result);

                // Loop through each product statistic
                foreach (var stat in stats)
                {
                    sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                    sb.AppendLine($"  Min: {stat.Min:c}");
                    sb.AppendLine($"  Max: {stat.Max:c}");
                    sb.AppendLine($"  Average: {stat.Average:c}");
                }
            }
            else
            {
                // Method syntax
                var stats = Products.GroupBy(sale => sale.Size)
                    .Where(sizeGroup => sizeGroup.Count() > 0)
                    .Select(sizeGroup => new
                    {
                        Size = sizeGroup.Key,
                        TotalProducts = sizeGroup.Count(),
                        Max = sizeGroup.Max(s => s.ListPrice),
                        Min = sizeGroup.Min(s => s.ListPrice),
                        Average = sizeGroup.Average(s => s.ListPrice),
                    })
                    .OrderBy(result => result.Size)
                    .Select(result => result);

                // Loop through each product statistic
                foreach (var stat in stats)
                {
                    sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                    sb.AppendLine($"  Min: {stat.Min:c}");
                    sb.AppendLine($"  Max: {stat.Max:c}");
                    sb.AppendLine($"  Average: {stat.Average:c}");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region AggregateUsingGroupingMoreEfficient
        /// <summary>
        /// Group products by Size property and calculate min/max/average prices.
        /// Using an accumulator class is more efficient because we don't loop
        /// through once each for Min, Max, Average as in the previous sample.
        /// </summary>
        public void AggregateUsingGroupingMoreEfficient()
        {
            StringBuilder sb = new StringBuilder(2048);

            // Method syntax only
            var stats = Products.GroupBy(sale => sale.Size)
                .Where(sizeGroup => sizeGroup.Count() > 0)
                .Select(sizeGroup =>
                {
                    var results = sizeGroup.Aggregate(new ProductStats(),
                        (acc, prod) => acc.Accumulate(prod),
                        acc => acc.ComputeAverage());
                    return new
                    {
                        Size = sizeGroup.Key,
                        results.TotalProducts,
                        results.Min,
                        results.Max,
                        results.Average
                    };
                })
                .OrderBy(result => result.Size)
                .Select(result => result);

            // Loop through each product statistic
            foreach (var stat in stats)
            {
                sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                sb.AppendLine($"  Min: {stat.Min:c}");
                sb.AppendLine($"  Max: {stat.Max:c}");
                sb.AppendLine($"  Average: {stat.Average:c}");
            }

            ResultText = sb.ToString();
        }
        #endregion
    }
}
