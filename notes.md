 
 # needed

 - [x] scene loading
 - [x] rendering loop
 - [*] collision detection \
partly done, needs refactoring
 - [ ] world / screen space sizing
 - [ ] update loop
 - [ ] rules engine 
 - [ ] actual game scene
    * [ ] player symbols
    * [ ] grid
    * [ ] UI
        - [ ] scores
        - [ ] current player
        - [ ] round count
        - [ ] prompt (round ended, play again?)
 - [ ] AI player \
 every move by player must be a message,\
 so an AI player can just send messages \
 onto the bus
----
 - [ ] animations

---

 ATM the `SceneManager` reacts to `MessagBus`.\
 Wrong.\
`Scene` should react to `MessageBus` events, `SM` should only be concerned with changing `Scenes`, possibly doing something with their start/end conditions.
