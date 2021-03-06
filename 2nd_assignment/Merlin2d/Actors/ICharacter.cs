﻿using Merlin2d.Commands;

namespace Merlin2d.Actors
{
    public interface ICharacter
    {
        void ChangeHealth(int delta);
        int GetHealth();
        void Die();
        void AddEffect(ICommand effect);
        void RemoveEffect(ICommand effect);
    }
}
