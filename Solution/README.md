# Blazor Puzzle #27

## Click Once, That's It

YouTube Video: https://youtu.be/n9nNZye-ns0

BlazorPuzzle Home Page: https://blazorpuzzle.com

### The Challenge:

We have a list of Blazor Puzzle episodes in a QuickGrid with buttons to get more details about each episode.  We can click the button for an episode and get details, but if we click a second button on the page, nothing happens?

What is the problem with this code?  How would you fix it to enable every button click to work?

### The Solution:

The solution is to handle the code in *EpisodeDetails.razor* that loads the .md file from `OnInitializedAsync()` to `OnParametersSetAsync()`.

Change this:

```c#
protected override async Task OnInitializedAsync()
{

    if (Number > 0)
    {
        episode = await Http.GetFromJsonAsync<Episode>($"api/episodes/{Number}");
    }
    await base.OnInitializedAsync();
}
```

to this:

```c#
protected override async Task OnParametersSetAsync()
{

    if (Number > 0)
    {
        episode = await Http.GetFromJsonAsync<Episode>($"api/episodes/{Number}");
    }
    await base.OnParametersSetAsync();
}
```

The reason for the problem is that `OnInitializedAsync()` only happens when the component is loaded or reloaded.  `OnParametersSetAsync()` occurs whenever the parameters change, such as the episode number.

