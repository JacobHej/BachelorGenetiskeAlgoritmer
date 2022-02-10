namespace Algorithms.Infrastructure.Interfaces
{
    public interface IPopulation<TIndividual> where TIndividual : IIndividual
    {
        public int PopulationSize { get; }
        public List<TIndividual> Individuals { get; set; }
    }
}