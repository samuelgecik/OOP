using System;

namespace Merlin2d.Commands
{
    public interface IAction<T>
    {
        void Execute(T t);
    }
}