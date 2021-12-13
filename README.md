# Chat Whisper Plugin

This unofficial TaleSpire plugin allows sending chat messages to a specific person. Only the player
with the matching name will see the chat message.
 
## Change Log

```
1.2.1: Improved GM detection method for GM shortcuts
1.2.0: Added whisper to everyone but function
1.2.0: Added shortcut for GM
1.0.1: Updated to latest Chat Service plugin version
1.0.1: Added period shortcut for own name (allows whispering to self to leave self notes)
1.0.0: Initial release
```

## Install

Use R2ModMan or similar installer to install this plugin.
   
## Usage

When using the chat, if a message starts with /w or /w! then whisper mode is triggered. The full syntaxes
for the two whisper modes are:

```/w target message```

Where target is the name of the player to receive the whisper and message is the message to be whispered.

```/w! target message```

Where target is the name of the player to not receive the whisper and message is the message to be whispered.

### Target Shortcuts

There are two shortcuts which can be used in place of a target name

. = Own name. This is typically used to make notes to yourself which will be shown in the chat but seen only
    by yourself. This mode does also exclude the GM.

.. = GM name. This is typiclaly used to whisper to the GM without having to write out the GM's name. This will
   make the message visible to the first GM player that it finds.

GM = Same as ..
   
