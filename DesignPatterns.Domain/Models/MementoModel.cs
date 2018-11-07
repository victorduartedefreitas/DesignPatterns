using System.Collections.Generic;

namespace DesignPatterns.Domain.Models
{
    public abstract class Memento
    {
    }

    public abstract class MementoModel<T>
        where T : Memento
    {
        private Stack<T> _previousStates = new Stack<T>();
        private Stack<T> _nextStates = new Stack<T>();

        public abstract void Undo();
        public abstract void Redo();
        public abstract void SaveCurrentState();

        public bool CanUndo()
        {
            return _previousStates.Count > 0;
        }

        public bool CanRedo()
        {
            return _nextStates.Count > 0;
        }

        protected void SetPreviousState(T model)
        {
            _previousStates.Push(model);
        }

        protected T GetPreviousState()
        {
            if (CanUndo())
                return _previousStates.Pop();

            return null;
        }

        protected T GetNextState()
        {
            if (CanRedo())
                return _nextStates.Pop();

            return null;
        }

        protected void SetNextState(T model)
        {
            _nextStates.Push(model);
        }
    }
}
