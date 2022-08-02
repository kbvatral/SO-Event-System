using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Nat1Wizard.EventSystem {

    public class GameEventContext {

        public object data;

        public GameEventContext() {
            data = null;
        }
        public GameEventContext(object data) {
            this.data = data;
        }
        public T GetData<T>() {
            if(data is T) {
                return (T)data;
            }
            try {
                return (T)Convert.ChangeType(data, typeof(T));
            } catch (InvalidCastException) {
                return default(T);
            }
        }
    }

    [System.Serializable]
    public class GameEventContextEvent : UnityEvent<GameEventContext> { }

}
