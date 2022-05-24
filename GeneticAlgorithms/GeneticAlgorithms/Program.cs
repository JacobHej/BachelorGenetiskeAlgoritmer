using GeneticAlgorithms.CreateSimulationForms;
using GeneticAlgorithms.CreateSimulationForms.BitStringSelector;
using GeneticAlgorithms.CreateSimulationForms.MuPlusLambdaSelector;
using GeneticAlgorithms.CreateSimulationForms.SimulatedAnnealingSelector;
using GeneticAlgorithms.CreateSimulationForms.TSPMutator;
using GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA;
using GeneticAlgorithms.CreateSimulationForms.TSPSelector;


namespace GeneticAlgorithms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ResourceManager.ScanRescources();

            Application.Run(new StartupForm());
        }
    }
}