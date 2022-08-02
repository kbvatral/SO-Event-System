using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Nat1Wizard.EventSystem {
    public class GameEventListener : MonoBehaviour {

        [SerializeField] protected GameEvent m_gameEvent;
        [SerializeField] protected GameEventContextEvent m_callbacks;

        private void Awake() => m_gameEvent.Register(this);
        private void OnDestroy() => m_gameEvent.Deregister(this);
        public void RaiseEvent(GameEventContext ctx) => m_callbacks.Invoke(ctx);

    }
}