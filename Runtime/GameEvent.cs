using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nat1Wizard.EventSystem {

    [CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
    public class GameEvent : ScriptableObject
    {
        HashSet<GameEventListener> m_listeners = new HashSet<GameEventListener>();

        public void Invoke(GameEventContext ctx) {
            foreach(var globalEventListener in m_listeners) {
                globalEventListener.RaiseEvent(ctx);
            }
        }
        public void Invoke() {
            var ctx = new GameEventContext();
            this.Invoke(ctx);
        }
        public void Invoke(object data) {
            GameEventContext ctx = new GameEventContext(data);
            this.Invoke(ctx);
        }

        public void Register(GameEventListener gameEventListener) => m_listeners.Add(gameEventListener);
        public void Deregister(GameEventListener gameEventListener) => m_listeners.Remove(gameEventListener);
    }
    
}