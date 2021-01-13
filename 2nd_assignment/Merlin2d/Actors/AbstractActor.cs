using System;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Actors
{
    public abstract class AbstractActor : IActor
    {
        private string name;
        private Animation animation;
        private IWorld world;
        private bool shouldDelete;
        private bool isPhysicsEnabled;
        private int posX;
        private int posY;

        public AbstractActor(string name)
        {
            this.name = name;
        }

        public virtual Animation GetAnimation()
        {
            return animation;
        }

        public int GetHeight()
        {
            return animation.GetHeight();
        }

        public string GetName()
        {
            return name;
        }

        public int GetWidth()
        {
            return animation.GetWidth();
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public int GetX()
        {
            return posX;
        }

        public int GetY()
        {
            return posY;
        }

        public bool IntersectsWithActor(IActor other)
        {
            int xRangeThis = this.GetX() + this.GetWidth();
            int yRangeThis = this.GetY() + this.GetHeight();
            int xRangeOther = other.GetX() + other.GetWidth();
            int yRangeOther = other.GetY() + other.GetHeight();

            if ((this.GetX() <= xRangeOther && other.GetX() <= xRangeThis) &&
                (this.GetY() <= yRangeOther && other.GetY() <= yRangeThis))
            {
                return true;
            }

            return false;
        }

        public bool IsAffectedByPhysics()
        {
            return isPhysicsEnabled;
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
            shouldDelete = false;
        }

        public bool RemovedFromWorld()
        {
            return shouldDelete;
        }

        public void RemoveFromWorld()
        {
            shouldDelete = true;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            this.isPhysicsEnabled = isPhysicsEnabled;
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}
