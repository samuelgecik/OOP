using System;
namespace Merlin
{
    public interface IObserver
    {
        void Notify(IObservable observable);
    }
}