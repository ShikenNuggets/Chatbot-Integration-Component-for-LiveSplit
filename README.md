# Chatbot Integration Component for LiveSplit
A component that allows data from LiveSplit to be used by other applications, mainly chatbots.

# What is it?
This component will output your Personal Best, Sum of Best, and the World Record for the current category, as well as how good the run is ("run is good" if ahead of PB, "run is bad" if behind PB), and the link to the speedrun.com rules for the currently selected category. The goal of this is so that these text files can be used with Twitch bots, so that these commands can be automatically updated instead of having to manually update them anytime you switch games/categories.

# Installation
* Download ChatBotIntegration.dll from [the Releases page](https://github.com/ShikenNuggets/Chatbot-Integration-Component-for-LiveSplit/releases)
* Find where you have LiveSplit installed and place that DLL in the 'Components' folder
* Open LiveSplit. Right click -> Edit Layout -> [Giant "+" Button] -> Other -> Chatbot Integration
* Double-click on the component you just added. Set the 'Output Path' to a folder you'll remember. Setting the speedrun.com username is optional, that is just used to make the WR text say "by me" when you have WR.
* Files should appear in that location once you start the timer, and they should update anytime you start a run, split, reset, skip/undo a split, or manually edit your splits. Note that the WR text requires you to have a 'World Record' component in your layout.

# To Use With [StreamLabs Chatbot](https://streamlabs.com/chatbot)
Simply add a new command with the following text: `$readline([Output Path you set in LiveSplit]\PB.txt)`

Note that the text files will only have the times themselves in them, so if you want your command output to be `Personal Best is 1:23:45`  
Your command response in StreamLabs Chatbot should be `Personal Best is $readline([Output Path you set in LiveSplit]\PB.txt)`

# To Use With [Nightbot](https://nightbot.tv/)
Setting this up to work with Nightbot is a bit more difficult since it can't read files directly off your computer. You'll need a service that can sync files between your PC and the cloud that Nightbot can also pull the raw text file from. I recommend Dropbox.
* Download and install the [Dropbox App](https://www.dropbox.com/install)
* Set the output path for the component in LiveSplit to the Dropbox folder (typically `C:/Users/[your name]/Dropbox`), then start the timer to create the files
* Open Dropbox in a web browser, click Share on one of the text files, then Create a link that anyone can view. Copy the ID for each link (so if the link is `https://www.dropbox.com/s/abcdefg/PB.txt?dl=0`, copy `abcdefg`)
* Your URL may also include something that looks like `rlkey=hijkl1234`. If so, copy this as well

* Now in Nightbot, the 'message' for the command should be:
`$(urlfetch https://dl.dropbox.com/s/[id from the link]/PB.txt)`  

* If your link had the *rlkey* thing, then you need to add that to your query as well:
`$(urlfetch https://dl.dropbox.com/s/[id from the link]/PB.txt?rlkey=[the second thing you copied])`  

Repeat for all the files you wish to use.  

This unfortunately cannot be used with Moobot, and I don't think many other bots provide the necessary utilities to use this either.
