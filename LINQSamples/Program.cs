using System;

namespace LINQSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the ViewModel
            SamplesViewModel vm = new SamplesViewModel
            {
                // Use Query or Method Syntax?
                UseQuerySyntax = true
            };

            // Call a sample method
            //vm.Count();
            //vm.CountFiltered();
            //vm.Minimum();
            vm.Maximum();

            // Display Result Text
            Console.WriteLine(vm.ResultText);
        }
    }
}
