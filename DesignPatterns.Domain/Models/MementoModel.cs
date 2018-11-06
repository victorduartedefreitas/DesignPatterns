using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Domain.Models
{
    public abstract class MementoModel<T>
        where T : class
    {
        protected Stack<T> PreviousStates = new Stack<T>();
        protected Stack<T> NextStates = new Stack<T>();

        public abstract void SaveState();
        public abstract void RestoreState(T original);

        public bool CanUndo()
        {
            return PreviousStates.Count > 0;
        }

        public bool CanRedo()
        {
            return NextStates.Count > 0;
        }
    }
}
