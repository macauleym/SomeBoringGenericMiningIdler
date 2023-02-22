using System.Numerics;

namespace SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;

public interface ICostOre
{
    BigInteger Cost { get; }
        
    BigInteger Purchase(BigInteger totalCurrency, BigInteger? amount = null);
}
