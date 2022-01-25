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

            }
            else
            {
                // Method Syntax

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

            }
            else
            {
                // Method Syntax

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

            }
            else
            {
                // Method Syntax

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

            }
            else
            {
                // Method Syntax

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

                // Loop through each product statistic
                //foreach (var stat in stats) {
                //  sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                //  sb.AppendLine($"  Min: {stat.Min:c}");
                //  sb.AppendLine($"  Max: {stat.Max:c}");
                //  sb.AppendLine($"  Average: {stat.Average:c}");
                //}
            }
            else
            {
                // Method syntax

                // Loop through each product statistic
                //foreach (var stat in stats) {
                //  sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                //  sb.AppendLine($"  Min: {stat.Min:c}");
                //  sb.AppendLine($"  Max: {stat.Max:c}");
                //  sb.AppendLine($"  Average: {stat.Average:c}");
                //}
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

            // Loop through each product statistic
            //foreach (var stat in stats) {
            //  sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
            //  sb.AppendLine($"  Min: {stat.Min:c}");
            //  sb.AppendLine($"  Max: {stat.Max:c}");
            //  sb.AppendLine($"  Average: {stat.Average:c}");
            //}

            ResultText = sb.ToString();
        }
        #endregion
    }
}
