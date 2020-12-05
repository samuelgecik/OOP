namespace Merlin2d.Actors
{
    public interface IObserver
    {
        void Notify(IObservable observable);
    }
}