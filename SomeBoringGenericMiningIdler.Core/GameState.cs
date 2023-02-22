using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SomeBoringGenericMiningIdler.Core;

public class GameState : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    BigInteger currency = 0;
    public BigInteger Currency
    {
        get => currency;
        set
        {
            if (currency == value) 
                return;
            
            currency = value;
            OnPropertyChanged();
        }
    }

    double timeFactor = 1d;
    public double TimeFactor
    {
        get => timeFactor;
        set
        {
            if (timeFactor == value) 
                return;
            
            timeFactor = value;
            OnPropertyChanged();
        }
    }

    BigInteger playerPower = 1;
    public BigInteger PlayerPower
    {
        get => playerPower;
        set
        {
            if (playerPower == value)
                return;

            playerPower = value;
            OnPropertyChanged();
        }
    }
}