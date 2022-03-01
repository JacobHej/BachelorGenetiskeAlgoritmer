namespace Algorithms.Infrastructure.Interfaces
{
    public interface IIndividual
    {
        public IIndividual Copy();
        public string ToString();

        public Guid ID { get; }
    }
}