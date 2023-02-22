using System.Numerics;

namespace SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;

public interface ICanHaveMultiple
{
    public BigInteger Owned { get; }
}
