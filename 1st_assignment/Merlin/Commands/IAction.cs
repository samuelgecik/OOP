using System;

namespace Merlin.Commands
{
    public interface IAction<T>
    {
        void Execute(T t);
    }
}