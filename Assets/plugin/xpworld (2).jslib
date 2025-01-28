mergeInto(LibraryManager.library, {

  /*
    EventType   ->  Payload
    game_start  ->  {}
    game_fail   ->  { score: string }
    game_retry  ->  {}
    game_exit   ->  {}
  */
  SendGameSessionEvent: function (eventName, payload) {
    if (window && window.unityInstance && window.unityInstance.xpworldGSM) {
      window.unityInstance.xpworldGSM.SendGameSessionEvent(UTF8ToString(eventName), UTF8ToString(payload));
    } else {
      console.error(`OnEvent: ${eventName} Game Session Manager not found`);
    }
  },
});